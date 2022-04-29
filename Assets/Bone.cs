using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    Manager manager;
    void Start()
    {
        manager = FindObjectOfType<Manager>();
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            Destroy(this.gameObject);
            manager.bones += 1;
        }
    }
}
