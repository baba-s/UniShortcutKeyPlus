using UnityEditor;

namespace KoganeEditorUtils
{
	public static class InvertActiveGameObject
	{
		private const string ITEM_NAME = "Edit/Plus/Invert Active &a";

		[MenuItem( ITEM_NAME )]
		public static void Invert()
		{
			EditorApplication.ExecuteMenuItem( "GameObject/Toggle Active State" );
		}

		[MenuItem( ITEM_NAME, true )]
		public static bool CanInvert()
		{
			var gameObjects = Selection.gameObjects;
			return gameObjects != null && 0 < gameObjects.Length;
		}
	}
}