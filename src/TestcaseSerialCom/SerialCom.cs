using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace TestcaseSerialCom {
    class SerialCom {
        //vars
        private SerialPort port;
        //private int redpin,greenpin,bluepin;

        private string comport;
        private int baudrate;
        private byte options;


        //properties
        

        //constr
        public SerialCom() {

        }

        //methodes
        public void Setup(string comport, int baudrate) {
            this.port = new SerialPort(comport, baudrate);
            this.port.Open();
            this.port.DataReceived +=  Recieved;
            this.port.NewLine = "\n";
        }

        public void Send(byte red, byte green, byte blue) {

            port.Write((new byte[3] {red,green,blue}),0,3);
            
            
            port.DiscardOutBuffer();
        }


        private void Recieved(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {

            string s = this.port.ReadLine();
            StringBuilder sb = new StringBuilder("Arduino geeft volgende waarden:");
            foreach(char c in s){
                if (c == ',') {
                    sb.Append(",");
                }
                else {
                    sb.Append((byte)c);
                }
            }
            System.Diagnostics.Debug.Print(sb.ToString());

            port.DiscardOutBuffer();
        }
    }
}
