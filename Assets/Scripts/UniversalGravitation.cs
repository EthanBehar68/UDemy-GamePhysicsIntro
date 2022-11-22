using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalGravitation : MonoBehaviour
{
    private PhysicsEngine[] physicsEngineArray;
    private const float bigG = 6.673e-11f; // [m^3 s^-2 kg^-1]

    // Start is called before the first frame update
    void Start()
    {
        physicsEngineArray = GameObject.FindObjectsOfType<PhysicsEngine>();
    }

    void FixedUpdate()
    {
        CaclulateGravity();
    }

    private void CaclulateGravity() 
    {
        foreach(PhysicsEngine engineA in physicsEngineArray)
            foreach(PhysicsEngine engineB in physicsEngineArray)
            {
                if(!engineA.Equals(engineB) && engineA != this)
                {
                    Vector3 distance = engineA.transform.position - engineB.transform.position;
                    
                    float rSquared = Mathf.Pow(distance.magnitude, 2f);
                    float gravityMagnitude = bigG * engineA.mass * engineB.mass / rSquared;
                    
                    Vector3 gravityFelt = gravityMagnitude * distance.normalized;
                    engineA.AddForce(-gravityFelt);
                }
            }
    }
}
