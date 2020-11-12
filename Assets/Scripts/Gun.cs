using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    readonly float dist = 50f;

    public Camera cam;

    public ParticleSystem flash;

    private float timer;
    private float wait = 0.4f;

    AudioSource shot;

    private void Start()
    {
        shot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int bullets = PlayerPrefs.GetInt("Bullets");

        if ((timer > wait) && Input.GetButtonDown("Fire1") && (bullets > 0))
        {
            PlayerPrefs.SetInt("Bullets", --bullets);

            timer = 0;

            flash.Play();
            shot.Play();

            RaycastHit hitMarker;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitMarker, dist))
            {
                Target enemy = hitMarker.transform.GetComponent<Target>();

                if (enemy != null)
                {
                    enemy.TakeDamage();
                }
            }

        }
    }
}
