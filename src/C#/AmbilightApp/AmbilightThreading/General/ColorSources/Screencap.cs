﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace TestCaseThreading.ColorSources {
    
    /// <summary>
    /// The Screen capture class
    /// </summary>
    class Screencap : ColorSource {
        
        // Variables
        private SerialCom serial;
        private System.Timers.Timer timer = new System.Timers.Timer();

        /// <summary>
        /// Non-Default constructor
        /// </summary>
        /// <param name="sc">The serial port source</param>
        public Screencap(SerialCom sc){
            this.serial = sc;
        }

        /// <summary>
        /// Start the screen capture
        /// </summary>
        public void Start() {
            timer.Interval = 500; //interval waarmee scherm geanalyseerd word
            timer.Elapsed += new System.Timers.ElapsedEventHandler(elapsed);
            timer.Start();
        }

        /// <summary>
        /// Stop the screen capture
        /// </summary>
        public void Stop() {
            Output(15, 0, 0, 0);
            timer.Stop();
        }

        /// <summary>
        /// Code executed every time the timer ticks: take a screencapture
        /// </summary>
        /// <param name="o">The timer object</param>
        /// <param name="e">The elapsed Event arguments</param>
        private void elapsed(object o, System.Timers.ElapsedEventArgs e) {
            capScreen();
        }

        /// <summary>
        /// Capture the screen
        /// </summary>
        private void capScreen() {
            Bitmap bmp;
            Graphics gfx;

            try {
                // Make objects for storage/processing of images
                bmp = new Bitmap(1920, 1080,PixelFormat.Format24bppRgb);
                gfx = Graphics.FromImage(bmp);

                //Screencapture + Save
                gfx.CopyFromScreen(0, 0, 0, 0, new Size(1920,1080), CopyPixelOperation.SourceCopy);

                
            }
            catch (ArgumentException error) {
                System.Diagnostics.Debug.Print(error.ToString());
                return;
            }
     
            
            // Analyze the screen capture:
            BitmapData srcData = bmp.LockBits(
            new Rectangle(0, 0, bmp.Width, bmp.Height),
            ImageLockMode.ReadOnly,
            PixelFormat.Format24bppRgb);

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
                            int idx = (y * stride) + x * 3 + color;

                            totals[color] += p[idx];
                        }
                    }
                }
            }

            byte avgR = (byte) (totals[2] / (width * height));
            byte avgG = (byte) (totals[1] / (width * height));
            byte avgB = (byte) (totals[0] / (width * height));

            Output(0, avgR, avgG, avgB);

            bmp.UnlockBits(srcData);
            bmp.Dispose();
            gfx.Dispose();
            
        }

        /// <summary>
        /// Output the colors to a ledstrip channel
        /// </summary>
        /// <param name="channel">The ledstrip channel</param>
        /// <param name="r">The red byte</param>
        /// <param name="g">The green byte</param>
        /// <param name="b">The blue byte</param>
        public void Output(byte channel, byte r, byte g, byte b){
            byte mode = 15; 
            serial.Send(mode,channel, r,g,b);
            System.Diagnostics.Debug.Print("Following data has been sent over {0}: Channel {1}, RGB: {2},{3},{4} ",serial.Comport,channel,r,g,b);
        }
    }
}
