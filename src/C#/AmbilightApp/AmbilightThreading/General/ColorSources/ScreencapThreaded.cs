﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;
using AmbilightThreading.Data_Layer;
// AForge.Imaging.ColorReduction;

namespace TestCaseThreading.ColorSources {
    
    /// <summary>
    /// Capture the screen (Threaded version)
    /// </summary>
    class ScreencapThread : ColorSource {
        
        // Variables
        private SerialCom serial;
        private bool running = false;
        private Thread t;
        private Size size;
        private Rectangle[] regions;

        /// <summary>
        /// The non-default constructor
        /// </summary>
        /// <param name="sc">The serial port source</param>
        /// <param name="regions">The rectangle array region</param>
        public ScreencapThread(SerialCom sc, Rectangle[] regions) {
            this.serial = sc;
            this.regions = regions;
            this.size = Screen.PrimaryScreen.Bounds.Size;
            t = new Thread(new ThreadStart(capScreen));
            t.Name = "Screen capture and analysation thread";
            t.IsBackground = true;
        }

        /// <summary>
        /// Start the screen capture
        /// </summary>
        public void Start() {
            this.running = true;
            t.Start();
        }

        /// <summary>
        /// Stop the screen capture
        /// </summary>
        public void Stop() {
            this.running = false;
            t.Abort();

            //Output(15, 0, 0, 0); //turn leds off
        }

        
        /// <summary>
        /// Capture the screen
        /// </summary>
        private void capScreen() {
            int teller=0;
            while (running) {
                teller++;
                Bitmap bmp;
                Graphics g;
                try {
                    System.IntPtr desktopDC = GDI.GetDC(System.IntPtr.Zero);
                    bmp = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
                    g = Graphics.FromImage(bmp);
                    System.IntPtr bmDC = g.GetHdc();

                    GDI.BitBlt(bmDC, 0, 0, bmp.Width, bmp.Height, desktopDC, 0, 0, 0x00CC0020 /*SRCCOPY*/);

                    GDI.ReleaseDC(System.IntPtr.Zero, desktopDC);
                    g.ReleaseHdc(bmDC);
                    g.Dispose();

                    /*
                    //aanmaken objecten voor opslag/verwerken afbeelding
                    bmp = new Bitmap(size.Width,size.Height, PixelFormat.Format24bppRgb);
                    gfx = Graphics.FromImage(bmp);

                    //screencap+save
                    gfx.CopyFromScreen(0, 0, 0, 0, size, CopyPixelOperation.SourceCopy);
                    */
                }
                catch (ArgumentException error) {
                    System.Diagnostics.Debug.Print(error.ToString());
                    return;
                }
                
                //DEBUGDEBUGDEBUG
                int a = bmp.Height;
                int b = bmp.Width;
                BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),ImageLockMode.ReadOnly,PixelFormat.Format24bppRgb);

                int stride = srcData.Stride;
                IntPtr Scan0 = srcData.Scan0;

                byte kanaal = 0;
                foreach( Rectangle r in regions) {
                    long[] totals = new long[] { 0, 0, 0 };
                    
                    int xCoord = r.X;
                    int yCoord = r.Y;
                    int width = r.Width;
                    int height = r.Height;

                    //System.Diagnostics.Debug.Print("Verwerken regio {0}: {1},{2},{3},{4}", kanaal, xCoord, yCoord, width, height);

                    unsafe {
                        byte* p = (byte*)(void*)Scan0;

                        for (int y = yCoord; y < height + yCoord; y++) {
                            for (int x = xCoord; x < width + xCoord; x++) {
                                for (int color = 0; color < 3; color++) {
                                    int i = (y * stride) + x * 3 + color;
                                    totals[color] += p[i];
                                }
                            }
                        }
                    }

                    byte avgR = (byte)(totals[2] / (float)(width * height));
                    byte avgG = (byte)(totals[1] / (float)(width * height));
                    byte avgB = (byte)(totals[0] / (float)(width * height));

                    Output(kanaal, avgR, avgG, avgB);
                    kanaal++;
                }

                bmp.UnlockBits(srcData);//opruimen van rommel hier
                bmp.Dispose();
                bmp = null;
                g.Dispose();
                g = null;
                GC.Collect(); 
            }

        }

        /// <summary>
        /// Output the color to a ledstrip channel
        /// </summary>
        /// <param name="channel">The ledstrip channel</param>
        /// <param name="r">The red byte</param>
        /// <param name="g">The green byte</param>
        /// <param name="b">The blue byte</param>
        public void Output(byte channel, byte r, byte g, byte b) {
            byte mode = 0;
            serial.Send(mode, channel, r, g, b);
            System.Diagnostics.Debug.Print("Following data has been sent over {0}: Channel {1}, RGB: {2},{3},{4} ", serial.Comport, channel, r, g, b);
        }
    }
}
