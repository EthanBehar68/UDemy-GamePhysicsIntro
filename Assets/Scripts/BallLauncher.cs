using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public float maxLaunchSpeed = 0;
    public AudioClip windup;
    public AudioClip launch;

    public Transform launchedBallParent;
    public PhysicsEngine ballPrefab;

    private AudioSource audioSource;
    private float additiveSpeed = 0;
    private float launchSpeed;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = windup;
        additiveSpeed = (maxLaunchSpeed * Time.fixedDeltaTime) / audioSource.clip.length;
    }

    // Lost respect for the UDemy course after
    // it suggested using these methods.
    void OnMouseDown()
    {
        launchSpeed = 0;
        InvokeRepeating("IncreaseLaunchSpeed", 0.5f, Time.fixedDeltaTime);
        audioSource.clip = windup;
        audioSource.Play(); 
    }

    void OnMouseUp()
    {
        CancelInvoke();
        audioSource.Stop();
        audioSource.clip = launch;
        audioSource.Play();

        PhysicsEngine newBall = Instantiate(ballPrefab) as PhysicsEngine;
        newBall.transform.parent = launchedBallParent.transform;

        Vector3 launchVelocity = new Vector3(1,1,0).normalized * launchSpeed;
        newBall.velocity = launchVelocity;
    }

    void IncreaseLaunchSpeed() 
    {
        if (launchSpeed <= maxLaunchSpeed)
        {
            launchSpeed += additiveSpeed;
        }
    }
}
