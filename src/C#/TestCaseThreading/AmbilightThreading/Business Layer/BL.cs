using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TestCaseThreading.ColorSources;
using AmbilightThreading.Data_Layer;

namespace TestCaseThreading {
    public class BL {

        // Variables
        private SerialCom serial;
        private Server server;
        private ColorSource source;
        private UpdateLogDelegate deleg;
        private Thread startServerThread;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comPort">The COM port</param>
        public BL(string comPort) {
            this.serial = new SerialCom(comPort, 19200);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comPort">The COM port</param>
        /// <param name="deleg">A delegate to update a log</param>
        public BL(string comPort, UpdateLogDelegate deleg) {
            this.serial = new SerialCom(comPort, 19200, deleg);
            this.deleg = deleg;
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

        public void StartServer() {
            server = new Server(deleg);
            startServerThread = new Thread(new ThreadStart(server.Start));
            startServerThread.Start();
        }

        public void StopServer() {
            startServerThread.Abort();
            server.Stop();
            server = null;
        }

        /// <summary>
        /// Start an effect
        /// </summary>
        public void StartFx(byte mode) {
            this.serial.Send(mode, 0, 0, 0, 0);
        }

    }
}
