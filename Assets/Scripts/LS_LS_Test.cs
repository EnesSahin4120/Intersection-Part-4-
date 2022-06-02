using UnityEngine;

public class LS_LS_Test : MonoBehaviour
{
    [SerializeField] private Transform line1_Start;
    [SerializeField] private Transform line1_End;
    [SerializeField] private Transform line2_Start;
    [SerializeField] private Transform line2_End;

    public float distance;

    private void Update()
    {
        Coordinates line1_StartCoord = new Coordinates(line1_Start.position.x, line1_Start.position.y, line1_Start.position.z);
        Coordinates line1_EndCoord = new Coordinates(line1_End.position.x, line1_End.position.y, line1_End.position.z);
        Coordinates line2_StartCoord = new Coordinates(line2_Start.position.x, line2_Start.position.y, line2_Start.position.z);
        Coordinates line2_EndCoord = new Coordinates(line2_End.position.x, line2_End.position.y, line2_End.position.z);

        Line line1 = new Line(line1_StartCoord, line1_EndCoord, Line.LINETYPE.SEGMENT);
        Line line2 = new Line(line2_StartCoord, line2_EndCoord, Line.LINETYPE.SEGMENT);

        Debug.DrawLine(line1_StartCoord.ToVector(), line1_EndCoord.ToVector(), Color.red);
        Debug.DrawLine(line2_StartCoord.ToVector(), line2_EndCoord.ToVector(), Color.red);

        Coordinates closestPoint1 = Mathematics.ClosestPointsBetweenLineSegments(line1, line2)[0];
        Coordinates closestPoint2 = Mathematics.ClosestPointsBetweenLineSegments(line1, line2)[1];

        Debug.DrawLine(closestPoint1.ToVector(), closestPoint2.ToVector(), Color.green);

        distance = Mathematics.DistanceBetweenLineSegments(line1, line2);
    }
}
