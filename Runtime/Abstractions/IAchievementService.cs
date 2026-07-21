//
// IAchievementService.cs
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
    /// Achievement operations of a mobile social backend. All identifiers are the ones configured
    /// in the platform console (App Store Connect, Google Play Console).
    /// </summary>
    public interface IAchievementService
    {
        /// <summary>
        /// Reports achievement progress, where <paramref name="percentCompleted"/> is 0..100.
        /// Backends that only support unlocking treat 100 as unlocked.
        /// </summary>
        Task<SocialResult> ReportProgressAsync(
            string achievementId,
            double percentCompleted,
            CancellationToken cancellationToken = default);

        /// <summary>Loads the achievements of the signed in user.</summary>
        Task<SocialResult<IReadOnlyList<AchievementInfo>>> LoadAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Opens the native achievements UI. The returned task completes once the UI has been
        /// presented, not when the user closes it.
        /// </summary>
        Task<SocialResult> ShowUIAsync(CancellationToken cancellationToken = default);
    }
}
