//
// ILeaderboardService.cs
// HephaestusMobileSocial
//
// Created by Serhii Chechui
// Copyright © 2021 WTFGames. All Rights reserved.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WTFGames.Hephaestus.MobileSocialSystem
{
    /// <summary>
    /// Leaderboard operations of a mobile social backend. All identifiers are the ones configured
    /// in the platform console (App Store Connect, Google Play Console).
    /// </summary>
    public interface ILeaderboardService
    {
        /// <summary>Submits a score to the given leaderboard.</summary>
        Task<SocialResult> ReportScoreAsync(
            string leaderboardId,
            long score,
            CancellationToken cancellationToken = default);

        /// <summary>Loads leaderboard entries matching the query.</summary>
        Task<SocialResult<IReadOnlyList<LeaderboardEntry>>> LoadScoresAsync(
            string leaderboardId,
            LeaderboardQuery query = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Opens the native leaderboard UI. Pass null to open the leaderboard list rather than a
        /// specific board. The returned task completes once the UI has been presented, not when
        /// the user closes it.
        /// </summary>
        Task<SocialResult> ShowUIAsync(
            string leaderboardId = null,
            CancellationToken cancellationToken = default);
    }
}
