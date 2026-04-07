using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private GameObject sphere;
    Vector3 Direction2;
    Vector3 directionOnFire = Vector3.zero;
    int maxbullettime = 120;
    int bullettime = 0;

    public static ILogger log = Debug.unityLogger;

    private Material newMat;
    private AudioSource audioShoot;

    // Start is called before the first frame update
    void Start()
    {
        newMat = Resources.Load("FireballMaterial", typeof(Material)) as Material;
         log.Log("Fireball loaded" + (newMat != null ? "Er loaded" : "Er ikke loaded"));

        var audioSources = GetComponents(typeof(AudioSource));
        audioShoot = (AudioSource)audioSources[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (sphere == null)
            {
                //To create the bullet
                sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                
                sphere.gameObject.GetComponent<Renderer>().material = newMat;

                Rigidbody sphereRidigBody = sphere.AddComponent<Rigidbody>();
                sphereRidigBody.mass = 1.0f;
                sphereRidigBody.useGravity = false;
                sphereRidigBody.isKinematic = true;

                SphereCollider sphereColidder = sphere.AddComponent<SphereCollider>();
                sphereColidder.radius = 1.0f;
                sphereColidder.isTrigger = true;
                

                sphere.transform.position = transform.position + (Camera.main.transform.forward.normalized * 5); //Not to shoot my inside cone

                audioShoot.time = 0.044f;
                audioShoot.Play(0);
            }
        }

        if(sphere != null)
        {
            if(directionOnFire == Vector3.zero)
            {
                directionOnFire = Camera.main.transform.forward * 0.6f;
            }
            sphere.transform.position += directionOnFire;
        }

        if (sphere != null)
        {
            bullettime++;

            if(bullettime > maxbullettime)
            {
                ResetShoot();
            }
        }
    }

    private void ResetShoot()
    {
        Destroy(sphere);
        directionOnFire = Vector3.zero;
        bullettime = 0;
        //audioShoot.Pause();
        //audioShoot.time = 0;
    }


}
