using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace KoganeEditorUtils
{
	public static class ToggleDebugMode
	{
		private const string ITEM_NAME = "Edit/Plus/Toggle Inspector Debug &k";

		[MenuItem( ITEM_NAME )]
		private static void Toggle()
		{
			var window = Resources.FindObjectsOfTypeAll<EditorWindow>();
			var inspectorWindow = ArrayUtility.Find( window, c => c.GetType().Name == "InspectorWindow" );

			if ( inspectorWindow == null ) return;

			var inspectorType = inspectorWindow.GetType();
			var tracker = ActiveEditorTracker.sharedTracker;
			var isNormal = tracker.inspectorMode == InspectorMode.Normal;
			var methodName = isNormal ? "SetDebug" : "SetNormal";

			var attr = BindingFlags.NonPublic | BindingFlags.Instance;
			var methodInfo = inspectorType.GetMethod( methodName, attr );
			methodInfo.Invoke( inspectorWindow, null );
			tracker.ForceRebuild();
		}

		[MenuItem( ITEM_NAME, true )]
		private static bool CanToggle()
		{
			var window = Resources.FindObjectsOfTypeAll<EditorWindow>();
			var inspectorWindow = ArrayUtility.Find( window, c => c.GetType().Name == "InspectorWindow" );

			return inspectorWindow != null;
		}
	}
}