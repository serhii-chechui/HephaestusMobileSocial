//
// SocialResult.cs
// HephaestusMobileSocial
//
// Created by Serhii Chechui
// Copyright © 2021 WTFGames. All Rights reserved.

namespace WTFGames.Hephaestus.MobileSocialSystem
{
    /// <summary>Reason a social operation did not succeed.</summary>
    public enum SocialError
    {
        /// <summary>The operation succeeded.</summary>
        None = 0,

        /// <summary>No social backend exists on this platform or build.</summary>
        NotAvailable,

        /// <summary>The operation requires a signed in user.</summary>
        NotSignedIn,

        /// <summary>The user or the caller cancelled the operation.</summary>
        Cancelled,

        /// <summary>The backend could not be reached.</summary>
        Network,

        /// <summary>The identifier passed to the backend is unknown or malformed.</summary>
        InvalidId,

        /// <summary>The backend failed for a reason the implementation could not classify.</summary>
        Unknown
    }

    /// <summary>
    /// Outcome of a social operation. Social backends fail routinely (no network, user declined
    /// sign in, feature unavailable), so operations report failure through this value instead of
    /// throwing.
    /// </summary>
    public readonly struct SocialResult
    {
        public bool Success { get; }
        public SocialError Error { get; }

        /// <summary>Backend supplied diagnostic text. For logs, never for end users.</summary>
        public string Message { get; }

        private SocialResult(bool success, SocialError error, string message)
        {
            Success = success;
            Error = error;
            Message = message;
        }

        public static SocialResult Ok()
        {
            return new SocialResult(true, SocialError.None, null);
        }

        public static SocialResult Fail(SocialError error, string message = null)
        {
            return new SocialResult(false, error, message);
        }
    }

    /// <summary>Outcome of a social operation that returns data.</summary>
    public readonly struct SocialResult<T>
    {
        public bool Success { get; }

        /// <summary>The payload, or default when <see cref="Success"/> is false.</summary>
        public T Value { get; }

        public SocialError Error { get; }

        /// <summary>Backend supplied diagnostic text. For logs, never for end users.</summary>
        public string Message { get; }

        private SocialResult(bool success, T value, SocialError error, string message)
        {
            Success = success;
            Value = value;
            Error = error;
            Message = message;
        }

        public static SocialResult<T> Ok(T value)
        {
            return new SocialResult<T>(true, value, SocialError.None, null);
        }

        public static SocialResult<T> Fail(SocialError error, string message = null)
        {
            return new SocialResult<T>(false, default, error, message);
        }
    }
}
