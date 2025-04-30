using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Curve))]
public class CurveInspector : Editor
{
	private Curve m_Curve;
	private Transform m_tHandleTransform;
	private Quaternion m_qHandleRotation;

	[SerializeField] private const int m_iDebugDrawLineSteps = 15;
	
	private void OnSceneGUI()
	{
		m_Curve = target as Curve;
		m_tHandleTransform = m_Curve.transform;
		m_qHandleRotation = Tools.pivotRotation == PivotRotation.Local ? m_tHandleTransform.rotation : Quaternion.identity;

		Vector3 p0 = ShowPoint(0);
		Vector3 p1 = ShowPoint(1);
		Vector3 p2 = ShowPoint(2);
		
		Handles.color = Color.yellow;
		Handles.DrawLine(p0, p1);
		Handles.DrawLine(p1, p2);
		
		
		Vector3 lineStart = m_Curve.GetPoint(0f);
		
		Handles.color = Color.white;
		for (int i = 1; i <= m_iDebugDrawLineSteps; i++)
		{
			Vector3 lineEnd = m_Curve.GetPoint(i / (float)m_iDebugDrawLineSteps);
			Handles.DrawLine(lineStart, lineEnd);
			lineStart = lineEnd;
		}
	}


	Vector3 ShowPoint(int index)
	{
		Vector3 point = m_tHandleTransform.TransformPoint(m_Curve.points[index]);
		
		
		EditorGUI.BeginChangeCheck();
		point = Handles.DoPositionHandle(point, m_qHandleRotation);
		if (EditorGUI.EndChangeCheck())
		{
			Undo.RecordObject(m_Curve, "Move Point");
			EditorUtility.SetDirty(m_Curve);
			m_Curve.points[index] = m_tHandleTransform.InverseTransformPoint(point);
		}
		
		
		return point;
	}
	
}
