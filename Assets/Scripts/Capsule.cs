using UnityEngine;

public class Capsule : MonoBehaviour
{
    public float radius;
    public Coordinates lineStart;
    public Coordinates lineEnd;

    public Capsule(float _radius, Coordinates _lineStart, Coordinates _lineEnd)
    {
        radius = _radius;
        lineStart = _lineStart;
        lineEnd = _lineEnd;
    }
}
