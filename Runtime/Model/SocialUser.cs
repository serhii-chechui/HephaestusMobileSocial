//
// SocialUser.cs
// HephaestusMobileSocial
//
// Created by Serhii Chechui
// Copyright © 2021 WTFGames. All Rights reserved.

namespace WTFGames.Hephaestus.MobileSocialSystem
{
    /// <summary>
    /// Backend agnostic view of the signed in player. Only fields every supported backend can
    /// provide are exposed here.
    /// </summary>
    public readonly struct SocialUser
    {
        /// <summary>Value returned while no user is signed in.</summary>
        public static readonly SocialUser None = default;

        /// <summary>Backend specific player identifier.</summary>
        public string Id { get; }

        /// <summary>Name suitable for display. May be empty when the backend withholds it.</summary>
        public string DisplayName { get; }

        /// <summary>
        /// True when the backend reports the player as underage, which some stores require for
        /// gating social features.
        /// </summary>
        public bool IsUnderage { get; }

        /// <summary>False for <see cref="None"/> and for any user without an identifier.</summary>
        public bool IsValid => !string.IsNullOrEmpty(Id);

        public SocialUser(string id, string displayName, bool isUnderage = false)
        {
            Id = id;
            DisplayName = displayName;
            IsUnderage = isUnderage;
        }
    }
}
