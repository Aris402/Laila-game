using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    Laila laila;
    public int score;
    public Text Score;
    Obstacles obstacles;
    obstaclesSpawner obsSp;
    groundMovement gm;
    CloudSpawner clouds;
    bool scored = false;
    float timer;
    bool firstPlay;
    void Start()
    {
        obstacles = FindObjectOfType<Obstacles>();
        obsSp = FindObjectOfType<obstaclesSpawner>();
        laila = FindObjectOfType<Laila>();
        gm = FindObjectOfType<groundMovement>();
        clouds = FindObjectOfType<CloudSpawner>();
        timer = 60;
    }
    void Update()
    {
        ScoreChange();
        if(laila.gameover == true){
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)){
                gm.speed = 8f;
                score = 0;
                SceneManager.LoadScene(0);
            }
        }
        if(!laila.gameover){
            timer -= 500 * Time.deltaTime;
            if(timer <= 0){
                score += 1;
                timer = 60;
            }
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
    public void ScoreChange(){
        if(score % 100 == 0 && score > 0 && scored == false){
            gm.speed += 0.5f;
            obsSp.timerVariation = Random.Range(obsSp.timerVariation, Random.Range(obsSp.timerVariation - 0.15f, obsSp.timerVariation - 0.20f));
            if(obsSp.timerVariation <= 0f){
                obsSp.timerVariation = 0.35f;
            }
            obsSp.instTime = Time.time + Random.Range(obsSp.timer - obsSp.timerVariation, 
                                obsSp.timer + obsSp.timerVariation);
            Debug.Log(gm.speed);
            scored = true;
        }
        else if(score % 100 != 0){
            scored = false;
        }
    }
}
