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
    class ScreencapThread : ColorSource {
        //vars
        private SerialCom serial;
        private bool running = false;
        private Thread t;
        private Size size;

        //constructor
        public ScreencapThread(SerialCom sc) {
            this.serial = sc;
            this.size = Screen.PrimaryScreen.Bounds.Size;
            t = new Thread(new ThreadStart(capScreen));
            t.Name = "Screen capture and analysation thread";
            t.IsBackground = true;
        }

        public void Start() {
            this.running = true;
            t.Start();
        }
        public void Stop() {
            this.running = false;
            t.Abort();

            Output(15, 0, 0, 0); //alle leds uit
        }

        // vanaf hier screencapture specifieke code
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

                //debugdebugdebugdebug
                if (teller % 30 == 0) {
                    bmp.Save("test" + teller.ToString() + ".bmp");
                }
                BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),ImageLockMode.ReadOnly,PixelFormat.Format24bppRgb);

                int stride = srcData.Stride;
                IntPtr Scan0 = srcData.Scan0;

                long[] totals = new long[] { 0, 0, 0 };

                int width = bmp.Width;
                int height = bmp.Height;

                unsafe {
                    byte* p = (byte*)(void*)Scan0;

                    for (int y = 0; y < height; y++) {
                        for (int x = 0; x < width; x++) {
                            for (int color = 0; color < 3; color++) {
                                int i = (y * stride) + x * 3 + color;
                                totals[color] += p[i];
                            }
                        }
                    }
                }

                byte avgR = (byte)(totals[2] / (width * height));
                byte avgG = (byte)(totals[1] / (width * height));
                byte avgB = (byte)(totals[0] / (width * height));

                Output(0, avgR, avgG, avgB);

                bmp.UnlockBits(srcData);//opruimen van rommel hier
                bmp.Dispose();
                bmp = null;
                g.Dispose();
                g = null;
                GC.Collect(); 
            }

        }
        public void Output(byte channel, byte r, byte g, byte b) {
            byte mode = 15;
            serial.Send(mode, channel, r, g, b);
            System.Diagnostics.Debug.Print("Following data has been sent over {0}: Channel {1}, RGB: {2},{3},{4} ", serial.Comport, channel, r, g, b);
        }
    }
}
