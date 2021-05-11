#include <Keyboard.h>
// Define Pins
const int buttonPin1 = 5; //1 button
//const int light = 4; //LED

boolean pressed1;

void setup() {
  //declare pinmode
  pinMode(buttonPin1, INPUT_PULLUP);
  //pinMode(light, OUTPUT);
  
  //open serial port (USB)
  Serial.begin(9600);                                                                                                                                                                                      
  //disguise as a keyboard
  Keyboard.begin();

  pressed1 = false;     
}

void loop() {
  
  /*keyboard press*/
  if (digitalRead(buttonPin1) == HIGH) {
    if (!pressed1) {
      Keyboard.press(' ');
      pressed1 = true;
    }
  } else {
    if (pressed1) {
      Keyboard.release(' ');                                                                                                                                                     
      //Keyboard.releaseAll();
      pressed1 = false;
    }
/*
      if (Serial.available() > 0) {
        digitalWrite(light, HIGH);
        
      }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      

     delay(100);*/
  }





  
}
