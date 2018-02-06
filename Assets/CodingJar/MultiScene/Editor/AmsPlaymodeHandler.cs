using UnityEngine;
using UnityEditor;

using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

namespace CodingJar.MultiScene.Editor
{
	public static class AmsPlaymodeHandler
	{
		[InitializeOnLoadMethod]
		private static void SaveCrossSceneReferencesBeforePlayInEditMode()
		{
			EditorApplication.playmodeStateChanged += () =>
				{
#if UNITY_5_6_OR_NEWER
					if ( EditorUtility.scriptCompilationFailed )
					{
						AmsDebug.Log( null, "Skipping cross-scene references due to compilation errors" );
						return;
					}
#endif

					if ( !EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode )
					{
						List<Scene> allScenes = new List<Scene>( EditorSceneManager.sceneCount );
						for (int i = 0 ; i < EditorSceneManager.sceneCount ; ++i)
						{
							var scene = EditorSceneManager.GetSceneAt(i);
							if ( scene.IsValid() && scene.isLoaded )
								allScenes.Add( scene );
						}

						AmsDebug.Log( null, "Handling Cross-Scene Referencing for Playmode" );
						AmsSaveProcessor.HandleCrossSceneReferences( allScenes );
					}
				};
		}
	} // class
} // namespace