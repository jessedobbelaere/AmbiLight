using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace TestCaseThreading {
    class SerialCom {

        //vars
        private SerialPort port;

        private string comport;
        private int baudrate;
        private byte startbit = 170;
        private byte mode=0;


        //properties
        public string Comport{
            get{
                return this.comport;
            }
        }

        //constr
        public SerialCom(string comport, int baudrate) {
            this.comport = comport;
            this.baudrate = baudrate;
            this.port = new SerialPort(comport, baudrate);
            this.port.Open();
            this.port.NewLine = "\n";
        }

        public void StopSerial(){
            this.port.Close();
        }


        public void Send(byte channel, byte red, byte green, byte blue) { //standaard, single channel 
            this.mode = channel;
            port.Write((new byte[2] {this.startbit, this.mode }), 0, 2);
            port.Write((new byte[3] {red,green,blue}),0,3);
            
            port.DiscardOutBuffer();
        }
        /// <summary>
        /// Function to set arduino in a mode
        /// </summary>
        /// <param name="modus"></param>
        /// <param name="options"></param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public void Send(byte modus, byte options, byte red, byte green, byte blue) { //modes met 1 kleur input
            this.mode = (byte)((modus << 4) + options);
            port.Write((new byte[2] { this.startbit, this.mode }), 0, 2);
            port.Write((new byte[3] { red, green, blue }), 0, 3);

            port.DiscardOutBuffer();
        }

        /// <summary>
        /// Function to set Arduino in a mode
        /// </summary>
        /// <param name="modus">Mode selection byte</param>
        /// <param name="options">Extra mode-specific options (eg. number of bytes to follow)</param>
        /// <param name="bytes">Bytes of information to send</param>
        public void Send(byte modus, byte options, byte[] bytes) { //modes met meerdere kleuren input
            this.mode =(byte) ((modus << 4)+options);
            port.Write((new byte[2] { this.startbit, this.mode }), 0, 2);
            port.Write(bytes, 0, bytes.Length);

            port.DiscardOutBuffer();
        }
    }
}
