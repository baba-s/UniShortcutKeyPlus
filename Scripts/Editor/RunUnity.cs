using UnityEditor;

namespace KoganeEditorUtils
{
	public static class RunUnity
	{
		private const string ITEM_NAME_RUN = "Edit/Plus/Run _F5";
		private const string ITEM_NAME_STOP = "Edit/Plus/Stop #_F5";

		[MenuItem( ITEM_NAME_RUN )]
		private static void Run()
		{
			EditorApplication.isPlaying = true;
		}

		[MenuItem( ITEM_NAME_RUN, true )]
		private static bool CanRun()
		{
			return !EditorApplication.isPlaying;
		}

		[MenuItem( ITEM_NAME_STOP )]
		private static void Stop()
		{
			EditorApplication.isPlaying = false;
		}

		[MenuItem( ITEM_NAME_STOP, true )]
		private static bool CanStop()
		{
			return EditorApplication.isPlaying;
		}
	}
}