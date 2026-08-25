---
applyTo: "src/Compute/Compute.Test/**,src/Compute/Compute/**/*.cs,Compute.Test/**,Compute/**/*.cs"
excludeAgent: "code-review"
---

# Compute Test Debugging Guidelines

> **IMPORTANT — When to use this workflow:**
> If the user asks to debug, fix, run, develop, or troubleshoot any Compute test (files matching `src/Compute/Compute.Test/**`), you **MUST** follow the numbered steps below in order. Do NOT skip ahead or improvise a different approach. Start at Step 1 and work through each step sequentially.

Follow this end-to-end workflow when developing or debugging Compute scenario tests. The approach is: build → run in Record mode → fix failures → iterate until Record passes → verify Playback → commit.

## Scope

- Cmdlet source: `src/Compute/Compute/**`
- SDK (generated, read-only): `src/Compute/Compute.Management.Sdk/Generated/**`
- SDK customizations (editable): `src/Compute/Compute.Management.Sdk/Customizations/**`
- Test scripts (PowerShell): `src/Compute/Compute.Test/ScenarioTests/<resource>Tests.ps1`
- Test harnesses (C#): `src/Compute/Compute.Test/ScenarioTests/<resource>Tests.cs`
- Test runner base: `src/Compute/Compute.Test/ScenarioTests/ComputeTestRunner.cs`
- Session recordings: `src/Compute/Compute.Test/SessionRecords/<FullyQualifiedTestClass>/<TestMethodName>.json`

## Test Infrastructure Overview

Tests use the Azure Test Framework with HTTP Record/Playback. For full setup and configuration details, see `documentation/testing-docs/using-azure-test-framework.md`.

Key points for this workflow:
- **Switching modes**: Edit the `HttpRecorderMode` field in `~/.azure/testcredentials.json` to `Record` or `Playback`. The JSON file takes precedence over the `AZURE_TEST_MODE` environment variable — always use the JSON file to avoid mode mismatches.
- Session recordings are stored at `src/Compute/Compute.Test/SessionRecords/<Class>/<Method>.json`.

## Workflow

### Step 1: Identify the Target Test

Automatically discover which test(s) were added or modified on the current branch. Do not ask the user for the test name — detect it.

> **REQUIRED: GitHub MCP must be configured.** This step uses the GitHub MCP server exclusively — do NOT fall back to local `git` CLI commands, `code_search`, `file_search`, or manual file reading as a substitute for this step. You MUST attempt to call the GitHub MCP tools below. If the tools do not exist in your available tool set, or any call fails with a connectivity/tool-not-found error, **stop immediately** and walk the user through the **GitHub MCP Setup** section below. Do not proceed to Step 2 until GitHub MCP is working. Do NOT silently skip this step or work around it by reading files directly.

You MUST use the GitHub MCP server to compare the current branch against the base branch and find changed test files. Start by attempting the first tool call. If the tool does not exist or the call fails with a connectivity/tool-not-found/authentication error, jump to the **GitHub MCP Setup** section below and guide the user through configuration. Do not continue to the next sub-step.

1. Call `compare_branches` (owner/repo from the active git remote, base: `main`, head: current branch name) to get the list of changed files.
2. Filter the changed files for paths matching `src/Compute/Compute.Test/ScenarioTests/*.cs`.
3. For each changed C# test file, retrieve the **diff** (not the full file) using `get_pull_request` with `get_diff`, or by comparing the file content on the branch against `main`. Extract only the **newly added** `[Fact]` methods that appear in the diff as added lines (prefixed with `+`). Do NOT include pre-existing test methods that were already on `main` — only tests that were added or modified on this branch. Each test method calls `TestRunner.RunTestScript("FunctionName")`, which maps to a PowerShell function.
4. Record the fully qualified test class name and **only the new/changed** method name(s) for use in later steps.

After this step you should have one or more concrete test identifiers in the form `<TestClassName>.<TestMethodName>`. These must be tests that are **new or modified on this branch** — never pre-existing unchanged tests.

#### GitHub MCP Setup

If any GitHub MCP tool call above failed (tool not found, connection error, authentication error), guide the user through the following setup and **do not proceed** to Step 2 until setup is complete and the `compare_branches` call succeeds:

1. In the Visual Studio menu bar, click **View**, then click **GitHub Copilot Chat**.
2. At the bottom of the chat panel, select **Agent** from the mode dropdown.
3. In the Copilot Chat window, click the **tools icon**, then click the **plus icon** in the tool picker window.
4. In the "Configure MCP server" pop-up window, fill out the fields:
   - For **Server ID**, type `github`.
   - For **Type**, select **HTTP/SSE** from the dropdown.
   - For **URL**, type `https://api.githubcopilot.com/mcp/`.
5. Click **Save**. The configuration in the `mcp.json` file should look like this:
   ```json
   {
     "servers": {
       "github": {
         "url": "https://api.githubcopilot.com/mcp/"
       }
     }
   }
   ```
6. In the tools menu again, click the **three dots** next to **github** under added tools and click **Configure**. In the new window, go to the **Authentication** tab and authenticate. A pop-up will appear allowing you to authenticate with your GitHub account.
7. Once authenticated, retry from the top of this step.

### Step 2: Build the Module

Before running any test, ensure the code compiles:
```bash
cd src/Compute
dotnet build
```
Fix any compilation errors before proceeding.

### Step 3: Run the Test in Record Mode

Run the discovered test(s) against live Azure APIs to generate a fresh session recording. This requires Azure credentials and network connectivity.

First, set the test credentials file to Record mode:
```powershell
$cred = Get-Content "$HOME/.azure/testcredentials.json" | ConvertFrom-Json
$cred.HttpRecorderMode = "Record"
$cred | ConvertTo-Json | Set-Content "$HOME/.azure/testcredentials.json"
```
Then run the test:
```powershell
cd src/Compute/Compute.Test
dotnet test --filter "FullyQualifiedName~<TestClassName>.<TestMethodName>"
```
- If the test **passes**, skip ahead to **Step 6** (Playback verification).
- If the test **fails**, continue to Step 4.

### Step 4: Analyze the Failure

Read the test output carefully and extract:
- **Test name** (e.g., `TestSshKeyWithLocation`)
- **Error type** (PowerShell `ActionPreferenceStopException`, HTTP error code, assertion failure, etc.)
- **Error message** (the actual API or cmdlet error)
- **Stack trace** (identify which cmdlet method and line failed)
- **HTTP request/response** (look for the failing API call, status code, and response body)

Locate the relevant files:
- Find the C# test class and PowerShell test function
- Find the cmdlet implementation referenced in the stack trace
- Find the SDK method if the error originates from a generated client call

First, check the **Known Issues** section at the bottom of this document. If the error matches a previously documented issue, apply the known fix directly — do not re-diagnose from scratch. If no known issue matches, classify the failure using the patterns below:

#### API Contract Errors (HTTP 400/404/409)
- **Symptom**: `BadRequest`, `NotFound`, or `Conflict` in the HTTP response body
- **Cause**: Cmdlet or test not sending a required parameter to the API
- **Fix location**: Prefer fixing the **test `.ps1` file** to explicitly pass the required parameter to the cmdlet. The test should exercise the cmdlet the way a real user would — if the API requires a parameter, the test should supply it. Only modify the cmdlet `.cs` file if the cmdlet itself has a bug (e.g., ignoring a parameter it receives, or incorrect mapping logic).
- **Example**: The API requires `encryptionType` but the test calls `New-AzSshKey` without `-SshKeyType` → update the test to pass `-SshKeyType "RSA"`

#### Parameter Binding Errors
- **Symptom**: PowerShell error about missing mandatory parameters or invalid parameter values
- **Cause**: Test script not passing required parameters, or cmdlet parameter metadata is wrong
- **Fix location**: Test `.ps1` file or cmdlet parameter declarations

#### Assertion Failures
- **Symptom**: `Assert-AreEqual` or `Assert-NotNull` failures
- **Cause**: Test expectations don't match actual cmdlet output
- **Fix location**: Test `.ps1` file (update assertions) or cmdlet logic (fix output)

### Step 5: Fix and Re-run (Iterate)

Apply a minimal, targeted fix based on the failure analysis, then repeat from Step 2 (build) and Step 3 (Record run). Keep iterating until the test passes in Record mode.

- **When fixing test scripts:**
  - If the API requires a parameter that the test is not passing, **update the test to pass it explicitly**. Tests should exercise cmdlets the way real users would.
  - Match the test pattern of existing tests in the same `.ps1` file.
  - Ensure cleanup in `finally` blocks (e.g., `Clean-ResourceGroup`).
- **When fixing cmdlet code:**
  - Only modify the cmdlet if it has an actual bug (e.g., ignoring a bound parameter, incorrect mapping, broken logic).
  - Do NOT add hidden defaults in the cmdlet to work around missing test parameters — the test should be explicit.
  - Use `IsParameterBound(c => c.ParamName)` to check if a parameter was provided.
  - Follow existing patterns in the cmdlet file.
- **When the SDK generated code is the issue:**
  - Do NOT modify files under `Compute.Management.Sdk/Generated/` — these are auto-generated.
  - Instead, fix the cmdlet layer to work with the SDK as-is (e.g., pass correct parameter values).

Track what you have already tried to avoid repeating the same fix. If the same API error recurs after a code fix, verify the build output was deployed (clean + rebuild).

### Step 6: Verify Playback Mode

Once the test passes in Record mode, a session recording JSON file has been generated. Switch to Playback mode and run the same test to confirm the recording replays correctly:
```powershell
$cred = Get-Content "$HOME/.azure/testcredentials.json" | ConvertFrom-Json
$cred.HttpRecorderMode = "Playback"
$cred | ConvertTo-Json | Set-Content "$HOME/.azure/testcredentials.json"
```
Then run the test:
```powershell
cd src/Compute/Compute.Test
dotnet test --filter "FullyQualifiedName~<TestClassName>.<TestMethodName>"
```
- If Playback **passes**, continue to Step 7.
- If Playback **fails** with `Could not find a matching HTTP request` or similar mismatch, the recording may be incomplete or the cmdlet may be making unexpected requests. Analyze the error and return to Step 5 to fix, then re-record.

### Step 7: Commit Changes

After both Record and Playback pass, stage and commit all changed files:
- Modified or new cmdlet source files (`src/Compute/Compute/**`)
- Modified or new test scripts and harnesses (`src/Compute/Compute.Test/ScenarioTests/`)
- New or updated session recording JSON files (`src/Compute/Compute.Test/SessionRecords/`)

### Step 8: Update These Instructions with Lessons Learned

After a successful debugging session, evaluate whether the issue you resolved is worth documenting for future runs. Add a new entry to the **Known Issues** section at the bottom of this file if **all** of the following are true:
- The failure required more than one iteration to fix (i.e., the first attempted fix did not resolve it).
- The root cause was not immediately obvious from the error message alone.
- The fix follows a pattern that would apply to similar tests or cmdlets in the future.

Do NOT add an entry for straightforward issues (e.g., simple typos, missing imports, obvious parameter mismatches that were fixed on the first try).

Each entry should follow this exact format under the **Known Issues** section:

```markdown
### <Short descriptive title>
- **Symptom**: <The error message or behavior observed>
- **Root cause**: <Why the error occurred>
- **Fix**: <What was changed and where>
- **Files involved**: <List of file paths that were modified>
```

Keep entries concise — 1–2 sentences per field. The goal is to give future debugging sessions enough information to apply the fix immediately without re-diagnosing.

## Key Files Reference

| Purpose | Path Pattern |
|---------|-------------|
| Cmdlet implementation | `src/Compute/Compute/**/<CmdletName>.cs` |
| SDK operations | `src/Compute/Compute.Management.Sdk/Generated/*Operations.cs` |
| SDK extension methods | `src/Compute/Compute.Management.Sdk/Generated/*OperationsExtensions.cs` |
| SDK models | `src/Compute/Compute.Management.Sdk/Generated/Models/*.cs` |
| Test harness (C#) | `src/Compute/Compute.Test/ScenarioTests/<resource>Tests.cs` |
| Test script (PS1) | `src/Compute/Compute.Test/ScenarioTests/<resource>Tests.ps1` |
| Session recordings | `src/Compute/Compute.Test/SessionRecords/<Namespace>.<Class>/<Method>.json` |
| Test runner base | `src/Compute/Compute.Test/ScenarioTests/ComputeTestRunner.cs` |
| Test credentials | `~/.azure/testcredentials.json` |

## Rules

- **Never modify** files under `Compute.Management.Sdk/Generated/` — they are auto-generated from Swagger specs.
- Files under `Compute.Management.Sdk/Customizations/` are hand-written overrides and CAN be modified.
- Always read the failing cmdlet source before proposing a fix — do not guess.
- Always read the test script to understand what the test is actually doing.
- When an HTTP trace is available, use the request body and response body as primary evidence.
- **Prefer fixing the test over fixing the cmdlet.** If the API requires a parameter, the test should pass it explicitly rather than the cmdlet silently defaulting it. Only fix the cmdlet if it has an actual bug in its logic.
- After fixing code, always verify the build compiles before re-running the test.

## Known Issues

<!-- Entries are added automatically by Step 8 after successful debugging sessions. Do not remove existing entries. -->

### Recording a VM/VMSS test fails on 'locations/publishers' with api-version 2026-04-01
- **Symptom**: A test that passes in Playback fails in Record with `No registered resource provider found for location '<region>' and API version '2026-04-01' for type 'locations/publishers'. The supported api-versions are '... 2026-03-01'`. The listed supported locations include every region, so it is not a regional gap.
- **Root cause**: `locations/publishers` has not shipped the `2026-04-01` api-version that the Compute SDK now targets, so any image-catalog lookup fails live. Two callers hit this: the `Get-DefaultCRPImage` test helper, and `New-AzVM`'s `GetBginfoExtension()`, which calls `VirtualMachineImages.ListPublishers` by default for Windows VMs. The second one is easy to miss because the test script itself contains no image query.
- **Fix**: Replace `Get-DefaultCRPImage` with an explicit image reference (`Set-AzVMSourceImage -PublisherName ... -Offer ... -Skus ... -Version latest`, or the literal `-ImageReference*` parameters on `Set-AzVmssStorageProfile`), and pass `-DisableBginfoExtension` to `New-AzVM`. Playback-only tests are unaffected because their recordings predate the SDK bump.
- **Files involved**: src/Compute/Compute.Test/ScenarioTests/ComputeTestCommon.ps1, src/Compute/Compute/VirtualMachine/Operation/NewAzureVMCommand.cs

### A test that makes no HTTP calls never produces a session recording
- **Symptom**: A scenario test passes in Record mode but no `.json` appears under `SessionRecords/<Class>/`, and Playback then fails with `Unable to find recorded mock file`.
- **Root cause**: `HttpMockServer.Flush()` only writes a file when `Mode == Record && _records.Count > 0`. A test that only exercises client-side config cmdlets (`New-AzVMConfig`, `New-AzVmssConfig`, `Set-AzVmss*Profile`) issues no requests, so nothing is persisted.
- **Fix**: If a real recording is required, extend the test to actually call the service (create the resource and assert on the `Get-` result). Hand-writing an empty `Entries: []` file makes Playback pass but records nothing and proves nothing about service behaviour.
- **Files involved**: tools/TestFx/DelegatingHandlers/HttpMockServer.cs, tools/TestFx/Mocks/MockContext.cs

### Scenario tests fail with "AuthenticationTelemetry is not registered"
- **Symptom**: Every Compute scenario test fails immediately with `CmdletInvocationException: AuthenticationTelemetry is not registered`; further down, the error stream shows `The specified module '<repo>/artifacts/Debug/Az.Accounts/Az.Accounts.psd1' was not loaded because no valid module file was found`.
- **Root cause**: `dotnet build` on `Compute.Test.csproj` compiles the assemblies but does not stage the PowerShell module manifests into `artifacts/Debug`. `ComputeTestRunner` loads Az.Accounts, Az.Compute, Az.Network, Az.KeyVault and Az.ManagedServiceIdentity from that folder, and the missing `.psd1` files surface as a misleading telemetry error rather than a module-load error.
- **Fix**: Before running tests, stage each required module with `pwsh -c "./tools/BuildScripts/BuildModules.ps1 -RepoRoot <repo> -Configuration Debug -TargetModule <Module>"` for Accounts, Compute, Network, KeyVault and ManagedServiceIdentity. Verify with `Test-Path artifacts/Debug/Az.<Module>/Az.<Module>.psd1`. Note the modules are loaded one at a time, so a first fix that only builds Accounts will simply move the error to the next missing module.
- **Files involved**: src/Compute/Compute.Test/ScenarioTests/ComputeTestRunner.cs, tools/BuildScripts/BuildModules.ps1, artifacts/Debug/Az.*/

### NuGet restore fails with NU1301 even when passing --no-restore
- **Symptom**: `dotnet build` and `dotnet build --no-restore` both fail in under a second with repeated `error NU1301: Unable to load the service index for source https://api.nuget.org/v3/index.json`.
- **Root cause**: A previous failed restore is cached in `obj/project.assets.json` under its `logs` array, and the `ResolvePackageAssets` target replays those logged errors at build time, so `--no-restore` cannot bypass them.
- **Fix**: Fix the restore itself rather than trying to skip it. If `api.nuget.org` is unreachable but `pkgs.dev.azure.com` is, restore against the sanctioned mirrors with a temporary config: `dotnet restore --configfile <temp.config>` listing `local-feed`, `azure-powershell`, and `https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json`. Pass the same file to `BuildModules.ps1` runs via the `RestoreConfigFile` environment variable. Never edit the repo's `NuGet.Config`.
- **Files involved**: NuGet.Config, tools/Common.Netcore.Dependencies.targets, src/Compute/Compute.Test/obj/project.assets.json

- **Symptom**: Every Compute scenario test fails immediately with `CmdletInvocationException: AuthenticationTelemetry is not registered`; further down, the error stream shows `The specified module '<repo>/artifacts/Debug/Az.Accounts/Az.Accounts.psd1' was not loaded because no valid module file was found`.
- **Root cause**: `dotnet build` on `Compute.Test.csproj` compiles the assemblies but does not stage the PowerShell module manifests into `artifacts/Debug`. `ComputeTestRunner` loads Az.Accounts, Az.Compute, Az.Network, Az.KeyVault and Az.ManagedServiceIdentity from that folder, and the missing `.psd1` files surface as a misleading telemetry error rather than a module-load error.
- **Fix**: Before running tests, stage each required module with `pwsh -c "./tools/BuildScripts/BuildModules.ps1 -RepoRoot <repo> -Configuration Debug -TargetModule <Module>"` for Accounts, Compute, Network, KeyVault and ManagedServiceIdentity. Verify with `Test-Path artifacts/Debug/Az.<Module>/Az.<Module>.psd1`. Note the modules are loaded one at a time, so a first fix that only builds Accounts will simply move the error to the next missing module.
- **Files involved**: src/Compute/Compute.Test/ScenarioTests/ComputeTestRunner.cs, tools/BuildScripts/BuildModules.ps1, artifacts/Debug/Az.*/

### NuGet restore fails with NU1301 even when passing --no-restore
- **Symptom**: `dotnet build` and `dotnet build --no-restore` both fail in under a second with repeated `error NU1301: Unable to load the service index for source https://api.nuget.org/v3/index.json`.
- **Root cause**: A previous failed restore is cached in `obj/project.assets.json` under its `logs` array, and the `ResolvePackageAssets` target replays those logged errors at build time, so `--no-restore` cannot bypass them.
- **Fix**: Fix the restore itself rather than trying to skip it. If `api.nuget.org` is unreachable but `pkgs.dev.azure.com` is, restore against the sanctioned mirrors with a temporary config: `dotnet restore --configfile <temp.config>` listing `local-feed`, `azure-powershell`, and `https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json`. Pass the same file to `BuildModules.ps1` runs via the `RestoreConfigFile` environment variable. Never edit the repo's `NuGet.Config`.
- **Files involved**: NuGet.Config, tools/Common.Netcore.Dependencies.targets, src/Compute/Compute.Test/obj/project.assets.json

