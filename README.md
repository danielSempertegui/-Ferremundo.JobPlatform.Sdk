# Ferremundo.JobPlatform.Sdk

Reusable SDK repository for Ferremundo.JobPlatform.

Contains only:
- Ferremundo.JobPlatform.Contracts
- Ferremundo.JobPlatform.Client

## GitHub Packages

`Ferremundo.JobPlatform.Client` now consumes:

- `Ferremundo.Integrations.Rest`

Before restoring this SDK, configure GitHub Packages locally.

Example:

```powershell
dotnet nuget add source https://nuget.pkg.github.com/danielSempertegui/index.json --name github-daniel --username danielSempertegui --password <GITHUB_PAT> --store-password-in-clear-text
```

Use a token with at least `read:packages`. If GitHub requires it for your account setup, include `repo` as well.
