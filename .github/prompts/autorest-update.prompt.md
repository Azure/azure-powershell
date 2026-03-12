---
description: "Use when: updating an AutoRest-generated module (regenerate from swagger, fix build errors, add tests for new cmdlets). Guides the full update lifecycle with user approval at each step."
---

# AutoRest Module Update Workflow

You are helping the user update an AutoRest-generated Azure PowerShell module. This is a **step-by-step interactive workflow** — you MUST ask the user to approve before making any code changes and before running any destructive commands.

## Inputs (ask the user if not provided)

1. **Module name** — e.g., `Cdn`, `EventGrid`, `ContainerRegistry`
2. **What to update in README.md** — e.g., new commit hash, new input-file path, new API version, new directives

The module's Autorest project lives at either:
- `src/<Module>/<Module>.Autorest/` (primary)
- `generated/<Module>/<Module>.Autorest/` (some modules)

## Workflow Steps

### Step 1: Update README.md

1. Read the current `README.md` in the `.Autorest` directory.
2. Apply the user's requested changes (new commit hash, new swagger path, new directives, etc.).
3. **Follow the README conventions:**
   - Always use commit hashes, never branch names, for API spec references.
   - Add a comment explaining the purpose of every new directive.
4. **Show the diff to the user and wait for approval before writing.**

### Step 2: Run AutoRest Code Generation

1. Navigate to the `.Autorest` directory.
2. Run: `autorest`
3. If `autorest` produces errors:
   - Analyze the error output.
   - Propose a fix **scoped only to files within the module directory** (e.g., `src/Cdn/`).
   - Show the proposed fix to the user, wait for approval, apply it, and re-run `autorest`.
   - Repeat until `autorest` succeeds.

### Step 3: Build the Module

1. In the same `.Autorest` directory, run: `pwsh -File ./build-module.ps1`
2. If the build produces errors:
   - Analyze the error output.
   - Propose a fix **scoped only to files within the module directory**.
   - Show the proposed fix to the user, wait for approval, apply it, and re-run `./build-module.ps1`.
   - Repeat until the build succeeds.
3. After a successful build, note the list of exported cmdlets from the `exports/` folder.

### Step 4: Identify New Cmdlets

1. Compare the current exported cmdlets (in `exports/`) with the test files already present in `test/`.
2. Any cmdlet that has an export but no corresponding `.Tests.ps1` file is considered **new**.
3. List the new cmdlets and confirm with the user which ones need tests.

### Step 5: Add Tests for New Cmdlets

For each new cmdlet that needs a test, create a test file in the `test/` directory following this exact pattern:

```powershell
if(($null -eq $TestName) -or ($TestName -contains '<CmdletName>'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot '<CmdletName>.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe '<CmdletName>' {
    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
```

Adapt the `It` blocks based on the cmdlet's parameter sets (check the export file to see which variants exist: `List`, `Get`, `GetViaIdentity`, `Delete`, `CreateExpanded`, `UpdateExpanded`, etc.).

**Show each test file to the user and wait for approval before creating it.**

### Step 6: Summary

After all steps are done, provide a summary:
- Files modified (README.md, any fixes applied)
- New cmdlets generated
- Test files created
- Any remaining manual steps the user should take (e.g., recording tests, updating ChangeLog.md)

## Error Fixing Rules

When fixing errors in Steps 2 and 3:
- **ONLY modify files within the module's own directory** (e.g., `src/Cdn/`). Never modify shared infrastructure, build scripts, or other modules.
- Common fixes include:
  - Adding/updating directives in `README.md` to rename, remove, or hide problematic cmdlets or models
  - Updating `custom/` scripts when custom cmdlets reference changed types or parameter names
  - Fixing `no-inline` entries when model names change
  - Adjusting `model-cmdlet` entries when model shapes change
- Always explain **why** a fix is needed before proposing it.
- After each fix, re-run the failed command to verify the fix works.

## Approval Protocol

Before ANY of these actions, show the user what you plan to do and wait for their explicit approval:
- Editing README.md
- Editing any source file to fix errors
- Creating test files
- Running `autorest` or `./build-module.ps1` (inform the user the command will be run, as they can take significant time)
