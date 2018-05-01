using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooglePlay : MonoBehaviour {
    public static void AddScoreToGlobalLeaderboard(int score) {
        #if UNITY_ANDROID && !UNITY_EDITOR
            if (PlayerPrefs.GetInt("OptOut", 0) == 0)
            {
                if (connectedToGooglePlay)
                {
                    Social.ReportScore(score, GPGSIds.leaderboard_global_leaderboard, success => { });
                }

                else
                {
                    Social.localUser.Authenticate((bool success) => { connectedToGooglePlay = success; });
                }
            }
        #endif
    }

    public static void InitializeGooglePlay() {
        #if UNITY_ANDROID && !UNITY_EDITOR
            //sign in to Google Play Services
            PlayGamesPlatform.Activate();

            if (!LeaderBoardController.connectedToGooglePlay)
            {
                Social.localUser.Authenticate((bool success) =>
                {
                    LeaderBoardController.connectedToGooglePlay = success;
                });
            }
        #endif
    }
}
