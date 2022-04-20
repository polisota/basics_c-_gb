using UnityEditor;

public class MenuItems
{
	[MenuItem("Spawn/SphereSpawn")]
	private static void MenuOption()
	{
		EditorWindow.GetWindow(typeof(MyWindow), false, "SphereSpawn");
	}
}
