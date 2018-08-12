using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_Controller : MonoBehaviour {

    public GameObject cutOutRectangle, cutOutPlus;
    public GameObject activeCutOut;
    public bool isFirstPlayer;

	// Use this for initialization
	void Start () {
        cutOutRectangle.SetActive(true);
        cutOutPlus.SetActive(false);
        activeCutOut = cutOutRectangle;
	}
	
	// Update is called once per frame
	void Update () {
        if (isFirstPlayer)
        {
            if (Input.GetKeyDown(KeyCode.W)){
                transform.Translate(Vector3.forward);
            }
            if (Input.GetKeyDown(KeyCode.A)){
                transform.Translate(Vector3.left);
            }
            if (Input.GetKeyDown(KeyCode.S)){
                transform.Translate(Vector3.back);
            }
            if (Input.GetKeyDown(KeyCode.D)){
                transform.Translate(Vector3.right);
            }
            if(Input.GetKeyDown(KeyCode.LeftShift)){
                ChangeCutOut();
            }
            if (Input.GetKeyDown(KeyCode.Q)){
                RotateCutOut();
            }
            if(Input.GetKeyDown(KeyCode.F)){
                activeCutOut.GetComponent<CutOutController>().CallDestroyCrops();
            }
        } else {
            if (Input.GetKeyDown(KeyCode.I)){
                transform.Translate(Vector3.forward);
            }
            if (Input.GetKeyDown(KeyCode.J)){
                transform.Translate(Vector3.left);
            }
            if (Input.GetKeyDown(KeyCode.K)){
                transform.Translate(Vector3.back);
            }
            if (Input.GetKeyDown(KeyCode.L)){
                transform.Translate(Vector3.right);
            }
            if(Input.GetKeyDown(KeyCode.RightShift)){
                ChangeCutOut();
            }
            if(Input.GetKeyDown(KeyCode.U)){
                RotateCutOut();
            }
            if(Input.GetKeyDown(KeyCode.H)){
                activeCutOut.GetComponent<CutOutController>().CallDestroyCrops();
            }
        }
	}

    void ChangeCutOut(){
        activeCutOut.SetActive(false);
        if(activeCutOut == cutOutRectangle){
            activeCutOut = cutOutPlus;
        } else {
            activeCutOut = cutOutRectangle;
        }
        activeCutOut.SetActive(true);
    }

    void RotateCutOut(){
        activeCutOut.transform.Rotate(new Vector3(0, 90, 0));
    }
}
