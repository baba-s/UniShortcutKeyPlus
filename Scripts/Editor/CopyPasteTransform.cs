using UnityEditor;
using UnityEngine;

namespace UniShortcutKeyPlus
{
	internal static class CopyPasteTransform
	{
		private sealed class Data
		{
			public readonly Vector3    m_localPosition;
			public readonly Quaternion m_localRotation;
			public readonly Vector3    m_localScale;

			private Data( Vector3 localPosition, Quaternion localRotation, Vector3 localScale )
			{
				m_localPosition = localPosition;
				m_localRotation = localRotation;
				m_localScale    = localScale;
			}

			public Data( Transform t ) : this( t.localPosition, t.localRotation, t.localScale )
			{
			}
		}

		private const string ITEM_NAME_COPY  = "Edit/UniShortcutKeyPlus/Copy Transform Values &c";
		private const string ITEM_NAME_PASTE = "Edit/UniShortcutKeyPlus/Paste Transform Values &v";

		private static Data m_data;

		[MenuItem( ITEM_NAME_COPY )]
		private static void Copy()
		{
			m_data = new Data( Selection.activeTransform );
		}

		[MenuItem( ITEM_NAME_COPY, true )]
		private static bool CanCopy()
		{
			return Selection.activeTransform != null;
		}

		[MenuItem( ITEM_NAME_PASTE )]
		private static void Paste()
		{
			foreach ( var n in Selection.gameObjects )
			{
				var t = n.transform;
				Undo.RecordObject( t, "Paste Transform Values" );
				t.localPosition = m_data.m_localPosition;
				t.localRotation = m_data.m_localRotation;
				t.localScale    = m_data.m_localScale;
			}
		}

		[MenuItem( ITEM_NAME_PASTE, true )]
		private static bool CanPaste()
		{
			var gameObjects = Selection.gameObjects;
			return m_data != null && gameObjects != null && 0 < gameObjects.Length;
		}
	}
}