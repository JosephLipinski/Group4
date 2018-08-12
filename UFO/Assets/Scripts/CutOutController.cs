using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutOutController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CallDestroyCrops(){
        foreach(Transform child in transform){
            child.gameObject.GetComponent<CropCutter>().DestroyCrops();
        }
    }
}
