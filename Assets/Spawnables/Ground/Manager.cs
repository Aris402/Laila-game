using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    Laila laila;
    public float score;
    public Text Score;
    Obstacles obstacles;
    groundMovement gm;
    CloudSpawner clouds;
    public float timer;
    void Start()
    {
        obstacles = FindObjectOfType<Obstacles>();
        laila = FindObjectOfType<Laila>();
        gm = FindObjectOfType<groundMovement>();
        clouds = FindObjectOfType<CloudSpawner>();
        timer = 60;
        Screen.fullScreen = true;
    }
    void Update()
    {
        if(laila.gameover == true){
            if(Input.GetKeyDown(KeyCode.Return)){
                SceneManager.LoadScene(0);
            }
        }
        timer--;
        if(timer == 0 && !laila.gameover){
            score += 1;
            timer = 60;
        }
        Score.text = score.ToString();
        Fullsceen();
    }
    public void Fullsceen(){
        if(Input.GetKeyDown(KeyCode.F11) && Screen.fullScreen == false){
            Screen.fullScreen = true;
        } else if(Input.GetKeyDown(KeyCode.F11) && Screen.fullScreen == true){
            Screen.fullScreen = false;
        }
    }
}
