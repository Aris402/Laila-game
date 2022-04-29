using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    Laila laila;
    GameObject gameOverText;
    GameObject pressAny;
    GameObject highScore;
    GameObject bonesHiS;
    GameObject HSText;
    GameObject BHSText;
    void Start()
    {
        gameOverText = transform.GetChild(2).gameObject;
        pressAny = transform.GetChild(3).gameObject;
        highScore = transform.GetChild(4).gameObject;
        bonesHiS = transform.GetChild(5).gameObject;
        HSText = transform.GetChild(6).gameObject;
        BHSText = transform.GetChild(7).gameObject;
        laila = FindObjectOfType<Laila>();
    }

    void Update()
    {
        if(laila.gameover == true){
            gameOverText.SetActive(true);
            pressAny.SetActive(true);
            highScore.SetActive(true);
            bonesHiS.SetActive(true);
            HSText.SetActive(true);
            BHSText.SetActive(true);
        }
    }
}
