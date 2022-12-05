using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private Rigidbody2D myBody;

    [SerializeField] private AudioSource dieSound;
    void Start()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            die();
        }
    }
    private void die()
    {
        dieSound.Play();
        myBody.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Die");
    }
    private void RestartScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
