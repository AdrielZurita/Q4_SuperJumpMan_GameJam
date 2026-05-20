using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerups : MonoBehaviour
{
    public int powerupType = 0; // 0 = none, 1 = big, 2 = fire
    public PlayerMovement2D playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (powerupType)
        {
            case 0:
                transform.localScale = new Vector3(1f, 1f, 1f);
                playerMovement.playerHeight = 0.7f;
                break;
            case 1:
                transform.localScale = new Vector3(2f, 2f, 1f);
                playerMovement.playerHeight = 1.2f;
                break;
            case 2:
                // Implement fire powerup behavior here.
                break;
        }
    }
}
