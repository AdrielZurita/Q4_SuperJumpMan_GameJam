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
            playerPowerups.Damaged();
        }
    }
    
    public void DestroyEnemy()
    {
        Destroy(top);
        Destroy(self);
    }
}
