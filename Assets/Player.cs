using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Inst { get; private set; }
    private void Awake() => Inst = this;

    public float speed;
    public float jumpPower;
    float horizontalInput;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D playerRB;
    public float gravity;
    public CapsuleCollider2D capsuleCollider;

    public bool isGround;
    public bool isDead;
    public bool isClear;

    public int life =3;
    public TextMeshProUGUI lifeCountText;
    AudioSource sound;
    public AudioClip jumpSound;
    public AudioClip dingSound;
    public AudioClip ouchSound;

    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        sound= GetComponent<AudioSource>();
        goal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(!isDead && !isClear)
        {
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
            LeftRight();
            Jump();
        }
        
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
            sound.PlayOneShot(jumpSound,0.2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Floor")
        {
            isGround = true;

            if (collision.gameObject.tag == "Floor")
            {
                jumpPower = 150.0f;
            }
            else
            {
                jumpPower = 50.0f;
            }
        }

        if (collision.gameObject.tag == "DeadZone")
        {
            isDead = true;
            capsuleCollider.enabled = false;
            playerRB.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            sound.PlayOneShot(ouchSound,0.1f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Floor")
        {
            isGround = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Floor")
        {
            isGround = true;

            if (collision.gameObject.tag == "Floor")
            {
                jumpPower = 150.0f;
            }
            else
            {
                jumpPower = 50.0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Goal")
        {
            isClear = true;
            GameManager.Inst.clear.SetActive(true);
            Debug.Log(SceneManager.GetActiveScene().name);
        }

        if(collision.CompareTag("Item"))
        {
            sound.PlayOneShot(dingSound, 0.03f);
        }

        if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            goal.SetActive(true);
        }
    }
}
