using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D Player;
    public bool GroundCheck = false;
    public float JumpForce = 0.0001f;
    public float DeathRay = -22f;
    public GameObject SpawnLocation;
    public SpriteRenderer Pea;
    public Sprite PeaRolling;
    public Rigidbody2D rigidBody2D;
    private bool mochi = false;


    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        Pea = gameObject.GetComponent<SpriteRenderer>();
        Resources.LoadAll<Sprite>("Rolling Pea_0");
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.rotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < DeathRay)
        {
            print("die");
            transform.position = new Vector2(-21, -1);
        }
        if (Input.GetButton("Jump") && GroundCheck)
        {
            Player.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
            GroundCheck = !GroundCheck;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Player.AddForce(Vector2.right * 2);
            ChangeSprite(PeaRolling);
            //rigidBody2D.rotation -= 5f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Player.AddForce(Vector2.left * 2);
            ChangeSprite(PeaRolling);
            //rigidBody2D.rotation += 5f;
        }
        if(mochi == true)
        {
            float counter = 0;
            counter += Time.deltaTime;
            Debug.Log(counter);
            rigidBody2D.mass = 1;
            if (counter > 1000)
            {
                rigidBody2D.mass = 1.5f;
                mochi = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "platform")
        {
            GroundCheck = true;
            print(GroundCheck);
        }
        if (other.gameObject.name == "Partner")
        {
            print("you win!");
        }
        if(other.gameObject.name == "Mochi")
        {
            mochi = true;
            GameObject gm = other.gameObject;
            Destroy(gm);
            
            
            
            

        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "platform")
        {
            GroundCheck = false;
            print(GroundCheck);

        }
    }
    private void ChangeSprite(Sprite newsprite)
    {
        Pea.sprite = newsprite;
    }
}