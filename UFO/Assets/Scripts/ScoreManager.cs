using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    
    public static ScoreManager instance = null;
    public int score;
    //public Text scoreText;

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
        //scoreText = GameObject.Find("Canvas/suspicionBar/ScoreText").GetComponent<Text>();
        //scoreText.text = "Score: " + score.ToString();
        DontDestroyOnLoad(gameObject);
	}

    public void UpdateScore(int scoreToApply){
        score += scoreToApply;
        Debug.Log("HER");
        //scoreText = GameObject.Find("Canvas/suspicionBar/ScoreText").GetComponent<Text>();
       // scoreText.text = "Score: " + score.ToString();
    }

    public float GetScore(){
        return score;
    }
}
