<!-- region Generated -->
# Az.EdgeAction
This directory contains the PowerShell module for the EdgeAction service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.EdgeAction`, see [how-to.md](how-to.md).
<!-- endregion -->

## Install the development tools

The following versions were used for stable API generation. The installer pins the npm and PowerShell packages exactly. It accepts compatible native runtimes (Node.js 20+, PowerShell 7.3+, and .NET SDK 8+) rather than downgrading an existing installation.

| Tool | Validated version | Installation |
| --- | --- | --- |
| Node.js | 20.20.2 | Native Node.js or nvm |
| npm | 10.8.2 | Included with the validated Node.js installation |
| PowerShell | 7.6.6 | Native PowerShell, not the npm `pwsh` package |
| .NET SDK | 10.0.401 | Native SDK, not the npm `dotnet` package |
| AutoRest CLI | 3.8.0 | Installed locally by the script |
| AutoRest core | 3.10.9 | Installed locally beside the CLI |
| AutoRest PowerShell extension | 4.0.758 | Pinned below; downloaded by AutoRest on first generation |
| AutoRest modelerfour extension | 4.26.2 | Pinned below; downloaded by AutoRest on first generation |
| Pester | 4.10.1 | Saved locally by the script |
| platyPS | 0.14.2 | Saved locally by the script |

### 1. Install native prerequisites

On Windows, with nvm already installed:

```powershell
nvm install 20.20.2
nvm use 20.20.2
node --version
npm --version
```

Install the native [PowerShell 7.6.6 x64 MSI](https://github.com/PowerShell/PowerShell/releases/download/v7.6.6/PowerShell-7.6.6-win-x64.msi) and [.NET SDK 10.0.401 x64 installer](https://builds.dotnet.microsoft.com/dotnet/Sdk/10.0.401/dotnet-sdk-10.0.401-win-x64.exe), then open a fresh native PowerShell window. Native installers may require administrator approval. Do not install `pwsh` or `dotnet` through npm.

For other operating systems or architectures, use the matching packages from the [PowerShell 7.6.6 release](https://github.com/PowerShell/PowerShell/releases/tag/v7.6.6), [Node.js 20.20.2 distribution](https://nodejs.org/dist/v20.20.2/), and [.NET 10 downloads](https://dotnet.microsoft.com/download/dotnet/10.0). The development-tools script does not install or change machine-wide native runtimes.

### 2. Install and activate repository-local dependencies

Run from the `azure-powershell` repository root, in the PowerShell process where you will generate and build:

```powershell
& .\tools\BuildScripts\Install-EdgeActionDevelopmentTools.ps1
```

If your environment uses Microsoft's approved package-feed proxy, use this instead:

```powershell
& .\tools\BuildScripts\Install-EdgeActionDevelopmentTools.ps1 -UseMicrosoftPackageFeedProxy
```

The script installs under `artifacts/edgeaction-tools`, prepends the local CLI and native .NET to `PATH`, adds the pinned PowerShell modules to `PSModulePath`, and sets `autorest_registry` to npm's configured registry. It isolates the AutoRest extension cache using `AUTOREST_HOME`. The proxy switch also sets a process-local `RestoreSources` override that retains the repository's local and Azure NuGet feeds. It does not edit global npm configuration, profiles, `NuGet.Config`, or certificate settings.

In each new PowerShell window, reactivate without downloading packages:

```powershell
& .\tools\BuildScripts\Install-EdgeActionDevelopmentTools.ps1 -ActivateOnly
# Include -UseMicrosoftPackageFeedProxy again if that environment requires it.
Get-Command node, autorest, pwsh, dotnet | Select-Object Name, Source
autorest --info
```

Use `-NpmRegistry <approved-https-registry>` for another registry, or `-DotNetPath <native-dotnet-executable>` for a nonstandard SDK installation. Invoke the script with `&` in the current process, not `pwsh -File`: environment changes in a child process do not activate tools in its parent.

## Generate and build

After installation/activation, stay at the repository root:

```powershell
$repoRoot = (Get-Location).Path
$ErrorActionPreference = 'Stop'
$PSNativeCommandUseErrorActionPreference = $true

