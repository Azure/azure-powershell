# How-To
This document describes how to develop for `Az.EdgeAction`.

## Regenerating the stable API

First follow [Install the development tools](README.md#install-the-development-tools) for exact validated versions and native prerequisites. From the repository root, run `& ./tools/BuildScripts/Install-EdgeActionDevelopmentTools.ps1` to install repository-local packages and activate the current PowerShell process. Use `-ActivateOnly` in later shells, and `-UseMicrosoftPackageFeedProxy` when that approved proxy is required. Installing npm packages named `dotnet` or `pwsh` does not replace native runtime installation.

`README.md` pins both the PowerShell generator and the specification commit. The `2026-10-01` input comes from [Azure/azure-rest-api-specs#46715](https://github.com/Azure/azure-rest-api-specs/pull/46715). Review the pinned commit rather than relying on a PR description or a moving branch.

From the repository root:

```powershell
$repoRoot = (Get-Location).Path
$ErrorActionPreference = 'Stop'
$PSNativeCommandUseErrorActionPreference = $true

Get-Command node, npm, autorest, pwsh, dotnet | Select-Object Name, Source
node --version
pwsh --version
dotnet --version
npm view '@autorest/powershell@4.0.758' version --registry $env:autorest_registry

& ./tools/BuildScripts/PrepareAutorestModule.ps1 -RepoRoot $repoRoot -ModuleRootName EdgeAction -ForceRegenerate
& ./tools/BuildScripts/BuildModules.ps1 -RepoRoot $repoRoot -Configuration Debug -TargetModule EdgeAction
```

Only preparation uses `-ForceRegenerate`: passing it to `BuildModules.ps1` would also force regeneration of the Accounts dependency. Preparation invokes AutoRest from this source directory, builds the generated proxies and Markdown help in `docs`, and moves generated output into `generated/EdgeAction/EdgeAction.Autorest`. The build assembles the module and its Accounts dependency under `artifacts/Debug`. Keep the original module GUID and release-managed assembly metadata when reviewing the generated diff.

After changing examples or API descriptions, refresh the parent module's help using the same platyPS operations as `AdaptAutorestModule.ps1`:

```powershell
Import-Module ./artifacts/Debug/Az.EdgeAction/Az.EdgeAction.psd1 -Force
Import-Module platyPS
Import-Module ./tools/BuildScripts/HelpMarkDown.psm1
$helpPath = Join-Path $repoRoot 'src/EdgeAction/EdgeAction/help'
Get-ChildItem ./src/EdgeAction/EdgeAction.Autorest/docs -Filter '*-*.md' |
    Copy-Item -Destination $helpPath -Force
Update-MarkdownHelpModule -Path $helpPath -RefreshModulePage -AlphabeticParamsOrder -UseFullTypeName -ExcludeDontShow
Get-ChildItem $helpPath -Filter '*-*.md' | ForEach-Object {
    Remove-CommonParameterFromMarkdown -Path $_.FullName -ParameterName 'ProgressAction'
}
New-ExternalHelp -Path $helpPath -OutputPath ./artifacts/Debug/Az.EdgeAction -Force
```

Run builds before importing the module into the validation shell. Exit that shell before rebuilding; Windows locks loaded assemblies.

### Resolving package errors

AutoRest core 3.10.9 defaults to `https://registry.npmjs.org` for extension resolution and installation, independently of npm's configured registry. The installer sets `autorest_registry` to the selected registry for the current process. Without the installer, if `npm view` succeeds through an approved registry but AutoRest reports `Unable to resolve package '@autorest/powershell@4.x'`, set `$env:autorest_registry = (npm config get registry).Trim()` in the process that runs generation. In Git Bash the equivalent is `export autorest_registry="$(npm config get registry)"`. Generator v4 exists; the deprecation warning does not cause this resolution failure. Do not downgrade to v3 or disable TLS verification.

On Windows, if `Get-Command dotnet` identifies an obsolete npm shim and the native SDK is installed at the standard location, prepend it for the current process:

```powershell
$env:PATH = "C:\Program Files\dotnet;$env:PATH"
dotnet --version
```

A subsequent NuGet TLS error is separate from AutoRest. Do not edit `NuGet.Config`. In environments configured to use Microsoft's package-feed proxy, the following process-local override retains the repository's local and Azure feeds and uses that proxy for public NuGet packages:

```powershell
$env:RestoreSources = @(
    (Join-Path $repoRoot 'tools/LocalFeed')
    'https://pkgs.dev.azure.com/azclitools/public/_packaging/azure-powershell/nuget/v3/index.json'
    'https://packagefeedproxy.microsoft.io/nuget/v3/index.json'
) -join ';'
```

Use only an organization-approved mirror. Set this before preparation/build, and leave certificate validation enabled. Review `artifacts/autorest/EdgeAction/EdgeAction.Autorest.log` for generator errors and the build output for restore/compiler errors.

### Offline validation

Use Pester 4.10.1, as required by the repository's AutoRest test harness. The development-tools installer saves this version locally and adds its directory to `PSModulePath`.

```powershell
Import-Module Pester -RequiredVersion 4.10.1
Import-Module ./artifacts/Debug/Az.EdgeAction/Az.EdgeAction.psd1 -Force
Get-Command -Module Az.EdgeAction
Get-Help Update-AzEdgeActionVersion -Full
$result = Invoke-Pester -Script ./src/EdgeAction/EdgeAction.Autorest/test/StableApi.Tests.ps1 -PassThru
if ($result.FailedCount -gt 0) { throw "$($result.FailedCount) stable API contract tests failed." }
git diff --check
```

`StableApi.Tests.ps1` uses synthetic HTTP responses to check stable request URLs, update payloads, DELETE status handling, and custom version-code/default-version behavior without Azure access. These tests are not live service recordings.

The existing scenario recordings target `2025-12-01-preview` and cannot replay requests for `2026-10-01`. They require fresh recording against an authorized stable-API test environment; do not replace API-version strings to fabricate stable recordings. Inspect the Pester summary or result XML, not just the generated runner's exit code, which can be zero despite failed tests.

## Building `Az.EdgeAction`
To build, run the `build-module.ps1` at the root of the module directory. This will generate the proxy script cmdlets that are the cmdlets being exported by this module. After the build completes, the proxy script cmdlets will be output to the `exports` folder. To read more about the proxy script cmdlets, look at the [README.md](exports/README.md) in the `exports` folder.

## Creating custom cmdlets
To add cmdlets that were not generated by the REST specification, use the `custom` folder. This folder allows you to add handwritten `.ps1` and `.cs` files. Currently, we support using `.ps1` scripts as new cmdlets or as additional low-level variants (via `ParameterSet`), and `.cs` files as low-level (variants) cmdlets that the exported script cmdlets call. We do not support exporting any `.cs` (dll) cmdlets directly. To read more about custom cmdlets, look at the [README.md](custom/README.md) in the `custom` folder.

## Generating documentation
To generate documentation, the process is now integrated into the `build-module.ps1` script. If you don't want to run this process as part of `build-module.ps1`, you can provide the `-NoDocs` switch. If you want to run documentation generation after the build process, you may still run the `generate-help.ps1` script. Overall, the process will look at the documentation comments in the generated and custom cmdlets and types, and create `.md` files into the `docs` folder. Additionally, this pulls in any examples from the `examples` folder and adds them to the generated help markdown documents. To read more about examples, look at the [README.md](examples/README.md) in the `examples` folder. To read more about documentation, look at the [README.md](docs/README.md) in the `docs` folder.

## Testing `Az.EdgeAction`
To test the cmdlets, we use [Pester](https://github.com/pester/Pester). Tests scripts (`.ps1`) should be added to the `test` folder. To execute the Pester tests, run the `test-module.ps1` script. This will run all tests in `playback` mode within the `test` folder. To read more about testing cmdlets, look at the [README.md](examples/README.md) in the `examples` folder.

## Packing `Az.EdgeAction`
To pack `Az.EdgeAction` for distribution, run the `pack-module.ps1` script. This will take the contents of multiple directories and certain root-folder files to create a `.nupkg`. The structure of the `.nupkg` is created so it can be loaded part of a [PSRepository](https://learn.microsoft.com/powershell/module/powershellget/register-psrepository). Additionally, this package is in a format for distribution to the [PSGallery](https://www.powershellgallery.com/). For signing an Azure module, please contact the [Azure PowerShell](https://github.com/Azure/azure-powershell) team.

## Module Script Details
There are multiple scripts created for performing different actions for developing `Az.EdgeAction`.
- `build-module.ps1`
  - Builds the module DLL (`./bin/Az.EdgeAction.private.dll`), creates the exported cmdlets and documentation, generates custom cmdlet test stubs and exported cmdlet example stubs, and updates `./Az.EdgeAction.psd1` with Azure profile information.
  - **Parameters**: [`Switch` parameters]
    - `-Run`: After building, creates an isolated PowerShell session and loads `Az.EdgeAction`.
    - `-Test`: After building, runs the `Pester` tests defined in the `test` folder.
    - `-Docs`: After building, generates the Markdown documents for the modules into the `docs` folder.
    - `-Pack`: After building, packages the module into a `.nupkg`.
    - `-Code`: After building, opens a VSCode window with the module's directory and runs (see `-Run`) the module.
    - `-Release`: Builds the module in `Release` configuration (as opposed to `Debug` configuration).
    - `-NoDocs`: Supresses writing the documentation markdown files as part of the cmdlet exporting process.
    - `-Debugger`: Used when attaching the debugger in Visual Studio to the PowerShell session, and running the build process without recompiling the DLL. This suppresses running the script as an isolated process.
- `run-module.ps1`
  - Creates an isolated PowerShell session and loads `Az.EdgeAction` into the session.
  - Same as `-Run` in `build-module.ps1`.
  - **Parameters**: [`Switch` parameters]
    - `-Code`: Opens a VSCode window with the module's directory.
      - Same as `-Code` in `build-module.ps1`.
- `generate-help.ps1`
  - Generates the Markdown documents for the modules into the `docs` folder.
  - Same as `-Docs` in `build-module.ps1`.
- `test-module.ps1`
  - Runs the `Pester` tests defined in the `test` folder.
  - Same as `-Test` in `build-module.ps1`.
- `pack-module.ps1`
  - Packages the module into a `.nupkg` for distribution.
  - Same as `-Pack` in `build-module.ps1`.
- `generate-help.ps1`
  - Generates the Markdown documents for the modules into the `docs` folder.
  - Same as `-Docs` in `build-module.ps1`.
  - This process is now integrated into `build-module.ps1` automatically. To disable, use `-NoDocs` when running `build-module.ps1`.
- `export-surface.ps1`
  - Generates Markdown documents for both the cmdlet surface and the model (class) surface of the module.
  - These files are placed into the `resources` folder.
  - Used for investigating the surface of your module. These are *not* documentation for distribution.
- `check-dependencies.ps1`
  - Used in `run-module.ps1` and `test-module.ps1` to verify dependent modules are available to run those tasks.
  - It will download local (within the module's directory structure) versions of those modules as needed.
  - This script *does not* need to be ran by-hand.