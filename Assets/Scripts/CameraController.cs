using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Camera[] stageCameras;
    private Camera current;

    void Awake() {

        current = stageCameras[0];
    }

    public void SwitchCameraTo(int stage) {
        if (current == null) {
            current = stageCameras[0];
        }
        if (current != stageCameras[stage]) {
            current.enabled = false;
            stageCameras[stage].enabled=true;
            current = stageCameras[stage];
        }


    }

}
