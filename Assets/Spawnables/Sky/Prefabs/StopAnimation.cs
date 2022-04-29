using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : MonoBehaviour
{
    Laila laila;
    Animator animator;
    void Start()
    {
        laila = FindObjectOfType<Laila>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(laila.gameover == true){
            animator.speed = 0;
        }
    }
}
