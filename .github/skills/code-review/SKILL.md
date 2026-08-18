---
name: azure-powershell-code-review
description: Review Azure PowerShell pull requests using the repository's generated-module, changelog, help, testing, cmdlet-design, compatibility, and release-readiness requirements.
compatibility: Requires authenticated GitHub access to inspect pull request metadata, diffs, checks, reviews, and discussion threads.
---

# Azure PowerShell Code Review

Use this skill for pull request reviews in `Azure/azure-powershell`.

The workflow has two phases:

1. **Triage:** identify generated modules, new modules, release routing, and conditions that prevent normal review.
2. **Code review:** inspect correctness, compatibility, documentation, tests, generated artifacts, and release readiness.

Do not post a review, comment, approval, assignment, email, or Teams message unless the user explicitly requests that external action. When asked only to review, return findings and concise comment drafts.

## Phase 1: Triage

### Review state

Before reviewing:

- Confirm the PR is not a draft.
- Check for `do-not-merge` or equivalent labels.
- Confirm the target branch is appropriate.
- Inspect the current head, all commits, CI checks, review threads, resolved threads, and suppressed Copilot comments.
- Do not repeat an existing finding.
- Verify that a resolved thread was actually fixed rather than merely resolved.

### Generated modules

Changes under:

```text
src/<ModuleName>/<SubModuleName>.Autorest/**
```

are changes to a generated module.

Determine the source from the **complete base and head Git trees**, not only the PR diff:

- TypeSpec sourced: `src/<ModuleName>/<SubModuleName>.Autorest/tsp-location.yaml` exists.
- Swagger sourced: no `tsp-location.yaml` exists.
- Check `tsp-location.yml` defensively, but treat `.yaml` as canonical.

If the project is Swagger sourced:

1. Stop the normal ownership flow.
2. Mark the PR for handoff to the Codegen Squad for TypeSpec migration.
3. Contact Bernard Pan `<bernardpan@microsoft.com>`.
4. Do not guess a GitHub username; resolve it before assigning.
5. Resume normal review after the migration is complete.

An upstream TypeSpec-generated `openapi.json` is still non-TypeSpec under this repository rule when `tsp-location.yaml` is absent.

### Generated-content rules

Contributor PRs must not change `generated/**`, except:

- Protected-branch merge PRs.
- PRs titled `[skip ci] Archive ...`.

For `.Autorest` changes, require these related updates unless the PR is documentation-only:

- `src/<Module>/<SubModule>.Autorest/generate-info.json`
- `src/<Module>/<Module>.sln`
- `src/<Module>/<Module>/help/**`
- `src/<Module>/<Module>/ChangeLog.md`
- `src/<Module>/<Module>/Az.<Module>.psd1`
- For a new or rebranded module: `tools/CreateMappings_rules.json`

After a generated-module PR merges:

- A `[skip ci] Archive ...` PR should be created for protected branches.
- Verify that archive changes are only under `generated/**`.
- Verify `generated/<Module>/<SubModule>.Autorest/generate-info.json` changed.
- Ensure the archive PR is also reviewed and merged.

Protected branches include `main`, `release-*`, `Az.*`, `LTS`, `generation-LTS`, `stack-dev`, `preview`, `AzureRM*`, `DeploymentRollouts`, `Compute-*`, and documented test or generation branches.

`release-network-*` is excluded. For non-protected branches, remind the reviewer to manually trigger Azure DevOps pipeline definition `787` with the branch and affected modules.

### New modules

Do not infer a new module from a large diff or many generated files.

For each changed `src/<ModuleName>/`:

1. Check whether `src/<ModuleName>` exists at the PR base SHA.
2. If absent, inspect added `.psd1`, `.csproj`, `.sln`, `.Autorest/README.md`, module mapping, help, and packaging files.
3. Treat rebrands as new-module onboarding when they create a new distributable module identity.

Do not merge a new module until:

1. Code review is complete.
2. An MCR manifest PR updates `microsoft/mcr/teams/psresource/azurepsmar.yaml`.
3. The MAR team approves that PR.

MCR/MAR approval is a merge blocker.

### Out-of-band releases

If the target is a module branch such as:

- `Az.<Module>`
- `Az.<Module>-preview`
- `<Module>-preview`

flag a likely out-of-band release and remind the Scrum Master to trigger the OOB release process.

Do not flag `main` or normal release branches solely because they contain a module name.

## Phase 2: Code Review

### PR metadata and ownership

- The title and description must match the actual change.
- Link the tracked issue when applicable.
- Public cmdlet API changes require a completed design review linked from the PR.
- Large or user-visible changes require service-team owner sign-off.
- Commits should be reasonably small and purposeful.

### Changelog and versioning

Treat the changelog as mandatory unless a clear exception applies.

