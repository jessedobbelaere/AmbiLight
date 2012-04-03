using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TestCaseThreading.ColorSources;

namespace TestCaseThreading {
    public class BL {

        // Variables
        private SerialCom serial;
        private ColorSource source;
       // private UpdateLogDelegate deleg;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comPort">The COM port</param>
        public BL(string comPort) {
            this.serial = new SerialCom(comPort, 19200);
            //source = new ScreencapThread(serial);
        }

        /// <summary>
        /// Select a color source
        /// </summary>
        /// <param name="src"></param>
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

        /// <summary>
        /// Start the Source
        /// </summary>
        public void Start() {
            source.Start();
        }

        /// <summary>
        /// Stop the source
        /// </summary>
        public void Stop() {
            source.Stop();
            //serial.StopSerial();
        }

        /// <summary>
        /// Disconnect the serial connection
        /// </summary>
        public void StopSerial() {
            serial.StopSerial();
        }

        /// <summary>
        /// Start an effect
        /// </summary>
        public void StartFx(byte mode) {
            this.serial.Send(mode, 0, 0, 0, 0);
        }

    }
}
