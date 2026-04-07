using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaManScript : MonoBehaviour
{

    //Den vi kan starte animationen med.
    //private Animation animation;

    //Den vi styre tilstande med i Animation Controller.
    private Animator animator;

    //Den vi bruger til at flytte charecteren
    private CharacterController controller;

    public float speed = 0;
    public float rotateSpeed = 330f; //Overruled ind ui

    // Start is called before the first frame update
    void Start()
    {
        //animation = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        //animation.Play();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.back);

        float vertical = Input.GetAxis("Vertical");

        if (vertical != 0)
        {
            speed = 10 * vertical;
        }

        controller.SimpleMove(forward * -speed);

        speed = 0;

        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");
        //Vector3 move = new Vector3(h, 0, v).normalized;

        //controller.Move(move * 9f * -Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //Sætter manden til at løbe
            animator.SetBool("RunEnabled", true);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {

        }
        else
        {
            animator.SetBool("RunEnabled", false);
        }

        animator.SetBool("JumpingEnabled", Input.GetKey(KeyCode.Space));
    }
}
