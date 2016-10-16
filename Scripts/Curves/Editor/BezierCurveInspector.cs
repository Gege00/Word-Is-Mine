using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using UnityEditor;

[CustomEditor(typeof(BezierCurve))]
public class BezierCurveInspector : Editor {
    private BezierCurve curve;
    private Transform handleTransform;
    private Quaternion handleRotation;

    public int lineSteps = 40;


    public override void OnInspectorGUI() {

     DrawDefaultInspector();
     lineSteps=EditorGUILayout.IntField(lineSteps);

    }

    void OnDrawGizmos() {
        Vector3 p0 = ShowPoint(0);
        Vector3 p1 = ShowPoint(1);
        Vector3 p2 = ShowPoint(2);

        Gizmos.DrawLine(p0,p1);
        Gizmos.DrawLine(p1,p2);

        Vector3 lineStart = curve.GetPoint(handleTransform, 0);
        for (int i = 1; i <= lineSteps; i++)
        {
            Vector3 lineEnd = curve.GetPoint(handleTransform, i / (float)lineSteps);
            Gizmos.DrawLine(lineStart, lineEnd);
            lineStart = lineEnd;
        }
    }


    private void OnSceneGUI()
    {
        curve = target as BezierCurve;
        handleTransform = curve.transform;
        handleRotation = Tools.pivotRotation == PivotRotation.Local ?
            handleTransform.rotation : Quaternion.identity;

        Vector3 p0 = ShowPoint(0);
        Vector3 p1 = ShowPoint(1);
        Vector3 p2 = ShowPoint(2);

        Handles.color = Color.gray;
        Handles.DrawLine(p0, p1);
        Handles.DrawLine(p1, p2);

        Handles.color = Color.white;
        Handles.color = Color.white;
        Vector3 lineStart = curve.GetPoint(handleTransform, 0);
        for (int i = 1; i <= lineSteps; i++){
            Vector3 lineEnd =curve.GetPoint(handleTransform,i / (float)lineSteps);
            Handles.DrawLine(lineStart, lineEnd);
            lineStart = lineEnd;
        }
    }

    private Vector3 ShowPoint(int index)
    {
        Vector3 point = handleTransform.TransformPoint(curve.controlPoints[index]);
        EditorGUI.BeginChangeCheck();
        point = Handles.DoPositionHandle(point, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(curve, "Move Point");
            EditorUtility.SetDirty(curve);
            curve.controlPoints[index] = handleTransform.InverseTransformPoint(point);
        }
        return point;
    }
  
}








