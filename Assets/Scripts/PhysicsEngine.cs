using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{

    public Vector3 velocity; // [m s^-1]
    public float mass = 0; // [kg]
    public Vector3 netForceVector; // N [kg m s^-2]

    private List<Vector3> forceVectorList = new List<Vector3>();

    void Start() 
    {
        SetupThrustTrails();
    }

    void FixedUpdate() 
    {
        RenderTrails();
        UpdatePosition();
    }

    public void AddForce(Vector3 forceVector)
    {
        forceVectorList.Add(forceVector);
    }

    void UpdatePosition() 
    {
        netForceVector = Vector3.zero;
        foreach(var vector in forceVectorList)
        {
            netForceVector += vector;
        }
        forceVectorList.Clear();

        Vector3 accelerationVector = netForceVector / mass;
        velocity += accelerationVector * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

	public bool showTrails = true;
	private LineRenderer lineRenderer;
	private int numberOfForces;
	
	void SetupThrustTrails () 
    {
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		lineRenderer.SetColors(Color.yellow, Color.yellow);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.useWorldSpace = false;
	}
	
	void RenderTrails() 
    {
		if (showTrails) 
        {
			lineRenderer.enabled = true;
			numberOfForces = forceVectorList.Count;
			lineRenderer.SetVertexCount(numberOfForces * 2);
			int i = 0;
			foreach (Vector3 forceVector in forceVectorList) 
            {
				lineRenderer.SetPosition(i, Vector3.zero);
				lineRenderer.SetPosition(i+1, -forceVector);
				i = i + 2;
			}
		} 
        else 
        {
			lineRenderer.enabled = false;
		}
	}
}
