using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance = null;
    [HideInInspector]
    public float score;
    public Text scoreText;

    private void Awake()
    {
        if (instance == null){
            instance = this;
        } else if(instance != this){
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
	}

    public void UpdateScore(float scoreToApply){
        score += scoreToApply;
        scoreText.text = "Score: " + score.ToString();
    }
}