& .\tools\BuildScripts\PrepareAutorestModule.ps1 -RepoRoot $repoRoot -ModuleRootName EdgeAction -ForceRegenerate
& .\tools\BuildScripts\BuildModules.ps1 -RepoRoot $repoRoot -Configuration Debug -TargetModule EdgeAction
```

Preparation regenerates only EdgeAction using this README, builds its proxies and help, and places generated source under `generated/EdgeAction/EdgeAction.Autorest`. Building produces `artifacts/Debug/Az.EdgeAction` and its Accounts dependency. Do not pass `-ForceRegenerate` to `BuildModules.ps1`, which would also force regeneration of Accounts. The generator log is `artifacts/autorest/EdgeAction/EdgeAction.Autorest.log`.

## Run and validate

Import the built module only after the build finishes:

```powershell
Import-Module .\artifacts\Debug\Az.EdgeAction\Az.EdgeAction.psd1 -Force
Get-Command -Module Az.EdgeAction
Get-Help Update-AzEdgeActionVersion -Full

Import-Module Pester -RequiredVersion 4.10.1
$result = Invoke-Pester -Script .\src\EdgeAction\EdgeAction.Autorest\test\StableApi.Tests.ps1 -PassThru
if ($result.FailedCount -gt 0) { throw "$($result.FailedCount) stable API contract tests failed." }
```

These contract tests do not access Azure. For an authorized, read-only live check, sign in to the intended subscription and query an existing resource:

```powershell
Connect-AzAccount -Subscription '<subscription-id>'
Get-AzEdgeAction -ResourceGroupName '<resource-group>' -Name '<edge-action>'
```

Exit the validation shell before rebuilding to release Windows assembly locks. Existing scenario recordings target the preview API and require authorized re-recording for the stable API; do not replace their API-version strings. See [how-to.md](how-to.md) for parent-help regeneration, playback limitations, and troubleshooting.

### AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
# Pin the stable API from Azure/azure-rest-api-specs#46715.
commit: 4f04246403c54561b9441ec356d9aa57273fb4c1
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/EdgeActions/stable/2026-10-01/openapi.json

# Keep EdgeAction generation reproducible without changing other modules.
use-extension:
  "@autorest/powershell": "4.0.758"
  "@autorest/modelerfour": "4.26.2"

# For new RP, the version is 0.1.0
module-version: 0.1.1
# Normally, title is the service name
title: EdgeAction
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true

resourcegroup-append: true
nested-object-to-string: true

directive:
  # ARM POST operations require an empty body for ASP.NET pipeline compatibility
  # The getVersionCode and swapDefault operations need {} body even though swagger doesn't define request body
  - from: source-file-csharp
    where: $
    transform: |
      $ = $.replace(
        /var request = new global::System\.Net\.Http\.HttpRequestMessage\(Microsoft\.Azure\.PowerShell\.Cmdlets\.EdgeAction\.Runtime\.Method\.Post, _url\);\s*await eventListener\.Signal\(Microsoft\.Azure\.PowerShell\.Cmdlets\.EdgeAction\.Runtime\.Events\.RequestCreated, request\.RequestUri\.PathAndQuery\)/gm,
        'var request = new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.Method.Post, _url);\n                request.Content = new global::System.Net.Http.StringContent("{}", global::System.Text.Encoding.UTF8, "application/json");\n                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery)'
      );
      return $;

  # Remove the unexpanded parameter set
  # For New-* cmdlets, ViaIdentity is not required
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Patch$|^PatchViaIdentity$
    remove: true
  
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  
  # Fix SubscriptionId parameter type conflict - keep only single string variant
  - where:
      parameter-name: SubscriptionId
    set:
      parameter-name: SubscriptionId

  # Format table to exclude system metadata
  - where:
      model-name: .*
    set:
      format-table:
        exclude-properties:
          - SystemData
          - SystemDataCreatedAt
          - SystemDataCreatedBy
          - SystemDataCreatedByType
          - SystemDataLastModifiedAt
          - SystemDataLastModifiedBy
          - SystemDataLastModifiedByType

  # Hide DeployVersionCode to customize with file deployment
  - where:
      verb: Deploy
      subject: EdgeActionVersionCode
    hide: true
  
  # Hide GetVersionCode to customize with empty body for ARM POST requirement
  - where:
      verb: Get
      subject: EdgeActionVersionCode
    hide: true
  
  # Hide Switch-AzEdgeActionVersionDefault to customize with empty body for ARM POST requirement
  - where:
      verb: Switch
      subject: EdgeActionVersionDefault
    hide: true
  
  # Remove array variant of SubscriptionId to fix parameter type conflict
  - where:
      parameter-name: SubscriptionId
    clear-alias: true
```
