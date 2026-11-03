---
name: recoveryservices-cmdlet-development
description: Develop or modify cmdlets in the Az.RecoveryServices module. Use for Recovery Services vault, Backup, Cross Region Restore, SDK contract or upgrade, adapter, model, help, test, recording, changelog, Swagger README, and API-version changes.
---

# Az.RecoveryServices cmdlet development

Use this workflow when adding or changing cmdlets under `src/RecoveryServices`.

## RecoveryServices project map

Identify the feature area before editing:

| Area | Primary locations |
|---|---|
| Recovery Services vault commands | `src/RecoveryServices/RecoveryServices/Vault` |
| Shared module manifest, help, formatting, resources, changelog | `src/RecoveryServices/RecoveryServices` |
| Backup cmdlets | `src/RecoveryServices/RecoveryServices.Backup/Cmdlets` |
| Backup REST and SDK adapter logic | `src/RecoveryServices/RecoveryServices.Backup.ServiceClientAdapter/BMSAPIs` |
| Backup PowerShell models | `src/RecoveryServices/RecoveryServices.Backup.Models` |
| Backup SDK-to-PowerShell conversions | `src/RecoveryServices/RecoveryServices.Backup.Helpers/Conversions` |
| Backup management SDK | `src/RecoveryServices/RecoveryServices.Backup.Management.Sdk` |
| Recovery Services management SDK | `src/RecoveryServices/RecoveryServices.Management.Sdk` |
| Backup scenario tests | `src/RecoveryServices/RecoveryServices.Backup.Test/ScenarioTests` |
| Vault scenario tests | `src/RecoveryServices/RecoveryServices.Test` |

This skill currently covers Recovery Services vault and Backup development. These areas use different clients, adapters, models, and test suites. Do not place a feature in a nearby project merely because it shares the `Az.RecoveryServices` module name.

### Confirm the target area

Before investigating or editing, determine which RecoveryServices area owns the requested feature. If the request does not make this explicit, use the user-question tool and ask the user to choose:

- `RecoveryServices` - Recovery Services vault resource commands and shared module surfaces.
- `RecoveryServices.Backup` - Backup vault settings, policies, containers, protected items, jobs, recovery points, restore, and Cross Region Restore.

Do not infer the area only from the `Az.RecoveryServices` module name. Wait for the user's selection when more than one area is plausible. Once selected, keep searches, implementation, tests, and validation focused on that area, while still updating shared manifest, help, formatting, or changelog files when required.

### Choose the implementation route

Use the resource targeted by the service operation, not the module name alone, to choose the implementation path:

| Feature shape | Typical implementation route |
|---|---|
| Recovery Services vault create, update, delete, or property | Vault cmdlet -> Recovery Services management SDK -> vault PowerShell model -> vault scenario tests |
| Backup vault setting owned by Backup | Existing Backup vault-property cmdlet or dedicated cmdlet -> Backup SDK/adapter -> Backup tests |
| Backup protected item, container, policy, job, or recovery point | Backup cmdlet -> `ServiceClientAdapter` or generated Backup operation -> Backup model/conversion -> workload-specific tests |
| Cross Region Restore operation | Backup cmdlet/provider -> Cross Region Restore SDK -> CRR model/conversion -> CRR tests |

If the feature crosses more than one route, identify each contract separately. Do not force vault, protected-item, recovery-point, and Cross Region Restore behavior through a single SDK or project.

## 0. Create a change ledger before editing

Turn the request and every review comment into a small implementation matrix. Keep it in the working context rather than creating a repository planning file.

| Contract area | Questions to answer |
|---|---|
| Public commands | What are the final PowerShell names, aliases, parameter sets, required parameters, accepted values, confirmation behavior, and output? |
| Service contract | Which resource provider, API version, operation path, HTTP method, request model, response model, and long-running-operation behavior are approved? |
| SDK ownership | Which generated SDK contains the operation? Is it owned by the Recovery Services, Backup, or Cross Region Restore SDK? |
| Read surfaces | Which `Get-*` cmdlets must expose the new state, status, summary, or recovery-point details? |
| State transitions | Must tests cover enable, disable, re-enable, already-in-state, unsupported workload, and vault/item prerequisites? |
| Repository surfaces | Which implementation, client construction, adapter, model, conversion, formatter, manifest, help, test, recording, README, and changelog files must change? |

Do not start implementation while essential contract details conflict. Resolve conflicts by priority: latest explicit reviewer decision, merged Swagger/service contract, current SDK shape, then older specification text. Record assumptions in the final response when authoritative inputs remain unavailable.

