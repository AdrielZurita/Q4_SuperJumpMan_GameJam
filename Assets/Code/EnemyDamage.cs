using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject top;
    public GameObject self;
    public PlayerPowerups playerPowerups;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!playerPowerups.invincible)
            {
                playerPowerups.powerupType -= 1;
                playerPowerups.Iframes();
            }
        }
    }
    
    public void DestroyEnemy()
    {
        Destroy(top);
        Destroy(self);
    }
}
