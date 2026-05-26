using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlayerPowerups : MonoBehaviour
{
    public int powerupType = 0; // 0 = none, 1 = big, 2 = fire
    public PlayerMovement2D playerMovement;
    public Animator animator;
    public bool invincible = false;
    public float invincibilityDuration = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (powerupType)
        {
            case -1:
                //death();
                break;
            case 0:
                animator.SetInteger("PowerUpType", 0);
                break;
            case 1:
                animator.SetInteger("PowerUpType", 1);
                break;
            case 2:
                // animator.SetInteger("PowerUpType", 2);
                // Implement fire powerup behavior here.
                break;
        }
    }

    void death()
    {
        //play animation
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Iframes()
    {      
        if (!invincible)
        {
            invincible = true;
            StartCoroutine(InvincibilityDuration());
        } 
    }

    System.Collections.IEnumerator InvincibilityDuration()
    {
        yield return new WaitForSeconds(invincibilityDuration); // Adjust duration as needed
        invincible = false;
    }
}