- Require `src/<Module>/<Module>/ChangeLog.md`.
- Add the note under `## Upcoming Release`.
- Inspect surrounding context because conflict resolution can place notes in an older release.
- Do not manually update module versions, manifest `ReleaseNotes`, `AssemblyInfo.cs`, or add a released-version heading.

### Public API and compatibility

- Check `BreakingChangeAnalyzer` results.
- Inspect `BreakingChangeIssues.csv`, `SignatureIssues.csv`, and other suppression changes.
- Stable modules must not introduce unapproved breaking changes.
- Preview suppressions still require intentionality and service-owner confirmation.
- Verify parameter names, aliases, types, mandatory state, positions, parameter sets, pipeline binding, output types, and defaults.
- Cmdlets with multiple parameter sets require an interactive `DefaultParameterSetName`.
- Distinguish supported PowerShell cmdlet contracts from internal generated SDK signatures; do not classify internal changes as user-facing blockers without evidence.

### Cmdlet behavior

- Server mutations must declare `SupportsShouldProcess = true`.
- Guard the actual network mutation with `ShouldProcess` or the repository-standard `ConfirmAction`.
- Verify `-WhatIf` makes no service request and `-Confirm` prompts.
- Remove cmdlets returning no output should provide `-PassThru`.
- Sensitive values must use `SecureString`, not `string`.
- Enumerated output must use `WriteObject(collection, true)`.
- Verify pagination through next-link operations.
- Exercise wildcard branches instead of testing only exact names.
- Check `New` overwrite and `Set` create-if-missing or upsert semantics against established module behavior.
- For full PUT operations, ensure omitted optional fields are preserved instead of silently deleted.
- Verify read-modify-write mapping does not write back or clear service-managed fields.
- Surface service errors explicitly; do not accept silent fallbacks.

Prioritize findings that can make a command fail, corrupt or remove configuration, operate on the wrong resource, or return materially incorrect results.

### Help and examples

- Added, removed, or modified cmdlets require regenerated module help.
- New cmdlets require examples with realistic output.
- Remove all platyPS placeholders such as `{{ Fill description }}`.
- Help must match code for parameter metadata, behavior, and output.
- Verify examples accurately describe replace, append, remove, and upsert semantics.
- Ensure headings and descriptions do not contradict the command being demonstrated.

### Tests and recordings

New cmdlets require:

- Help.
- PowerShell live or scenario tests.
- Playback recording files.

Mock-only C# tests are not a replacement for live tests and recordings.

Also verify:

- All parameter sets, including pipeline input.
- Wildcard/list and pagination paths.
- `-WhatIf` behavior for mutating commands.
- Successful service calls, not only `-WhatIf` paths.
- Partial-update preservation.
- New-overwrite and Set-missing behavior.
- Setup and cleanup sufficient for another engineer to re-record.
- No skipped existing tests or `NotImplementedException` stubs.
- No personal resource names, subscriptions, resource IDs, or unreproducible environments.
- Assertions match actual exception messages and output shapes.
- Test categories are understood: `LiveOnly` tests may not run in normal PR CI.

An empty recording or a test that only uses `-WhatIf` does not validate serialization, service acceptance, long-running operation handling, or returned output.

### Manifest, formatting, and SDK

- Maintain `CmdletsToExport` and `AliasesToExport`.
- Add required assemblies correctly.
- Tags must not contain spaces.
- Do not change manifest version or `ReleaseNotes` outside the release process.
- Regenerate formatting output when new `Ps1Xml` formatting annotations require it.
- SDK dependencies must use packages published to NuGet.
- Inspect additions under `tools/LocalFeed`.
- Command projects must not introduce cross-service management SDK dependencies.
- Check common assembly version conflicts.

### AI-assisted contribution checks

Pay extra attention to:

1. PR description versus actual diff.
2. Missing help, live tests, or recordings for new commands.
3. Help and cmdlet-code inconsistencies.
4. Cross-file naming and parameter inconsistencies.
5. Tests that assert only null or default values.
6. Resolved or suppressed Copilot comments whose underlying issue remains.

## Review Result

Use one of:

- `HANDOFF_CODEGEN` — Swagger-sourced `.Autorest` PR requiring Codegen Squad migration.
- `BLOCKED_NEW_MODULE` — MCR/MAR onboarding is incomplete.
- `NEEDS_OOB_RELEASE` — the Scrum Master must trigger the OOB process.
- `APPROVE` — no blocking correctness or process issue remains.
- `REQUEST_CHANGES` — concrete blocking findings remain.
- `NEEDS_SERVICE_OWNER` — behavior or compatibility requires owner confirmation.

Lead with the recommendation. Include only high-confidence findings and state:

- Severity.
- Exact file and line.
- User impact.
- Evidence.
- Suggested fix.
- Whether an equivalent comment already exists.

Write comments like a teammate:

- Start with the observed behavior.
- Include the smallest concrete example or recording evidence.
- Ask for the intended fix or owner confirmation.
- Avoid boilerplate labels and exaggerated severity.
