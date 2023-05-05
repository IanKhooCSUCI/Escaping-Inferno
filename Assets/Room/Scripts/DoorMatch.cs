using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorMatch : MonoBehaviour
{
    public bool isTouchingDoor = false;
    
    void OnTriggerEnter(Collider door)
    {
        print("Checking if object is door...");
        if (door.name == "North Door" || door.name == "East Door" || door.name == "South Door" || door.name == "West Door")
        {
            print("Is touching another door...");
            isTouchingDoor = true;
        }
        else if (isTouchingDoor != true)
        {
            isTouchingDoor = false;
        }
    }
}
