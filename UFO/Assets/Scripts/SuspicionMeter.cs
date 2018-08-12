using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionMeter: MonoBehaviour {

    public Text meterText;
    public Color color;

    Image meter;
    float time;
    int currentLevel = 1;



	// Use this for initialization
	void Start () {
        meter = GetComponent<Image>();
        meter.fillAmount = 0;


	}
	
	// Update is called once per frame
	void Update () {
        time += currentLevel * 0.1f * Time.deltaTime / 100;
        meter.fillAmount = time;
        if(time <= 1){
            meterText.text = "Suspicion Level: " + Mathf.Floor(time * 100).ToString() + "%";
            color = Color.Lerp(Color.white, Color.black, Mathf.Floor(time / 10));
        } else {
            meterText.text = "Suspicion Level: 100%";
        }
       
	}
}