## 1. Understand the RecoveryServices feature

1. Read the repository and path-specific instruction files before editing.
2. Review every available design input, including specifications, meeting notes or recordings, review comments, Swagger pull requests, and existing implementation changes.
3. Reconcile the proposed design against the current repository. Do not assume a specification uses the module's latest command names, SDK shape, or conventions.
4. Classify the change as vault management, Backup, or Cross Region Restore.
5. Identify which SDK owns the REST operation and whether the PowerShell layer uses a generated operation, `ServiceClientAdapter`, provider class, or direct management client.
6. Read `Az.RecoveryServices.psd1`, `ChangeLog.md`, the relevant SDK README, nearby cmdlets, models, conversions, format views, scenario tests, and help.
7. Find an existing RecoveryServices cmdlet with similar parameters, operation type, long-running behavior, and output. Reuse its patterns.
8. Confirm the approved cmdlet design, Swagger API version, operation path, request and response models, enum values, and long-running-operation headers before implementing.
9. Inspect the current branch diff before changing code. Preserve valid work already present and distinguish unfinished feature changes from unrelated local edits.
10. Search both write and read paths. A configuration command is incomplete if users cannot retrieve the resulting service state through the corresponding PowerShell getter.

When several existing commands could host a new vault setting, choose based on existing semantics:

- Prefer `Update-AzRecoveryServicesVault` for general Recovery Services vault resource PATCH properties.
- Use `Set-AzRecoveryServicesVaultProperty` only for settings already owned by its Backup vault-property contract.
- Use a dedicated Backup item cmdlet when the operation targets a protected item rather than the vault.

Treat review feedback as an end-to-end public contract change. If reviewers remove parameters, rename a cmdlet, add an alias, or require both enable and disable directions, update the specification, implementation, manifest, help, examples, tests, and changelog together.

The RecoveryServices SDK folders contain legacy generated C# clients. Prefer the supported README generation workflow. If the available AutoRest version produces an incompatible modern module instead of the legacy management SDK, do not copy it wholesale. Make only the smallest contract-accurate generated-style addition required by the approved Swagger and keep it isolated.

### End-to-end implementation sequence

Use this sequence for a new feature or cmdlet:

1. **Map the service contract:** Confirm the owning resource provider, API version, Swagger operation, request/response models, supported resource types, and long-running behavior.
2. **Choose the owning project:** Select the vault, Backup, or Cross Region Restore route from the project map.
3. **Update the SDK contract:** Regenerate through the supported README workflow, or make the smallest generated-style contract addition when regeneration is incompatible.
4. **Wire the operation:** Use the owning generated client directly or add a narrow `ServiceClientAdapter`/provider method that preserves headers, errors, cancellation, and vault context.
5. **Add public models and conversions:** Project new SDK fields into stable PowerShell models and update formatting only when the default view should display them.
6. **Implement the cmdlet:** Follow nearby parameter-set, pipeline, `ShouldProcess`, confirmation, error, output, and resource-string patterns.
7. **Export the command:** Update the manifest and aliases, then verify the command is discoverable after module import.
8. **Add focused tests:** Cover valid parameter sets, state transitions, unsupported inputs, service errors, output projection, and long-running behavior.
9. **Update user documentation:** Add help, examples, online links, help index entries, and a user-focused changelog entry.
10. **Validate the complete path:** Build affected projects, run targeted playback tests, generate help, run static analysis, import the module, and inspect the final diff.

Do not implement only the cmdlet class. A feature is complete only when its SDK contract, invocation path, public models, exports, tests, help, and changelog are consistent.

### Cross-surface feature contract checklist

Some RecoveryServices features span vault configuration, protected-item actions, and read-only models. Treat each surface as a separate contract:

| Scope | Expected ownership and behavior |
|---|---|
| Vault | A Recovery Services vault resource property, normally updated through `Update-AzRecoveryServicesVault` and read through `Get-AzRecoveryServicesVault`. The service manages operation identity unless the approved contract explicitly exposes identity input. |
| Protected item | Use a dedicated Backup cmdlet when the service exposes a protected-item action. Use the generated SDK action rather than replacing it with a direct REST call or a broad protected-item PUT. |
| Protected-item output | `Get-AzRecoveryServicesBackupItem` must retain and expose every approved service property needed to understand the feature state or result. |
| Recovery-point output | Recovery-point getters must expose approved feature-specific status and structured details without flattening away service data. |
| Related resources | Update container, policy, job, vault, or Cross Region Restore getters when the service contract adds related fields to those resources. |

For any stateful configuration feature:

