using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fruitCollector : MonoBehaviour
{
    private string KIWI_TAG = "Kiwi";
    [SerializeField]
    private TMP_Text kiwiText;

    [SerializeField]
    private AudioSource eatKiwiSound;
    private int kiwi = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(KIWI_TAG))
        {
            Destroy(collision.gameObject);
            kiwi++;
            kiwiText.text = "Kiwi: " + kiwi;
            eatKiwiSound.Play();
        }
    }
}
