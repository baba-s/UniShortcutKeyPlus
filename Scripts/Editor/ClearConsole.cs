using System.Reflection;
using UnityEditor;

namespace UniShortcutKeyPlus
{
	internal static class ClearConsole
	{
		private const string ITEM_NAME = "Edit/UniShortcutKeyPlus/Clear Console &#c";

		[MenuItem( ITEM_NAME )]
		private static void Invert()
		{
			var type = Assembly
					.GetAssembly( typeof( SceneView ) )
#if UNITY_2017_1_OR_NEWER
					.GetType( "UnityEditor.LogEntries" )
#else
				.GetType( "UnityEditorInternal.LogEntries" )
#endif
				;

			var attr   = BindingFlags.Static | BindingFlags.Public;
			var method = type.GetMethod( "Clear", attr );
			method.Invoke( null, null );
		}
	}
}