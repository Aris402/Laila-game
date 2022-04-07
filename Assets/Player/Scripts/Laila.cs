using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laila : MonoBehaviour
{
    groundMovement gm;
    Obstacles obs;
    obstaclesSpawner spawner;
    CloudSpawner clouds;
    CloudsMovement cloudsmove;
    float jumpSpeed;
    float timeToPeak = 0.33f;
    float maxHeight = 2.3f;
    public bool Jumping;
    public bool gameover = false;
    Rigidbody2D corpo;
    public Animator animator;

    void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
        Physics2D.gravity = ((-2 * maxHeight) / Mathf.Pow(timeToPeak, 2)) * Vector2.up;
        jumpSpeed = Physics2D.gravity.y * timeToPeak;
        animator = GetComponent<Animator>();
        gm = FindObjectOfType<groundMovement>();
        spawner = FindObjectOfType<obstaclesSpawner>();
        clouds = FindObjectOfType<CloudSpawner>();
    }
    void Update()
    {
       if(Input.GetButtonDown("Jump") && !Jumping){
           corpo.AddForce(-jumpSpeed * Vector2.up, ForceMode2D.Impulse);
       }
    }
    private void OnCollisionEnter2D(Collision2D collisor) {
        if(collisor.gameObject.layer == 6){
            gameover = true;
            gm.speed = 0;
            Obstacles[] obs = FindObjectsOfType<Obstacles>();
            CloudsMovement[] clds = FindObjectsOfType<CloudsMovement>();
            foreach(Obstacles o in obs){
                o.speed = 0;
            }
            foreach(CloudsMovement c in clds){
                c.speed = 0;
            }
            spawner.stopped = true;
            clouds.stopped = true;
        }
    }
}
