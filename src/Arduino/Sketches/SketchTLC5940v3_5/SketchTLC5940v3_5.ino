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
 Indien andere mode gekozen bepaald mode zelf wat hij met deze bits doet
 
 R,G,B:	Kleurwaardes (8 bit) (indien kanaal aansturing mode gekozen is)
 
 */

#include "Tlc5940.h"

byte startbit=170;    //aanpassen indien nodig
byte mode;
byte red=0,green=0,blue=0;

void setup()
{
  Tlc.init(2);
  Serial.begin(19200);
}



void loop()
{
  //Tlc.clear();

  /* als er 5 bytes in de buffer zijn word gekeken of eerste gelijk is aan startbit
   indien niet word deze verwijdert uit buffer (duh) */
  if (Serial.available() >= 5){
    if(Serial.read()==startbit){ //startbit staat op 170
      byte input = Serial.read();


      mode = input >> 4; // 4 keer right shift op input om zo de 4 MSB bits van mode te bekomen
      byte options = input & B00001111; //logische AND met 15 om enkel 4 LSB te behouden
      

      switch (mode){
      case 0:
        setChannel(options);
        break;
      case 1:
        allColorsCycle(options);
        break;
      case 2:
        strobeLight();
        break;
      case 3:
        PoliceLight();
        break;

        //hier alle andere in-de-arduino-ingebouwde functies oproepen

      case 14:
        //placeholder voor oproep naar functie die bytes uitleest om arduino te configureren: aantal kanalen, andere dingen, we zien wel
        break;
      case 15:
        setAllChannels();
        break;
      default:
        Serial.write("No such mode available");
        break;
      }
    }
  }
}


void setChannel(byte channel, int red, int green, int blue)
{
  Tlc.set(2+(channel*3), red*16);
  Tlc.set(1+(channel*3), green*16);
  Tlc.set(3+(channel*3), blue*16);

  Tlc.update();
}


void setAll(int red, int green, int blue)
{
  //hier uiteindelijk loop die door # ledstrips gaat. Word ingegeven door mode 14 (configuratie mode)

  Tlc.set(2, red*16);
  Tlc.set(1, green*16);
  Tlc.set(3, blue*16);

  Tlc.set(5, red*16);
  Tlc.set(4, green*16);
  Tlc.set(6, blue*16);

  Tlc.update();
}

//mode 0
void setChannel(byte channel)
{
  red = Serial.read();
  green= Serial.read();
  blue = Serial.read(); 
  setChannel(channel,red,green,blue);
}

//mode 15
void setAllChannels()
{
  red = Serial.read();
  green= Serial.read();
  blue = Serial.read(); 

  setAll(red,green,blue);
}

//mode 1
void allColorsCycle(byte options) // source: https://gist.github.com/766994 
{
  long del=64;
  while(Serial.available()<4){
    unsigned int rgbColour[3];


    rgbColour[0] = 255;
    rgbColour[1] = 0;
    rgbColour[2] = 0;  

    // Choose the colours to increment and decrement.
    for (int decColour = 0; decColour < 3; decColour += 1) {
      int incColour = decColour == 2 ? 0 : decColour + 1;

      // cross-fade the two colours.
      for(int i = 0; i < 255; i += 1) {
        rgbColour[decColour] -= 1;
        rgbColour[incColour] += 1;

        setAll(rgbColour[0], rgbColour[1], rgbColour[2]);
        
        delay(del);
        
        if(Serial.available()>3){
          setAll(0,0,0);
          return;
        }
        
      }
    }
  }
  setAll(0,0,0);
}

//mode 2
void strobeLight() {
   while(Serial.available()<4) {
      setAll(255, 255, 255);
      delay(25);
      setAll(0, 0, 0);
      delay(25);
   } 
}

//mode 3
void PoliceLight() {
   while(Serial.available()<4){
      for(int i=0; i < 2; i++) {
        setAll(255, 0, 0);
        delay(50);
        setAll(0, 0, 0);
        delay(50);
      } 
      
      delay(150);
      
     for(int i=0; i < 2; i++) {
        setAll(0, 0, 255);
        delay(50);
        setAll(0, 0, 0);
        delay(50);
      } 
      
   }
}





