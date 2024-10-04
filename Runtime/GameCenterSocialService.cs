// 
// GameCenterSocialProvider.cs
// HephaestusMobileSocial
// 
// Created by Serhii Chechui
// Copyright © 2021 WTFGames. All Rights reserved.

using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Zenject;

namespace WTFGames.Hephaestus.MobileSocial {
    public class GameCenterSocialService : IInitializable, IDisposable, IMobileSocialService {
        
        public ISocialPlatform Active { get; private set; }
        public ILocalUser LocalUser { get; private set; }

        public ISocialAchievementsProvider AchievementsProvider { get; private set; }
        public ISocialLeaderboardsProvider LeaderboardsProvider { get; private set; }
        
        public string UserInfo { get; private set; }

        public void Initialize() {
            Active = Social.Active;
            AchievementsProvider = new SocialAchievementsProvider();
            LeaderboardsProvider = new SocialLeaderboardsProvider();
            
            Authenticate(Active.localUser, success =>
            {
                if (success) {
                    Debug.Log("Authentication successful");
                    UserInfo = $"Username: {Social.localUser.userName}, User ID: {Social.localUser.id}, IsUnderage: {Social.localUser.underage}";
                    Debug.Log(UserInfo);
                } else {
                    Debug.LogError("Authentication failed");
                }
            });
        }
        
        public void Dispose()
        {
            
        }

        public void Authenticate(ILocalUser user, Action<bool> callback) {
            Active?.Authenticate(user, callback);
        }

        public void Authenticate(ILocalUser user, Action<bool, string> callback) {
            Active?.Authenticate(user, callback);
        }

        public void LoadUsers(string[] userIDs, Action<IUserProfile[]> callback) {
            if (Social.Active.localUser != null) {
                Social.LoadUsers(userIDs, callback);
            }
        }

        public void ReportScores(int scores, string boardName, Action<bool> callback)
        {
            if (Social.Active.localUser == null) return;
            
            Social.ReportScore(scores, boardName, success => {
                if (success)
                {
                    Debug.Log($"Saved scores into leaderboard: {scores}");
                    callback?.Invoke(true);
                }
                else
                {
                    Debug.LogError("Failed to report score");
                    callback?.Invoke(false);
                }
            });
        }
    }
}
