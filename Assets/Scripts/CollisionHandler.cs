using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip failure;
    AudioSource mAudioSource;
    public static int deathCounter { get; private set; }

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem failureParticles;

    bool isTransitioning = false;
    bool collisionDisabled = false;
    public static float time = 0;

    void Start()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        time = time + Time.deltaTime;
        Debug.Log((int)time);
        DebugKey();
    }

    private void DebugKey()
    {
        if (Input.GetKeyDown(KeyCode.L))
            NextLevel();
        else if (Input.GetKeyDown(KeyCode.C))
            collisionDisabled = !collisionDisabled;

    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || collisionDisabled)
            return;

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("I am friendly go on."); break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        isTransitioning = true;
        mAudioSource.Stop();
        mAudioSource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movement_Alt>().enabled = false;
        Invoke("NextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        mAudioSource.Stop();
        mAudioSource.PlayOneShot(failure);
        failureParticles.Play();
        GetComponent<Movement_Alt>().enabled = false;
        deathCounter = deathCounter + 1;
        Debug.Log(deathCounter);
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
