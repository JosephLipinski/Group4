using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropCutter : MonoBehaviour {

    public List<GameObject> CollidingWith = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Crop")
            CollidingWith.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Crop")
            CollidingWith.Remove(other.gameObject);
    }

    public void DestroyCrops(){
        foreach (GameObject crop in CollidingWith){
            Destroy(crop);
        }
        CollidingWith.Clear();
    }


}
