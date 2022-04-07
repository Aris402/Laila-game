using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed;
    Laila laila;
    groundMovement gm;
    void Start()
    {
        gm = FindObjectOfType<groundMovement>();
        laila = FindObjectOfType<Laila>();
    }
    void Update()
    {
        speed = gm.speed;
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x <= -13.55f){
            Destroy(gameObject);
        }
    }
}
