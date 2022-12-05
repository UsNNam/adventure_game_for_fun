using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    private float speedSaw = -4f;
    // Start is called before the first frame update
    private Rigidbody2D myBody;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(1f, 0, 0) * Time.deltaTime * speedSaw;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BlockSaw") || collision.gameObject.CompareTag("Trap"))
        {
            speedSaw = -speedSaw;
        }

    }
}
