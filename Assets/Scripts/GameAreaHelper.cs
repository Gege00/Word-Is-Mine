using UnityEngine;


public class GameAreaHelper : MonoBehaviour {

    void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(gameObject.transform.position, gameObject.transform.localScale*10);
    }
}
