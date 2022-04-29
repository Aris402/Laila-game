using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject bonePrefab;
    public bool stopped = false;
    public Vector3 trackPos;
    public float timer = 0.8f;
    public float instTime = 0;
    Manager manager;
    groundMovement gm;
    public float posVariation;
    public float timerVariation = 0.4f;
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
            Vector3 bonePos = new Vector3();
            int randomValue = Random.Range(1, 10);
            bool collSpawned = false;
            if(spawn == obstaclePrefabs[3]){
                posVariation = Random.Range(1f, 1.5f);
                bonePos = new Vector3(2.29f, obstaclePrefabs[3].transform.position.y + posVariation);
                posSpawn = new Vector3(2.29f, Random.Range(-4.9f, -5.28f), 2f);
                if(collSpawned == false && randomValue <= 2){
                    Instantiate(bonePrefab, bonePos, Quaternion.identity);
                    collSpawned = true;
                }
            }
            else{
                posSpawn = new Vector3(1.67f, -6f, 2f);
            }
            if(spawn == obstaclePrefabs[2] && randomValue <= 2){
                posVariation = Random.Range(0.3f, 0.6f);
                bonePos = new Vector3(2.29f, obstaclePrefabs[2].transform.position.y + posVariation);
                if(collSpawned == false && obstaclePrefabs[2].transform.position.x <= -0.57f){
                    Instantiate(bonePrefab, bonePos, Quaternion.identity);
                    collSpawned = true;
                }
            }
            if(spawn == obstaclePrefabs[1] && randomValue <= 2 || spawn == obstaclePrefabs[0] && randomValue <= 2){
                posVariation = Random.Range(0f, 0.5f);
                bonePos = new Vector3(2.29f, spawn.transform.position.y + posVariation);
                if(bonePos.y >= -3.49f){
                    bonePos.y = -3.49f;
                }
                if(collSpawned == false){
                    Instantiate(bonePrefab, bonePos, Quaternion.identity);
                    collSpawned = true;
                }
            }
            Instantiate(spawn, posSpawn, Quaternion.identity);
            instTime = Time.time + Random.Range(timer - timerVariation, timer);
        }
    }
}
