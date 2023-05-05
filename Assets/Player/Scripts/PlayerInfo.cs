using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerInfo : MonoBehaviour
{
    public int playerHealth;
    public int actions;
    public bool isMoving = false;
    public bool isTurnEnd = false;
    public int roll;
    
    private HealthManager healthManager;
    private RollManager rollManager;
    private ActionManager actionManager;
    private BoardManager boardManager;
    private DoorMatch doorMatch;
    private FireHazard fireHazard;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 playerLoc = gameObject.transform.position;
        playerHealth = 100;
        actions = 2;
        
        playerLoc.z = -4;
        playerLoc.x = 4;
        
        healthManager = GameObject.Find("UI").GetComponent<HealthManager>();
        actionManager = GameObject.Find("UI").GetComponent<ActionManager>();
        rollManager = GameObject.Find("UI").GetComponent<RollManager>();
        boardManager = GameObject.Find("EventSystem").GetComponent<BoardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthManager.health = playerHealth;
        if (actions == 0)
        {
            isTurnEnd = true;
            print("My turn is over...");
            TurnReset();
        }

        if (isMoving && roll <= rollManager.moveCount)
        {
            if (Input.GetKeyDown(KeyCode.Space) || roll == rollManager.moveCount)
            {
                isMoving = false;
                actionManager.actions--;
                actions--;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                print("up");
                gameObject.transform.Translate(0, 0, 1);
                roll++;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                print("left");
                gameObject.transform.Translate(-1, 0, 0);
                roll++;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                print("down");
                gameObject.transform.Translate(0, 0, -1);
                roll++;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                print("right");
                gameObject.transform.Translate(1, 0, 0);
                roll++;
            }
        }
    }

    public void Move()
    {
        print("Moves detected...");
        isMoving = true;
        roll = 0;
    }

    void OnTriggerEnter(Collider door)
    {
        print("Checking door info...");

        GameObject doorObj = door.gameObject;
        
        doorMatch = doorObj.GetComponent<DoorMatch>();
        GameObject room = doorObj.transform.parent.gameObject;
        
        if (doorMatch.isTouchingDoor == false)
        {
            print("Player is at Door!");
            if (door.name == "North Door")
            {
                boardManager.RoomGenerate(1, room);
            }
            else if (door.name == "East Door")
            {
                boardManager.RoomGenerate(2, room);
            }
            else if (door.name == "South Door")
            {
                boardManager.RoomGenerate(3, room);
            }
            else if (door.name == "West Door")
            {
                boardManager.RoomGenerate(4, room);
            }
        }
    }

    void TurnReset()
    {
        actions = 2;
        actionManager.actions = actions;
        isTurnEnd = false;
    }
}
