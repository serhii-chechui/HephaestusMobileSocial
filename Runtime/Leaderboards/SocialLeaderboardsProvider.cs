// 
// SocialLeaderboardsProvider.cs
// HephaestusPackages
// 
// Created by Serhii Chechui
// Copyright © 2021 WTFGames. All Rights reserved.

using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace HephaestusMobileSocial.Runtime {
    public class SocialLeaderboardsProvider : ISocialLeaderboardsProvider {
        public void ShowLeaderboardUI() {
            Social.ShowLeaderboardUI();
        }

        public ILeaderboard CreateLeaderboard(string leaderboardId) {
            var leaderboard = Social.CreateLeaderboard();
            leaderboard.id = leaderboardId;
            leaderboard.LoadScores(result => {
                Debug.Log($"Received {leaderboard.scores.Length} scores");
                foreach (var score in leaderboard.scores) {
                    Debug.Log(score);
                }
            });
            return leaderboard;
        }

        public void LoadScores(string leaderboardID, Action<IScore[]> callback) {
            Social.LoadScores(leaderboardID, scores => {
                if (scores.Length > 0) {
                    Debug.Log($"Got {scores.Length} scores");
                    var myScores = scores.Aggregate("Leaderboard:\n", (current, score) => current + ("\t" + score.userID + " " + score.formattedValue + " " + score.date + "\n"));
                    Debug.Log(myScores);
                } else {
                    Debug.Log("No scores loaded");
                }
                
                callback?.Invoke(scores);
            });
        }

        public void ReportScore(long score, string leaderboardID, Action<bool> callback) {
            Debug.Log($"Reporting score {score} on leaderboard {leaderboardID}");
            Social.ReportScore(score, leaderboardID, success => {
                Debug.Log(success ? "Reported score successfully" : "Failed to report score");
                callback?.Invoke(success);
            });
        }
    }
}