- Support every approved transition, such as enable, disable, suspend, resume, lock, unlock, or re-enable.
- Validate supported backup management types, workloads, resource states, and feature combinations before sending the request.
- Require the vault-level prerequisite when the service contract requires it; surface the service error clearly if the prerequisite is not met.
- Require confirmation only for destructive, irreversible, or security-reducing transitions.
- If the cmdlet supports `-PassThru`, re-read and return the updated resource; without `-PassThru`, preserve the established output behavior.
- Derive native container and protected-item names from the selected item's ARM ID. Do not reconstruct names from friendly names.
- Verify behavior when the requested state is already set. Only suppress a documented idempotency error when the command's established contract intentionally treats it as success.
- Keep terminology consistent with the approved public contract. Explain uncommon acronyms on first use and do not leak internal stamp, rollout, or implementation terminology into help.

## 2. Implement the command surface

Follow Azure PowerShell naming and design conventions:

- Use `[Cmdlet]`, `[OutputType]`, parameter sets, positions, pipeline binding, validation attributes, and help messages consistently with neighboring cmdlets.
- Construct Az aliases with `AzureRMConstants.AzureRMPrefix`, for example:

  ```csharp
  [Alias("Set-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesExample")]
  ```

- Use `SupportsShouldProcess = true` for commands that change or delete resources.
- Use the module's established `ShouldProcess`, `ConfirmAction`, and `-Force` patterns.
- Prompt for confirmation only for destructive or irreversible behavior.
- Preserve service errors instead of replacing them with broad catches or success-shaped fallbacks.
- Validate unsupported workloads and invalid parameter combinations before sending a request.
- Keep public parameter types strongly typed and reuse existing enums and models.
- Use resource strings for user-facing messages when the project follows that pattern.

Update every public surface affected by the command:

- Vault or Backup cmdlet implementation.
- Relevant management SDK request, response, and enum models.
- Backup `ServiceClientAdapter` operation when the generated client does not expose the API.
- PowerShell models in `RecoveryServices.Backup.Models` and conversions in `RecoveryServices.Backup.Helpers`.
- `RecoveryServices.Backup.format.ps1xml` when compact output should expose new properties.
- `RecoveryServices/Properties/Resources.resx` or the feature project's resource file for user-facing messages.
- `RecoveryServices/Az.RecoveryServices.psd1` cmdlet and alias exports.
- Existing `Get-*` conversion paths and format views so new service properties survive SDK-to-PowerShell projection.

When a reviewed command name changes:

- Rename the C# file and class.
- Update the `[Cmdlet]` noun and `[Alias]` attributes.
- Replace the old name in tests, examples, help filenames, help indexes, manifests, and changelogs.
- Search the module for stale references before completing the task.

When a public parameter is removed:

- Remove the parameter declaration, validation, enum if no longer used, request construction, resource strings, help sections, examples, and test inputs.
- Do not continue sending the removed value implicitly unless the approved service contract requires it.
- Document service-managed behavior without exposing implementation-specific identity choices.

## 3. Handle service operations correctly

- Use the API version and Swagger commit pinned by the module generation configuration.
- When a Swagger pull request is supplied, verify its merged commit and stable file paths before updating generation configuration.
- Update both the generation README commit pin and API path. If generated clients are maintained in the repository, ensure their default API version also matches the approved contract.
- Match the exact HTTP method, resource path, payload shape, and accepted response codes.
- For long-running operations, preserve `Azure-AsyncOperation`, `Location`, `Retry-After`, request ID, and service error details.
- Use existing generated operations or adapter helpers where possible.
- Do not temporarily mutate a shared client's API version for one request.
- Do not replace a dedicated action API with a broad resource PUT unless the service contract explicitly requires it.
- For Backup long-running operations, return an `AzureOperationResponse` compatible with `RSBackupVaultCmdletBase.HandleCreatedJob`.
- Pass the vault name and resource group explicitly when a cmdlet accepts `-VaultId`; do not rely on stale global vault context.
- Use `HelperUtils.ParseUri`, `GetContainerUri`, and `GetProtectedItemUri` for protected-item identifiers when neighboring Backup cmdlets use them.
- Restrict workload-specific operations client-side using `BackupManagementType` and `WorkloadType`.
- Use the generated SDK method whenever the approved SDK exposes the operation. Do not add or retain a direct REST implementation for a cmdlet when the SDK operation is available.
- Preserve the generated SDK's request model. Do not substitute a similarly named model from another SDK or stamp.
- After any SDK upgrade, inspect all call sites in the affected command module, not only the new feature path.

