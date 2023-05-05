using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHazard : MonoBehaviour
{
    private PlayerInfo playerInfo;
    public GameObject fire;
    
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.Find("player").GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInfo.isTurnEnd)
        {
            print("Trying to make a new fire...");
            FireSpread();
        }
    }

    void FireSpread()
    {
        GameObject origin = gameObject;
        GameObject newFire = Instantiate(fire, origin.transform.position, Quaternion.identity, origin.transform.parent);

        int spreadDirect = Random.Range(1, 8);

        Vector3 spreadLoc = origin.transform.position;

        switch (spreadDirect)
        {
            case 1:
                spreadLoc.x += 1;
                break;
            case 2:
                spreadLoc.x -= 1;
                break;
            case 3:
                spreadLoc.z += 1;
                break;
            case 4:
                spreadLoc.x -= 1;
                break;
            case 5:
                spreadLoc.x += 1;
                spreadLoc.z += 1;
                break;
            case 6:
                spreadLoc.x -= 1;
                spreadLoc.z -= 1;
                break;
            case 7:
                spreadLoc.x += 1;
                spreadLoc.z -= 1;
                break;
            case 8:
                spreadLoc.x -= 1;
                spreadLoc.z += 1;
                break;
        }
        
        newFire.transform.Translate(spreadLoc.x, 0, spreadLoc.z);
    }
}
