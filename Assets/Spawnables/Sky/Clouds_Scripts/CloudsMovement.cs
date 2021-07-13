using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMovement : MonoBehaviour
{
    public float speed;
    Vector2 screenBounds;
    CloudSpawner cloudSpawner;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        cloudSpawner = FindObjectOfType<CloudSpawner>();
        speed = 2f;
    }
    void Update()
    {
        transform.position += speed * Vector3.left * Time.deltaTime;
        if(transform.position.x < screenBounds.x - 12f){
            Destroy(gameObject);
        }
    }
}
