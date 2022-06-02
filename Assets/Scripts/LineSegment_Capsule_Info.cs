using UnityEngine;

public class LineSegment_Capsule_Info : MonoBehaviour
{
    public Transform capsule_Start;
    public Transform capsule_End;
    public float capsule_Radius;

    public Transform line_Start;
    public Transform line_End;

    private bool _isIntersecting;
    public bool IsIntersecting
    {
        get
        {
            return _isIntersecting;
        }
        set
        {
            _isIntersecting = value;
        }
    }

    private void Update()
    {
        Coordinates capsule_StartCoord = new Coordinates(capsule_Start.position.x, capsule_Start.position.y, capsule_Start.position.z);
        Coordinates capsule_EndCoord = new Coordinates(capsule_End.position.x, capsule_End.position.y, capsule_End.position.z);
        Coordinates line_StartCoord = new Coordinates(line_Start.position.x, line_Start.position.y, line_Start.position.z);
        Coordinates line_EndCoord = new Coordinates(line_End.position.x, line_End.position.y, line_End.position.z);

        Capsule capsule = new Capsule(capsule_Radius, capsule_StartCoord, capsule_EndCoord);
        Line line = new Line(line_StartCoord, line_EndCoord, Line.LINETYPE.SEGMENT);

        _isIntersecting = Mathematics.IsIntersectCapsule_LineSegment(capsule, line);
    }
}
