using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using RgbLedLibrary.BusinessLayer;

namespace TestcaseSerialCom {
    internal class SerialCom {
        
        // Variables
        private SerialPort serialPort;
        private string comPort;
        private int baudrate;


        // Properties
        

        /// <summary>
        /// Default constructor
        /// </summary>
        public SerialCom() {

        }

        /// <summary>
        /// Non-default constructor
        /// </summary>
        /// <param name="comPort">The COM port (e.g. COM3)</param>
        /// <param name="baudrate"></param>
        public SerialCom(string comPort, int baudrate) {
            this.comPort = comPort;
            this.baudrate = baudrate;

            this.serialPort = new SerialPort(comPort, baudrate);
            this.serialPort.Open();
            this.serialPort.DataReceived += Recieved;
            this.serialPort.NewLine = "\n";
        }

        /// <summary>
        /// Sends an RGB value through the serial connection
        /// </summary>
        /// <param name="red">The red byte</param>
        /// <param name="green">The green byte</param>
        /// <param name="blue">The blue byte</param>
        public void Send(byte red, byte green, byte blue) {
            serialPort.Write((new byte[3] { green, red, blue }), 0, 3);   //  <-------- OPGELET! WAARDEN OMGEDRAAID
            serialPort.DiscardOutBuffer();
        }

        /// <summary>
        /// Sends a Color RGB value through the serial connection
        /// </summary>
        /// <param name="color">A color (rgb)</param>
        public void Send(Color color) {
            serialPort.Write((new byte[3] { color.g, color.r, color.b }), 0, 3);   //  <-------- OPGELET! WAARDEN OMGEDRAAID
            serialPort.DiscardOutBuffer();
        }

        /// <summary>
        /// Debug prints received information of the Arduino
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void Recieved(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {

            string s = this.serialPort.ReadLine();
            StringBuilder sb = new StringBuilder("Arduino has the following values:");
            foreach(char c in s){
                if (c == ',') {
                    sb.Append(",");
                }
                else {
                    sb.Append((byte)c);
                }
            }
            System.Diagnostics.Debug.Print(sb.ToString());

            serialPort.DiscardOutBuffer();
        }
    }
}
