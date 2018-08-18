using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropCircle : MonoBehaviour {

    public Material m_material;
    public Color color;
    float fadeAmount = 5f;
    float index = 1;

	// Use this for initialization
	void Start () {
        m_material = GetComponent<Renderer>().material;
        color = m_material.color;
        StartCoroutine(Fade());
	}
	
    IEnumerator Fade(){
        yield return new WaitForSecondsRealtime(3.0f);
        Destroy(gameObject);

    }

	// Update is called once per frame
	void Update () {
		
	}
}
