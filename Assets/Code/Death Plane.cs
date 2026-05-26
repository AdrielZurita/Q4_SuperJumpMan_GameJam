using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public PlayerPowerups playerPowerups;

    // Start is called before the first frame update
    void Start()
    {
        playerPowerups = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPowerups>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerPowerups.death();
        }
    }
}
