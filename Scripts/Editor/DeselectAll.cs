using UnityEditor;
using UnityEngine;

namespace UniShortcutKeyPlus
{
	internal static class DeselectAll
	{
		private const string ITEM_NAME = "Edit/UniShortcutKeyPlus/Deselect All &e";

		[MenuItem( ITEM_NAME )]
		private static void Deselect()
		{
			Selection.objects = new Object[0];
		}

		[MenuItem( ITEM_NAME, true )]
		private static bool CanDeselect()
		{
			var objects = Selection.objects;
			return objects != null && 0 < objects.Length;
		}
	}
}