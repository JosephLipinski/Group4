using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + ScoreManager.instance.GetScore().ToString();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + ScoreManager.instance.GetScore().ToString();
	}
}
