using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    Laila laila;
    void Start()
    {
       laila = FindObjectOfType<Laila>();
    }
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collisor) {
        if(collisor.gameObject.layer == 3){
            laila.Jumping = false;
            laila.animator.SetBool("IsJumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collisor) {
        if(collisor.gameObject.layer == 3){
            laila.Jumping = true;
            laila.animator.SetBool("IsJumping", true);
        }
    }
}
