using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    int qnt;
    AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            qnt = PlayerPrefs.GetInt("Lives");
            if (qnt < 3)
            {
                PlayerPrefs.SetInt("Lives", qnt + 1);
            }
            sound.Play();
            Invoke("Inactive", 0.75f);
        }
    }

    private void Inactive()
    {
        gameObject.SetActive(false);
    }
}
