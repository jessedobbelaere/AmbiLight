using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RgbLedLibrary.BusinessLayer;
using System.Threading;

namespace TestcaseSerialCom {
    public class Main {

        // Variables
        RgbControl rgb;
        byte channel;

        /// <summary>
        /// Default-constructor
        /// </summary>
        public Main() {
        }

        /// <summary>
        /// Start
        /// </summary>
        public void Start() {
            

            Console.Clear();
            Console.WriteLine("**********************************************************");
            Console.WriteLine("*                ARDUINO RGB STRIP CONTROLLER            *");
            Console.WriteLine("**********************************************************");
            Console.WriteLine("\n");

            Console.WriteLine("Enter COM-port of your Arduino (eg. COM9)");
            string prt = Console.ReadLine();

            Console.WriteLine("Choose which ledstrip to control (0-4):");
            channel = byte.Parse(Console.ReadLine());

            rgb = new RgbControl(prt, 19200);

            Menu();
        }

        /// <summary>
        /// Print the menu on the console
        /// </summary>
        public void Menu() {
            // Run Menu
            bool validMenuOption = false;
            while (!validMenuOption) {

                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("     a) Choose a solid color");
                Console.WriteLine("     b) Turn leds off");
                Console.WriteLine("     c) Start RGB Crossfader (Work in progress)");
                Console.WriteLine("     d) Start Police Strobelight");
                Console.WriteLine("     e) Start Strobelight");
                Console.WriteLine("     f) Choose different channel");

                string menuOption = Console.ReadLine();

                switch (menuOption) {
                    case "a":
                        StartSolidColor();
                        validMenuOption = true;
                        break;
                    case "b":
                        TurnOff();
                        validMenuOption = true;
                        break;
                    case "c":
                        StartCrossFader();
                        validMenuOption = true;
                        break;
                    case "d":
                        StartPoliceLight();
                        break;
                    case "e":
                        StartStrobelight();
                        break;
                    case "f":
                        ChooseChannel();
                        break;
                    default:
                        validMenuOption = false;
                        break;
                }
            }
        }
        public void ChooseChannel() {
            Console.WriteLine("Choose which ledstrip to control (0-4):");
            channel = byte.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Ask and set a solid color on the RGB led(s).
        /// </summary>
        public void StartSolidColor() {
            bool quit = false;
            while (!quit) {
                Console.WriteLine("\nGeef een RGB kleurwaardes in aub:");

                Console.Write("R:");
                byte r = byte.Parse(Console.ReadLine());
                Console.Write("G:");
                byte g = byte.Parse(Console.ReadLine());
                Console.Write("B:");
                byte b = byte.Parse(Console.ReadLine());

                rgb.SetSolidColor(channel,r, g, b);

                Console.Write("Go back (y/n)?");
                string answer = Console.ReadLine();
                if (answer == "y") {
                    quit = true;
                }
            }

            Menu();
        }

        /// <summary>
        /// Turn all leds off
        /// </summary>
        public void TurnOff() {
            rgb.SetOff(channel);
            Menu();
        }

        /// <summary>
        /// Start a crossfader
        /// </summary>
        public void StartCrossFader() {            
            Console.WriteLine("Starting RGB Crossfader modus...Done!");
            rgb.SetCrossFader(channel);
        }

        /// <summary>
        /// Start police light simulation
        /// </summary>
        public void StartPoliceLight() {         
            Console.WriteLine("Starting RGB Crossfader modus...Done!");
            rgb.SetPoliceLight(channel);
        }

        /// <summary>
        /// Start strobelight
        /// </summary>
        public void StartStrobelight() {
            Console.WriteLine("Starting RGB strobelight modus...Done!");
            rgb.SetStrobeLight();
        }


    }
}
