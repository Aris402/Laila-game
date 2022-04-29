using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundMovement : MonoBehaviour
{
    Vector3 finalPosition = new Vector2(-16.33f, -6.384f);
    public SpriteRenderer[] grounds;
    public Sprite[] randSprites;
    Manager manager;
    public float speed;
    List<SpriteRenderer> stack = new List<SpriteRenderer>();
    void Start()
    {
        manager = FindObjectOfType<Manager>();
        speed = 10f;
        foreach(var item in grounds)
        {
            stack.Add(item);
        }
    }
    void Update()
    {
        for(int i = 0; i <= grounds.Length-1; i++){
            grounds[i].transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            if(grounds[i].transform.position.x < finalPosition.x)
            {
                if(stack.Contains(grounds[i]))
                {
                    stack.Remove(grounds[i]);
                    grounds[i].transform.position = new Vector3(stack[stack.Count-1].bounds.max.x - 0.2f, -6.384f);
                    stack.Add(grounds[i]);
                }
                grounds[i].sprite = randSprites[Random.Range(0, randSprites.Length)];
            }
        }
    }
}
