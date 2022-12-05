using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D myPigLaunch;
    void Start()
    {
        myPigLaunch = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }
    void attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("attack");
            myPigLaunch.velocity = new Vector3(2, 2, 0) * Time.deltaTime;
            StartCoroutine(updateAttack());
        }
    }
    IEnumerator updateAttack()
    {
        yield return new WaitForSeconds(1);
        transform.position -= new Vector3(3, 0, 0) * Time.deltaTime;
    }
}
