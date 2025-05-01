using UnityEngine;

public class Curve : MonoBehaviour
{
	public Vector3[] points;

	public void Reset()
	{
		points = new Vector3[]
		{
			new Vector3(1f, 0f, 0f),
			new Vector3(2f, 0f, 0f),
			new Vector3(3f, 0f, 0f),
			new Vector3(4f, 0f, 0f),
		};
	}
	
	// Supports curves of length 3 and 4
	public Vector3 GetPoint(float t)
	{
		if (points.Length == 3)
		{
			return transform.TransformPoint(MathHelp.GetCurvePoint(points[0], points[1], points[2], t));
		}
		else if (points.Length == 4)
		{
			return transform.TransformPoint(MathHelp.GetCurvePoint(points[0], points[1], points[2], points[3], t));
		}
		else
		{
			Debug.LogError("Invalid number of points!");
			return Vector3.zero;
		}
	}
}
