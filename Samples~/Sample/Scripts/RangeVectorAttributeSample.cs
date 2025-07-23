using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeVectorAttributeSample : MonoBehaviour
{
	[RangeVector(0f, 1f)]
	public Vector2 vector2;

	[RangeVector(0f, 1f)]
	public Vector3 vector3;

	[RangeVector(0f, 1f)]
	public Vector4 vector4;

	[RangeVector(0, 1)]
	public Vector2Int vector2Int;

	[RangeVector(0, 10)]
	public Vector3Int vector3Int;
}
