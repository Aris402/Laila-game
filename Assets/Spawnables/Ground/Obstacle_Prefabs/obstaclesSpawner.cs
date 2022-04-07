using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public bool stopped = false;
    public Vector3 trackPos;
    public float timer = 1f;
    public float instTime = 0;
    Manager manager;
    groundMovement gm;
    public float timerVariation = 0.25f;
    void Start()
    {
        gm = FindObjectOfType<groundMovement>();
        manager = FindObjectOfType<Manager>();
    }
    void Update()
    {
        if(Time.time > instTime && !stopped){
            GameObject spawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            SpriteRenderer spawnSprite = spawn.GetComponent<SpriteRenderer>();
            Vector3 posSpawn = new Vector3();
            if(spawn == obstaclePrefabs[3]){
                posSpawn = new Vector3(2.29f, Random.Range(-4.399937f, -5.838695f), 2f);
            } else{
                posSpawn = new Vector3(2.29f, -6.330952f, 2f);
            }
            Instantiate(spawn, posSpawn, Quaternion.identity);
            instTime = Time.time + Random.Range(timer - timerVariation, timer + timerVariation);
        }
    }
}
