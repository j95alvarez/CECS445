using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class GooglePlay : MonoBehaviour
{

    private void Start()
    {
        InitializeGooglePlay();
    }

    public static void AddScoreToGlobalLeaderboard(int score)
    {
#if UNITY_ANDROID
        Social.ReportScore(score, GPGSIds.leaderboard_top_runners, success => { });
#endif
    }

    public static void InitializeGooglePlay()
    {
#if UNITY_ANDROID
        //sign in to Google Play Services
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) => { });
#endif
    }

    public static void ShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }
}