# Changelog

## [2.0.0] - 2026-07-20

### Changed

- **BREAKING.** Rewritten as a pure abstraction. The public API no longer exposes
  `UnityEngine.SocialPlatforms` types (`ISocialPlatform`, `ILocalUser`, `IScore`, `ILeaderboard`,
  `IAchievement`, `IUserProfile`), which tied every consumer to the deprecated `Social` API that
  only ever worked on iOS.
- Namespace is now `WTFGames.Hephaestus.MobileSocialSystem`, matching the other Hephaestus systems.
- Operations are `Task` based and take a `CancellationToken` instead of using callbacks.
- Failures are reported through `SocialResult` / `SocialResult<T>` rather than a bare `bool`, so
  callers can tell "not available" from "not signed in" from a network error.
- The assembly builds on every platform and no longer references Zenject or UnityEngine, so game
  code can depend on it without platform conditionals.

### Added

- `IMobileSocialService` with `IsAvailable`, `IsSignedIn`, `CurrentUser` and `SignInAsync`.
- `ILeaderboardService` and `IAchievementService`.
- Backend agnostic model types: `SocialUser`, `LeaderboardEntry`, `LeaderboardQuery`,
  `AchievementInfo`, `SocialResult`, `SocialError`.
- `NullMobileSocialService`, a no-op backend for platforms without social support.

### Removed

- `GameCenterSocialService`, `SocialLeaderboardsProvider`, `SocialAchievementsProvider` and
  `HephaestusMobileSocialInstaller`. Concrete backends and their DI wiring now live in the
  consuming project.

## [0.0.2] - 2023-05-21

### Changed

- Cleaned the code and updated the namespaces;

## [0.0.1] - 2021-04-25

### Added

- Created HephaestusMobileSoccial as UnityPackage.
