using UnityEditor;

namespace UniShortcutKeyPlus
{
	internal static class InvertActiveGameObject
	{
		private const string ITEM_NAME = "Edit/UniShortcutKeyPlus/Invert Active &a";

		[MenuItem( ITEM_NAME )]
		private static void Invert()
		{
			EditorApplication.ExecuteMenuItem( "GameObject/Toggle Active State" );
		}

		[MenuItem( ITEM_NAME, true )]
		private static bool CanInvert()
		{
			var gameObjects = Selection.gameObjects;
			return gameObjects != null && 0 < gameObjects.Length;
		}
	}
}