### SDK split and upgrade workflow

Recovery Services features can span SDKs with similar namespaces but different operations or models. Treat each SDK as a separate contract:

1. List the exact SDK project versions and pinned Swagger contracts before editing.
2. Identify which SDK owns Recovery Services vault, Backup, and Cross Region Restore operations.
3. If more than one SDK is affected, update each project and generation README independently. Do not assume a Backup SDK update also updates the Recovery Services vault SDK.
4. Compare operation method signatures and model constructors between old and new SDK versions.
5. Search every affected operation invocation. Generated SDK upgrades can change overloads, parameter order, optional arguments, model types, or serialized property names.
6. Update adapters, provider classes, and client construction so each cmdlet uses the generated client that owns its API.
7. Do not add hybrid constructors, serializers, or broad compatibility shims only to conceal model incompatibilities. Add compatibility handling only for a real public-output requirement and scope it narrowly.
8. Build or import the module immediately after the SDK wiring change, before debugging scenario recordings.

### Swagger README updates

When adopting a new Swagger contract, update every relevant RecoveryServices SDK generation README:

- `RecoveryServices.Management.Sdk/README.md` for Recovery Services vault resource APIs.
- `RecoveryServices.Backup.Management.Sdk/README.md` for Backup management APIs.
- `RecoveryServices.Backup.CrossRegionRestore.Management.Sdk/README.md` for Cross Region Restore APIs.

1. Locate all relevant SDK projects, including resource-management and data-plane or backup SDKs.
2. Update the `commit` value to the full merged commit SHA from `azure-rest-api-specs`.
3. Update each `input-file` URL to use `$(commit)` and the approved stable or preview API folder.
4. Confirm the service namespace and Swagger filename are correct for each SDK.
5. Do not pin an unmerged pull-request head commit unless the task explicitly targets temporary validation.
6. Keep README API versions, generated client defaults, hand-authored adapter requests, tests, and documentation consistent.
7. Search for stale commit hashes, old API folders, and preview versions after the update.

Example:

```yaml
commit: <full-merged-commit-sha>
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservicesbackup/resource-manager/Microsoft.RecoveryServices/RecoveryServicesBackup/stable/<api-version>/bms.json
```

## 4. Add tests

Add focused unit or scenario coverage for:

- Each parameter set and valid state transition.
- Request payload and API action mapping.
- `ShouldProcess`, `-WhatIf`, `-Confirm`, and `-Force`.
- Pipeline input and aliases.
- Unsupported resource or workload validation.
- Service error propagation.
- Output from related `Get-*` cmdlets when new model fields are added.
- Long-running-operation job tracking.
- Both directions of stateful configuration, such as enable and disable, including re-enabling after disable where supported.
- Native-name resolution and ambiguous friendly-name handling.
- Vault prerequisite and already-in-requested-state behavior.

For scenario tests:

- Use existing setup and assertion helpers.
- Put Backup scenarios under the matching workload folder such as `ScenarioTests/IaasVm`, `AzureFiles`, `AzureSql`, or `AzureWorkload`.
- Add or update the corresponding xUnit wrapper in the same scenario area.
- Avoid new hardcoded resource identifiers when reusable test variables or setup helpers are available.
- Validate that required output properties exist before checking expected values.
- After changing protected-item models, call the corresponding protected-item getter and validate all newly exposed status and summary properties.
- After changing recovery-point models, call the recovery-point getter and validate all newly exposed status and structured detail properties.
- Keep tests compatible with Windows PowerShell 5.1 unless the test infrastructure explicitly requires PowerShell 7.
- Do not skip an existing test. New live scenarios may be skipped only when recordings or service availability genuinely block execution, with a precise reason.

For stateful protected-item scenarios:

1. Retrieve an existing item and inspect its current state.
2. Normalize it to a known starting state rather than assuming the environment is clean.
3. Exercise every supported transition, including reversing the change where supported.
4. Re-fetch the item after each operation; do not assert against a stale object.
5. Verify the presence of newly exposed properties before asserting their values.
6. If the feature affects recovery points, retrieve a known recovery point and verify its feature-specific status and structured details.
7. Use a stable item selector. If a friendly name can return multiple items, select through a container or native item identity.

### Recording and failure triage

Never treat every playback failure as a code regression. Classify failures before editing:

