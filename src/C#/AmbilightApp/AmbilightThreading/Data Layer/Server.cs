using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using TestCaseThreading;
using System.Threading;
using System.IO;

namespace AmbilightThreading.Data_Layer {
    
    /// <summary>
    /// The server class. Listens/Receives messages sent over TCP/IP
    /// </summary>
    internal class Server {

        // Variables
        private IPAddress ipAd;
        private TcpListener myList;
        private UpdateLogDelegate deleg;
        private Socket s;
        private bool servRunning;
        private Thread thrListener;
        private Thread thrReceiver;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Server() {
            // Get ip address and initialize the tcp listener on port 8001
            ipAd = IPAddress.Parse(GetLocalIP());
            myList = new TcpListener(ipAd, 8001);
        }

        /// <summary>
        /// Non-Default Constructor for the delegate
        /// </summary>
        /// <param name="deleg">Delegate that updates the log</param>
        public Server(UpdateLogDelegate deleg) : this() {
            this.deleg = deleg;
        }

        /// <summary>
        /// Start the server
        /// </summary>
        public void Start() {
            try {
                // Start listening at the specified port
                myList.Start();

                deleg.Invoke("The server is running at port 8001...");
                deleg.Invoke("The local End point is  :" + myList.LocalEndpoint);
                deleg.Invoke("Waiting for a connection.....");

                // The while loop will check for true in this before checking for connections
                servRunning = true;

                // Start the new tread that hosts the listener
                thrListener = new Thread(KeepListening);
                thrListener.Start();
            }
            catch (Exception e) {
                deleg.Invoke("Error: " + e.StackTrace);
            }   
        }

        /// <summary>
        /// Keep listening for incoming connections
        /// </summary>
        private void KeepListening() {
            // While the server is running
            while (servRunning == true) {
                // Accept a pending connection
                s = myList.AcceptSocket();

                if (s.Connected && SocketConnected(s)) {
                    deleg.Invoke("Connection accepted from " + s.RemoteEndPoint);
                    thrReceiver = new Thread(Receive);
                    thrReceiver.Start();
                }

            }
        }

        /// <summary>
        /// Listen to the connection for received messages
        /// </summary>
        private void Receive() {
            while (s.Connected && SocketConnected(s)) {
                byte[] bytes = new byte[256];
                int i = s.Receive(bytes);
                string message = Encoding.UTF8.GetString(bytes);
                if (message == "\0") {
                    s.Disconnect(true);
                    deleg.Invoke("Connection closed: ");
                }
                deleg.Invoke("Received message: " + message);
            }
        }

        /// <summary>
        /// Is socket still connected?
        /// </summary>
        /// <param name="s">The socket</param>
        /// <returns>Socket connected or not</returns>
        private bool SocketConnected(Socket s) {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 && part2) {
                deleg.Invoke("Connection lost");
                return false;
            }
            else {
                return true;
            }
        }

        /// <summary>
        /// Stop the server
        /// </summary>
        public void Stop() {
            if (s != null && myList != null) {
                //s.Close(); --> makes it crash??
                myList.Stop();
                thrListener.Abort();
                thrReceiver.Abort();
                thrListener = null;
                thrReceiver = null;
                servRunning = false;
                deleg("Running server is aborted");
            }
            else {
                deleg("No server running at the moment...");
            }
        }
        

        /// <summary>
        /// Get the local ip address of this machine
        /// </summary>
        /// <returns>IP Address</returns>
        public string GetLocalIP() {
            string ip = null;

            // Resolves a host name or IP address to an IPHostEntry instance.
            // IPHostEntry - Provides a container class for Internet host address information. 
            System.Net.IPHostEntry _IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());

            // IPAddress class contains the address of a computer on an IP network. 
            foreach (System.Net.IPAddress _IPAddress in _IPHostEntry.AddressList) {
                // InterNetwork indicates that an IP version 4 address is expected 
                // when a Socket connects to an endpoint
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork") {
                    ip = _IPAddress.ToString();
                }
            }
            return ip;
        }
    }
}
