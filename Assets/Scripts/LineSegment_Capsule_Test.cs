using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LineSegment_Capsule_Info))]
public class LineSegment_Capsule_Test : Editor
{
    public void OnSceneGUI()
    {
        var t = target as LineSegment_Capsule_Info;

        if (!t.IsIntersecting)
            Handles.color = Color.green;
        else
            Handles.color = Color.red;

        CapsuleDrawer.SetCapsule(t.capsule_Start.position, t.capsule_End.position, t.capsule_Radius);
        Debug.DrawLine(t.line_Start.position, t.line_End.position, Color.red);
    }
}
