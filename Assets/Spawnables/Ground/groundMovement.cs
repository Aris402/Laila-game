using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundMovement : MonoBehaviour
{
    public SpriteRenderer[] grounds;
    public Sprite[] rand;
    Manager manager;
    public float speed;
    Vector2 finalPosition = new Vector2(-13.15f, -5.47f);
    Vector2 startPosition = new Vector2(2.486f, -5.47f);
    void Start()
    {
        manager = FindObjectOfType<Manager>();
        speed = 4f;
    }
    void Update()
    {
        for(int i = 0; i < grounds.Length; i++){
            grounds[i].transform.position += Vector3.left * speed * Time.deltaTime;
            if(grounds[i].transform.position.x < finalPosition.x){
                grounds[i].transform.position += (Vector3.right * 15f);
                grounds[i].sprite = rand[Random.Range(0, rand.Length)];
            }
        }
        if(manager.score % 100 == 0){
            speed += 0.006f;
        }
    }
}
