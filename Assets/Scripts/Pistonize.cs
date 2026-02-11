using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistonize : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 0.7f;
    [SerializeField] float offset = 13.5f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float cycles = Time.time / period;
        Vector3 test = new Vector3(0, Mathf.Sin(cycles) * offset, 0);
        transform.position = startingPosition + test;

        /*if (period <= Mathf.Epsilon)
            return;

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;*/
    }
}


