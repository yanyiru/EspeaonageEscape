using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D Player;
    public bool GroundCheck = false;
    public float JumpForce = 0.00001f;
    public float DeathRay = -22f;
    public GameObject SpawnLocation;
    float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < DeathRay)
        {
            print("die");
            transform.position = new Vector2(-8, -2);
        }
        if (Input.GetButton("Jump") && GroundCheck)
        {
            Player.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
            GroundCheck = !GroundCheck;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Player.AddForce(Vector2.right * 2);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Player.AddForce(Vector2.left * 2);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        GroundCheck = true;
        print(GroundCheck);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        GroundCheck = false;
        print(GroundCheck);
    }

}