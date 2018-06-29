
  #include <EtherCard.h>
  #include <IPAddress.h> 

  #define A 0X28  //I2C address selection pin LOW
  #define B 0x29  //                        HIGH
  
  //ethercard 8,11,12,13  
  //timer 2 controls 9,10
  #define GEAR1_PIN 4  //PD4
  #define GEAR2_PIN 5 //PD5
  #define CLUTCH1_PIN 6  //PD6
  #define CLUTCH2_PIN 7  //PD7 
  #define THROTTLE1_PIN 9  //PB1
  #define THROTTLE2_PIN 10  //PB2
  
  //loop time variables in microseconds
  const unsigned int LOOP_TIME = 100; //100hz 
  unsigned int lastTime = LOOP_TIME;
  unsigned int currentTime = LOOP_TIME;
  unsigned int dT = 50000;
  unsigned int count = 0;
  byte watchdogTimer = 0;
    
  byte relay = 0, uTurn = 0, speeed = 0;
  static char sent[] = "Th";
 
// ethernet interface ip address
static byte myip[] = { 192,168,1,73 };
// gateway ip address
static byte gwip[] = { 192,168,1,1 };
//DNS- you just need one anyway
static byte myDNS[] = { 8,8,8,8 };
//mask
static byte mask[] = { 255,255,255,0 };
//this is port of this module
unsigned int portMy = 5555; 

//sending back to where and which port
static byte ipDestination[] = {192, 168, 1, 255};
unsigned int portDestination = 9999; 

// ethernet mac address - must be unique on your network
static byte mymac[] = { 0x70,0x69,0x69,0x2D,0x30,0x31 };

byte Ethernet::buffer[400]; // tcp/ip send and receive buffer

void(* resetFunc) (void) = 0;

void setup()
{
  Serial.begin(9600);   
  if (ether.begin(sizeof Ethernet::buffer, mymac) == 0)
    Serial.println(F("Failed to access Ethernet controller"));

  //set up connection
  ether.staticSetup(myip, gwip, myDNS, mask); 
  ether.printIp("IP:  ", ether.myip);
  ether.printIp("GW:  ", ether.gwip);
  ether.printIp("DNS: ", ether.dnsip);

  //register udpSerialPrint() to port 8888.
  ether.udpServerListenOnPort(&udpSteerRecv, 8888);
  
  pinMode(GEAR1_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
  pinMode(GEAR2_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
  pinMode(CLUTCH1_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
  pinMode(CLUTCH2_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
  pinMode(THROTTLE1_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
  pinMode(THROTTLE2_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
} 

void loop()
{ 
  currentTime = millis();
  unsigned int time = currentTime;

  if (currentTime - lastTime >= LOOP_TIME)
  {   
    dT = currentTime - lastTime;
    lastTime = currentTime;

    //If connection lost to AgOpenGPS, the watchdog will count up and turn off steering
    if (watchdogTimer++ > 253) watchdogTimer = 12;
    
    if (watchdogTimer < 10)    {
      SetRelays();
    }
    else    {
      uTurn = 0;
      SetRelays();
      //resetFunc();
    }
      //Serial.write(data);
      //count++;
      // convert 123 to string [buf]
      //itoa(count, sent, 10);
      //sprintf(sent,"%d",count);
      //ether.sendUdp(sent, strlen(sent), portMy, ipDestination, portDestination);
  
  } //end of timed loop
  
  delay(50);
  //this must be called for ethercard functions to work.
  ether.packetLoop(ether.packetReceive());  
}

//callback when received packets
void udpSteerRecv(uint16_t dest_port, uint8_t src_ip[IP_LEN], uint16_t src_port, byte *data, uint16_t len)
{
  /* IPAddress src(src_ip[0],src_ip[1],src_ip[2],src_ip[3]); 
  Serial.print("dPort:");  Serial.print(dest_port);
  Serial.print("  sPort: ");  Serial.print(src_port); 
  Serial.print("  sIP: ");  ether.printIp(src_ip);  Serial.println("  end");

  for (int i = 0; i < len; i++) {
    Serial.print(data[i],HEX); Serial.print("\t"); } Serial.println(len);  */

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
}
