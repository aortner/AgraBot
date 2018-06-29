/* Author: Garmin
 * Modified by: Brian Tischler
 * Date: June 25, 2018
 */

#include <Wire.h>
#include <LIDARLite.h>

#include <EtherCard.h>
#include <IPAddress.h> 

#define A 0X28  //I2C address selection pin LOW
#define B 0x29  //                        HIGH

// Globals
LIDARLite lidarLite;
int cal_cnt = 0;

// Define the number of samples to keep track of. The higher the number, the
// more the readings will be smoothed, but the slower the output will respond to
// the input. Using a constant rather than a normal variable lets us use this
// value to determine the size of the readings array.
const byte numReadings = 5;

unsigned int readings[numReadings];      // the readings from the analog input
byte readIndex = 0;              // the index of the current reading
unsigned int total = 0;                  // the running total
int distAverage = 0;                // the average

// ethernet interface ip address
static byte myip[] = { 192,168,1,72 };
// gateway ip address
static byte gwip[] = { 192,168,1,1 };
//DNS- you just need one anyway
static byte myDNS[] = { 8,8,8,8 };
//mask
static byte mask[] = { 255,255,255,0 };
//this is port of this module
unsigned int portMy = 5566; 

//sending back to where and which port
static byte ipDestination[] = {192, 168, 1, 255};
unsigned int portDestination = 9999; 

// ethernet mac address - must be unique on your network
static byte mymac[] = { 0x69,0x69,0x69,0x30,0x30,0x30 };

byte Ethernet::buffer[400]; // tcp/ip send and receive buffer

void(* resetFunc) (void) = 0;

byte loopCount;

void setup()
{
  Serial.begin(9600); // Initialize serial connection to display distance readings

  lidarLite.begin(0, false); // Set configuration to default and I2C to 100 kHz
  lidarLite.configure(0); // Change this number to try out alternate configurations

  //zero out ring averages
  for (int thisReading = 0; thisReading < numReadings; thisReading++)
    readings[thisReading] = 0;

  if (ether.begin(sizeof Ethernet::buffer, mymac) == 0)
    Serial.println(F("Failed to access Ethernet controller"));

  //set up connection
  ether.staticSetup(myip, gwip, myDNS, mask); 
  ether.printIp("IP:  ", ether.myip);
  ether.printIp("GW:  ", ether.gwip);
  ether.printIp("DNS: ", ether.dnsip);

  //register udpSerialPrint() to port 8888.
  ether.udpServerListenOnPort(&udpSteerRecv, 8888);
}

void loop()
{
  total = total - readings[readIndex];// subtract the last reading:
  // every 100 readings, take a measurement with receiver bias correction
  if ( cal_cnt == 0 ) readings[readIndex] = lidarLite.distance();      // With bias correction
  else  readings[readIndex] = lidarLite.distance(false); // Without bias correction  
  if (cal_cnt++ > 100) cal_cnt = 0;// Increment reading counter  

  // greater the 40m reads as 1 cm
  if (readings[readIndex] < 100) readings[readIndex] = 4000;
  if (readings[readIndex] > 3900) readings[readIndex] = 4000;
  
  total = total + readings[readIndex];// add the reading to the total:  
  readIndex = readIndex + 1;// advance to the next position in the array:  
  if (readIndex >= numReadings) readIndex = 0; // if we're at the end of the array...  
  distAverage = total / numReadings;// calculate the average:

 //sprintf(sent,"%d",distanceAverage);
 char sent[12] = "LIDAR,      ";

 if (loopCount++ > 4)
 {
   //this must be called for ethercard functions to work.
  ether.packetLoop(ether.packetReceive()); 
  
  itoa(distAverage,sent+6, 10);
   ether.sendUdp(sent, strlen(sent), portMy, ipDestination, portDestination);
   loopCount = 0;

    // Display distance
  Serial.print(distAverage);
  Serial.println(" cm");
 }
  
 delay(50);

 
}

//callback when received packets
void udpSteerRecv(uint16_t dest_port, uint8_t src_ip[IP_LEN], uint16_t src_port, byte *data, uint16_t len)
{
  /* IPAddress src(src_ip[0],src_ip[1],src_ip[2],src_ip[3]); 
  Serial.print("dPort:");  Serial.print(dest_port);
  Serial.print("  sPort: ");  Serial.print(src_port); 
  Serial.print("  sIP: ");  ether.printIp(src_ip);  Serial.println("  end");

  for (int i = 0; i < len; i++) {
    Serial.print(data[i],HEX); Serial.print("\t"); } Serial.println(len);  

    // PGN - 32766 - 127.254
    if (data[0] == 0x7F && data[1] == 0xFE)
    {
      relay = data[2];   // read relay control from AgOpenGPS     
      speeed = data[3];  //actual speed times 4, single byte
      speeed /=4;
      uTurn = data[8];  

      //heard from AgOpenGPS - we're alive
      watchdogTimer = 0;  //reset watchdog
      //count++;
      //Serial.print(speeed);
      //Serial.print(",");    
      //Serial.print(steerAngleSetPoint);   //the pwm value to solenoids or motor
      Serial.print(count);Serial.print("\t");
      Serial.println(uTurn);
    }
    */
}

