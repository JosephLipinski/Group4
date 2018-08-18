using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionMeter: MonoBehaviour {

    public Text meterText;
    public Color color;
    public bool hasBeenSeen = true;

    Image meter;
    float suspicionLevel;
    int currentLevel;

	// Use this for initialization
	void Start () {
        meter = GetComponent<Image>();
        meter.fillAmount = 0;
        currentLevel = LevelManager.instance.GetLevel();
	}
	
	// Update is called once per frame
	void Update () {
        if(hasBeenSeen){
            suspicionLevel += currentLevel * 0.1f * Time.deltaTime / 100;
            meter.fillAmount = suspicionLevel;
            if (suspicionLevel <= 1)
            {
                meterText.text = "Suspicion Level: " + Mathf.Floor(suspicionLevel * 100).ToString() + "%";
                //color = Color.Lerp(Color.white, Color.black, Mathf.Floor(suspicionLevel / 10));
            }
            else
            {
                meterText.text = "Suspicion Level: 100%";
                ScoreManager.instance.UpdateScore(-20f);
                hasBeenSeen = !hasBeenSeen;
            }
        }

    }

    public void Seen(){
        suspicionLevel += 0.1f;
    }
}
