using UnityEditor;

namespace KoganeEditorUtils
{
	public static class ChangeSibiling
	{
		private const string ITEM_NAME_UP = "Edit/Plus/Sibiling Up &UP";
		private const string ITEM_NAME_DOWN = "Edit/Plus/Sibiling Down &DOWN";

		[MenuItem( ITEM_NAME_UP )]
		private static void Up()
		{
			var t = Selection.activeTransform;
			t.SetSiblingIndex( t.GetSiblingIndex() - 1 );
		}

		[MenuItem( ITEM_NAME_UP, true )]
		private static bool CanUp()
		{
			return Selection.activeTransform != null;
		}

		[MenuItem( ITEM_NAME_DOWN )]
		private static void Down()
		{
			var t = Selection.activeTransform;
			t.SetSiblingIndex( t.GetSiblingIndex() + 1 );
		}

		[MenuItem( ITEM_NAME_DOWN, true )]
		private static bool CanDown()
		{
			return Selection.activeTransform != null;
		}
	}
}