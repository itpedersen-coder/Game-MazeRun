using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCalc : MonoBehaviour
{
    private float currentfps;
    private Text fps;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        fps = GetComponent<Text>();
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (i > 60)
        {
            currentfps = (int)(1f / Time.unscaledDeltaTime);
            fps.text = currentfps.ToString();
            i = 0;
        }

        i++;
    }
}
