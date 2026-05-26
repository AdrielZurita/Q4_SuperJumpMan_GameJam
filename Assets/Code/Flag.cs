using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;


public class Flag : MonoBehaviour
{
    public Animator animator;
    public string levelToLoad;
    public float loadTime = 0.5f;
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
            animator.SetTrigger("FlagTouched");
            StartCoroutine(LoadLevelAfterDelay(loadTime)); // Adjust the delay as needed
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(levelToLoad);
        print("Level Loaded: " + levelToLoad);
    }
}
