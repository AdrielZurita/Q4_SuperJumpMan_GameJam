using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public bool isBreakable = true;
    public GameObject parentBrick;
    public GameObject powerupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isBreakable)
            {
                PlayerPowerups playerPowerups = other.gameObject.GetComponent<PlayerPowerups>();
                if (playerPowerups.powerupType != 0)
                {
                    Destroy(parentBrick);
                    Destroy(gameObject);
                }
            }
            else
            {
                Instantiate(powerupPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }
        }
    }
}
