using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject player;
    CharacterController controller;
    Animator animator;
    AudioSource sound;
    public GameManager gameManager;
    int lives = 2;
    float speed = 1.5f;
    bool dead = false;

    float time = 16;
    float wait = 16;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        time += Time.deltaTime;
        
        if (Vector3.Distance(player.transform.position, transform.position) < 8f && dead == false)
        {
            if (time > wait)
            {
                time = 0;
                sound.Play();
            }

            animator.SetFloat("speed", 1f);

            Vector3 dir = player.transform.position - transform.position;
            dir.Normalize();
            transform.LookAt(player.transform.position);
            controller.Move(dir * speed * Time.deltaTime);

            if (Vector3.Distance(player.transform.position, transform.position) < 1f)
            {
                animator.SetBool("attack", true);
                Invoke("KillPlayer", 2f);
            }
            else
            {
                animator.SetBool("attack", false);
            }
        }
        else
        {
            time = 16;
            sound.Stop();
            animator.SetFloat("speed", 0);
        }
    }

    public void TakeDamage()
    {
        lives -= 1;

        if (lives == 0)
        {
            dead = true;
            Die();
        }
        else
        {
            animator.SetBool("damage", true);
        }
    }

    void Die()
    {
        animator.SetBool("death", true);
        Invoke("Destroy", 5);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    void KillPlayer()
    {
        gameManager.Died();
    }

}
