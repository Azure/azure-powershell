# Developing Az.EdgeAction

This page covers manual development-environment setup, repository generation/build/help refresh, and automated scenario tests. The module-local generation wrapper introduced here uses existing repository tooling; it is not an installer.

**Run the generation wrapper and tests from `src\EdgeAction\EdgeAction.Autorest`.** One-time build-tool setup starts at the repository root. Neither wrapper needs a caller-defined root variable; tests also need no user-set environment variables.

## Prerequisites and build

Use native runtimes, not npm dotnet or PowerShell shims. The accepted minimums below are not a guarantee that every newer combination has been tested.

| Prerequisite | Minimum | Validated development version | Native installation |
| --- | --- | --- | --- |
| PowerShell | 7.3 | 7.6.6 | [PowerShell installation](https://learn.microsoft.com/powershell/scripting/install/installing-powershell); Windows: `winget install --id Microsoft.PowerShell --exact --source winget` |
| .NET SDK | 8 | 10.0.401 | [SDK downloads](https://dotnet.microsoft.com/download/dotnet/10.0); Windows: `winget install --id Microsoft.DotNet.SDK.10 --exact --source winget` |
| Node.js | 20 | 20.20.2 with npm 10.8.2 | [Node.js 20.20.2](https://nodejs.org/download/release/v20.20.2/); with an existing nvm installation recommended: `nvm install 20.20.2`, then `nvm use 20.20.2` |

Install missing runtimes, then reopen native PowerShell. The winget commands install the available package version, not necessarily the validated patch; use the linked release downloads for exact versions. npm is included with Node.js.

The wrapper checks these minimum versions before preparation changes any generated files; the validated patch versions are not enforced. It selects a native SDK executable from PATH, or the standard Windows Program Files installation, ahead of npm dotnet shims. If no native SDK is available, install it or correct PATH. No caller-defined root variable or environment assignments are required.

### Install pinned developer dependencies

Run this manual setup once, skipping installs if the exact versions are already present. **platyPS 0.14.2 is required for parent Markdown and XML help**, even though AutoRest can generate its own command docs without it. These commands use the approved Microsoft npm proxy. npm installation is global, while PowerShell modules are installed for the current user.

```powershell
npm install --global autorest@3.8.0 @autorest/core@3.10.9 --registry=https://packagefeedproxy.microsoft.io/npm/
Install-Module platyPS -RequiredVersion 0.14.2 -Scope CurrentUser -Repository PSGallery

Get-Command autorest | Select-Object Name, Source
npm list --global --depth=0 autorest '@autorest/core'
```

The wrapper checks the active AutoRest CLI's installed package metadata for **3.8.0** and loads exactly **platyPS 0.14.2**. Core **3.10.9** is an installation/reproducibility pin, not a checked selected-core version: preflight does not launch AutoRest, resolve extensions or populate its cache.

Inside its isolated child process, the wrapper sets `autorest_registry` to `https://packagefeedproxy.microsoft.io/npm/` and `RestoreSources` to the checkout's `tools\LocalFeed`, `https://pkgs.dev.azure.com/azclitools/public/_packaging/azure-powershell/nuget/v3/index.json`, and `https://packagefeedproxy.microsoft.io/nuget/v3/index.json`. These build-only overrides replace inherited values without changing the caller's environment, global npm configuration, `NuGet.Config`, TLS validation or vulnerability auditing. No repeated feed setup is needed.

### Check inputs, prepare, and build

1. **Update the specification input before generation.** Edit the AutoRest YAML in `src\EdgeAction\EdgeAction.Autorest\README.md`: set `commit` to the immutable `Azure/azure-rest-api-specs` commit SHA containing the intended changes, not a branch name, and set `input-file` to the OpenAPI JSON path at that commit. The current branch uses this fragment:

```yaml
commit: 0f8c562ea012f15798c44473e0ecc825f6f52495
input-file:
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/EdgeActions/stable/2026-10-01/openapi.json
```

Replace the SHA and API-version/path for your chosen specification, and confirm that the JSON file exists at that exact commit in `Azure/azure-rest-api-specs`. Update only these fields; preserve the README's other configuration and directives.

2. **Review the input change and metadata.** Review the README diff; optionally commit the input change separately for traceability before regenerating. Keep the existing `generate-info.json` and `Properties\AssemblyInfo.cs`. If either was removed or rewritten by direct generation, review the diff and recover only unintended changes from this branch; do not invent generation IDs or discard intentional edits.

3. **Run the module-local wrapper in the configured native shell to generate and build files.** From the repository root, run:

```powershell
Set-Location .\src\EdgeAction\EdgeAction.Autorest
git diff HEAD -- README.md generate-info.json Properties\AssemblyInfo.cs
& ..\tools\GenerationScripts\Update-EdgeActionGeneratedFiles.ps1
```

Close shells holding built assemblies before rebuilding, and do not edit the module concurrently. The script loads platyPS 0.14.2, runs shared `PrepareAutorestModule.ps1 -ForceRegenerate` for EdgeAction, then `BuildModules.ps1 -Configuration Debug -TargetModule EdgeAction`. The build includes Accounts using the repository helper's normal preparation behavior, without forcing its regeneration. Normal AutoRest extension resolution and NuGet restore can download generator/build packages; the wrapper does not install developer prerequisites or configure machine-wide feeds.

On Windows, the wrapper first probes `artifacts\Debug\Az.Accounts\Microsoft.Azure.PowerShell.AssemblyLoading.dll` for exclusive writable access **without writing to it**, before prerequisite loading or Prepare can change generated output. Absent artifacts are allowed; locked or inaccessible files stop with the exact path. Close the owning PowerShell session, including older terminal tabs; opening a new window or running `Remove-Module` does not unload assemblies held by another process. Process Explorer's **Find Handle or DLL** search can identify the owner. The wrapper never terminates processes or changes permissions.

On failure only, the script checks PowerShell processes for that exact loaded DLL and reports verified process names/PIDs. Run `$PID` in candidate terminals to find the matching session, finish/save its work, and close it normally. The error also prints an optional `Stop-Process -Id <detected-PID> -Confirm` command for each verified holder; use it from another terminal only after rechecking the PID, because it interrupts all work in that process. Inaccessible/exited processes produce an explicit incomplete-inspection warning, not proof that no owner exists. The message includes the exact DLL path for Process Explorer and the generation retry command from the module directory.

This is a focused check for the recurring Accounts DLL conflict, not a scan of every build output. Other files or a process loading the DLL after preflight can still cause a build failure. The Windows-specific probe is skipped on other platforms. The wrapper's own Accounts/EdgeAction imports happen only after the build, inside its short-lived child; they do not load those assemblies into your calling shell.

The shared prepare helper already passes `-DisableAfterBuildTasks` to its generated build script. Do not add that switch to Prepare or the wrapper. After building, the script imports built Accounts/EdgeAction and runs `Update-MarkdownHelpModule`, the repository's common-parameter cleanup, and `New-AzMamlHelp`, then copies refreshed Markdown/XML to their destinations. It retains the parent module-page GUID/description. Explicit parameter-set metadata prevents platyPS 0.14.2 from dropping default-only syntax from XML; detailed help consistency checks live in tests, not the runtime script.

4. **Review the results before committing.** The wrapper uses upstream delete/replace behavior for generated outputs, regardless of Git status. You can rerun without committing or undoing the previous generated results. Save any manual edits to generated files or parent cmdlet help first: there is no custom merge, backup or recovery system. Maintain examples/customizations in their source folders; refreshed command help comes from generated docs, not previous parent cmdlet pages. The maintained how-to is restored because AutoRest otherwise replaces it with a generic scaffold.

Before preparation, the wrapper prints the README's configured commit and input-file excerpt, with variables unresolved, and confirms forced regeneration; generation IDs are bookkeeping, not specification SHAs or proof of the effective remote input.

Prepare retains the existing generation ID and generated module GUID through the repository's own handling; bare AutoRest does not perform that repository preparation and can replace metadata. Failures may leave partial output. Fix the cause and rerun, recovering missing metadata manually if necessary. Help intermediates under `artifacts\edgeaction-help-<id>` are new output, not backups. There is no automatic rollback, git reset, staging or commit; the index is unchanged.

```powershell
git status --short
git diff -- . ..\EdgeAction\help ..\..\..\generated\EdgeAction
```

Do **not** run bare `autorest` in `src`, reset its cache, or rerun source `build-module.ps1`/Adapt as a help repair. Preparation relocates the standalone exports and manifest; that source directory is no longer a complete standalone module. Installing platyPS alone does not refresh existing help. The README owns the specification input; shared configuration selects generator `4.x`, not an exact extension version, so review runtime-generator changes too.

| Location | Ownership |
| --- | --- |
| `src\EdgeAction\EdgeAction.Autorest` | Maintained configuration, customizations, examples, and tests |
| `src\EdgeAction\tools\GenerationScripts` | Single generation/build/help script and offline tests |
| `src\EdgeAction\EdgeAction\help` | Reviewed parent-module command help and module page |
| `src\EdgeAction\tools\TestScripts` | Module-local scenario runner, `EdgeAction.TestRunner.psm1`, configuration, and offline runner tests |
| `generated\EdgeAction\EdgeAction.Autorest` | Generated code and standalone scripts |
| `artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest` | Built scenario harness and copied tests |

Standalone `build-module.ps1`/`test-module.ps1` workflows assume a complete colocated generated module. In this repository, use the wrapper above and the artifact test runner below instead. Artifact Markdown lives in `artifacts\Debug\Az.EdgeAction\help`; the wrapper also writes `Az.EdgeAction-help.xml` in that artifact module directory.

Generator errors are logged in `artifacts\autorest\EdgeAction\EdgeAction.Autorest.log`; NuGet/compiler errors are in build output. Recheck native executable resolution and process-local feeds before retrying a failed build.

If preparation reports only a nested `build-module.ps1` process failure, inspect the current run's `obj\project.nuget.cache` for restore errors; old cache entries may belong to an earlier attempt. `NU1900` with an unreachable `https://api.nuget.org/v3/index.json` means vulnerability-data retrieval failed during restore (warnings are errors), not that AutoRest failed. The wrapper now supplies the approved NuGet proxy automatically. If restore still fails, check the reported source and network access to the configured feeds before retrying; do not disable auditing/TLS or change `NuGet.Config` to hide the error. Build-feed configuration does not apply to scenario-test invocation.

## Configure and run scenario tests

Use native PowerShell 7.3+ and **run all test commands from `src\EdgeAction\EdgeAction.Autorest`**. From the correct checkout's repository root, enter the module once:

```powershell
Set-Location .\src\EdgeAction\EdgeAction.Autorest
```

If your shell is elsewhere, navigate directly to that folder in the intended checkout using its full path. Stay there for the remaining test instructions, including offline runner tests. No previously assigned path variables or user-set environment variables are required. The runner derives repository and artifact paths from its own script location.

The runner switches its child process to the artifact harness directory before invoking tests, so relative assembly paths use the built artifact DLLs rather than source-folder copies. Your shell stays in the source module directory.

Confirm built artifacts and install any missing test prerequisites below before configuring the runner. It does not install native tools or build EdgeAction; authorized Record/Live runs automatically generate/build missing Resources test support as described below.

### Confirm built artifacts

If artifacts are missing or source files changed, follow the separate [Check inputs, prepare, and build](#check-inputs-prepare-and-build) instructions, then return to this module directory using the test entry step above. The runner requires `artifacts\Debug\Az.Accounts\Az.Accounts.psd1` and `artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest\test-module.ps1` under the invoked script's checkout; it does not build them automatically.

### Install test prerequisites

#### Install Pester 4.10.1 only if missing

The runner automatically discovers Pester 4.10.1, validates its manifest/version, and imports an isolated temporary copy before running tests. **No manual discovery or verification step is required.** It does not install Pester or change your installed versions or global settings.

If Pester 4.10.1 is not installed, install it once for the current user. Other Pester versions can remain installed alongside it:

```powershell
Install-Module -Name Pester -RequiredVersion 4.10.1 -Scope CurrentUser -Repository PSGallery -Force
```

If adding 4.10.1 alongside Pester 5.7.0 fails with the known Authenticode issuer-chain mismatch (publisher `CN=Jakub Jares` in both, but `DigiCert Assured ID Root CA` versus `DigiCert Trusted Root G4`), **only for that error and an intentionally trusted PSGallery source**, retry:

```powershell
Install-Module -Name Pester -RequiredVersion 4.10.1 -Scope CurrentUser -Repository PSGallery -Force -SkipPublisherCheck
```

[`-SkipPublisherCheck`](https://learn.microsoft.com/powershell/module/powershellget/install-module?view=powershellget-2.x#-skippublishercheck) bypasses the publisher-continuity check for this installation; it does **not** establish package trust or change global trust, TLS, or execution policy. Do not use it for arbitrary installation errors. Keep Pester 5 installed; the runner selects 4.10.1 explicitly. An existing trusted 4.10.1 installation selected through `PesterPath` below avoids installation altogether.

Leave `PesterPath = ''` for automatic discovery. If the runner cannot find an existing 4.10.1 installation, reopen native PowerShell or set `PesterPath` in the optional local settings file below to its **absolute manifest filename**, for example `C:\tools\modules\Pester\4.10.1\Pester.psd1`, not a directory or `Pester.psm1`. The runner validates that file too; no reinstall or separate verification is needed. `PesterPath` is a settings key, not a runner parameter.

### Test Settings

**No local settings file is required.** The runner always loads `..\tools\TestScripts\TestSettings.psd1`. Without a local file or `-ConfigPath`, these shared defaults are used unchanged: Azure public cloud (`AzureCloud`), automatic Pester discovery, and no subscription.

Create `TestSettings.local.psd1` beside it only when you need personal overrides, such as Brazilus, a test subscription, or a nonstandard Pester path. The runner loads this optional file automatically **over the shared defaults**; settings omitted from it still use `TestSettings.psd1`.

| File | Role |
| --- | --- |
| `TestSettings.psd1` | Required, tracked shared defaults; used alone when no override is selected. |
| `TestSettings.local.psd1` | Optional, Git-ignored personal overrides; loaded automatically when present. |
| `TestSettings.local.example.psd1` | Optional Brazilus starter template; never loaded automatically. |

For Brazilus, copy the example once, then edit the local copy with your authorized test subscription. This command preserves an existing local file:

```powershell
if (-not (Test-Path ..\tools\TestScripts\TestSettings.local.psd1)) {
    Copy-Item ..\tools\TestScripts\TestSettings.local.example.psd1 ..\tools\TestScripts\TestSettings.local.psd1
}
```

To choose a different override file, pass `-ConfigPath '<path>'`; it replaces the automatic local override, not the shared defaults. Relative paths are resolved from your current working directory. To ignore an existing local file and use only shared defaults, pass `-ConfigPath ..\tools\TestScripts\TestSettings.psd1`.

A nonempty `-SubscriptionId` argument takes precedence over either settings file. `-Mode` (default `Playback`), `-TestName`, `-AllowResourceChanges`, and `-Login` are command-line options, not settings keys.

These are the only supported settings keys; values must be strings. Omitted keys inherit the shared defaults.

| Key | Shared default and meaning | Record/Live requirement |
| --- | --- | --- |
| `SubscriptionId` | `''`; expected subscription GUID, not its display name. The example also leaves it empty. | Supply an authorized test subscription here or with `-SubscriptionId`; it must match the authenticated context. |
| `EnvironmentName` | `AzureCloud`; the example uses `Brazilus`. No other environment names are accepted. | The selected Az environment must already be registered and match the context. |
| `ResourceManagerUrl` | `https://management.azure.com/` for AzureCloud; the example uses `https://brazilus.management.azure.com/` for Brazilus. | Must match the selected environment and context. Arbitrary endpoints are rejected. |
| `Audience` | `https://management.core.windows.net/` for both environments. | Must match the environment's authentication audience and context. |
| `ResourceGroupName` | `powershelltests`; current source tests hardcode this group and resource names. Other groups are rejected. | The group must already exist and be readable; configuration does not retarget tests. |
| `ApiVersion` | `2026-10-01`; validation of the expected API, not a way to rewrite generated requests or recordings. | Keep this value; other versions are rejected in every mode. |
| `PesterPath` | `''`; discover installed Pester 4.10.1, or specify an absolute path to its `Pester.psd1` manifest. | The same installed version is required for all modes; the runner does not install it. |

Copying the Brazilus example changes settings only; it does not register an Az environment or sign in. An existing Brazilus local override continues to take precedence over public defaults. Neither configuration proves stable-API availability or permissions. Do not put real subscription IDs, tenants, credentials, or tokens in the tracked defaults or example.

Results and recordings remain in the artifact harness directory. Successful Record runs also copy eligible outputs to source for unstaged review, as described below. The runner does not back them up.

### Playback

Playback is the default and requires no login:

```powershell
& ..\tools\testscripts\test-edgeaction.ps1
```

Optionally select one describe group:
```powershell
& ..\tools\testscripts\test-edgeaction.ps1 -testname 'get-azedgeaction'
```

Or use shared azurecloud settings explicitly, bypassing any local override:
```powershell
& ..\tools\testscripts\test-edgeaction.ps1 -configpath ..\tools\testscripts\testsettings.psd1
```

Existing preview recordings cannot satisfy stable `2026-10-01` requests. Playback failures are reported, not repaired by rewriting request keys. Skipped tests remain skipped; a run with no executed tests fails.

### Explicit recording or live execution

Review `.\test\*.Tests.ps1` first. The scenarios hardcode resource names and `powershelltests`; even Get scenarios create/delete resources. Configuration **does not** retarget those names. Use an authorized dedicated subscription with no conflicting resources, and create the resource group beforehand. Unsupported resource-group overrides fail rather than silently running elsewhere.

Edit source tests and assertions, then rebuild to refresh artifact tests. There is no manual `setupEnv` or sign-in step inside it: the harness calls it automatically; use the runner's `-Login` option below for authentication.

#### Automatic Resources test support (Record/Live only)

After configuration and `-AllowResourceChanges` checks, the runner loads built Accounts and Pester, then verifies the registered environment before preparing missing or incomplete `Az.Resources.TestSupport` under `$HOME\.PSSharedModules\Resources`. A missing Brazilus registration requires separate confirmation as described below; an unapproved or mismatched registration stops before support setup, login, or scenarios. **Playback skips environment verification and never prepares Resources support.** A complete installed module is validated/imported and reused without downloads or generation.

Missing support requires the native build tools from the build prerequisites above (Node.js 20+, native .NET SDK 8+, installed AutoRest CLI). The runner supplies approved npm/NuGet feeds and native dotnet resolution inside its child process, restores those settings after setup, and does not install native tools or change global configuration. Pester 4.10.1 and built Accounts must already be available.

The runner fills missing artifact `tools\Resources` files from the source module's generated `.\tools\Resources` README/customizations, then invokes the unchanged artifact `check-dependencies.ps1 -NotIsolated -Pester -Resources`. The helper downloads generator/NuGet packages and generates/builds local support, not Azure resources. An incomplete installation is regenerated in place by that helper; complete installations and existing artifact support inputs are not overwritten. Setup reports completion only after successful helper exit, required manifest/script/assembly checks, and module import.

If source support inputs are missing, run the repository generation/build steps first; an empty artifact directory is not a substitute. Setup failures stop before authentication/scenarios and may leave partial local support output; recovery is not transactional. If all required files exist but the module cannot import, inspect that installation rather than replacing it automatically. The original direct `test-module.ps1` does not use this runner's automatic setup.

#### Run with explicit consent

Before Resources setup or `-Login`, the runner uses `Get-AzEnvironment` in its fresh `pwsh -NoProfile` child to verify the configured name, ARM endpoint, and audience. Existing registrations are checked read-only and are never overwritten. A registration made only in another shell is not inherited. An error starting with **Registered Azure environment** identifies this preflight check; **Azure context** identifies the later context check. Errors name the mismatched property without printing subscription IDs or credential-bearing URLs.

If the configured Brazilus environment is missing, an interactive console prompts **[y/N]** before running `Add-AzEnvironment -Name Brazilus -ARMEndpoint 'https://brazilus.management.azure.com/' -Scope CurrentUser`. Only `y` or `yes` approves this separate action: it requests authentication metadata over the network and persistently adds the named environment to the CurrentUser Az profile for future processes; it does not sign in or switch the active context. A blank answer, decline, unavailable console input, or noninteractive execution stops without registration. `-AllowResourceChanges` does not approve registration, and Playback never prompts.

After approval, the runner re-reads and validates the registered endpoints before support setup. A failed registration or unexpected metadata stops the run; any registration already persisted remains, with no rollback. Do not change the discovered audience merely to bypass validation. For unattended runs, use the same command manually in a setup shell with built Accounts imported, then verify `Get-AzEnvironment -Name Brazilus` in a fresh shell using that module before retrying.

```powershell
& ..\tools\TestScripts\Test-EdgeAction.ps1 -Mode Record -AllowResourceChanges -Login -TestName 'Get-AzEdgeAction'
```

That command uses the subscription in local configuration; alternatively add `-SubscriptionId '<authorized-test-subscription-id>'`. Use `-Mode Live` with the same consent flags for live execution without recording. These flags authorize resource mutations, not just HTTP capture.

The runner authenticates with `-Login` inside a child PowerShell process and invokes the artifact harness with `-NotIsolated` in that **same child**, preserving its process-local context. Context autosave is disabled for that child: its login does not switch the calling shell's context, so no production-context reset is needed afterward. The separately approved environment registration persists and is not removed on exit. Without `-Login`, an already-saved matching Az context must be available to the child; a process-only login in the caller is not inherited. Before any scenario, the runner verifies subscription, environment name, ARM endpoint, audience, and read access to the existing resource group. Endpoint selection does not prove that the stable API is deployed or the identity can perform every operation.

#### Record and replay all EdgeAction scenarios

From `src\EdgeAction\EdgeAction.Autorest`, omit `-TestName` to select all EdgeAction scenario groups, **not the entire repository's tests**. Recording creates/deletes real resources in the configured authorized subscription and `powershelltests` resource group:

```powershell
& ..\tools\TestScripts\Test-EdgeAction.ps1 -Mode Record -AllowResourceChanges -Login
```

After recording succeeds, run playback against those artifacts **without rebuilding between these commands**:

```powershell
& ..\tools\TestScripts\Test-EdgeAction.ps1 -Mode Playback
```

Recording a single filtered group does not refresh the other groups' recordings. Outputs remain under `artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest\test`; successful Record runs copy eligible recordings/metadata to source for review as described below. Review source changes and preserve any uncopied outputs before rebuilding. Skipped scenario bodies are not recorded or covered; their groups may still record setup/teardown.

### Results and recording ownership

The child contains Pester's `-EnableExit` so it cannot close the caller. The parent rejects a nonzero child exit and missing, stale, failing, malformed, or all-skipped NUnit results, even if the generated harness reports success. Review the summary and `artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest\test\Az.EdgeAction-TestResults.xml`.

The wrapper loads settings/dependencies, checks the selected live context, and invokes the existing artifact harness in an isolated child. It clears the previous results XML to require a fresh result. **Only after a successful Record run passes fresh-result validation**, it copies recordings written by that run's selected groups to `src\EdgeAction\EdgeAction.Autorest\test`, overwriting those source recordings as **unstaged Git diff changes**. File hashes and modification times distinguish newly written recordings (including deterministic same-content rewrites) from stale artifacts. Playback, Live, failed runs, and unchanged unrelated artifacts never trigger copy-back. The runner never stages or commits files.

The harness writes originals and `env.json` under `artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest\test`. Copy-back includes `env.json` only when needed and compatible with the recording set; a filtered run cannot replace metadata required by untouched source recordings. Subscription/tenant identifiers remain consistent for playback, rather than being rewritten independently. Source files edited during the run stop handoff. Results XML, source test scripts, `localEnv.json`, and other files are never copied.

**Copied for review does not mean sanitized or ready to publish.** The upstream recorder filters `Authorization` headers only. Handoff rejects detected credential-bearing headers, common secret fields, signed URLs, and private keys before any source writes; it does not decode or certify embedded code/archives or comprehensively scan arbitrary payloads. Review and sanitize the Git diff, including identifiers and payloads, before staging or committing. A blocked handoff leaves originals in artifacts and reports the file/reason without printing its contents. After addressing incompatible metadata or sensitive content, manually preserve a reviewed, playback-compatible set; do not bypass the check by staging raw artifacts.

The runner does not back up recordings or roll back partial copy failures. Copy errors fail explicitly and may leave some source changes for inspection. **Preserve any uncopied outputs before rebuilding or rerunning**, because the upstream workflow can replace them. Existing snapshot directories are untouched. Do not run multiple harnesses/builds concurrently against the same artifacts or source test directory. After reviewing the copied files, rebuild and rerun playback to verify the source inputs. The developer still owns cleanup after interrupted/failed cloud runs, and skipped tests are not coverage.

## Offline tests for the wrappers

Run these from the same `src\EdgeAction\EdgeAction.Autorest` directory. They exercise generation sequencing/error handling and the scenario runner with fixtures; they do not generate/build or access cloud resources:

```powershell
Import-Module Pester -RequiredVersion 4.10.1
$result = Invoke-Pester -Script ..\tools\GenerationScripts\tests\Update-EdgeActionGeneratedFiles.Tests.ps1, ..\tools\TestScripts\tests\Test-EdgeAction.Tests.ps1 -PassThru
if ($result.FailedCount -gt 0 -or $result.TotalCount -eq 0) { throw 'Offline wrapper tests failed or none ran.' }
```
