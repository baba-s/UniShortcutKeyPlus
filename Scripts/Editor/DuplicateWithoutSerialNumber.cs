using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UniShortcutKeyPlus
{
	internal static class DuplicateWithoutSerialNumber
	{
		private const string ITEM_NAME = "Edit/UniShortcutKeyPlus/Duplicate Without Serial Number &d";

		[MenuItem( ITEM_NAME )]
		private static void Duplicate()
		{
			var list = new List<int>();

			foreach ( var n in Selection.gameObjects )
			{
				var clone = Object.Instantiate( n, n.transform.parent );
				clone.name = n.name;
				list.Add( clone.GetInstanceID() );
				Undo.RegisterCreatedObjectUndo( clone, "Duplicate Without Serial Number" );
			}

			Selection.instanceIDs = list.ToArray();
			list.Clear();
		}

		[MenuItem( ITEM_NAME, true )]
		private static bool CanDuplicate()
		{
			var gameObjects = Selection.gameObjects;
			return gameObjects != null && 0 < gameObjects.Length;
		}
	}
}