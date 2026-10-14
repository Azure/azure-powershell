# Developing Az.EdgeAction

Use the repository's existing preparation/build scripts, platyPS commands, and the generated artifact test harness. No EdgeAction-specific development wrapper is required or included in the feature change.

## Workflow and commit boundaries

| Files | Ownership |
| --- | --- |
| AutoRest `README.md`, `custom`, `examples`, scenario scripts and `test\utils.ps1` | Maintained inputs; commit intentional changes. |
| `EdgeAction.Autorest\docs` and `EdgeAction\help` | Review meaningful generated help changes for the feature commit. |
| `test\*.Recording.json` and compatible `test\env.json` | Review and sanitize recorded HTTP fixtures before committing. |
| `Properties\AssemblyInfo.cs`, generation IDs and module GUIDs | Preserve existing metadata. Release automation owns assembly versions; omit formatting/GUID-only churn. |
| `generated\EdgeAction` | Required local build input, but changes do not belong in this feature PR. Repository automation archives generated output separately. |
| `artifacts` and `EdgeAction.Autorest\tools` | Local outputs/tools, not feature-commit content. The module's existing ignore rule covers its `tools` directory. |

Inspect both the working tree and index before and after generation. Do not collect generated output with `git add -A`, and do not discard local outputs merely to clean Git status. Already-staged files still require review. The [archive pipeline](../../../.azure-pipelines/azure-powershell-ci.yml) owns the separate generated-code archive PR; HTTP scenario recordings are different test inputs.

The steps below assume the intended checkout and a fresh native PowerShell session. Each command block identifies its starting directory. **Repository root** means the directory containing `build.proj`, `src`, and `tools`, not `src\EdgeAction\EdgeAction.Autorest`. Initialize the following variables again whenever a later step needs them in a new shell. Test commands change directories; return to the repository root before starting another repository-root block.

**Run from: repository root.**

```powershell
$repo = (Get-Location).Path
$source = Join-Path $repo 'src\EdgeAction\EdgeAction.Autorest'
$artifact = Join-Path $repo 'artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest'
git status --short
git diff --cached --stat
```

Generation/build can replace local files. Preserve uncommitted inputs and recordings first; none of these commands provides automatic backup or rollback. Close PowerShell sessions holding built assemblies before rebuilding. On Windows, Process Explorer's **Find Handle or DLL** can identify an owner; opening another terminal or using `Remove-Module` does not unload DLLs held by an existing process.

## Prerequisites and process-local feeds

Use native PowerShell, .NET and Node.js executables, not npm PowerShell/.NET shims. This development workflow uses PowerShell 7.3+, .NET SDK 8+, and Node.js 20+. The development environment used PowerShell 7.6.6, .NET SDK 10.0.401, Node.js 20.20.2 and npm 10.8.2; these are observations, not repository-wide requirements.

