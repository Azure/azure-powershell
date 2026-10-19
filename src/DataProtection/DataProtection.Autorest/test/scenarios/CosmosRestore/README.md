# Opt-in Cosmos restore scenario tools

These DataProtection-specific tools live under the module's test tree, not the
repository-wide tools directory. The build copies this tree into Debug artifacts.
Neither filename ends in `.Tests.ps1`; Pester does not discover or invoke them.
They are separate from the [offline suites and recorded-test workflow](../../README.md).

| Entrypoint | Operation boundary |
| --- | --- |
| [Invoke-CosmosRestoreScenario.ps1](Invoke-CosmosRestoreScenario.ps1) | Creates owned Cosmos fixtures, policy and BI; runs native backup, full/ILR restore, job snapshots and exact data/exclusion verification |
| [Invoke-CosmosRestoreNegativeTests.ps1](Invoke-CosmosRestoreNegativeTests.ps1) | Local fail-fast checks by default; an additional explicit switch allows native validation-only service observations, never restore submission |

## Preconditions and scope

- PowerShell **7.2+**, a fresh process per phase and a built local DataProtection
  AutoRest manifest under this checkout's artifacts directory.
- Existing authorized subscription, resource group and backup vault; already
  authenticated executing Entra user and required provisioning/RBAC/data access.
- Explicit `-EnableLive`. Service negatives additionally require
  `-ServiceValidation` and an explicitly selected owned empty target.
- No automatic sign-in, source migration, identity attachment, vault setting
  change, firewall change, destructive cleanup or direct DataProtection REST fallback.
- Source fixture accounts are NoSQL, AAD-only and Continuous7Days. Continuous
  backup retention is not vault retention. The unchanged native Cosmos policy
  template has **P10Y vault retention**; obtain cost/retention approval first.
- Default run creates five accounts (one source, four targets); all three optional
  cases require eight total. State and resources persist and can incur charges.

The target must already be created by the owned run and contain **zero databases**,
not merely no conflicting selected containers. `FailIfExists` does not authorize
deleting or overwriting existing data. Keep source and target IDs distinct.

## Positive phases

Run from the repository root. Replace placeholders with approved test resources.
The prefix must end in eight unique lowercase hex digits. Output must be ignored,
outside the module artifact; preserve it as trusted private run state.

```powershell
pwsh -NoProfile -File ./src/DataProtection/DataProtection.Autorest/test/scenarios/CosmosRestore/Invoke-CosmosRestoreScenario.ps1 `
    -EnableLive -Phase Prepare `
    -SubscriptionId '<subscription-id>' `
    -ResourceGroupName '<existing-test-rg>' -VaultName '<existing-test-vault>' `
    -ModulePath './artifacts/Debug/Az.DataProtection/DataProtection.Autorest/Az.DataProtection.psd1' `
    -TestPrefix 'cosmos-<eight-random-hex-digits>' `
    -OutputDirectory './artifacts/CosmosLive/<unique-run>'
```

Repeat the same run arguments for **Prepare → Backup → Poll → Restore → Poll →
Verify**. `Poll` takes one read-only snapshot of each saved job; it does not sleep
until completion. Call it later when pending, never resubmit the original write.
Restores are sequential; a pending/unknown job blocks the next target and case.

- `Targets` optionally creates owned empty targets/verification roles before
  restore. No restore job is submitted by that phase.
- `Churn`, after the completed backup/RP and before any restore intent, adds
  `db2/afterBackup` plus one document to the owned source. It never changes the
  frozen backup-time baseline. `All` never performs churn.
- `AdditionalScenario` can append `containers`, `multiDatabase`, or `uami`. When
  invoking via a PowerShell wrapper, pass a real string array, not a comma-bearing
  single argument to `pwsh -File`.
- The `uami` case requires an already attached `RestoreUserAssignedIdentityArmId`;
  other cases/backup identities remain unchanged. `UserAssignedIdentityArmId`
  separately selects the backup/default-case identity. Preserve these values on resume.

## Fixture and required verification

Baseline: `db1` has `cont1`, `col1`, `col2`, `excluded`; `db2` has `c1`, `c2`;
`unselectedDB` has `control`. Each container uses `/id` and two deterministic
documents: **3 databases / 7 containers / 14 documents** before backup.

| Case | Selection | Expected DB / container / document count |
| --- | --- | --- |
| Full | No ILR/configuration | 3 / 7 / 14 |
| Single | `db1/cont1` | 1 / 1 / 2 |
| Database | `db2` | 1 / 2 / 4 |
| Mixed | `db1/col1`, `db1/col2`, `db2` | 2 / 4 / 8 |
| Optional containers | `db1/col1`, `db1/col2` | 1 / 2 / 4 |
| Optional databases | `db1`, `db2` | 2 / 6 / 12 |
| Optional attached UAMI | `db1/cont1` | 1 / 1 / 2 |

Require the specific restore job to be `Completed`, then compare complete inventory,
partition keys and canonical application documents against the frozen baseline
projected through that case's selection. Full includes all baseline resources;
database-only includes all its baseline siblings. Exclude only unselected scopes
and, in every case, the optional post-backup `afterBackup` container/document.
Check the source remains unchanged by restores. Do not count validation acceptance
or HTTP 202 as completed/data-verified acceptance.

## Negative observations

Without `-ServiceValidation`, the negative tool calls only public local object
helpers; it does not read an Azure context, validate with the service or submit jobs.
It still requires `-EnableLive`, the same built `ModulePath`, the positive run's
`StatePath` and a separate ignored output directory.

Service validation requires a completed backup/RP, exact saved context, the same
selected identity and an explicitly owned empty target whose restore is not yet
submitted. A valid control must pass first. This tool never invokes the restore
trigger, even if malformed selectors are accepted by validation.

The observed empty, three-segment, overlapping and nonexistent-selector validation
acceptances are **VALIDATION_GAP**, not successful negative tests. Missing criteria
was rejected with `UserErrorInvalidRequestParameter`. No invalid restore job was
submitted. Client duplicate/overlap/empty/51-item guards and service observations
must be reported separately. The 50/51 boundary is offline coverage, not proof of
a live service limit from this seven-container fixture.

## State, failure handling and costs

An exclusive run lease, ownership tags, exact context/module fingerprint and
persisted write-ahead intents protect against duplicate/adopted resources. Never
reset `Submitting` or a known job ID merely because a process stopped. Reconcile
the specific vault jobs, BI, category, RP/target and submission time first.
Retain the same state directory and module build across phases.

Do not enable transcripts, HTTP Debug/Verbose or token-capturing tracing. Reports
are private and sanitize errors; do not commit run state, document contents,
subscription/principal IDs, credentials or raw service traces. A native run is
not a `.Recording.json` capture. Real recording is a separately approved workflow.

No cleanup is automatic. Review retained accounts, scheduled protection, vault
retention and ongoing costs with the owner; obtain separate deletion approval.