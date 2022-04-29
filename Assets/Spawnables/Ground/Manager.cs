using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    Laila laila;
    public int score;
    public int bones;
    public Text Bones;
    public Text Score;
    Obstacles obstacles;
    obstaclesSpawner obsSp;
    groundMovement gm;
    CloudSpawner clouds;
    bool scored = false;
    float timer;
    int highScore;
    public Text HighScore;
    public Text BonesHigh;
    int bonesHigh;
    bool firstPlay;
    void Start()
    {
        obstacles = FindObjectOfType<Obstacles>();
        obsSp = FindObjectOfType<obstaclesSpawner>();
        laila = FindObjectOfType<Laila>();
        gm = FindObjectOfType<groundMovement>();
        clouds = FindObjectOfType<CloudSpawner>();
        timer = 60;
        highScore = PlayerPrefs.GetInt("highscore");
        bonesHigh = PlayerPrefs.GetInt("boneshigh");
    }
    void Update()
    {
        ScoreChange();
        if(laila.gameover == true){
            if(highScore < score){
                highScore = score;
                PlayerPrefs.SetInt("highscore", highScore);
            }
            if(bonesHigh < bones){
                bonesHigh = bones;
                PlayerPrefs.SetInt("boneshigh", bonesHigh);
            }
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
        Bones.text = bones.ToString();
        HighScore.text = highScore.ToString();
        BonesHigh.text = bonesHigh.ToString();
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
            gm.speed += 1f;
            obsSp.timerVariation += 0.1f;
            if(obsSp.timerVariation >= 0.7f){
                obsSp.timerVariation = 0.4f;
            }
            scored = true;
        }
        else if(score % 100 != 0){
            scored = false;
        }
    }
}
