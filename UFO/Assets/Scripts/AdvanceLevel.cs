using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceLevel : MonoBehaviour {

	int collidingPlayers = 0;

    private void Update(){
        if(collidingPlayers == 2){
            LevelManager.instance.NextLevel();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            collidingPlayers++;
        }

    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            if(other.gameObject.tag == "Player"){
                collidingPlayers--;
            }
        }
     }

}
