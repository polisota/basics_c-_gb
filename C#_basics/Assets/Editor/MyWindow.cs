using UnityEditor;
using UnityEngine;

public class MyWindow : EditorWindow
{	
	public static GameObject ObjectInstantiate1;
	public static GameObject ObjectInstantiate2;
	public static GameObject ObjectInstantiate3;
	
	public bool _groupEnabled;
	public bool _randomColor = true;
	public int _countObject = 1;
	
	public float _xpos = 10;
	public float _zpos = 10;

	private void OnGUI()
	{
		GUILayout.Label("������� ���������", EditorStyles.boldLabel);

		
		ObjectInstantiate1 = EditorGUILayout.ObjectField("������ �1", ObjectInstantiate1, typeof(GameObject), true) as GameObject;
		ObjectInstantiate2 = EditorGUILayout.ObjectField("������ �2", ObjectInstantiate2, typeof(GameObject), true) as GameObject;
		ObjectInstantiate3 = EditorGUILayout.ObjectField("������ �3", ObjectInstantiate3, typeof(GameObject), true) as GameObject;		

		_groupEnabled = EditorGUILayout.BeginToggleGroup("�������������� ���������", _groupEnabled);
		_randomColor = EditorGUILayout.Toggle("����", _randomColor);
		
		_xpos = EditorGUILayout.Slider("������� �� �", _xpos, -24, 24);
		_zpos = EditorGUILayout.Slider("������� �� z", _zpos, -24, 24);

		EditorGUILayout.EndToggleGroup();

		var button = GUILayout.Button("�������");

		if (button)
		{
			GameObject[] PrefabForSpawn = new GameObject[] { ObjectInstantiate1, ObjectInstantiate2, ObjectInstantiate3 };
			GameObject obj = PrefabForSpawn[Random.Range(0, PrefabForSpawn.Length)];

			if (obj)
			{				
				Vector3 position = new Vector3(_xpos, 2, _zpos);
				var newobj = Instantiate(obj, position, Quaternion.identity);

				var newobjRenderer = newobj.GetComponent<Renderer>();
				if (newobjRenderer && _randomColor)
				{
					var tempMaterial = new Material(newobjRenderer.sharedMaterial);
					tempMaterial.color = Random.ColorHSV();
					newobjRenderer.sharedMaterial = tempMaterial;					
				}
			}


		}

	}
}
