using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private int HitPoint { get; set; }

    public void IncrementPoint()
    {
        HitPoint++;
    }

    public void DecrementPoint()
    {
        HitPoint--;
    }

    public int GetPoints()
    {
        return HitPoint;
    }
}
