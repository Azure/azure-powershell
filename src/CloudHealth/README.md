# Develop Az.CloudHealth

Requirements: [module manifest](CloudHealth/Az.CloudHealth.psd1).

## Build

PowerShell, repository root:

```powershell
pwsh ./tools/BuildScripts/BuildModules.ps1 -TargetModule CloudHealth
Import-Module ./artifacts/Debug/Az.CloudHealth/Az.CloudHealth.psd1
Get-Command -Module Az.CloudHealth
```

Add `-ForceRegenerate` to force TypeSpec regeneration.

## Change inputs

- Specification pin: [tsp-location.yaml](CloudHealth.Autorest/tsp-location.yaml).
- Cmdlets, parameters, models: [tspconfig.yaml](CloudHealth.Autorest/tspconfig.yaml).
- Handwritten cmdlets: [custom/](CloudHealth.Autorest/custom/README.md). Export C# variants through scripts.
- Help: edit cmdlet comments and [examples/](CloudHealth.Autorest/examples/), then rebuild.

## Recording and playback

```powershell
$module = './artifacts/Debug/Az.CloudHealth/CloudHealth.Autorest'
& "$module/test-module.ps1" -Playback
```

Replace `-Playback` with `-Record` to capture Azure responses, or `-Live` to skip saving them.
For record/live, set `$env:AZURE_TEST_SUBSCRIPTION_ID` and select the matching Az context.

1. After recording, sanitize private values consistently across recordings and `env.json` in `$module/test/`.
2. Copy both to [source tests](CloudHealth.Autorest/test/).
3. Copy source fixtures into `$module/test/` before verifying playback.

## Test resource cleanup

- Record/live: [setupEnv](CloudHealth.Autorest/test/utils.ps1) creates a fresh group; cleanup deletes only that group, including after setup failures, and rejects subscription changes.
- Playback: no Azure resource creation or deletion.
- Interrupted process: check for a leftover group before retrying.

## Standalone module commands

Run in complete TypeSpec emitter output, before the repository build separates source and generated files:

| Task | Command |
| --- | --- |
| Build DLL, exports, and docs | `./build-module.ps1` |
| Build without docs | `./build-module.ps1 -NoDocs` |
| Load an isolated module session | `./run-module.ps1` |
| Regenerate help | `./generate-help.ps1` |
| Create a `.nupkg` | `./pack-module.ps1` |
| Inspect cmdlets and models in `resources/` | `./export-surface.ps1` |
