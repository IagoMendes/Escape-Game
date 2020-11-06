using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    float speed = 6f;
    float g = -9.8f * 2;
    float jump = 1.5f;

    public Transform feet;
    float feetDist = 0.2f;
    public LayerMask feetMask;

    Vector3 vel;
    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(feet.position, feetDist, feetMask);

        if (grounded && vel.y < 0)
        {
            vel.y = -1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = (transform.right * x) + (transform.forward * z);
        controller.Move(movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            vel.y = Mathf.Sqrt(jump * (-2f) * g);
        }

        vel.y += g * Time.deltaTime;
        controller.Move(vel * Time.deltaTime);
    }

}
