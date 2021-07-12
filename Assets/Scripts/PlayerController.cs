using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const int BORDERS = 10;

    private Vector2 speed;
    private Vector2 movement;

    GameObject player;
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        speed = new Vector2(9, 0);
        player = GameObject.Find("Player");
        rigidbody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        movement = new Vector2(speed.x * inputX, 0);
        Debug.Log("Movement: " + movement);
    }

    void FixedUpdate()
    {
        rigidbody.velocity = movement;
        float x = rigidbody.position.x;
        if (x > BORDERS || x < -BORDERS)
        {
            rigidbody.position = new Vector2(-x, rigidbody.position.y);
        }
    }
}
