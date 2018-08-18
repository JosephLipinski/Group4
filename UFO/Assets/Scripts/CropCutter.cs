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

    private void OnCollisionEnter(Collision collision){
        Debug.Log("Colliding");
        if(collision.gameObject.tag == "Crop"){
            CollidingWith.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision){
        if(collision.gameObject.tag == "Crop"){
            CollidingWith.Remove(collision.gameObject);
        }
    }

    public void DestroyCrops(){
        foreach (GameObject crop in CollidingWith){
            crop.GetComponent<Score>().KillCrop();
            Destroy(crop);
        }
        CollidingWith.Clear();
    }


}
