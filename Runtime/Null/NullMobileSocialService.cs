//
// NullMobileSocialService.cs
// HephaestusMobileSocial
//
// Created by Serhii Chechui
// Copyright © 2021 WTFGames. All Rights reserved.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WTFGames.Hephaestus.MobileSocialSystem
{
    /// <summary>
    /// Does nothing. Bind it on platforms without a social backend (Editor, desktop, or builds
    /// where the feature is off) so callers can depend on <see cref="IMobileSocialService"/>
    /// unconditionally and simply hide social UI while <see cref="IsAvailable"/> is false.
    /// Actions (sign in, report, show UI) fail with <see cref="SocialError.NotAvailable"/>; reads
    /// succeed with an empty collection, so list UI renders as empty rather than as an error.
    /// </summary>
    public sealed class NullMobileSocialService : IMobileSocialService, ILeaderboardService, IAchievementService
    {
        private static readonly IReadOnlyList<LeaderboardEntry> NoEntries = Array.Empty<LeaderboardEntry>();
        private static readonly IReadOnlyList<AchievementInfo> NoAchievements = Array.Empty<AchievementInfo>();

        public bool IsAvailable => false;

        public bool IsSignedIn => false;

        public SocialUser CurrentUser => SocialUser.None;

        public ILeaderboardService Leaderboards => this;

        public IAchievementService Achievements => this;

        public Task<SocialResult> SignInAsync(CancellationToken cancellationToken = default)
        {
            return NotAvailable();
        }

        Task<SocialResult> ILeaderboardService.ReportScoreAsync(
            string leaderboardId,
            long score,
            CancellationToken cancellationToken)
        {
            return NotAvailable();
        }

        Task<SocialResult<IReadOnlyList<LeaderboardEntry>>> ILeaderboardService.LoadScoresAsync(
            string leaderboardId,
            LeaderboardQuery query,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(
                SocialResult<IReadOnlyList<LeaderboardEntry>>.Ok(NoEntries));
        }

        Task<SocialResult> ILeaderboardService.ShowUIAsync(
            string leaderboardId,
            CancellationToken cancellationToken)
        {
            return NotAvailable();
        }

        Task<SocialResult> IAchievementService.ReportProgressAsync(
            string achievementId,
            double percentCompleted,
            CancellationToken cancellationToken)
        {
            return NotAvailable();
        }

        Task<SocialResult<IReadOnlyList<AchievementInfo>>> IAchievementService.LoadAsync(
            CancellationToken cancellationToken)
        {
            return Task.FromResult(
                SocialResult<IReadOnlyList<AchievementInfo>>.Ok(NoAchievements));
        }

        Task<SocialResult> IAchievementService.ShowUIAsync(CancellationToken cancellationToken)
        {
            return NotAvailable();
        }

        private static Task<SocialResult> NotAvailable()
        {
            return Task.FromResult(
                SocialResult.Fail(SocialError.NotAvailable, "No mobile social backend on this platform."));
        }
    }
}
