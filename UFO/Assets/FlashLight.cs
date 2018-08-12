using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {

    public SuspicionMeter _SM;
	

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            //Debug.Log("Collided");
            _SM.Seen();
        }
    }
}
