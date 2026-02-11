using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = "Time: " + (int)CollisionHandler.time;
    }
}
