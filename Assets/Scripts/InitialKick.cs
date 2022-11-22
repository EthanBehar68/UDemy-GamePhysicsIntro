using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class InitialKick : MonoBehaviour {

	public Vector3 initialKick = new Vector3 (4f, 0, 0);

	public Vector3 angularVelocity = new Vector3(4f, 0, 0);

	private Rigidbody rigidbody;
	
	// Use this for initialization
	void OnEnable () {
		rigidbody = GetComponent<Rigidbody> ();
		rigidbody.velocity = initialKick;
		rigidbody.angularVelocity = angularVelocity;
	}
}