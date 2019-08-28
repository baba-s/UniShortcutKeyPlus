using System.Reflection;
using UnityEditor;

namespace KoganeEditorUtils
{
	public static class ClearConsole
	{
		private const string ITEM_NAME = "Edit/Plus/Clear Console &#c";

		[MenuItem( ITEM_NAME )]
		public static void Invert()
		{
			var type = Assembly
				.GetAssembly( typeof( SceneView ) )
#if UNITY_2017_1_OR_NEWER
				.GetType( "UnityEditor.LogEntries" )
#else
				.GetType( "UnityEditorInternal.LogEntries" )
#endif
		;

			var attr = BindingFlags.Static | BindingFlags.Public;
			var method = type.GetMethod( "Clear", attr );
			method.Invoke( null, null );
		}
	}
}