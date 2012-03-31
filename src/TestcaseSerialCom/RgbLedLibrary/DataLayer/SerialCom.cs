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
        private byte startbit = 170; //aanpassen in zowel arduino code als hier!!!


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
        /// <param name="channel">The channel to send too</param>
        /// <param name="red">The red byte</param>
        /// <param name="green">The green byte</param>
        /// <param name="blue">The blue byte</param>
        public void Send(byte channel, byte red, byte green, byte blue) {
            serialPort.Write((new byte[2] { startbit, channel }), 0, 2);
            serialPort.Write((new byte[3] {red, green, blue }), 0, 3);   
            serialPort.DiscardOutBuffer();
        }

        /// <summary>
        /// Sends a Color RGB value through the serial connection
        /// </summary>
        /// <param name="channel">The channel to send too</param>
        /// <param name="color">A color (rgb)</param>
        public void Send(byte channel, Color color) {
            serialPort.Write((new byte[2] { startbit, channel }), 0, 2);
            serialPort.Write((new byte[3] { color.r, color.g, color.b }), 0, 3);   
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
