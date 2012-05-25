using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace TestCaseThreading {
    
    /// <summary>
    /// The serial communication class
    /// </summary>
    internal class SerialCom {

        // Variables
        private SerialPort port;

        private string comport;
        private int baudrate;
        private byte startbit = 170;
        private byte mode=0;

        private UpdateLogDelegate deleg;


        /// <summary>
        /// Property for the COM port
        /// </summary>
        public string Comport{
            get{
                return this.comport;
            }
        }

        /// <summary>
        /// Non-Default Constructor
        /// </summary>
        /// <param name="comport">The COM port</param>
        /// <param name="baudrate">The Baudrate</param>
        public SerialCom(string comport, int baudrate) {
            this.comport = comport;
            this.baudrate = baudrate;
            this.port = new SerialPort(comport, baudrate);
            this.port.Open();
            this.port.NewLine = "\n";
        }

        /// <summary>
        /// Non-Default Constructor
        /// </summary>
        /// <param name="comport">The COM port</param>
        /// <param name="baudrate">The Baudrate</param>
        /// <param name="deleg">The log delegate</param>
        public SerialCom(string comport, int baudrate, UpdateLogDelegate deleg) : this(comport, baudrate) {
            this.deleg = deleg;
            deleg("Connected to " + comport);
        }

        /// <summary>
        /// Stop the serial connection
        /// </summary>
        public void StopSerial(){
            this.port.Close();
        }

        /// <summary>
        /// Send a color to a single channel
        /// </summary>
        /// <param name="channel">The ledstrip channel</param>
        /// <param name="red">The red color</param>
        /// <param name="green">The green color</param>
        /// <param name="blue">The blue color</param>
        public void Send(byte channel, byte red, byte green, byte blue) { //standaard, single channel 
            this.mode = channel;
            port.Write((new byte[2] {this.startbit, this.mode }), 0, 2);
            port.Write((new byte[3] {red,green,blue}),0,3);
            
            port.DiscardOutBuffer();
        }


        /// <summary>
        /// Function to set arduino in a mode
        /// </summary>
        /// <param name="modus">Mode selection byte</param>
        /// <param name="options">Extra mode-specific options (eg. number of bytes to follow)</param>
        /// <param name="red">The Red color</param>
        /// <param name="green">The green color</param>
        /// <param name="blue">The blue color</param>
        public void Send(byte modus, byte options, byte red, byte green, byte blue) { //modes met 1 kleur input
            this.mode = (byte)((modus << 4) + (options));
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
            this.mode = (byte)((modus << 4) + (options));
            port.Write((new byte[2] { this.startbit, this.mode }), 0, 2);
            port.Write(bytes, 0, bytes.Length);

            port.DiscardOutBuffer();
            deleg("Arduino set to mode "+modus.ToString());
        }
    }
}
