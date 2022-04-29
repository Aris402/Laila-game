using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMovement : MonoBehaviour
{
    public float speed;
    Vector2 screenBounds;
    groundMovement gm;
    CloudSpawner cloudSpawner;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        cloudSpawner = FindObjectOfType<CloudSpawner>();
        gm = FindObjectOfType<groundMovement>();
    }
    void Update()
    {
        speed = gm.speed - 9f;
        if(gm.speed == 0){
            speed = 0;
        }
        transform.position += speed * Vector3.left * Time.deltaTime;
        if(transform.position.x < screenBounds.x - 17f){
            Destroy(gameObject);
        }
    }
}
