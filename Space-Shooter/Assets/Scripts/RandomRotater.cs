using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour
{
    Rigidbody RB;
    public int turnSpeed;

    void Start()
    {
        RB = GetComponent<Rigidbody>();



        RB.angularVelocity = Random.insideUnitSphere * turnSpeed;
    }
}
