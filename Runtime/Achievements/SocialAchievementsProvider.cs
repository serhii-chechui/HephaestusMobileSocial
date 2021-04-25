// 
// SocialAchievementsProvider.cs
// HephaestusPackages
// 
// Created by Serhii Chechui
// Copyright © 2021 WTFGames. All Rights reserved.

using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace HephaestusMobileSocial.Runtime {
    public class SocialAchievementsProvider : ISocialAchievementsProvider {
        
        public void ShowAchievementsUI() {
            Social.ShowAchievementsUI();
        }

        public IAchievement CreateAchievement(string achievementID, double percentCompleted, Action<bool> result) {
            var achievement = Social.CreateAchievement();
            achievement.id = achievementID;
            achievement.percentCompleted = percentCompleted;
            achievement.ReportProgress(result);
            return achievement;
        }

        public void LoadAchievementDescriptions(Action<IAchievementDescription[]> callback) {
            Social.LoadAchievementDescriptions(descriptions => {
                if (descriptions.Length > 0) {
                    Debug.Log($"Got {descriptions.Length} achievement descriptions");
                    var achievementDescriptions = descriptions.Aggregate("Achievement Descriptions:\n", (current, ad) => current + ("\t" + ad.id + " " + ad.title + " " + ad.unachievedDescription + "\n"));
                    Debug.Log(achievementDescriptions);
                } else {
                    Debug.LogError("Failed to load achievement descriptions");
                }
                
                callback?.Invoke(descriptions);
            });
        }

        public void LoadAchievements(Action<IAchievement[]> callback) {
            Social.LoadAchievements(achievements => {
                if (achievements.Length > 0) {
                    Debug.Log($"Got {achievements.Length} achievement instances");
                    var myAchievements = achievements.Aggregate("My achievements:\n", (current, achievement) => current + ("\t" + achievement.id + " " + achievement.percentCompleted + " " + achievement.completed + " " + achievement.lastReportedDate + "\n"));
                    Debug.Log(myAchievements);
                } else {
                    Debug.Log("No achievements returned");
                }
                
                callback?.Invoke(achievements);
            });
        }

        public void ReportProgress(string achievementID, double progress, Action<bool> callback) {
            Social.ReportProgress(achievementID, progress, callback);
        }
    }
}
