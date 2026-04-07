using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonScript : MonoBehaviour
{
    //public float mouseSensitivity = 200f;
    //public Transform playerBody;
    //public float xRotation = 0f;
    //public float yRotation = 0f;
    //public float cameraForwardPosition = 0f;

    public float speed = 0.0f;
    public float rotateSpeed = 330f;

    public static ILogger log = Debug.unityLogger;

    AudioSource audioFootsteps;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        log.Log("First Person script loaded");

        audioFootsteps = GetComponent<AudioSource>();
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

            if (!audioFootsteps.isPlaying)
            {
                audioFootsteps.Play();
            }
        }
        else
        {
            if (audioFootsteps.isPlaying)
            {
                audioFootsteps.Pause();
            }
        }

        controller.SimpleMove(forward * speed);

        speed = 0;
    }    
}
