using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public bool isBreakable = true;
    public GameObject parentBrick;
    public GameObject powerupPrefab;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsBreakable", isBreakable);
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
                    animator.SetBool("Hit", true);
                    StartCoroutine(DestroyBrick());
                }
            }
            else
            {
                if (animator.GetBool("Hit") == false)
                {
                    Instantiate(powerupPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    animator.SetBool("Hit", true);
                }
            }
        }
    }

    System.Collections.IEnumerator DestroyBrick()
    {
        yield return new WaitForSeconds(1f);
        Destroy(parentBrick);
        Destroy(gameObject);
    }
}
