// 
// GameCenterSocialProvider.cs
// HephaestusMobileSocial
// 
// Created by Serhii Chechui
// Copyright © 2021 WTFGames. All Rights reserved.

using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace HephaestusMobileSocial.Runtime {
    public class GameCenterSocialProvider : MonoBehaviour, IMobileSocialProvider {
        
        public ISocialPlatform Active { get; private set; }
        public ILocalUser LocalUser { get; private set; }

        public ISocialAchievementsProvider AchievementsProvider { get; private set; }
        public ISocialLeaderboardsProvider LeaderboardsProvider { get; private set; }
        
        public void Initialize() {
            Active = Social.Active;
            AchievementsProvider = new SocialAchievementsProvider();
            LeaderboardsProvider = new SocialLeaderboardsProvider();
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
    }
}
