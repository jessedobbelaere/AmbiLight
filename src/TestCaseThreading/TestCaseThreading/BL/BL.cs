using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TestCaseThreading.ColorSources;

namespace TestCaseThreading {
    class BL {
        private SerialCom serial;
        private ColorSource source;
        private UpdateLogDelegate deleg;

        public BL(string comport) {
            this.serial = new SerialCom(comport, 19200);
            //source = new ScreencapThread(serial);
        }

        public void SetColorSource(Source src) {
            switch (src) {
                case Source.Screencap:
                    source = new Screencap(serial);
                    break;
                case Source.ScreencapThreaded:
                    source = new ScreencapThread(serial);
                    break;
                default:
                    source = new ScreencapThread(serial);
                    break;
            }
        }
        public void Start() {
            source.Start();
        }
        public void Stop() {
            source.Stop();
            //serial.StopSerial();
        }
        public void StartMode(){ //dummy om te testen
            this.serial.Send(1, 0, 0, 0, 0); //colorcylce activeren
        } 
    }
}
