using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class UFO_Controller : MonoBehaviour {
    
    //[HideInInspector]
    public GameObject cutOutOne, cutOutTwo;
    public List<GameObject> stencils = new List<GameObject>(6);
    public int currentStencilIndex;
    public bool isFirstPlayer;
    public float moveSpeed = 5f;
    float xAxis, yAxis;

    //Rewired
    public int playerID;
    Player player;


	// Use this for initialization
	void Start () {
        stencils.Insert(0, cutOutOne);
        stencils.Insert(1, cutOutTwo);

        SetActive();
        if(isFirstPlayer){
            playerID = 0;
        } else {
            playerID = 1;
        }
        player = ReInput.players.GetPlayer(playerID);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movementVector = Vector3.zero;
        if (isFirstPlayer)
        {
            
            xAxis = player.GetAxis("Horizontal0");
            yAxis = player.GetAxis("Vertical0");

            if ((xAxis <= -.50f) || (Input.GetKey(KeyCode.A))){
                movementVector += Vector3.left;
            } else if ((xAxis >= 0.50f) || (Input.GetKey(KeyCode.D))){
                movementVector += Vector3.right;
            }

            if ((yAxis >= 0.50f) || (Input.GetKey(KeyCode.W))){
                movementVector += Vector3.forward;
            } else if (((yAxis <= -0.50f) || Input.GetKey(KeyCode.S))){
                movementVector += Vector3.back;
            }

            if ((Input.GetKeyDown(KeyCode.LeftShift)) || player.GetButtonDown("Swap0")){
                ChangeCutOut();
                SetActive();
            }

            if ((Input.GetKey(KeyCode.Q)) || (player.GetButton("RotateLeft0"))){
                RotateCutOutLeft();
            }

            if ((Input.GetKey(KeyCode.E)) || (player.GetButton("RotateRight0"))){
                RotateCutOutRight();
            }

            if ((Input.GetKey(KeyCode.Q)) || (player.GetButton("RotateLeft0"))){
                RotateCutOutLeft();
            }

            if(Input.GetKey(KeyCode.Z) || (player.GetButton("Shrink0"))){
                stencils[currentStencilIndex].transform.localScale += (new Vector3(1f, 1f, 0) * Time.deltaTime * -1);
            }

            if(Input.GetKey(KeyCode.X) || player.GetButton("Grow0")){
                stencils[currentStencilIndex].transform.localScale += (new Vector3(1f, 1f, 0) * Time.deltaTime);
            }

            if(Input.GetKeyDown(KeyCode.F) || player.GetButtonDown("Cut0")){
                CropCutter cutter = stencils[currentStencilIndex].GetComponent<CropCutter>();
                if(cutter != null){
                    cutter.DestroyCrops();
                } else {
                    cutter = stencils[currentStencilIndex].transform.GetChild(0).transform.GetComponent<CropCutter>();
                    cutter.DestroyCrops();
                }
            }

        } else {

            xAxis = player.GetAxis("Horizontal1");
            yAxis = player.GetAxis("Vertical1");

            if ((xAxis <= -.50f) || (Input.GetKey(KeyCode.J))){
                movementVector += Vector3.left;
            } else if ((xAxis >= 0.50f) || (Input.GetKey(KeyCode.L))){
                movementVector += Vector3.right;
            }

            if ((yAxis >= 0.50f) || (Input.GetKey(KeyCode.K))){
                movementVector += Vector3.forward;
            } else if (((yAxis <= -0.50f) || Input.GetKey(KeyCode.K))){
                movementVector += Vector3.back;
            }

            if((Input.GetKeyDown(KeyCode.RightShift)) || player.GetButtonDown("Swap1")){
                ChangeCutOut();
                SetActive();
            }

            if((Input.GetKey(KeyCode.U)) || (player.GetButton("RotateLeft1"))){
                RotateCutOutLeft();
            }

            if ((Input.GetKey(KeyCode.O)) || (player.GetButton("RotateRight1"))){
                RotateCutOutRight();
            }

            if (Input.GetKey(KeyCode.M) || (player.GetButton("Shrink1")))
            {
                stencils[currentStencilIndex].transform.localScale += (new Vector3(1f, 1f, 0) * Time.deltaTime * -1);
            }

            if (Input.GetKey(KeyCode.Comma) || player.GetButton("Grow1"))
            {
                stencils[currentStencilIndex].transform.localScale += (new Vector3(1f, 1f, 0) * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.H) || player.GetButtonDown("Cut1")){
                CropCutter cutter = stencils[currentStencilIndex].GetComponent<CropCutter>();
                if (cutter != null){
                    cutter.DestroyCrops();
                } else {
                    cutter = stencils[currentStencilIndex].transform.GetChild(0).transform.GetComponent<CropCutter>();
                    cutter.DestroyCrops();
                }
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
