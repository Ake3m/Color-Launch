using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] AudioClip ThrustSound;
    Rigidbody rocket_rigid_body;//rigid body for rocket'
    AudioSource thruster;
    [SerializeField] float mainThrust=1000f; // spacebar thrust
    [SerializeField] float rotationThrust = 100f;

    [SerializeField] ParticleSystem mainThrusterParticle;
    // Start is called before the first frame update
    void Start()
    {
        rocket_rigid_body=GetComponent<Rigidbody>();
        thruster=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            // Debug.Log("Pressed Space - Thrusting");
            if(!thruster.isPlaying)
            {
                thruster.PlayOneShot(ThrustSound);
            }
            rocket_rigid_body.AddRelativeForce(Vector3.up * mainThrust*Time.deltaTime);

            if(!mainThrusterParticle.isPlaying)
            {
                mainThrusterParticle.Play();
            }
            
        }
        else{
            mainThrusterParticle.Stop();
            thruster.Stop();
        }

        
        
    }
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            // Debug.Log("Rotating left");
            ApplyRotation(-rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(rotationThrust);
        }
    }
    void ApplyRotation(float rotationThisFrame)
    {
        rocket_rigid_body.freezeRotation = true; // freezing rotation to be able to manually rotate
        transform.Rotate(Vector3.forward* rotationThisFrame *Time.deltaTime);
        rocket_rigid_body.freezeRotation = false; // unfreezing so the phsyics system cannot take over
    }
}
