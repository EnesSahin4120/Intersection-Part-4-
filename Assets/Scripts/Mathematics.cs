using UnityEngine;

public class Mathematics : MonoBehaviour
{
    static public float Square(float grade)
    {
        return grade * grade;
    }

    static public float Distance(Coordinates coord1, Coordinates coord2)
    {
        float diffSquared = Square(coord1.x - coord2.x) +
            Square(coord1.y - coord2.y) +
            Square(coord1.z - coord2.z);
        float squareRoot = Mathf.Sqrt(diffSquared);
        return squareRoot;
    }

    static public float VectorLength(Coordinates vector)
    {
        float length = Distance(new Coordinates(0, 0, 0), vector);
        return length;
    }

    static public Coordinates Normalize(Coordinates vector)
    {
        float length = VectorLength(vector);
        vector.x /= length;
        vector.y /= length;
        vector.z /= length;

        return vector;
    }

    static public float Dot(Coordinates vector1, Coordinates vector2)
    {
        return (vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z);
    }

    static public Coordinates Projection(Coordinates vector1, Coordinates vector2)
    {
        float numeratorPart = Dot(vector1, vector2);
        float vector2Length = VectorLength(vector2);
        float denominatorPart = Square(vector2Length);
        Coordinates resultCoordinate = new Coordinates(vector2.x * (numeratorPart / denominatorPart), vector2.y * (numeratorPart / denominatorPart), vector2.z * (numeratorPart / denominatorPart));

        return resultCoordinate;
    }

    static public Coordinates[] ClosestPointsBetweenLineSegments(Line line1,Line line2)
    {
        Coordinates[] resultCoordinates = new Coordinates[2];
        float s, t;

        Coordinates d1 = line1.B - line1.A;
        Coordinates d2 = line2.B - line2.A;
        Coordinates r = line1.A - line2.A;
        float a = Dot(d1, d1);
        float e = Dot(d2, d2);
        float f = Dot(d2, r);

        if (a <= 0 && e <= 0)
        {
            s = t = 0f;
            resultCoordinates[0] = line1.A;
            resultCoordinates[1] = line2.A;

            return resultCoordinates;
        }
        if (a <= 0)
        {
            s = 0f;
            t = f / e;
            t = Mathf.Clamp(t, 0f, 1f);
        }
        else
        {
            float c = Dot(d1, r);
            if (e <= 0)
            {
                t = 0f;
                s = Mathf.Clamp(-c / a, 0f, 1f);
            }
            else
            {
                float b = Dot(d1, d2);
                float denom = a * e - b * b;

                if (denom != 0f)
                    s = Mathf.Clamp((b * f - c * e) / denom, 0f, 1f);
                else
                    s = 0f;

                t = (b * s + f) / e;


                if (t < 0f)
                {
                    t = 0f;
                    s = Mathf.Clamp(-c / a, 0f, 1f);
                }
                else if (t > 1f)
                {
                    t = 1f;
                    s = Mathf.Clamp((b - c) / a, 0f, 1f);
                }
            }
        }
        resultCoordinates[0] = line1.A + new Coordinates(line1.v.x * s, line1.v.y * s, line1.v.z * s);
        resultCoordinates[1] = line2.A + new Coordinates(line2.v.x * t, line2.v.y * t, line2.v.z * t);

        return resultCoordinates;
    }

    static public float DistanceBetweenLineSegments(Line line1,Line line2)
    {
        Coordinates closestPoint1 = ClosestPointsBetweenLineSegments(line1, line2)[0];
        Coordinates closestPoint2 = ClosestPointsBetweenLineSegments(line1, line2)[1];

        return Dot(closestPoint1 - closestPoint2, closestPoint1 - closestPoint2);
    }

    static public bool IsIntersectCapsule_Capsule(Capsule capsule1,Capsule capsule2)
    {
        Line capsule1_Line = new Line(capsule1.lineStart, capsule1.lineEnd, Line.LINETYPE.SEGMENT);
        Line capsule2_Line = new Line(capsule2.lineStart, capsule2.lineEnd, Line.LINETYPE.SEGMENT);

        float radiusSum = capsule1.radius + capsule2.radius;

        return DistanceBetweenLineSegments(capsule1_Line, capsule2_Line) <= radiusSum * radiusSum;
    }

    static public bool IsIntersectCapsule_LineSegment(Capsule capsule, Line line)
    {
        Line capsuleLine = new Line(capsule.lineStart, capsule.lineEnd, Line.LINETYPE.SEGMENT);

        return DistanceBetweenLineSegments(capsuleLine, line) <= capsule.radius * capsule.radius; 
    }
}