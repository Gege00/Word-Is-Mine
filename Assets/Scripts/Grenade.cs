using UnityEngine;
using UnityEngine.UI;

public class Grenade : MonoBehaviour
{

    public BezierSpline spline;
    public float duration;
    public bool moving;

    public GameObject characterContainer;

    private Camera _mainCamera;
    private Material _characterMaterial;
    private CharacterData _charData;
    private float _progress;
    

    public void Launch() {
        Reset();
        moving = true;
    }



    public void ShowCharacter() {
        characterContainer.GetComponent<MeshCollider>().enabled = true;
        characterContainer.GetComponent<Renderer>().enabled = true;
    }

    public void SetGrenade(BezierSpline spline, float speed, CharacterData charData) {
        characterContainer.GetComponent<MeshCollider>().enabled = false;
        characterContainer.GetComponent<Renderer>().enabled = false;
        _characterMaterial = characterContainer.GetComponent<MeshRenderer>().material;
        _mainCamera = FindObjectOfType<Camera>();
        this.spline = spline;
        duration = speed;
        _charData = charData;
        _characterMaterial.mainTexture = charData.texture;


    }

    private void Update() {
        if (moving) {
            _progress += Time.deltaTime/duration;
            if (_progress > 1f) {
                _progress = 1f;
                moving = false;
            }
            transform.localPosition = spline.GetPoint(_progress);
            FaceToCamera();
        }
    }


    

    public void Reset() {
        gameObject.transform.localPosition = spline.GetPoint(0);
        _progress = 0f;
        moving = false;
        characterContainer.GetComponent<MeshCollider>().enabled = false;
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
