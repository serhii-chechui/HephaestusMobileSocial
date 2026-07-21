# Hephaestus Mobile Social

Platform agnostic abstraction for mobile social features: sign in, leaderboards and achievements.

This package contains **only the abstraction**. It has no dependency on Zenject, on UnityEngine, or
on any platform SDK, so it compiles on every target and can be referenced from any assembly. The
concrete backends (Game Center, Google Play Games, ...) are implemented by the consuming project.

## Why not `UnityEngine.Social`

Unity's built in `Social` / `UnityEngine.SocialPlatforms` API is legacy. It is only implemented on
iOS via Game Center; on Android it silently does nothing. Version 1.x of this package exposed those
types directly, so every consumer inherited that limitation. Version 2 defines its own model types
instead.

## API

```csharp
public interface IMobileSocialService
{
    bool IsAvailable { get; }          // a backend exists on this platform/build
    bool IsSignedIn { get; }
    SocialUser CurrentUser { get; }
    ILeaderboardService Leaderboards { get; }
    IAchievementService Achievements { get; }

    Task<SocialResult> SignInAsync(CancellationToken cancellationToken = default);
}
```

`ILeaderboardService` exposes `ReportScoreAsync`, `LoadScoresAsync` and `ShowUIAsync`.
`IAchievementService` exposes `ReportProgressAsync`, `LoadAsync` and `ShowUIAsync`.

Operations never throw for expected failures. They return `SocialResult` (or `SocialResult<T>`),
which carries a `SocialError` describing why the call did not succeed:

```csharp
var result = await _social.Leaderboards.ReportScoreAsync("sgldb_001", score, cancellationToken);
if (!result.Success && result.Error != SocialError.NotAvailable)
{
    Debug.LogWarning($"Score report failed: {result.Error} {result.Message}");
}
```

## Usage

Gate social UI on `IsAvailable` rather than on platform defines:

```csharp
leaderboardsButton.gameObject.SetActive(_social.IsAvailable);
```

On platforms without a backend, bind `NullMobileSocialService`. Every call then reports
`SocialError.NotAvailable` and no caller needs a conditional.

## Implementing a backend

Implement `IMobileSocialService`, `ILeaderboardService` and `IAchievementService`, keeping all
platform SDK types internal to the implementation, and bind your implementation per platform in
your project's DI installer.
