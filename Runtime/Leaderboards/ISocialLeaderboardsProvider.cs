// 
// ISocialLeaderboardsProvider.cs
// HephaestusMobileSocial
// 
// Created by Serhii Chechui
// Copyright © 2021 WTFGames. All Rights reserved.

using System;
using UnityEngine.SocialPlatforms;

namespace HephaestusMobileSocial.Runtime {
    public interface ISocialLeaderboardsProvider {
        void         ShowLeaderboardUI();
        ILeaderboard CreateLeaderboard(string leaderboardId);
        void         LoadScores(string leaderboardID, Action<IScore[]> callback);
        void         ReportScore(long score, string leaderboardID, Action<bool> callback);
    }
}