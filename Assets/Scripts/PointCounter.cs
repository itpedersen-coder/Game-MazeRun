using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    private Text text;
    private int hitOnBoxes;
    private Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        stats = GameObject.FindObjectOfType(typeof(Stats)) as Stats;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = stats.GetPoints().ToString();
    }
}
