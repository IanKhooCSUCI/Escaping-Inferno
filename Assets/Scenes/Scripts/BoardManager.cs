using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject hall;

    public void RoomGenerate(int door, GameObject room)
    {
        GameObject newRoom = Instantiate(hall);
        newRoom.transform.SetParent(null);
        Vector3 newLoc = room.transform.position;

        if (door == 1)
        {
            newLoc.z += 9;
        }
        else if (door == 2)
        {
            newLoc.x += 9;
        }
        else if (door == 3)
        {
            newLoc.z -= 9;
        }
        else
        {
            newLoc.x -= 9;
        }
        newRoom.transform.Translate(newLoc.x, 0, newLoc.z);
    }
}
