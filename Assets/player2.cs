using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{

    public float hiz;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, hiz * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, -hiz * Time.deltaTime, 0);
        }
    }
}
