using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.IO.Ports;

public class ArduinoJoystick : MonoBehaviour {
    SerialPort noh;
    public string COMPort;
    public Rigidbody Rigidbody;
    public Vector4 Map = new Vector4(0,1024,-5,5);
    public float Deadzone = 0;
    public Vector2 currentMap;
    string[] Numbers = new string[2];
	// Use this for initialization
	void Start () {
        noh = new SerialPort(COMPort, 9600);
        if (noh.IsOpen)
        {
            noh.Close();
            noh.Open();
        }
        else
        {
            noh.Open();
        }
        
	}

    // Update is called once per frame
    void Update() {
        if (noh.IsOpen)
        {
            Numbers = noh.ReadLine().Split(',');
        }
        currentMap = new Vector2(map((float)Int16.Parse(Numbers[0]), Map.x, Map.y, Map.z, Map.w, Deadzone),(map((float)Int16.Parse(Numbers[1]), Map.x, Map.y, Map.z, Map.w, Deadzone)));
        Rigidbody.AddForce(new Vector3(currentMap.x,0,currentMap.y));
        
    }

    float map(float Number, float rangeMin1, float rangeMax1, float rangeMin2, float rangeMax2,float Deadzone)
    {
        float map = (Number - rangeMin1) / (rangeMax1 - rangeMin1) * (rangeMax2 - rangeMin2) + rangeMin2;
        if (Math.Abs(map) < Deadzone)
        {
            return (float)0;
        }
        return map;
    }
}
