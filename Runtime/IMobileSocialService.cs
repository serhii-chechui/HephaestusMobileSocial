// 
// ISocialAchievementsProvider.cs
// IMobileSocialProvider
// 
// Created by Serhii Chechui
// Copyright © 2021 WTFGames. All Rights reserved.

using System;
using UnityEngine.SocialPlatforms;

namespace WTFGames.Hephaestus.MobileSocial {
     public interface IMobileSocialService
     {
          ISocialPlatform Active { get; }
          ILocalUser LocalUser { get; }
          ISocialAchievementsProvider AchievementsProvider { get; }
          ISocialLeaderboardsProvider LeaderboardsProvider { get; }
          string UserInfo { get; }
          
          void Initialize();
          void Authenticate(ILocalUser user, Action<bool> callback);
          void Authenticate(ILocalUser user, Action<bool, string> callback);
          void LoadUsers(string[] userIDs, Action<IUserProfile[]> callback);
          void ReportScores(int scores, string boardName, Action<bool> callback);
     }
}
