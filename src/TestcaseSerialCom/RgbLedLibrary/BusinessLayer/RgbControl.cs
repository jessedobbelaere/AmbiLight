using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestcaseSerialCom;
using System.Threading;

namespace RgbLedLibrary.BusinessLayer {
    public class RgbControl {

        // Variables
        SerialCom serial;


        /// <summary>
        /// Default-constructor
        /// </summary>
        public RgbControl() {
        }

        /// <summary>
        /// Non-default constructor
        /// </summary>
        /// <param name="comPort">The COM port (e.g. COM3)</param>
        /// <param name="baudrate">The Baudrate (e.g. 9600)</param>
        public RgbControl(string comPort, int baudrate) {
            serial = new SerialCom(comPort, baudrate);
        }

        /// <summary>
        /// Set a solid color on the RGB led(s)
        /// </summary>
        /// <param name="red">Red color byte</param>
        /// <param name="green">Green color byte</param>
        /// <param name="blue">Blue color byte</param>
        public void SetSolidColor(byte red, byte green, byte blue) {
            serial.Send(red, green, blue);
        }

        /// <summary>
        /// Turn all leds off
        /// </summary>
        public void SetOff() {
            serial.Send(0, 0, 0);
        }

        /// <summary>
        /// Set leds to simulate a crossfader
        /// </summary>
        public void SetCrossFader() {
            Color ActualColor = new Color(255, 0, 0);
            int State = 0;
            PrimaryColor[] Order = { PrimaryColor.Red, PrimaryColor.Green, PrimaryColor.Blue };

            while (true) {

                switch (Order[State]) {
                    case PrimaryColor.Red:
                        ActualColor.r++;
                        if (ActualColor.g > 0) ActualColor.g--;
                        if (ActualColor.b > 0) ActualColor.b--;
                        if (ActualColor.r == 255 && ActualColor.g == 0 && ActualColor.b == 0) State++;
                        break;
                    case PrimaryColor.Green:
                        ActualColor.g++;
                        if (ActualColor.r > 0) ActualColor.r--;
                        if (ActualColor.b > 0) ActualColor.b--;
                        if (ActualColor.r == 0 && ActualColor.g == 255 && ActualColor.b == 0) State++;
                        break;
                    case PrimaryColor.Blue:
                        ActualColor.b++;
                        if (ActualColor.g > 0) ActualColor.g--;
                        if (ActualColor.r > 0) ActualColor.r--;
                        if (ActualColor.r == 0 && ActualColor.g == 0 && ActualColor.b == 255) State++;
                        break;
                    default:
                        break;
                }

                if (State == Order.Length) State = 0;

                serial.Send(ActualColor);
            }

        }

        /// <summary>
        /// Set leds to simulate a police strobelight
        /// </summary>
        public void SetPoliceLight() {
            int sleep = 0;
            double sleepLonger = sleep + 20;

            while (true) {
                for (int i = 0; i < 3; i++) {
                    serial.Send(255, 0, 0);
                    Thread.Sleep(sleep);
                    serial.Send(0, 0, 0);
                    Thread.Sleep(sleep);
                }

                Thread.Sleep((int)sleepLonger);

                for (int i = 0; i < 3; i++) {
                    serial.Send(0, 0, 255);
                    Thread.Sleep(sleep);
                    serial.Send(0, 0, 0);
                    Thread.Sleep(sleep);
                }

                Thread.Sleep((int)sleepLonger);

            }


        }


    }
}
