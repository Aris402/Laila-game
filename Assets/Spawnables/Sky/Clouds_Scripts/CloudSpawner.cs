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
        timer = 2.5f;
        timerVariation = 1;
    }
    void Update()
    {
        startPosition = new Vector3(0.06417894f, Random.Range(-0.5963413f, -3.02f));
        if(Time.time > instTime && !stopped){
            Instantiate(clouds[Random.Range(0, clouds.Length)], startPosition, Quaternion.identity);
            instTime = Time.time + Random.Range(timer - timerVariation, timer + timerVariation);
        }
    }
}
