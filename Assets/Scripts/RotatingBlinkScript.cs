using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBlinkScript : MonoBehaviour
{
    public float SpeedRotateY = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, SpeedRotateY, 0);
    }
}
