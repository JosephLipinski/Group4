using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance = null;
    public int level;

    private void Awake(){
        if (instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
        level = 1;
    }

    public int GetLevel(){
        return level;
    }

    public void NextLevel(){
        switch(level){
            case 1:
                SceneManager.LoadScene("Level_Two");
                ScoreManager.instance.UpdateScore(1464);
                break;
            case 2:
                ScoreManager.instance.UpdateScore(1464);
                SceneManager.LoadScene("Level_Three");
                break;
            case 3:
                ScoreManager.instance.UpdateScore(1464);
                SceneManager.LoadScene("Results");
                break;
        }
        level++;

    }
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
