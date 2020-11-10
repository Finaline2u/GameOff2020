using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (FieldOfView))]
public class FieldOfViewEditor : Editor {

    void OnSceneGUI() {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;

        Vector3 viewAngleA = fov.DirFromAngle((-fov.viewAngle + fov.rotationZ) / 2, false);
		Vector3 viewAngleB = fov.DirFromAngle((fov.viewAngle + fov.rotationZ) / 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewDistance);
		Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewDistance);
    }

}
