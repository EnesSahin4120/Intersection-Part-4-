using UnityEngine;
using UnityEditor;

public class CapsuleDrawer : MonoBehaviour
{
    public static void SetCapsule(Vector3 p1, Vector3 p2, float radius)
    {
        Quaternion p1Rotation = Quaternion.LookRotation(p1 - p2);
        Quaternion p2Rotation = Quaternion.LookRotation(p2 - p1);

        float c = Vector3.Dot((p1 - p2).normalized, Vector3.up);
        if (c == 1f || c == -1f)
            p2Rotation = Quaternion.Euler(p2Rotation.eulerAngles.x, p2Rotation.eulerAngles.y + 180f, p2Rotation.eulerAngles.z);

        Handles.DrawWireArc(p1, p1Rotation * Vector3.left, p1Rotation * Vector3.down, 180f, radius);
        Handles.DrawWireArc(p1, p1Rotation * Vector3.up, p1Rotation * Vector3.left, 180f, radius);
        Handles.DrawWireDisc(p1, (p2 - p1).normalized, radius);

        Handles.DrawWireArc(p2, p2Rotation * Vector3.left, p2Rotation * Vector3.down, 180f, radius);
        Handles.DrawWireArc(p2, p2Rotation * Vector3.up, p2Rotation * Vector3.left, 180f, radius);
        Handles.DrawWireDisc(p2, (p1 - p2).normalized, radius);

        Handles.DrawLine(p1 + p1Rotation * Vector3.down * radius, p2 + p2Rotation * Vector3.down * radius);
        Handles.DrawLine(p1 + p1Rotation * Vector3.left * radius, p2 + p2Rotation * Vector3.right * radius);
        Handles.DrawLine(p1 + p1Rotation * Vector3.up * radius, p2 + p2Rotation * Vector3.up * radius);
        Handles.DrawLine(p1 + p1Rotation * Vector3.right * radius, p2 + p2Rotation * Vector3.left * radius);
    }
}
