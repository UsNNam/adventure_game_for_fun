using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float moveForce = 10f;
    private Animator anim;
    private float movementX;
    [SerializeField]
    private float speed = 7;

    [SerializeField] private AudioSource jumpSound, win;

    private string GROUND_TAG = "Ground";

    private bool double_jump = false;

    private bool isGround;
    private enum MovementState { Idle, Running, Jumping, Falling, Double_Jump}

    private Rigidbody2D myBody;

    private SpriteRenderer mySP;
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mySP = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;
        
        if (movementX > 0)
        {
            state = MovementState.Running;
            mySP.flipX = false;
        }
        else if (movementX < 0)
        {
            state = MovementState.Running;
            mySP.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
            mySP.flipX = false;
        }
        if(myBody.velocity.y > 0.1)
        {
            state = MovementState.Jumping;
        }
        else if(myBody.velocity.y < -0.1)
        {
            state = MovementState.Falling;
        }
        if (double_jump && !isGround)
        {
            state = MovementState.Double_Jump;
        }
        anim.SetInteger("State", (int)state);
    }
    private void playerMove()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        myBody.position += new Vector2(movementX, 0) * Time.deltaTime * speed;
        //a = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump") && isGround)
        {
            jumpSound.Play();
            myBody.AddForce(new Vector2(0f, moveForce), ForceMode2D.Impulse);
            isGround = false;
        }
        else if(Input.GetButtonDown("Jump") && isGround == false && !double_jump)
        {
            jumpSound.Play();
            myBody.AddForce(new Vector2(0f, moveForce), ForceMode2D.Impulse);
            double_jump = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG) || collision.gameObject.CompareTag("Untagged"))
        {
            isGround = true;
            double_jump = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "CheckPoint")
        {
            win.Play();
            StartCoroutine(LoadLevelAfterDelay(1.5f));
        }
    }
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
