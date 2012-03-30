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

        /// <summary>
        /// Default-constructor
        /// </summary>
        public Main() {
        }

        /// <summary>
        /// Start
        /// </summary>
        public void Start() {
            rgb = new RgbControl("COM3", 9600);

            Console.Clear();
            Console.WriteLine("**********************************************************");
            Console.WriteLine("*                ARDUINO RGB STRIP CONTROLLER            *");
            Console.WriteLine("**********************************************************");
            Console.WriteLine("\n");

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
                    default:
                        validMenuOption = false;
                        break;
                }
            }
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

                rgb.SetSolidColor(r, g, b);

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
            rgb.SetOff();
            Menu();
        }

        /// <summary>
        /// Start a crossfader
        /// </summary>
        public void StartCrossFader() {            
            Console.WriteLine("Starting RGB Crossfader modus...Done!");
            rgb.SetCrossFader();
        }

        /// <summary>
        /// Start police light simulation
        /// </summary>
        public void StartPoliceLight() {         
            Console.WriteLine("Starting RGB Crossfader modus...Done!");
            rgb.SetPoliceLight();
        }


    }
}
