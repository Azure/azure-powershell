# Cosmos DB item-level recovery: test results

**Evidence date: 2026-10-15.** Results use the locally built `Az.DataProtection`
module and tracked API **2026-06-01**, not an installed module or stale generated
models. All seven positive native restore scenarios completed and passed data verification.
No new public cmdlets or parameters are introduced.

## Local verification

| Check | Observed result |
| --- | --- |
| Tracked module and parent builds | PASS: each completed with 0 warnings and 0 errors. |
| PowerShell 7.6.6 | PASS: 849 passed, 0 failed, 0 skipped, 0 errors. |
| Windows PowerShell 5.1 | PASS: 817 passed, 0 failed, 0 skipped, 0 errors. |
| Unchanged existing tests | PASS: 35 total: eSAN configuration 14; Blob/ADLS auto-protection 5; policy retention 16. |
| Fresh-process MAML generation | PASS: 56 cmdlet pages; generated XML approximately 1.4 MB. |
| Unmodified full repository Markdown gate | FAIL: module-name extraction path bug produces `//`. |
| Targeted Markdown diagnostic | PASS: the exact same rules, with an in-memory module-name correction, checked 56 pages with 0 issues. Diagnostic only; not an unmodified repository-gate pass. |
| Script analyzer | 0 errors. |
| Affected generated examples | 0 analysis errors; 71 existing warnings retained. |

The PowerShell 7 total comprises 809 product tests and 40 behavioral harness tests.
The Windows PowerShell total comprises the same 809 product tests and 8 AST checks
for the PowerShell-7-only tooling; it does not claim execution of that harness on 5.1.
The 35 unchanged tests above are a separate regression run, not additional cases
within either total. Shared identity regression coverage includes Disk, Postgres,
PGFlex, MySQL, ADLS, AKS, Blob, and eSAN; these are offline checks, not live restores.

The shared offline suite list contains six suites: `CosmosRestoreConfiguration`,
`CosmosRestoreRegression`, `CosmosRestorePermission`, `CosmosRestoreTransport`,
`CosmosRestoreHarness`, and `CosmosRestoreSharedIdentity`. On Windows PowerShell
5.1, the behavioral harness is replaced by the 8 AST checks described above.
The final typed-list compatibility fix preserves AKS/eSAN single-element arrays
and locally flattens the two AKS configuration paths. All 6 targeted compatibility
cases passed on both runtimes; they are included in the product totals above.
The six added legacy-array cases increased the shared product count from 803 to
809, not 815: PowerShell 7 is 849 minus 40 harness tests, and Windows PowerShell
is 817 minus 8 AST checks. The prior PowerShell 7 total was 843 (803 plus 40).

## Native lifecycle and restored data

The owned source baseline contained **3 databases, 7 containers, and 14 documents**.
The native policy was created from the unchanged template with **10-year retention**.
Initial readiness failed on a periodic-backup source. After the owned source was
corrected to **Continuous7Days**, permission readiness and backup-instance creation
passed, and the native backup completed. Continuous retention and vault retention
are distinct settings.

The following PASS results require both a completed native restore and independent
inventory/document verification; validation acceptance alone is insufficient.
Selector names below are synthetic fixture names, not account identifiers.

| Native restore case | Status | Verified inventory and exclusions |
| --- | --- | --- |
| Full account | PASS: COMPLETED + DOCUMENT/EXCLUSION VERIFIED | 3 databases, 7 containers, 14 documents. |
| Single container: `db1/cont1` | PASS: COMPLETED + DOCUMENT/EXCLUSION VERIFIED | 1 database, 1 container, 2 documents. |
| Database: `db2` | PASS: COMPLETED + DOCUMENT/EXCLUSION VERIFIED | 1 database, 2 containers, 4 documents; excludes post-backup `afterBackup`. |
| Mixed: `db1/col1`, `db1/col2`, `db2` | PASS: COMPLETED + DOCUMENT/EXCLUSION VERIFIED | 2 databases, 4 containers, 8 documents; excludes the other 3 baseline containers and post-backup churn. |
| Two containers | PASS: COMPLETED + DOCUMENT/EXCLUSION VERIFIED | 1 database, 2 containers, 4 documents. |
| Multiple whole databases | PASS: COMPLETED + DOCUMENT/EXCLUSION VERIFIED | 2 databases, 6 containers, 12 documents; excludes the unselected database and post-backup `afterBackup`. |
| Restore-specific UAMI | PASS: COMPLETED + DOCUMENT/EXCLUSION VERIFIED | 1 database, 1 container, 2 documents; explicit attached identity, exact content, and exclusions verified. |

The exact documentation sample `@('DB1/col1', 'Db1/col2', 'db2')` has offline
case/order and serialization proof. Live mixed selection used the lowercase fixture;
no live case-variant equivalence is claimed.

Full and the first single-container results reuse earlier completed native runs.
The final PowerShell client-list change preserves the same payload, proved offline.
Those restores were not repeated live after the narrow typed-list fix; the earlier
job/data evidence is retained, not represented as a new post-fix execution.

