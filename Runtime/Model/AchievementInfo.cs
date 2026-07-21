//
// AchievementInfo.cs
// HephaestusMobileSocial
//
// Created by Serhii Chechui
// Copyright © 2021 WTFGames. All Rights reserved.

namespace WTFGames.Hephaestus.MobileSocialSystem
{
    /// <summary>State of a single achievement for the signed in player.</summary>
    public readonly struct AchievementInfo
    {
        /// <summary>Identifier configured in the platform console.</summary>
        public string Id { get; }

        /// <summary>Progress in the 0..100 range.</summary>
        public double PercentCompleted { get; }

        public bool IsCompleted { get; }

        public AchievementInfo(string id, double percentCompleted, bool isCompleted)
        {
            Id = id;
            PercentCompleted = percentCompleted;
            IsCompleted = isCompleted;
        }
    }
}
