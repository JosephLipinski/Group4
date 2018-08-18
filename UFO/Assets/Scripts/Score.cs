using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public bool ShouldBeDeleted = false;

	// Use this for initialization
	void Start () {
        ///DontDestroyOnLoad(gameObject);
	}
	
	private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "CropCircle"){
            ShouldBeDeleted = true;
        }
    }

    private void OnDestroy()
    {
        if(ShouldBeDeleted){
            ScoreManager.instance.UpdateScore(1);
        } else {
            ScoreManager.instance.UpdateScore(-1);
        }
    }
}
