using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhysicsEngine))]
public class RocketEngine : MonoBehaviour
{

    public float fuelMass; // [kg]
    public float maxThrust; // kN [kg m s^-2] https://en.wikipedia.org/wiki/Newton_(unit)
    [Range(0, 1)]
    public float thrustPercent; // [none]
    public Vector3 thrustUnitVector; // [none]
    
    private PhysicsEngine physicsEngine;
    private float currentThrust; // [N]
    void Start() 
    {
        physicsEngine = GetComponent<PhysicsEngine>();
        physicsEngine.mass += fuelMass;
    }

    void FixedUpdate() 
    {
        if(fuelMass > FuelThisUpdate())
        {
            fuelMass -= FuelThisUpdate();
            physicsEngine.mass -= FuelThisUpdate();
            ExtertForce();
        } 
        else
        {
            Debug.LogWarning("Out of rocket fuel.");
        }
    }

    private float FuelThisUpdate() 
    {
        float effectiveExhaustVelocity = 4462f; // [m s^-1] liquid H O
        float exhaustMassFlow = currentThrust / effectiveExhaustVelocity; // []



        return exhaustMassFlow * Time.deltaTime; // [kg]
    }

    private void ExtertForce()
    {
        currentThrust = thrustPercent * maxThrust * 1000f; // going from kN to N
        Vector3 thrustVector = thrustUnitVector.normalized * currentThrust; // N
        physicsEngine.AddForce(thrustVector);
    }
}