The first six completed cases above used the system-assigned managed identity (SAMI).
Native UAMI restore-permission `WhatIf` passed without assigning a role. An already attached existing
identity was selected successfully, and its actual principal mapping worked.
The seventh native restore then completed using that explicit UAMI, and independent
document, partition-key, inventory, and exclusion checks passed. The run's final
all-cases-verified checkpoint is true. Source post-backup inventory remained unchanged.

## Formal benchmark observations

These nine report rows separate positive restore evidence from negative validation.
The G labels follow the supplied benchmark's selector categories; the same single-container
alternate-location execution supports G1 and G13 rather than being counted as two runs.
B15 denotes the nonexistent selector
observation (named `Nonexistent` by the negative runner).

| Label | Case | Client / offline evidence | Native evidence and status |
| --- | --- | --- | --- |
| G1 | Single container | Selector and transport proof | PASS: completed; 1 database / 1 container / 2 documents. |
| G3 | Mixed selection | Ordered mixed criterion proof | PASS: completed; 2 databases / 4 containers / 8 documents; exclusions verified. |
| G4 | Database selection | Database-only criterion proof | PASS: completed; 1 database / 2 containers / 4 documents; churn excluded. |
| G13 | Single-container alternate-location restore | Existing ALR request and target proof | PASS: same completed single-container run as G1; no duplicate execution count. |
| B1 | Missing restore criteria | Deliberate service-model mutation | OBSERVED EXPECTED ARM 400: HTTP 400, `UserErrorInvalidRequestParameter`; no restore submitted. |
| B2 | Empty selectors | PASS: client fail-fast | `VALIDATION_GAP`: service validation accepted; no restore submitted. |
| B11 | Malformed three-segment selector | PASS: client fail-fast | `VALIDATION_GAP`: service validation accepted; no restore submitted. |
| B14 | Overlapping database/container scopes | PASS: client fail-fast | `VALIDATION_GAP`: service validation accepted; no restore submitted. |
| B15 | Nonexistent selection | Membership is service-authoritative | `VALIDATION_GAP`: service validation accepted; no restore submitted. |

Seven client benchmark negatives passed fail-fast checks: empty, malformed,
overlap, duplicate, 51 identifiers, missing configuration, and invalid restore mode.
This is **not** a claim that nine service negatives passed. Native negative calls
used validation only; negative RESTORE execution was intentionally not performed.
Accepted invalid requests are validation gaps, not successful negative tests or
proof that restore would accept them.

B1's native exception had no `Code` property, so the first sanitized report labeled
it `UnexpectedError`. The sanitizer was corrected to extract `ErrorId`; the measured
service response is the expected ARM HTTP 400 `UserErrorInvalidRequestParameter`,
not an unknown service failure. The other four `VALIDATION_GAP` observations remain
unchanged. No negative restore execution was performed.

Additional native validation correctly rejected an owned nonempty target with
`RequestNotSupportedOnNonEmptyCosmosDBAccountUserError` and a nonexistent target
with `ResourceNotFound`. These checks submitted no restore jobs.

The 50-accepted/51-rejected boundary is **offline only**. The live source had seven
containers; no 51-identifier live test was executed. This finite coverage is not
exhaustive and does not establish behavior for every possible input or environment.

## Static-analysis limitations and PR gates

**Overall repository static analysis: INCOMPLETE, not PASS.** The full run was
blocked by baseline `Api20260301` type-mismatch and cmdlet-diff issues.
An isolated, filtered signature/help/UX/check-error run returned native analyzer
exit code 0 with 50 existing style warnings, but its wrapper failed with loader
warnings; this result remains incomplete. The original full-run baseline mismatch
remains unresolved; the filtered result does not establish a full static-analysis
pass or clear the full repository gate.

The unmodified full repository Markdown gate also failed because module-name
extraction produced `//`. The targeted diagnostic used the exact same rules with
only an in-memory module-name correction: 56 pages, 0 issues. It is not a pass of
the unmodified gate and does not clear that repository blocker. Fresh-process
MAML generation passed independently; it does not override either gate result.

All seven positive native scenarios and data/exclusion verification are complete.
Remaining release work is resolution or explicit disposition of the known static-analysis
and repository Markdown environment/path blockers. Keep the PR **draft** while
these gates remain pending or incomplete: this report does **not** establish
readiness to ship. Do not promote an in-progress restore or partial analysis to PASS.

## Reproduction and evidence handling

Use the standard Pester invocation in the [command-level test matrix](test-matrix/README.md),
the [native scenario runner](../../../tools/Test/Invoke-CosmosRestoreScenario.ps1), and
[negative validation runner](../../../tools/Test/Invoke-CosmosRestoreNegativeTests.ps1).
See the [development guide](README.md) for prerequisites, opt-in phases, identity,
selector contracts, and the validation-versus-restore distinction; the
[repository overview](../../../README.md) describes the workspace.

Detailed raw evidence and state remain private and are intentionally not linked.
This report contains no subscription, principal, resource, or job identifiers,
local evidence paths, user references, or internal telemetry references.
There is **no automatic cleanup**: accounts, continuous backups, protected data,
and recovery points persist and can incur charges, including under the unchanged
10-year vault policy. Cleanup requires separate owner authorization.
