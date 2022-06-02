using UnityEngine;

public class Capsule_Capsule_Info : MonoBehaviour
{
    public Transform capsule1_Start;
    public Transform capsule1_End;
    public float capsule1_Radius;

    public Transform capsule2_Start;
    public Transform capsule2_End; 
    public float capsule2_Radius;

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
        Coordinates capsule1_StartCoord = new Coordinates(capsule1_Start.position.x, capsule1_Start.position.y, capsule1_Start.position.z);
        Coordinates capsule1_EndCoord = new Coordinates(capsule1_End.position.x, capsule1_End.position.y, capsule1_End.position.z);
        Coordinates capsule2_StartCoord = new Coordinates(capsule2_Start.position.x, capsule2_Start.position.y, capsule2_Start.position.z);
        Coordinates capsule2_EndCoord = new Coordinates(capsule2_End.position.x, capsule2_End.position.y, capsule2_End.position.z);

        Capsule capsule1 = new Capsule(capsule1_Radius, capsule1_StartCoord, capsule1_EndCoord);
        Capsule capsule2 = new Capsule(capsule2_Radius, capsule2_StartCoord, capsule2_EndCoord);

        _isIntersecting = Mathematics.IsIntersectCapsule_Capsule(capsule1, capsule2);
    }
}
