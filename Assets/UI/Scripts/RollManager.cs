using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Serialization;
using UnityEngine;

public class RollManager : MonoBehaviour
{
    public TMP_Text roll;
    public int moveCount;

    private PlayerInfo _playerInfo;
    // Start is called before the first frame update
    void Start()
    {
        moveCount = 0;
        roll.text = moveCount.ToString();

        _playerInfo = GameObject.Find("player").GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        roll.text = moveCount.ToString();
    }

    public void OnMouseDown()
    {
        if (!_playerInfo.isMoving && _playerInfo.actions > 0)
        {
            print("Activated...");
            moveCount = UnityEngine.Random.Range(1, 7);
            roll.text = moveCount.ToString();
            _playerInfo.Move();
        }
        else
        {
            print("Player is already moving!");
        }
    }
}
