int analogzero = 0;
int analogone = 1;
int LR;
int UD;
String strung;
void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  LR = analogRead(analogone);
  UD = analogRead(analogzero);
  
  Serial.print(LR);
  Serial.print(",");
  Serial.println(UD);
  delay(20);
}
