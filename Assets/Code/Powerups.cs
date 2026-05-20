using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public int powerupType = 1; // 0 = none, 1 = big, 2 = fire
    public bool movingHorizontally = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingHorizontally)
        {
            transform.Translate(Vector2.right * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPowerups playerPowerups = other.gameObject.GetComponent<PlayerPowerups>();
            if (playerPowerups != null)
            {
                playerPowerups.powerupType = powerupType;
                Destroy(gameObject);
            }
        }
    }
}
