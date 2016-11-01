using UnityEngine;
using System.Collections;

public class RotateSample : MonoBehaviour {
    public Vector3 rotation= Vector3.forward;
    public float animationTime =1;

	void Update(){
        //iTween.RotateBy(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .4));
        iTween.RotateBy(gameObject, iTween.Hash("amount", rotation, "time", animationTime, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
    }
}

