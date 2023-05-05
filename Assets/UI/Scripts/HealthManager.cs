using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public TMP_Text playerHealth;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        playerHealth.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.text = health.ToString();
    }
}
