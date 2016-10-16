using System;
using UnityEngine;
using System.Collections;
using test;


public class MovingObject : MonoBehaviour {

    public BezierCurve curve;

   public Vector3[] path;
    [Range(0.001f,1)]
    public float speed;
    [Range(1,20)]
    public int limit=1;

    public int resolution;

    public bool loop;

    void GetPath() {
        //path = curve.GetPoints(resolution);
    }

    public void Move() {

        transform.position = curve.gameObject.transform.position;
        GetPath();
       
        StartCoroutine(Moving());
    }

    IEnumerator Moving() {
        float step;
        float t;
        int length = path.GetLength(0);

        step = speed/(path[0] - path[1]).magnitude;
        System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
        
        timer.Start();
        for (int i = 0; i < length-1; i+=limit) {
            if (i == 0) {
                transform.position = path[0];
            }
            t = 0;
            while (t<=1.0f) {
                t += step;
                transform.position =Vector3.Lerp(path[i], path[i+1],t);
                yield return new WaitForSeconds(t);
            }
           
            transform.position = path[i];
           


        }
        timer.Stop();
        Debug.Log(timer.ElapsedMilliseconds + " ms");


    }
}




