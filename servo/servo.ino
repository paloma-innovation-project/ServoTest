//www.elegoo.com
//2016.12.08
#include <Servo.h>

Servo myservo;  // create servo object to control a servo
// twelve servo objects can be created on most boards

int pos = 0;    // variable to store the servo position

void setup() {
  Serial.begin(9600);
  myservo.attach(9);  // attaches the servo on pin 9 to the servo object
}

void loop() {
    if(Serial.available() != 0){
      myservo.write((int)Serial.read());              // tell servo to go to position in variable 'pos'
    }
}
