using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestcaseSerialCom {
    class Program {
        static void Main(string[] args) {
            SerialCom serial = new SerialCom();
            serial.Setup("COM9",9600);

            bool quit=false;
            byte r, g, b;
            while (!quit) {
                Console.WriteLine("Geef kleurwaardes in:");
                Console.Write("R:");
                r = byte.Parse(Console.ReadLine());
                Console.Write("G:");
                g = byte.Parse(Console.ReadLine());
                Console.Write("B:");
                b = byte.Parse(Console.ReadLine());
                serial.Send(r,g,b);
            }
        }
    }
}
