using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAnfForth : MonoBehaviour
{
    public float baseSpeed = 3f;
    public int direction = 1; // 1 for right, -1 for left
    public float jankCompenstation = 0.5f;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
    public GameObject thisObject;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        thisObject.transform.localScale = new Vector3(-direction, 1, 1);

        transform.Translate(new Vector2(direction, 0) * speed * Time.deltaTime);

        if (Physics2D.Raycast(thisObject.transform.position, new Vector2(direction, 0), 0.7f, whatIsGround) || Physics2D.Raycast(thisObject.transform.position, new Vector2(direction, 0), 0.45f, whatIsPlayer))
        {
            direction *= -1; // Reverse direction
        }

        speed = baseSpeed - direction * jankCompenstation;
        
        //print(new Vector2(direction, 0) * speed * Time.deltaTime);
    }
}
