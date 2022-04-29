using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Laila : MonoBehaviour
{
    groundMovement gm;
    Obstacles obs;
    obstaclesSpawner spawner;
    CloudSpawner clouds;
    float jumpSpeed;
    float timeToPeak = 0.29f;
    float maxHeight = 2.3f;
    public bool Jumping;
    public bool gameover = false;
    Rigidbody2D corpo;
    public Animator animator;
    AudioSource[] audioSource;
    AudioSource jump;
    AudioSource gameOverSound;
    AudioSource collect;
    void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
        Physics2D.gravity = ((-2 * maxHeight) / Mathf.Pow(timeToPeak, 2)) * Vector2.up;
        jumpSpeed = Physics2D.gravity.y * timeToPeak;
        animator = GetComponent<Animator>();
        audioSource = GetComponents<AudioSource>();
        jump = audioSource[0];
        gameOverSound = audioSource[1];
        collect = audioSource[2];
        gm = FindObjectOfType<groundMovement>();
        spawner = FindObjectOfType<obstaclesSpawner>();
        clouds = FindObjectOfType<CloudSpawner>();
    }
    void Update()
    {
       if(Input.GetButtonDown("Jump") && !Jumping){
           corpo.AddForce(-jumpSpeed * Vector2.up, ForceMode2D.Impulse);
           jump.Play();
       }
    }
    private void OnCollisionEnter2D(Collision2D collisor) {
        if(collisor.gameObject.layer == 6){
            gameover = true;
            gameOverSound.Play();
            gm.speed = 0;
            Obstacles[] obs = FindObjectsOfType<Obstacles>();
            CloudsMovement[] clds = FindObjectsOfType<CloudsMovement>();
            spawner.stopped = true;
            clouds.stopped = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Collectable"){
            collect.Play();
        }
    }
}
