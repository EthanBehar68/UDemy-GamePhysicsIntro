using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagusEffect : MonoBehaviour
{

    public float magnusConstant = 1;

    public Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rigidbody.AddForce(magnusConstant * 
            Vector3.Cross(rigidbody.angularVelocity, rigidbody.velocity));
    }
}
