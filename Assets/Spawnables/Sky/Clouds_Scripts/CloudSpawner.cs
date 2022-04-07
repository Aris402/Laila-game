using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject[] clouds;
    public bool stopped = false;
    float timer;
    float instTime;
    float timerVariation;
    public Vector3 startPosition;
    void Start()
    {
        timer = 3.5f;
        timerVariation = 1f;
    }
    void Update()
    {
        startPosition = new Vector3(2.276435f, Random.Range(0.33f, -4.19f), 91f);
        if(Time.time > instTime && !stopped){
            Instantiate(clouds[Random.Range(0, clouds.Length)], startPosition, Quaternion.identity);
            instTime = Time.time + Random.Range(timer - timerVariation, timer + timerVariation);
        }
    }
}
