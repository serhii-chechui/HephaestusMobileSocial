// 
// ISocialAchievementsProvider.cs
// HephaestusMobileSocial
// 
// Created by Serhii Chechui
// Copyright © 2021 WTFGames. All Rights reserved.

using System;
using UnityEngine.SocialPlatforms;

namespace HephaestusMobile.MobileSocial {
    public interface ISocialAchievementsProvider {
        void         ShowAchievementsUI();
        IAchievement CreateAchievement(string achievementID, double percentCompleted, Action<bool> result);
        void         LoadAchievementDescriptions(Action<IAchievementDescription[]> callback);
        void         LoadAchievements(Action<IAchievement[]> callback);
        void         ReportProgress(string achievementID, double progress, Action<bool> callback);
    }
}
