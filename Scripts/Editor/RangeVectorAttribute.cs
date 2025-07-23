using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class RangeVectorAttribute : PropertyAttribute
{
	public readonly float Min;
	public readonly float Max;

	public RangeVectorAttribute(float min, float max)
	{
		Min = min;
		Max = max;
	}
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(RangeVectorAttribute))]
public class RangeVectorAttributeDrawer : PropertyDrawer
{
	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		int fieldCount = GetFieldCount(property);
		// 折りたたみ時はラベル1行分だけ
		if (!property.isExpanded || fieldCount == 0)
			return EditorGUIUtility.singleLineHeight + 2;

		// 展開時はラベル＋各成分分の高さ
		return EditorGUIUtility.singleLineHeight * (fieldCount + 1) + 4;
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		RangeVectorAttribute range = attribute as RangeVectorAttribute;

		EditorGUI.BeginProperty(position, label, property);

		// Foldoutラベル
		Rect foldoutRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
		property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, label);

		int fieldCount = GetFieldCount(property);
		if (fieldCount == 0)
		{
			if (property.isExpanded)
			{
				Rect errorRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight);
				EditorGUI.LabelField(errorRect, "Unsupported type");
			}
			EditorGUI.EndProperty();
			return;
		}

		if (property.isExpanded)
		{
			float sliderHeight = EditorGUIUtility.singleLineHeight;
			float spacing = 2f;
			float y = position.y + EditorGUIUtility.singleLineHeight + spacing;

			for (int i = 0; i < fieldCount; i++)
			{
				SerializedProperty component = property.FindPropertyRelative(GetFieldName(i));
				if (component != null)
				{
					Rect sliderRect = new Rect(position.x, y, position.width, sliderHeight);
					string labelText = GetFieldName(i).ToUpper(); // ラベルのみ大文字
					if (component.propertyType == SerializedPropertyType.Float)
					{
						component.floatValue = EditorGUI.Slider(sliderRect, labelText, component.floatValue, range.Min, range.Max);
					}
					else if (component.propertyType == SerializedPropertyType.Integer)
					{
						int newValue = Mathf.RoundToInt(EditorGUI.Slider(sliderRect, labelText, component.intValue, range.Min, range.Max));
						component.intValue = Mathf.Clamp(newValue, Mathf.RoundToInt(range.Min), Mathf.RoundToInt(range.Max));
					}
					y += sliderHeight + spacing;
				}
			}
		}

		EditorGUI.EndProperty();
	}

	private int GetFieldCount(SerializedProperty property)
	{
		switch (property.type)
		{
			case "Vector2":
			case "Vector2Int":
				return 2;
			case "Vector3":
			case "Vector3Int":
				return 3;
			case "Vector4":
				return 4;
			default:
				return 0;
		}
	}

	private string GetFieldName(int index)
	{
		return index switch
		{
			0 => "x",
			1 => "y",
			2 => "z",
			3 => "w",
			_ => ""
		};
	}
}
#endif
