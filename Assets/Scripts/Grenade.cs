using UnityEngine;
using UnityEngine.UI;

public class Grenade : MonoBehaviour
{

    public BezierSpline spline;
    public float duration;
    public bool moving;
    public bool rotating;

    private Vector3 rotation;
    private float rotationTime;

    public GameObject characterContainer;
    public GameObject ObjectToRotate;

    private Camera _mainCamera;
    private Material _characterMaterial;
    private CharacterData _charData;
    private float _progress;
    

    public void Launch() {
        Reset();
        moving = true;
        rotating = true;
        ObjectToRotate.GetComponent<Renderer>().enabled = true;
        rotation = new Vector3(0,Random.Range(0.8f,1), Random.Range(0.8f, 1));
        rotationTime = Random.Range(0.8f, 1.2f);


    }



    public void ShowCharacter() {
        rotating = false;
        iTween.RotateBy(gameObject,Vector3.zero,0);
        ObjectToRotate.GetComponent<Renderer>().enabled = false;

        characterContainer.GetComponent<Collider>().enabled = true;
        characterContainer.GetComponent<Renderer>().enabled = true;
    }

    public void SetGrenade(BezierSpline spline, float speed, CharacterData charData) {
        characterContainer.GetComponent<Collider>().enabled = false;
        characterContainer.GetComponent<Renderer>().enabled = false;
        _characterMaterial = characterContainer.GetComponent<MeshRenderer>().material;
        _mainCamera = FindObjectOfType<Camera>();
        this.spline = spline;
        duration = speed;
        _charData = charData;
        _characterMaterial.mainTexture = charData.texture;


    }

    private void FixedUpdate() {
        if (moving) {
            _progress += Time.deltaTime/duration;
            if (_progress > 1f) {
                _progress = 1f;
                moving = false;
            }
            transform.localPosition = spline.GetPoint(_progress);
            FaceToCamera();
        }
        if (rotating) {
            iTween.RotateBy(gameObject, iTween.Hash("amount", rotation, "time", rotationTime, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        }




    }


    

    public void Reset() {
        gameObject.transform.localPosition = spline.GetPoint(0);
        _progress = 0f;
        moving = false;

        characterContainer.GetComponent<Collider>().enabled = false;
        characterContainer.GetComponent<Renderer>().enabled = false;
    }

    void FaceToCamera() {
        characterContainer.transform.LookAt(-_mainCamera.transform.position,Vector3.up);
    }

    public void OnClick() {
        if (GrenadeLauncher.Validate(_charData.c)) {
            Reset();
        }
    }


}
