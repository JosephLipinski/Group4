using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_Controller : MonoBehaviour {

    [HideInInspector]
    public GameObject cutOutSquare, cutOutCircle, cutOutLine;
    public List<GameObject> stencils = new List<GameObject>(6);
    public int currentStencilIndex;
    public bool isFirstPlayer;
    public float moveSpeed = 5f;

	// Use this for initialization
	void Start () {
        stencils.Insert(0, cutOutSquare);
        stencils.Insert(1, cutOutCircle);
        stencils.Insert(2, cutOutLine);
        SetActive();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movementVector = Vector3.zero;
        if (isFirstPlayer)
        {
            if (Input.GetKey(KeyCode.W)){
                movementVector += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.A)){
                movementVector += Vector3.left;
            }
            if (Input.GetKey(KeyCode.S)){
                movementVector += Vector3.back;
            }
            if (Input.GetKey(KeyCode.D)){
                movementVector += Vector3.right;
            }
            if(Input.GetKeyDown(KeyCode.LeftShift)){
                ChangeCutOut();
                SetActive();
            }
            if (Input.GetKey(KeyCode.Q)){
                RotateCutOutLeft();
            }
            if(Input.GetKey(KeyCode.E)){
                RotateCutOutRight();
            }
            if(Input.GetKeyDown(KeyCode.F)){
                stencils[currentStencilIndex].GetComponent<CropCutter>().DestroyCrops();
            }
        } else {
            if (Input.GetKey(KeyCode.I))
            {
                movementVector += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.J))
            {
                movementVector += Vector3.left;
            }
            if (Input.GetKey(KeyCode.K))
            {
                movementVector += Vector3.back;
            }
            if (Input.GetKey(KeyCode.L))
            {
                movementVector += Vector3.right;
            }
            if(Input.GetKeyDown(KeyCode.RightShift)){
                ChangeCutOut();
                SetActive();
            }
            if(Input.GetKey(KeyCode.U)){
                RotateCutOutLeft();
            }
            if (Input.GetKey(KeyCode.O))
            {
                RotateCutOutRight();
            }
            if(Input.GetKeyDown(KeyCode.H)){
                stencils[currentStencilIndex].GetComponent<CropCutter>().DestroyCrops();
            }
        }
        transform.Translate(movementVector * moveSpeed * Time.deltaTime);
	}

    void ChangeCutOut(){
        if (currentStencilIndex < stencils.Count - 1){
            currentStencilIndex++;
        } else {
            currentStencilIndex = 0;
        }
    }

    void SetActive(){
        for (int i = 0; i < stencils.Count; i++){
            if (i == currentStencilIndex){
                stencils[i].SetActive(true);
            } else {
                stencils[i].SetActive(false);
            }
        }
            
            
        
    }
    void RotateCutOutLeft(){
        stencils[currentStencilIndex].transform.Rotate(new Vector3(0, 0, -90 * Time.deltaTime));
    }
    void RotateCutOutRight(){
        stencils[currentStencilIndex].transform.Rotate(new Vector3(0, 0, 90 * Time.deltaTime));
    }
}
