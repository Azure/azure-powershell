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
