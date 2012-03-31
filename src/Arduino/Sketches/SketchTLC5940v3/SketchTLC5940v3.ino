/* Sketch ontvangt 5 bytes (SYN, mode, r, g, b) per overdracht  
  
	1                2                3               4                5 
	|	SYN	|	Mode	|	R	|	G	|	B	|
		
SYN: 	synchronisatie-bit (10101010 ofzo, doet er weinig toe wat het precies is, zie declaratie hieronder)

Mode:	4 MSB:	Bepalen van welke mode (kanaal aansturen met rgb waardes die volgen/functie op arduino starten)
				0000:	Kanaal aansturen (kanaal bepaald in 4 LSB)
				0001:	Arduino mode 1 
						...
				1111:	Alle kanalen aansturen met zelfde waarde

	4 LSB:	Indien mode kanaalaansturing bekozen:	Bepalen van welk kanaal
				0000: 	Kanaal 0
				0001:	Kanaal 1
						...
				1111:	Kanaal 15

R,G,B:	Kleurwaardes (8 bit) (indien kanaal aansturing mode gekozen is)
  
*/

#include "Tlc5940.h"

byte startbit=170;    //aanpassen indien nodig
byte mode;
byte red=0,green=0,blue=0;

void setup()
{
  /* Call Tlc.init() to setup the tlc.
     You can optionally pass an initial PWM value (0 - 4095) for all channels.*/
  Tlc.init();
  Serial.begin(9600);
}



void loop()
{
    //Tlc.clear();
    
    /* als er 5 bytes in de buffer zijn word gekeken of eerste gelijk is aan startbit
       indien niet word deze verwijdert uit buffer (duh) */
    if (Serial.available() >= 5){
      if(Serial.read()==startbit){ //startbit staat op 170
        int input = Serial.read();
        
        
        mode = input >> 4; // 4 keer right shift op input om zo de 4 MSB bits van mode te bekomen
        byte channel = input & 15; //logische AND met 15 om enkel 4 LSB te behouden
        
        switch (mode){
          case 0:
            setChannel(channel);
            break;
            
            //hier alle andere in-de-arduino-ingebouwde functies oproepen
            
            
          case 15:
            setAllChannels();
            break;
          default:
            Serial.write("No such mode available");
            break;
        }
      }
  }
  delay(50);
}

void setChannel(byte channel)
{
        red = Serial.read();
        green= Serial.read();
        blue = Serial.read(); 
        
        Tlc.set(2+(channel*3), red*4);
        Tlc.set(1+(channel*3), green*4);
        Tlc.set(3+(channel*3), blue*4);
        
        Tlc.update();
}

void setAllChannels()
{
        red = Serial.read();
        green= Serial.read();
        blue = Serial.read(); 
        Tlc.set(2, red*4);
        Tlc.set(1, green*4);
        Tlc.set(3, blue*4);
      
        Tlc.set(5, red*4);
        Tlc.set(4, green*4);
        Tlc.set(6, blue*4);
        
        Tlc.update();
}



