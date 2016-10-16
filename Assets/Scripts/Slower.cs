using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class Slower : MonoBehaviour {

    private Grenade grenade;
    [Range(2,7)]
    public float slowingValue = 3.2f;


    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "grenade") {

          grenade=collider.gameObject.GetComponent<Grenade>();
          grenade.duration += slowingValue;
          grenade.ShowCharacter();
            
        }
    }

    void OnDrawGizmos() {

        Gizmos.DrawWireCube(GetComponent<Collider>().bounds.center, GetComponent<Collider>().bounds.size);
    }
}