| Failure class | Typical evidence | Action |
|---|---|---|
| Code/SDK contract | Build error, missing generated operation, wrong model type, constructor mismatch, serialization exception | Fix the call site, generated model, adapter, client construction, or conversion. |
| Recording mismatch | No matching request, exhausted cassette, changed API version/path/query/body | Compare the exact request with the recording; re-record only when the code request is correct. |
| Live environment | RBAC/forbidden, quota exhaustion, resource already registered, operation still running, missing prerequisite | Repair or clean the test environment without weakening product code. |
| Assertion drift | Service returns a valid new state such as `CompletedWithWarnings` or a newly populated property | Confirm the intended contract before updating the assertion. |
| Service issue | Correct request receives a reproducible service failure | Capture request ID, operation, region, resource state, and error details; do not mask it in client code. |

Recording rules:

- Run playback before live tests when recordings exist.
- Do not overwrite or hand-edit recordings merely to make tests pass.
- Preserve existing user recording changes unless the changed request contract makes them obsolete.
- For a mismatch, report the test, recording file, unmatched method/path/query/body, and first actionable stack location.
- Re-record only the affected tests after code and environment are correct.
- Run live tests serially when scenarios share vaults, VMs, policies, quotas, or mutable state.
- If a long-running test appears stuck, inspect the Azure job/resource state and expected polling duration before stopping it.

## 5. Update user documentation

Update the module `ChangeLog.md` under `## Upcoming Release`:

- Write from the user's perspective.
- Start feature details with wording such as "Added support" rather than imperative wording such as "Use".
- Explain less-common acronyms on first use.
- Mention the primary cmdlet and meaningful aliases.

Update or generate Markdown help:

- Place public help in `src/RecoveryServices/RecoveryServices/help`.
- Use the final cmdlet name and online help URL.
- Document every public parameter and accepted value.
- Include realistic enable, disable, and pipeline examples where applicable.
- Remove superseded parameters and examples.
- Update the module help index and rename obsolete help files.
- Document vault-level, workload, resource-state, and permission prerequisites before examples that depend on them.

## 6. Validate the complete change

Use the smallest commands that cover the modified behavior:

1. Build the changed SDK, adapter, cmdlet, module, and test projects. Typical Backup feature projects are:
   - `RecoveryServices.Management.Sdk`
   - `RecoveryServices.Backup.Management.Sdk`
   - `RecoveryServices.Backup.ServiceClientAdapter`
   - `RecoveryServices.Backup.Models`
   - `RecoveryServices.Backup.Helpers`
   - `RecoveryServices.Backup`
   - `RecoveryServices`
   - `RecoveryServices.Backup.Test`
2. Parse changed PowerShell scripts and the module manifest.
3. Confirm the manifest exports the new cmdlet and aliases.
4. Run targeted tests in playback mode when recordings exist.
5. Generate help when public command syntax changed.
6. Run module static analysis for changes intended for submission.
7. Import the built module and verify `Get-Command`, aliases, parameter metadata, and help.
8. Search for old cmdlet names, removed parameters, preview API versions, and stale help links.
9. Run `git diff --check` and inspect the final diff for unrelated changes.
10. Separate remaining failures into code, recording, environment, assertion, and service categories. Do not report only a raw failed-test count.

Do not cancel Azure PowerShell builds or tests because they may remain quiet for extended periods.

For full module validation, use:

```powershell
dotnet msbuild build.proj /p:Scope=RecoveryServices
dotnet msbuild build.proj /t:GenerateHelp
dotnet msbuild build.proj /t:StaticAnalysis
```

After building, import `artifacts/Debug/Az.RecoveryServices/Az.RecoveryServices.psd1` and verify the changed cmdlet with `Get-Command` and `Get-Help`.

### Completion checklist

Before declaring the feature complete, verify:

- The final reviewed names and parameters are used everywhere.
- Every affected SDK is updated when the feature spans multiple service contracts.
- The implementation uses generated SDK calls rather than a redundant direct REST path.
- Vault, protected-item, and recovery-point read models expose all approved fields.
- Native resource names are derived correctly and duplicate friendly names cannot silently select the wrong item.
- Supported transitions, unsupported workloads, prerequisites, idempotency, and confirmation behaviors are covered.
- Playback failures have been classified before any re-recording.
- Help, examples, manifests, adapters, changelogs, and recordings match the final contract.

## Reference documents

Consult these repository documents as needed:

- `CONTRIBUTING.md`
- `documentation/development-docs/azure-powershell-developer-guide.md`
- `documentation/development-docs/design-guidelines/cmdlet-best-practices.md`
- `documentation/development-docs/design-guidelines/parameter-best-practices.md`
- `documentation/development-docs/design-guidelines/piping-best-practices.md`
- `documentation/development-docs/help-generation.md`
