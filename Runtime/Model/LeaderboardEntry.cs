//
// LeaderboardEntry.cs
// HephaestusMobileSocial
//
// Created by Serhii Chechui
// Copyright © 2021 WTFGames. All Rights reserved.

using System;

namespace WTFGames.Hephaestus.MobileSocialSystem
{
    /// <summary>Which players a leaderboard query covers.</summary>
    public enum LeaderboardScope
    {
        Global = 0,
        FriendsOnly
    }

    /// <summary>Which time window a leaderboard query covers.</summary>
    public enum LeaderboardTimeScope
    {
        AllTime = 0,
        Week,
        Today
    }

    /// <summary>
    /// Query options for <see cref="ILeaderboardService.LoadScoresAsync"/>. The default value asks
    /// for the global all time board with <see cref="DefaultMaxResults"/> entries.
    /// </summary>
    public readonly struct LeaderboardQuery
    {
        public const int DefaultMaxResults = 25;

        public LeaderboardScope Scope { get; }
        public LeaderboardTimeScope TimeScope { get; }

        /// <summary>Requested entry count. Zero means <see cref="DefaultMaxResults"/>.</summary>
        public int MaxResults { get; }

        /// <summary>
        /// <see cref="MaxResults"/> with the zero default resolved, so implementations do not each
        /// have to special case it.
        /// </summary>
        public int ResolvedMaxResults => MaxResults > 0 ? MaxResults : DefaultMaxResults;

        public LeaderboardQuery(
            LeaderboardScope scope = LeaderboardScope.Global,
            LeaderboardTimeScope timeScope = LeaderboardTimeScope.AllTime,
            int maxResults = DefaultMaxResults)
        {
            Scope = scope;
            TimeScope = timeScope;
            MaxResults = maxResults;
        }
    }

    /// <summary>A single row of a leaderboard.</summary>
    public readonly struct LeaderboardEntry
    {
        /// <summary>Backend specific identifier of the player who set the score.</summary>
        public string UserId { get; }

        /// <summary>Name suitable for display. May be empty when the backend withholds it.</summary>
        public string DisplayName { get; }

        public long Score { get; }

        /// <summary>One based rank on the board, or 0 when the backend does not report it.</summary>
        public int Rank { get; }

        /// <summary>When the score was set, in UTC.</summary>
        public DateTime DateUtc { get; }

        public LeaderboardEntry(string userId, string displayName, long score, int rank, DateTime dateUtc)
        {
            UserId = userId;
            DisplayName = displayName;
            Score = score;
            Rank = rank;
            DateUtc = dateUtc;
        }
    }
}
