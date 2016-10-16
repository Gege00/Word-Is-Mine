using UnityEngine;
using System.Collections;

namespace test {



    public class BezierCurve : MonoBehaviour {

        public Vector3[] controlPoints;

        public void Reset() {
            controlPoints = new Vector3[] {
                new Vector3(1, 0, 0),
                new Vector3(2, 0, 0),
                new Vector3(3, 0, 0)
            };


        }

        public Vector3[] GetPoints(Transform transform, int resolution) {
            Vector3[] points = new Vector3[resolution];
            points[0] = GetPoint(transform, 0);
            for (int i = 1; i < resolution; i++) {
                points[i] = GetPoint(transform, i/(float) resolution);
            }

            return points;

        }

        public Vector3[] GetPoints(int resolution) {
            Vector3[] points = new Vector3[resolution];
            points[0] = GetPoint(0);
            for (int i = 1; i < resolution; i++) {
                points[i] = GetPoint(i/(float) resolution);
            }

            return points;
        }

        public Vector3 GetPoint(Transform transform, float t) {
            return transform.TransformPoint(GetBezierPoint(controlPoints[0], controlPoints[1], controlPoints[2], t));
        }

        public Vector3 GetPoint(float t) {
            return GetBezierPoint(controlPoints[0], controlPoints[1], controlPoints[2], t);
        }

        static Vector3 GetBezierPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t) {
            t = Mathf.Clamp01(t);
            float oneMinusT = 1f - t;
            return
                oneMinusT*oneMinusT*p0 +
                2f*oneMinusT*t*p1 +
                t*t*p2;
        }
    }
}
