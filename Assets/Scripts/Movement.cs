using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource mAudioSource;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 1000f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainThrusterParticle;
    [SerializeField] ParticleSystem rightThrusterParticle;
    [SerializeField] ParticleSystem leftThrusterParticle;

    bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProccessThrust();
        ProccessRotation();
    }

    void ProccessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    void ProccessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!mAudioSource.isPlaying)
            mAudioSource.PlayOneShot(mainEngine);
        if (!mainThrusterParticle)
            mainThrusterParticle.Play();
    }

    private void StopThrusting()
    {
        mAudioSource.Stop();
        mainThrusterParticle.Stop();
    }

    private void RotateRight()
    {
        Rotate(-rotationThrust);
        if (!leftThrusterParticle)
            leftThrusterParticle.Play();
    }

    private void RotateLeft()
    {
        Rotate(rotationThrust);
        if (!rightThrusterParticle)
            rightThrusterParticle.Play();
    }

    private void StopRotating()
    {
        rightThrusterParticle.Stop();
        leftThrusterParticle.Stop();
    }

    private void Rotate(float rotationFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
