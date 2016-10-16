using UnityEngine;
using System.Collections;

public class SpeedChanger : MonoBehaviour {

    public BoxCollider boxcollider;


    void OnEnable() {

        boxcollider = GetComponent<Collider>() as BoxCollider;
    }

    void OnDrawGizmos() {

        Gizmos.DrawWireCube(gameObject.transform.position,boxcollider.size);
    }

    void OnTriggerEnter(Collider other) {

       Debug.Log(other.gameObject);
   }

 

}
