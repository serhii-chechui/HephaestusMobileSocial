//
// IMobileSocialService.cs
// HephaestusMobileSocial
//
// Created by Serhii Chechui
// Copyright © 2021 WTFGames. All Rights reserved.

using System.Threading;
using System.Threading.Tasks;

namespace WTFGames.Hephaestus.MobileSocialSystem
{
    /// <summary>
    /// Platform agnostic entry point for mobile social features such as Game Center or
    /// Google Play Games. Implementations must never expose platform SDK types through this API,
    /// so game code can depend on it without platform conditionals.
    /// </summary>
    public interface IMobileSocialService
    {
        /// <summary>
        /// True when a social backend exists for the current platform and build. Use it to show or
        /// hide social UI instead of branching on platform defines.
        /// </summary>
        bool IsAvailable { get; }

        /// <summary>True once the local user has been successfully signed in.</summary>
        bool IsSignedIn { get; }

        /// <summary>The signed in user, or <see cref="SocialUser.None"/> when not signed in.</summary>
        SocialUser CurrentUser { get; }

        /// <summary>Leaderboard operations. Never null.</summary>
        ILeaderboardService Leaderboards { get; }

        /// <summary>Achievement operations. Never null.</summary>
        IAchievementService Achievements { get; }

        /// <summary>
        /// Signs the local user in. Safe to call repeatedly: implementations reuse an existing
        /// session instead of prompting the user again.
        /// </summary>
        Task<SocialResult> SignInAsync(CancellationToken cancellationToken = default);
    }
}
