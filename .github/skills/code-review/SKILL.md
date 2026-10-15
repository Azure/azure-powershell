---
name: azure-powershell-code-review
description: Review Azure PowerShell pull requests, comment on concrete issues, and apply relevant repository labels.
---

# Azure PowerShell Code Review

Use this skill for pull request reviews in `Azure/azure-powershell`.

The workflow has three phases:

1. **Triage:** identify generated modules, new modules, and special review requirements.
2. **Code review:** inspect correctness, compatibility, documentation, tests, generated artifacts, and release readiness.
3. **Review actions:** post focused review comments and apply relevant labels.

## Phase 1: Triage

### Review state

Before reviewing:

- Confirm the target branch is appropriate.
- Inspect the current head, all commits, CI checks, review threads, resolved threads, and suppressed Copilot comments.
- Do not repeat an existing finding.
- Verify that a resolved thread was actually fixed rather than merely resolved.
- Treat draft state and the existing `Do Not Merge :no_entry_sign:` label as context, not as code findings.

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

1. Comment that the project must be handled by the Codegen Squad for TypeSpec migration.
2. Apply the `Generator` and `needs-revision` labels.
3. Do not review generated implementation details as handwritten code.

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

For an archive PR, verify that changes are limited to `generated/**` and that the relevant `generate-info.json` changed.

### New modules

Do not infer a new module from a large diff or many generated files.

For each changed `src/<ModuleName>/`:

1. Check whether `src/<ModuleName>` exists at the PR base SHA.
2. If absent, inspect added `.psd1`, `.csproj`, `.sln`, `.Autorest/README.md`, module mapping, help, and packaging files.
3. Treat rebrands as new-module onboarding when they create a new distributable module identity.

For a new or rebranded module, check whether the PR links the required onboarding work for `microsoft/mcr/teams/psresource/azurepsmar.yaml` and its MAR approval. If the evidence is absent, comment on the missing onboarding requirement and apply `needs-revision`.

## Phase 2: Code Review

### PR metadata and ownership

- The title and description must match the actual change.
- Link the tracked issue when applicable.
- Public cmdlet API changes require a completed design review linked from the PR.
- Large or user-visible changes require service-team owner sign-off.

### Changelog and versioning

Treat the changelog as mandatory unless a clear exception applies.

- Require `src/<Module>/<Module>/ChangeLog.md`.
- Add the note under `## Upcoming Release`.
- Inspect surrounding context because conflict resolution can place notes in an older release.
- Do not manually update module versions, manifest `ReleaseNotes`, `AssemblyInfo.cs`, or add a released-version heading.

### Public API and compatibility

- Check `BreakingChangeAnalyzer` results.
- Inspect `BreakingChangeIssues.csv`, `SignatureIssues.csv`, and other suppression changes.
- Stable modules must not introduce breaking changes without explicit justification.
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

## Review Actions

### Post review comments

Post comments for concrete correctness, user-impact, test-coverage, documentation, compatibility, or required-review issues.

- Prefer inline comments on the smallest relevant changed line.
- Post one issue per comment.
- Do not post a duplicate when an equivalent open, resolved, or suppressed comment already exists.
- If a prior comment exists but the issue remains, refer to that thread instead of restating it.
- Do not comment on speculative risks without evidence from code, tests, recordings, API behavior, or repository precedent.
- Prioritize issues that can make a cmdlet fail, modify the wrong resource, lose configuration, expose an unsafe public contract, or ship without meaningful validation.

Each comment should:

- Start with the observed behavior and user impact.
- Include the smallest concrete example or recording evidence.
- Ask for a specific fix or confirmation.
- Avoid boilerplate labels and exaggerated severity.

### Apply labels

Use only labels that already exist in this repository. Preserve unrelated existing labels.

- Apply the module or service label matching the changed area, such as `Network`, `SQL`, `Compute`, or `KeyVault`.
- Apply `needs-revision` when blocking review comments require author changes.
- Apply `Cmdlet Review Required :warning:` when public cmdlet API changes lack a completed design review.
- Apply `Contains Breaking Change` only for a verified public breaking change.
- Apply `Merge Conflicts` when GitHub reports that the PR conflicts with its target branch.
- Apply `Generator` for AutoRest or code-generation concerns.
- Apply `Test Debt` when required live, scenario, or playback coverage is absent.
- Apply `ps1xml` when the issue concerns PowerShell formatting data.
- Apply `Service Attention` when a behavior or compatibility decision requires service-owner input.

Do not invent labels. Do not use a label as a substitute for a review comment that explains the issue.

### Final summary

After commenting and labeling, summarize:

- The concrete issues commented on.
- Existing comments that already cover unresolved issues.
- Labels added.
- Whether no additional high-confidence issue was found.
