using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Capsule_Capsule_Info))]
public class Capsule_Capsule_Test : Editor
{
    public void OnSceneGUI()
    {
        var t = target as Capsule_Capsule_Info;

        if (!t.IsIntersecting)
            Handles.color = Color.green;
        else
            Handles.color = Color.red;

        CapsuleDrawer.SetCapsule(t.capsule1_Start.position, t.capsule1_End.position, t.capsule1_Radius);
        CapsuleDrawer.SetCapsule(t.capsule2_Start.position, t.capsule2_End.position, t.capsule2_Radius);
    }
}
