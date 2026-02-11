using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    public TMP_Text death;
    public TMP_Text time;
    public GameObject test;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = "Death: " + CollisionHandler.deathCounter;
    }
}
