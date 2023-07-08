using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    float horizontalInput;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D playerRB;
    public float gravity;
    public CapsuleCollider2D capsuleCollider;

    public bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        Physics2D.gravity *= gravity;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        LeftRight();
        Jump();
    }

    public void LeftRight()
    {
        float Xrotate = spriteRenderer.transform.localScale.x;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Xrotate = -1f;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Xrotate = 1f;
        }
        spriteRenderer.transform.localScale = new Vector3(Xrotate, 1f, 1f);
    }

    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            playerRB.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
}
