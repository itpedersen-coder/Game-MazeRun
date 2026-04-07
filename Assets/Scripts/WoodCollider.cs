using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class WoodCollider : MonoBehaviour
{

    public static ILogger log = Debug.unityLogger;

    private GameObject explotionsphere;
    private float explodesize;
    private Material newMat;

    private Stats stats;

    AudioSource audioData;

    public void Start()
    {
        explodesize = 20.0f;
        newMat = Resources.Load("ExplotionSphere", typeof(Material)) as Material;
        stats = GameObject.FindObjectOfType(typeof(Stats)) as Stats;
    }

    public void Update()
    {
        if (explotionsphere != null)
        {
            explotionsphere.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);

            if(explodesize < explotionsphere.transform.localScale.y)
            {
                Destroy(explotionsphere);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.name != "Floor" && !collision.gameObject.name.Contains("ood") && !collision.gameObject.name.StartsWith("Cube"))
            {
                log.Log(collision.gameObject.name);

                if(this != null)
                {
                    //log.Log("Destroy: " + this.gameObject.name);
                    //Destroy(this.gameObject);

                    //this.gameObject.SetActive(false);

                    if (explotionsphere == null)
                    {
                        //Effect on impact
                        explotionsphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        explotionsphere.gameObject.GetComponent<Renderer>().material = newMat;
                        explotionsphere.transform.position = transform.position;

                        audioData = GetComponent<AudioSource>();
                        audioData.Play(0);
                        stats.IncrementPoint();
                        
                    }

                    
                }
            }
        }

      
    }
}
