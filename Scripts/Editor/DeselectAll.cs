using UnityEditor;
using UnityEngine;

namespace KoganeEditorUtils
{
	public static class DeselectAll
	{
		private const string ITEM_NAME = "Edit/Plus/Deselect All &e";

		[MenuItem( ITEM_NAME )]
		public static void Deselect()
		{
			Selection.objects = new Object[ 0 ];
		}

		[MenuItem( ITEM_NAME, true )]
		public static bool CanDeselect()
		{
			var objects = Selection.objects;
			return objects != null && 0 < objects.Length;
		}
	}
}