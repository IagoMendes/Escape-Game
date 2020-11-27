using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        sound.Play();
    }

}
