using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace KoganeEditorUtils
{
	public static class DuplicateWithoutSerialNumber
	{
		private const string ITEM_NAME = "Edit/Plus/Duplicate Without Serial Number &d";

		private static readonly int LENGTH = "(Clone)".Length;

		[MenuItem( ITEM_NAME )]
		public static void Duplicate()
		{
			var list = new List<int>();

			foreach ( var n in Selection.gameObjects )
			{
				var clone = GameObject.Instantiate( n, n.transform.parent );
				clone.name = clone.name.Substring( 0, clone.name.Length - LENGTH );
				list.Add( clone.GetInstanceID() );
				Undo.RegisterCreatedObjectUndo( clone, "Duplicate Without Serial Number" );
			}

			Selection.instanceIDs = list.ToArray();
			list.Clear();
		}

		[MenuItem( ITEM_NAME, true )]
		public static bool CanDuplicate()
		{
			var gameObjects = Selection.gameObjects;
			return gameObjects != null && 0 < gameObjects.Length;
		}
	}
}