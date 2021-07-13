using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public bool stopped = false;
    public Vector3 trackPos;
    float timer = 1.5f;
    float instTime = 0;
    Manager manager;
    float timerVariation = 0.25f;
    void Start()
    {
        manager = FindObjectOfType<Manager>();
    }
    void Update()
    {
        if(Time.time > instTime && !stopped){
            GameObject spawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            SpriteRenderer spawnSprite = spawn.GetComponent<SpriteRenderer>();
            Vector3 posSpawn = new Vector3();
            if(spawn == obstaclePrefabs[3]){
                posSpawn = new Vector3(0.03811359f, Random.Range(-4.399937f, -4.97f), 2f);
            } else{
                posSpawn = new Vector3(0.1906221f, -5.188f, 2f);
            }
            Instantiate(spawn, posSpawn, Quaternion.identity);
            instTime = Time.time + Random.Range(timer - timerVariation, timer + timerVariation);
        }
        if(manager.score % 300 == 0){
            timerVariation += 0.25f;
            if(timerVariation == timer){
                timerVariation = 0.25f;
            }
        }
    }
}
