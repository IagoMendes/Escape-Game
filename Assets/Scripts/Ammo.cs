using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    int qnt;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            qnt = PlayerPrefs.GetInt("Bullets");
            if (qnt < 15)
            {
                if (qnt >= 10)
                {
                    PlayerPrefs.SetInt("Bullets", 15);
                    Destroy(gameObject);
                }
                else
                {
                    PlayerPrefs.SetInt("Bullets", qnt + 5);
                    Destroy(gameObject);
                }
            }
        }
    }
}
