using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public TMP_Text actionCount;
    public float actions;
    // Start is called before the first frame update
    void Start()
    {
        actions = 2f;
        actionCount.text = actions.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        actionCount.text = actions.ToString();
    }
}
