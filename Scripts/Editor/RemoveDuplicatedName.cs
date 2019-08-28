using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;

namespace KoganeEditorUtils
{
	public static class RemoveDuplicatedName
	{
		private const string ITEM_NAME = "Edit/Plus/Remove Duplicated Name &r";

		private static Regex m_regex = new Regex( @"(.*)(\([0-9]*\))" );

		[MenuItem( ITEM_NAME )]
		public static void Remove()
		{
			var list = Selection.gameObjects
				.Where( c => m_regex.IsMatch( c.name ) )
				.ToArray()
			;

			if ( list == null || list.Length == 0 ) return;

			foreach ( var n in list )
			{
				Undo.RecordObject( n, "Remove Duplicated Name" );
				n.name = m_regex.Replace( n.name, @"$1" );
			}
		}

		[MenuItem( ITEM_NAME, true )]
		public static bool CanRemove()
		{
			var gameObjects = Selection.gameObjects;
			return gameObjects != null && 0 < gameObjects.Length;
		}
	}
}