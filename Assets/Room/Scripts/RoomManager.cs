using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject fire;
    public GameObject starterFire;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 player = GameObject.Find("player").transform.position;
        starterFire = Instantiate(fire, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        Vector3 firePosition;

        do
        {
            firePosition.x = Mathf.Floor(Random.Range(-5, 5));
            firePosition.z = Mathf.Floor(Random.Range(-5, 5));
        } while (firePosition.x.Equals(player.x) && firePosition.z.Equals(player.z));
        
        starterFire.transform.Translate(firePosition.x, 0, firePosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
