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
        private bool serialWorks;
        private Server server;
        private ColorSource source;
        private UpdateLogDelegate deleg;
        private Thread startServerThread;

        public bool SerialWorks {
            get {
                return serialWorks;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public BL() {}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="deleg">A delegate to update a log</param>
        public BL(UpdateLogDelegate deleg) {
            this.deleg = deleg;
        }



        public void SetSerial(string comPort){
            try{
                this.serial = new SerialCom(comPort, 19200, deleg);
                this.serialWorks = true;
            }
            catch(Exception e){
                this.serialWorks =false;
                deleg("Failed to connect to serial port " + comPort);
                System.Diagnostics.Debug.Print(e.ToString());
            }
        }
        /// <summary>
        /// Disconnect the serial connection
        /// </summary>
        public void StopSerial() {
            serial.StopSerial();
            this.serialWorks = false;
            this.serial = null;
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
                    System.Diagnostics.Debug.Print("Optie nog niet in busineslayer geimplementeerd");
                    break;
            }
        }

        /// <summary>
        /// Start the Source
        /// </summary>
        public void StartSource() {
            this.source.Start();
        }

        /// <summary>
        /// Stop the source
        /// </summary>
        public void StopSource() {
            source.Stop();
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
        public void StartFx(byte mode, byte options) {
            this.serial.Send(mode,options,0,0,0);
        }
        public void StartFx(byte mode, byte options, byte[] bytes) {
            this.serial.Send(mode, options, bytes);
        }

        public void StopFX() {
            this.serial.Send(15, 0, 0, 0);
        }

    }
}