Install missing native runtimes using the [PowerShell instructions](https://learn.microsoft.com/powershell/scripting/install/installing-powershell), [.NET downloads](https://dotnet.microsoft.com/download/dotnet) and [Node.js releases](https://nodejs.org/download/release/). Reopen PowerShell after installation, and verify executable resolution.

**Run from: any directory** (these checks do not depend on the checkout).

```powershell
Get-Command pwsh, dotnet, node, npm | Select-Object Name, Source
pwsh --version
dotnet --version
node --version
npm --version
```

Install missing pinned developer dependencies. platyPS is needed for parent Markdown/MAML help; Pester 4.10.1 is needed for the existing scenario harness.

**Run from: any directory** (npm installs globally; PowerShell modules install for the current user).

```powershell
npm install --global autorest@3.8.0 @autorest/core@3.10.9 --registry=https://packagefeedproxy.microsoft.io/npm/
Install-Module platyPS -RequiredVersion 0.14.2 -Scope CurrentUser -Repository PSGallery
Install-Module Pester -RequiredVersion 4.10.1 -Scope CurrentUser -Repository PSGallery -Force
```

Do not silently bypass a PowerShell module publisher/signature failure. Verify the intended PSGallery package and publisher before choosing a publisher-check exception. Other Pester versions may coexist, but explicitly import 4.10.1 in the disposable test process below; the harness imports Pester by name.

For the Microsoft development environment, set approved feeds **in this disposable shell only** before generation/build.

**Run from: repository root**, after initializing `$repo` above, in the shell that will perform preparation/build.

```powershell
$ErrorActionPreference = 'Stop'
$PSNativeCommandUseErrorActionPreference = $true
$env:autorest_registry = 'https://packagefeedproxy.microsoft.io/npm/'
$env:RestoreSources = @(
    (Join-Path $repo 'tools\LocalFeed')
    'https://pkgs.dev.azure.com/azclitools/public/_packaging/azure-powershell/nuget/v3/index.json'
    'https://packagefeedproxy.microsoft.io/nuget/v3/index.json'
) -join ';'
```

These values do not modify global npm configuration or `NuGet.Config`. Close the shell afterward to discard them. If restore reports an unreachable feed or `NU1900` while retrieving vulnerability data, fix network/feed access rather than disabling TLS or NuGet auditing.

## Prepare and build in the repository

The AutoRest YAML in `README.md` owns the specification pin. Keep an immutable commit SHA, not a branch name. The stable input is:

```yaml
commit: 65eb9311d304dcf9874d05fdec39ea65baae8db8
input-file:
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/EdgeActions/stable/2026-10-01/openapi.json
```

Preserve `generate-info.json` and `Properties\AssemblyInfo.cs` before preparation. Generation IDs are not specification SHAs. If metadata was deleted by a previous bare AutoRest run, compare with this branch's tracked version and recover only the unintended changes; do not invent replacement IDs or discard intentional edits.

Use the shared repository helpers. AutoRest can replace this guide with its scaffold, so retain this file while preparing.

**Run from: repository root**, in the same shell with `$repo`, `$source`, and the feed configuration initialized.

```powershell
$guidePath = Join-Path $source 'how-to.md'
$guide = [IO.File]::ReadAllBytes($guidePath)
try {
    & .\tools\BuildScripts\PrepareAutorestModule.ps1 -RepoRoot $repo -ModuleRootName EdgeAction -ForceRegenerate
    if ($LASTEXITCODE -ne 0) { throw "Preparation failed (exit $LASTEXITCODE)." }
} finally {
    [IO.File]::WriteAllBytes($guidePath, $guide)
}
& .\tools\BuildScripts\BuildModules.ps1 -RepoRoot $repo -Configuration Debug -TargetModule EdgeAction
if ($LASTEXITCODE -ne 0) { throw "Build failed (exit $LASTEXITCODE)." }
```

Preparation invokes AutoRest/standalone build steps and relocates generated output to `generated\EdgeAction`. The shared helper already supplies `-DisableAfterBuildTasks` to the generated build script; it is not a parameter of `PrepareAutorestModule.ps1`. There is no source-only generation promise: preparation/build writes generated code and local binaries as well as derived source documentation.

Review `artifacts\autorest\EdgeAction\EdgeAction.Autorest.log` for generator failures and console output for restore/compiler failures. Failed preparation may leave partial output. Inspect the Git diff, correct the cause and rerun; do not reset the AutoRest cache or modify repository feeds as a generic repair.

### Refresh parent help

After building, import the built modules in a fresh shell.

**Run from: repository root.**

```powershell
Import-Module .\artifacts\Debug\Az.Accounts\Az.Accounts.psd1 -Global
Import-Module .\artifacts\Debug\Az.EdgeAction\Az.EdgeAction.psd1 -Global
Import-Module platyPS -RequiredVersion 0.14.2
$help = Join-Path (Get-Location) 'src\EdgeAction\EdgeAction\help'
Update-MarkdownHelpModule -Path $help -RefreshModulePage -AlphabeticParamsOrder -UseFullTypeName -ExcludeDontShow
Import-Module .\tools\BuildScripts\HelpMarkDown.psm1
Get-ChildItem $help -Filter '*-*.md' | ForEach-Object {
    Remove-CommonParameterFromMarkdown -Path $_.FullName -ParameterName ProgressAction
}
```

AutoRest also refreshes command descriptions/examples in `EdgeAction.Autorest\docs`. Review and transfer relevant descriptions/examples into the corresponding parent help pages; `Update-MarkdownHelpModule` updates command metadata, not every authored description. Preserve the parent module-page GUID and description. With platyPS 0.14.2, check that commands with multiple parameter sets retain their default-only syntax in MAML; parameter blocks may need explicit parameter-set names instead of `(All)`.

Generate local MAML after that review.

**Run from: repository root**, in the same help-review shell with `$help` initialized.

```powershell
Import-Module .\tools\HelpGeneration\HelpGeneration.psm1
$helpOutput = Join-Path (Get-Location) 'artifacts\edgeaction-help-review'
$null = New-Item -ItemType Directory -Path (Join-Path $helpOutput 'help') -Force
Copy-Item (Join-Path $help '*.md') (Join-Path $helpOutput 'help') -Force
New-AzMamlHelp -HelpFolderPath (Join-Path $helpOutput 'help')
```

Review the Markdown/MAML against built command metadata before publishing the source help. MAML/build outputs stay local. Do not manually normalize assembly versions or include GUID-only source-document churn.

### Repository versus standalone layout

The repository build copies the complete module and scenario harness to `artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest`. Run its `test-module.ps1` there. The maintained `src` directory is not a complete standalone module after preparation moves exports and the manifest.

Standalone `build-module.ps1`/`test-module.ps1` instructions apply only to a complete generated module with its colocated manifest, exports, runtime and dependencies. Do not run bare AutoRest or a leftover source `build-module.ps1` as a repository help-repair step.

## Run scenario tests directly

The artifact harness supports `-Record`, `-Playback`, `-Live`, `-NotIsolated`, `-UsePreviousConfigForRecord`, `-RegenerateSupportModule`, and `-TestName`. Use one mode at a time. Playback is the default.

**Use a disposable PowerShell terminal.** With `-NotIsolated`, Pester's `-EnableExit` can close that process. Omitting `-NotIsolated` launches another process; a process-only Azure login in the caller is not inherited. Direct execution does not read the former wrapper's local settings, refresh test scripts, validate the intended cloud/subscription, enforce mutation consent, summarize failures beyond Pester, or copy recordings back.

### Refresh scenario-only edits

If only scenario scripts or `utils.ps1` changed and current build artifacts exist, no regeneration is required. Explicitly copy the maintained scripts before starting the harness.

**Run from: repository root.**

```powershell
$sourceTest = Join-Path (Get-Location) 'src\EdgeAction\EdgeAction.Autorest\test'
$artifactTest = Join-Path (Get-Location) 'artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest\test'
if (-not (Test-Path $artifactTest)) { throw 'Build EdgeAction first; the artifact test directory is missing.' }
Get-ChildItem $sourceTest -Filter '*.Tests.ps1' | Copy-Item -Destination $artifactTest -Force
Copy-Item (Join-Path $sourceTest 'utils.ps1') $artifactTest -Force
```

This does not copy recordings, environment files, results or binaries. If a scenario was removed or renamed, inspect the corresponding orphan artifact script before running; do not execute stale tests. Changes to cmdlets/runtime or other fixture files require an appropriate build or separately reviewed fixture refresh.

### Playback

**Start from: repository root in a fresh native PowerShell terminal.** The block changes to `artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest` before executing `test-module.ps1`.

```powershell
Import-Module Pester -RequiredVersion 4.10.1
Set-Location .\artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest
.\test-module.ps1 -NotIsolated -Playback -TestName 'Update-AzEdgeAction'
```

Omit `-TestName` to run all groups. Missing request keys require compatible recordings, not regeneration alone. API-version changes, changed request sequences and separate fixture setup/cleanup recording contexts can all invalidate older recordings.

### Authorized Record runs, including Brazilus

Record and Live create/delete resources. Use only an authorized test subscription with permission to create and delete resource groups. Setup creates one run-owned resource group named `rgps-powershellsdk-edgeaction-tests-<12 random hex characters>` and saves randomized parent names for the 15 scenario groups in `EdgeActionFixtures`. Creation refuses existing resources instead of pre-cleaning them. Each scenario cleans its own fixture; the harness's final `cleanupEnv` deletes the confirmed run-owned resource group and any remaining resources inside it. It never deletes the shared `powershelltests` group or discovers groups by prefix. Do not run multiple harnesses/builds concurrently against the same environment files or output directories.

The naming follows the Python test pattern selected for these scenarios; it is not a repository-wide PowerShell prefix standard.

| Phase | Resource-group name and behavior |
| --- | --- |
| Azure during Record/Live | `rgps-powershellsdk-edgeaction-tests-<random suffix>`; created for this run and deleted during final cleanup |
| Saved Record output after cleanup | `powershellsdk-edgeaction-tests-rgname`; the module test helper substitutes the live RG name in recording keys, URLs, payloads, and `env.json` |
| Playback | Uses the saved placeholder and HTTP responses; no Azure RG, live login, or resource-group setup/cleanup is needed |

The RG metadata location defaults to `westus`, independently of EdgeActions' `global` location. To use another approved region, set `EDGEACTION_TEST_RESOURCE_GROUP_LOCATION` in the recording shell before running the harness.

The harness's `check-dependencies.ps1` checks Pester and, for Record/Live, prepares Resources test support if missing. That preparation can download packages and invoke native build tools. Have the prerequisites/feed configuration above ready before starting; Playback does not require live Resources support.

For an already registered Brazilus environment, explicitly authenticate and verify the context **in the same fresh terminal** that will execute the harness.

**Start from: repository root.** The block changes to `artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest` after authentication and runs `test-module.ps1` there.

```powershell
Import-Module .\artifacts\Debug\Az.Accounts\Az.Accounts.psd1
Import-Module Pester -RequiredVersion 4.10.1
$subscription = '<authorized-test-subscription-id>'
$environment = Get-AzEnvironment -Name Brazilus
if (-not $environment -or $environment.ResourceManagerUrl.TrimEnd('/') -ne 'https://brazilus.management.azure.com') {
    throw 'Register and verify the approved Brazilus environment before recording.'
}
Disable-AzContextAutosave -Scope Process
Connect-AzAccount -Environment Brazilus -Subscription $subscription -Scope Process
$context = Get-AzContext
if ($context.Subscription.Id -ne $subscription -or $context.Environment.Name -ne 'Brazilus') {
    throw 'Unexpected test subscription or environment.'
}
Set-Location .\artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest
.\test-module.ps1 -NotIsolated -Record -TestName 'Update-AzEdgeAction'
```

If Brazilus is not registered, obtain approval before registering its ARM endpoint with `Add-AzEnvironment`; verify the resulting endpoint and audience rather than accepting an environment name alone. For Azure public cloud, explicitly select and verify `AzureCloud` instead. The direct harness does not enforce these boundaries for you.

`setupEnv` lives in maintained `src\EdgeAction\EdgeAction.Autorest\test\utils.ps1` and executes from the copied artifact file. It saves subscription/tenant/environment from the current context; later fixture operations reject a context mismatch. This does not replace verifying that the initial context is authorized. Record writes artifact `test\env.json`; Live uses `test\localEnv.json`. Resource-group provisioning runs outside HTTP scenario recording. `-UsePreviousConfigForRecord` loads earlier values before setup, but does not reuse the live RG or randomized fixture names, or override unfinished cleanup.

After a successful Record, open another fresh terminal and run the Playback command above. Do not rebuild between Record and that first Playback. For all three Update groups, pass `-TestName 'Update-AzEdgeAction','Update-AzEdgeActionVersion','Update-AzEdgeActionExecutionFilter'`, or omit the filter for a complete run.

Execution-filter update setup requires creation to return a resource with an ID and `ProvisioningState = Succeeded`; create errors stop setup. The create cmdlet already polls the asynchronous operation without `-NoWait`. If Playback requests a missing poll after a recorded `Running` response, preserve the recording and live error output, then obtain a fresh successful Record and Playback. An added sleep or an edited terminal response does not repair that missing exchange; a passing Record test summary alone is not sufficient.

**Record all 15 groups without `-TestName` before publishing fixtures for this change.** Existing fixed-name recordings are not compatible with the new environment mapping. A filtered Record is useful for debugging but generates a new mapping; do not copy that `env.json` over metadata used by the other groups' recordings. Publish a complete matching set from a full run.

Parent Update coverage uses nonempty expanded tags for replacement and the public `-JsonString '{"tags":{}}'` path for clearing. The current expanded serializer omits empty objects; `-Tag @{}` is not equivalent to the required tag-clear body. Version tag updates verify default/deployment-type preservation; changing the default requires `Switch-AzEdgeActionVersionDefault`. Filter updates cover `VersionId`, headers and tags, including preservation during a header-only PATCH. Skipped JSON/identity stubs are not coverage.

### Recover failed cleanup

The environment file records `ResourceGroupState` and each fixture as `NotCreated`, `Creating`, `Created`, or `Cleaned`. `Creating` is saved before the create request, so a timeout or interrupted process leaves a visible, uncertain outcome. Cleanup retains the real RG name and outstanding entries on failure, and new Record/Live setup refuses to overwrite either environment file while `Creating` or `Created` entries remain. Preserve these files before rebuilding. Older unfinished fixtures in the shared `powershelltests` group require exact-resource manual recovery; this helper will not delete that group.

Use `-ResourceGroup` to retry cleanup of the saved run-owned group and all its remaining resources after verifying/authenticating to the saved context. Alternatively, `-Name '<saved-fixture-name>'` retries one parent's child/default-last cleanup; final RG cleanup is still required. The recovery helper checks subscription, tenant, and environment and supports `-WhatIf`. For `Creating`, it marks an entry cleaned only on an observed 404; if the resource exists, it stops for ownership inspection and manual recovery. After manual recovery, verify absence before marking that entry `Cleaned`.

**Run from: the built artifact module directory, `artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest`, in a fresh authenticated shell.** Dot-source the artifact helper so recovery updates the same artifact environment file. The example previews cleanup; remove `-WhatIf` only after reviewing the saved fixture.

```powershell
Import-Module .\Az.EdgeAction.psd1
Import-Module (Join-Path $HOME '.PSSharedModules\Resources\Az.Resources.TestSupport.psd1') -ErrorAction Stop
. .\test\utils.ps1
Resume-EdgeActionTestCleanup -Mode record -ResourceGroup -WhatIf
```

Use `-Mode live` for `localEnv.json`. Recovery sends live requests when `-WhatIf` is removed; it does not record a new scenario. Successful Record RG recovery also finishes RG-name substitution in existing recordings and `env.json`. If substitution failed after cleanup, retry this same command against the retained live-name metadata; it will not recreate or delete the already-cleaned group.

## Results and recording review

The harness prints normal Pester output and writes `test\Az.EdgeAction-TestResults.xml` under the artifact module. Inspect the latest timestamp, failed test/suite names, stack locations and messages; do not treat an old report as evidence about the latest code. Direct harness exit behavior is not a substitute for inspecting XML, especially after setup/cleanup failures.

Record saves HTTP requests/responses in artifact `test\*.Recording.json`, including failed responses. A public cmdlet can display only a generic status if its generated error model cannot deserialize the service's error shape. Inspect the relevant response locally; do not publish full headers, URLs, IDs or payloads in logs. Playback reuses recordings and does not create new service responses.

After confirmed Record cleanup, the helper replaces the `t`, `c`, `s`, and `h` query values in EdgeAction operation-polling URLs with `Sanitized`. It updates polling response headers, subsequent request URIs, and recording lookup keys together, preserving operation IDs, API versions, other query parameters, and payloads. Duplicate lookup keys stop normalization before any recording is written.

The module test helper also substitutes the run-owned RG name after confirmed cleanup. This is module-local behavior in `test\utils.ps1`, not the Python sanitizer or a new shared PowerShell recorder feature, and is not a general secret sanitizer. There is **no automatic recording handoff**. Preserve failed/uncopied outputs before another Record/build. After successful Record and Playback, review identifiers, credentials, polling URLs and embedded code/archives, preserving consistent request/response keys needed by Playback. Then copy only the reviewed recording(s) and compatible environment metadata back to source.

Existing complete recordings can be sanitized without another live Record. With the current helper loaded and `env.json` confirming `Cleaned` ownership state, `Resume-EdgeActionTestCleanup -Mode record -ResourceGroup -Confirm:$false` finishes normalization; an already-normalized, cleaned group requires no Azure calls. Run offline Playback afterward to verify lookup consistency. This operation does not invent missing responses or repair incomplete recordings.

**Run from: repository root**, in a new shell after completing the recording review. This example copies only the parent Update recording.

```powershell
$artifactTest = Join-Path (Get-Location) 'artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest\test'
$sourceTest = Join-Path (Get-Location) 'src\EdgeAction\EdgeAction.Autorest\test'
Copy-Item (Join-Path $artifactTest 'Update-AzEdgeAction.Recording.json') $sourceTest -Force
```

Copy `env.json` only after confirming compatibility with **all** source recordings that share it; a filtered run must not invalidate other groups. Never copy results XML, local settings, `localEnv.json` or entire artifact directories into source. Review `git diff` and stage explicit files only. Rebuild/replay the reviewed source fixtures before submitting them; neither generated-code archives nor successful tests certify that recordings are safe to publish.

## Script reference

### Repository workflow

Use these entry points for this checkout. The commands above include their prerequisite configuration and review steps; this table is a reference, not a second sequence to execute.

| Script | Execute from | Purpose |
| --- | --- | --- |
| `.\tools\BuildScripts\PrepareAutorestModule.ps1` | Repository root | Regenerate with `-RepoRoot $repo -ModuleRootName EdgeAction -ForceRegenerate`; writes both derived source files and local generated output. |
| `.\tools\BuildScripts\BuildModules.ps1` | Repository root | Build with `-RepoRoot $repo -Configuration Debug -TargetModule EdgeAction`; creates the artifact module used for testing. |
| `.\test-module.ps1` | `artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest`, relative to repository root | Run Pester scenarios with one of `-Playback`, `-Record`, or `-Live`. Use `-TestName` to select groups; follow the authentication/disposable-shell instructions above for `-NotIsolated`. |
| `.\check-dependencies.ps1` | The same artifact module directory | Normally invoked by the harness, not a separate manual step. Checks/downloads dependencies and can prepare Resources support for Record/Live. |

Maintain custom PowerShell cmdlets in `src\EdgeAction\EdgeAction.Autorest\custom`, authored help examples in `examples`, and scenarios/fixtures in `test` under that same source directory. Build/generation consumes those inputs; edit them rather than the copies in `generated` or `artifacts`.

### Complete standalone module only

**Execute each command below from the root of a complete standalone generated module**, where the script, project, `Az.EdgeAction.psd1`, exports, generated runtime, and dependencies are colocated (after building where needed). This is **not** the repository root, the post-preparation maintained `src` directory, or the repository's test artifact directory. Repository preparation splits these files across locations; the presence of a script alone does not make its directory a standalone module.

| Command | Purpose and important options |
| --- | --- |
| `.\build-module.ps1` | Compile and refresh exports, manifest, help and test scaffolding. `-Release` selects Release compilation; `-NoDocs` suppresses Markdown generation. Optional follow-on actions include `-Run`, `-Test`, `-Docs`, and `-Pack`; `-Code` opens the development session in VS Code. |
| `.\run-module.ps1` | Open an isolated PowerShell session with the built module imported; `-Code` also opens VS Code and configures attachment to that process. |
| `.\generate-help.ps1` | Refresh standalone `docs` from built command metadata and authored `examples`. This does not replace the repository's separate parent-help/MAML steps. |
| `.\test-module.ps1 -Playback` | Run recorded Pester scenarios. `-TestName` filters groups; Record/Live still require authorized fixtures and authentication. |
| `.\pack-module.ps1` | Create a NuGet package from existing build output using `dotnet pack --no-build`; this does not publish the package. |
| `.\export-surface.ps1` | Export cmdlet/model surface Markdown to `resources` for inspection. Options include `-IncludeGeneralParameters` and `-UseExpandedFormat`; this is not distributed command help. |
| `.\check-dependencies.ps1` | Normally called by other scripts; checks/downloads selected dependencies with `-Accounts`, `-Pester`, or `-Resources`. It is not a read-only environment check. |
