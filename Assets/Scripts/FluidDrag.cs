using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stupid simple and not accuarte
public class FluidDrag : MonoBehaviour
{

    [Range(1, 2)]
    public float velocityExponent; // [none]

    public float dragConstant; // [??]

    private PhysicsEngine physicsEngine;

    // Start is called before the first frame update
    void Start()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
    }

    void FixedUpdate()
    {
        Vector3 velocity = physicsEngine.velocity;
        float speed = velocity.magnitude;
        Vector3 drag = CalculateDrag(speed) * -velocity.normalized;

        physicsEngine.AddForce(drag);
    }

    float CalculateDrag(float speed)
    {
        return dragConstant * Mathf.Pow(speed, velocityExponent);
    }
}
