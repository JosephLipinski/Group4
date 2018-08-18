using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour {

    public GameObject panelOne;
    GameObject activePanel;

	// Use this for initialization
	void Start () {
        panelOne.SetActive(true);
	}

    public void ViewControlls(){
        SceneManager.LoadScene("ControlsScreen");
    }
    public void Back(){
        SceneManager.LoadScene("StartScreen");
    }

    public void StartGame(){
        SceneManager.LoadScene("Level_One");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
