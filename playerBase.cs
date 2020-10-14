using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBase : MonoBehaviour
{
    GameObject Player;
    float playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
