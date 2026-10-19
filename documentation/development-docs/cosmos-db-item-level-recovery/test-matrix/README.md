# Cosmos DB recovery: executed cmdlet test matrix

**Execution dates: 2026-10-15; offline Unix follow-up 2026-10-16.** This matrix records what was actually exercised
using the locally built `Az.DataProtection` module and API `2026-06-01`.
It is not a claim that every possible input, workload, or service environment was tested.
See the [results and release limitations](../TEST_RESULTS.md) and [feature guide](../README.md).

## 1. Test placement: existing infrastructure, no separate unit runner

The tests use the repository's existing **Pester 4.10.1** framework and live under
the existing [DataProtection test area](../../../../src/DataProtection/DataProtection.Autorest/test/README.md).
The extra Cosmos unit-runner script was a convenience wrapper, not a test suite;
it has been removed. No test assertions were removed.

Dedicated workload suites are an existing repository convention, for example
[Elastic SAN configuration tests](../../../../src/DataProtection/DataProtection.Autorest/test/ElasticSanBackupRestoreConfiguration.Tests.ps1).
The Cosmos files separate local construction, permissions, real generated HTTP
serialization, cross-workload regressions, and live-tool safety. Several older
cmdlet-named files contain skipped placeholders or recorded service workflows.
Moving these tests into those files would mix execution layers or duplicate their
fixtures; it is not necessary just to use the existing Pester infrastructure.

The [tracked generated module runner](../../../../generated/DataProtection/DataProtection.Autorest/test-module.ps1)
is retained unchanged. CI copies it and the source tests into the artifact module.
Its `-TestName` filters outer `Describe` names, not files; other discovered files
can still run top-level recording/environment setup. For the isolated offline
command below, explicitly select the six **artifact test files** and import the
**built module**, matching CI's directory layout. The suites also support source
test selection, but that alone does not establish CI discovery compatibility.
Canonical source freshness and generated-manifest checks remain separate from the
artifact path. Permission tests provide a throwing offline command boundary when
Az.Resources is absent, rather than depending on that unrelated module being built.

### Standard offline invocation

Run from the repository root in a **fresh PowerShell process** after building.
Pester 4.10.1 must already be installed on the process module path from an approved
source; do not import it from an ignored source-generation cache. This command
does not install dependencies or sign in to Azure. The built Accounts module or
another compatible Accounts dependency must be discoverable; Az.Resources is not
required by these isolated offline suites.

```powershell
$ErrorActionPreference = 'Stop'
$env:PSModulePath = (Join-Path $PWD 'artifacts/Debug') + [IO.Path]::PathSeparator + $env:PSModulePath
$artifact = Join-Path $PWD 'artifacts/Debug/Az.DataProtection/DataProtection.Autorest'

Import-Module Pester -RequiredVersion 4.10.1
Import-Module (Join-Path $artifact 'Az.DataProtection.psd1')

$files = @(Get-ChildItem (Join-Path $artifact 'test') `
    -Filter 'CosmosRestore*.Tests.ps1' -File)
if ($files.Count -ne 6) { throw 'Expected all six Cosmos restore suites.' }
$output = Join-Path $PWD 'artifacts/CosmosRestoreTests/ArtifactPester'
$null = New-Item -ItemType Directory -Path $output -Force
$result = Invoke-Pester -Script $files.FullName -PassThru `
    -OutputFile (Join-Path $output 'UnitTests.xml') -OutputFormat NUnitXml
$result | Select-Object TotalCount, PassedCount, FailedCount, SkippedCount, PendingCount
if ($result.TotalCount -eq 0 -or $result.FailedCount -gt 0 -or
    $result.SkippedCount -gt 0 -or $result.PendingCount -gt 0) {
    throw 'All selected tests must pass without skips or pending cases.'
}
```

This is ordinary `Invoke-Pester`, not another runner or test framework. The public
transport and shared-identity suites verify the loaded artifact's module/assembly
location; they do not replace the public commands with test-scope functions.

### Standard complete module playback

In another fresh process with Pester 4.10.1 and Accounts available, run the same
generated artifact runner used by CI. This discovers the complete module test
directory, not only the Cosmos suites. Existing unrelated placeholder/live-only
skips are expected in this broader run; a failure is not acceptable.

```powershell
$env:PSModulePath = (Join-Path $PWD 'artifacts/Debug') + [IO.Path]::PathSeparator + $env:PSModulePath
& ./artifacts/Debug/Az.DataProtection/DataProtection.Autorest/test-module.ps1 -Playback
if ($LASTEXITCODE -ne 0) { throw 'Complete DataProtection playback failed.' }
```

## 2. Evidence levels

| Level | What it proves | What it does not prove |
| --- | --- | --- |
| Local construction | Parameter validation and typed request construction | Azure service acceptance or restored data |
| Mocked permissions / intercepted transport | Correct principal/scope, WhatIf, actual generated JSON and endpoint | Real RBAC propagation or live job completion |
| Native service validation | The public validation cmdlet sent a request and its actual response | Restore completion or exhaustive selector validation |
| Native restore plus data verification | Completed job and exact selected inventory/content | Other untested API kinds, regions, or account configurations |

DataProtection policy, backup-instance, backup, validation, restore, recovery-point,
and job operations used native public cmdlets. No direct DataProtection REST
request or eSAN-labelled workaround was counted as feature acceptance.
Account/container provisioning used Az.CosmosDB and, where required for AAD-only
properties, Az.Resources. Document seeding/comparison used the Cosmos data plane;
those are fixture operations, not additional Az.DataProtection test cases.

## 3. Native policy, protection, and backup matrix

The source fixture was **3 databases, 7 containers, 14 documents**, with `/id`
partitioning and deterministic document contents. All steps below were executed.

| ID | Public Az.DataProtection command | Variation / assertion | Observed result |
| --- | --- | --- | --- |
| L01 | `Get-AzDataProtectionBackupVault` | Read the selected existing vault, location, SAMI and attached UAMI | PASS; no vault creation or settings change |
| L02 | `Get-AzDataProtectionPolicyTemplate -DatasourceType AzureCosmosDB` | Build the existing account-level VaultStore policy locally | PASS; full backup rule and existing 10-year retention |
| L03 | `New-AzDataProtectionBackupPolicy` | Create a uniquely named test policy from that template | PASS |
| L04 | `Get-AzDataProtectionBackupPolicy` | Retrieve and compare the created policy with the intended template | PASS |
| L05 | `Initialize-AzDataProtectionBackupInstance` | Cosmos account ARM ID, policy ID, location, explicit SAMI | PASS; typed BI constructed |
| L06 | `Set-AzDataProtectionMSIPermission -BackupInstance` | Source Cosmos DB Operator and source-resource-group Reader | PASS; correct selected principal/scope |
| L07 | `Test-AzDataProtectionBackupInstanceReadiness` | Periodic source, then the same owned source corrected to Continuous7Days | Initial user-error rejection; subsequent readiness PASS |
| L08 | `New-AzDataProtectionBackupInstance` | Create protection for the owned source and test policy | PASS |
| L09 | `Get-AzDataProtectionBackupInstance` | Check source/policy and wait for `ProtectionConfigured` | PASS; a transient earlier state did not trigger duplicate submissions |
| L10 | `Backup-AzDataProtectionBackupInstanceAdhoc` | Actual policy rule `BackupWeekly`, retention tag `Default` | PASS; one adhoc backup submitted |
| L11 | `Get-AzDataProtectionJob` | Poll that specific backup job to `Completed` | PASS |
| L12 | `Get-AzDataProtectionRecoveryPoint` | Resolve the completed backup's point for the correct BI | PASS; one point reused across restore comparisons |

The readiness rejection was
`RequestNotSupportedOnPeriodicBackupModeCosmosDBAccountUserError`: native long-term
protection required Continuous Backup Mode. Only the newly owned test source was
corrected. This was not a change to an existing customer account or vault setting.
No incremental-backup, policy-update, policy-deletion, or BI-deletion test is claimed.

## 4. Seven native restore combinations

Every row used this native sequence:

1. For ILR, `New-AzDataProtectionRestoreConfigurationClientObject` with Cosmos selectors.
2. `Initialize-AzDataProtectionRestoreRequest` with `VaultStore`, a recovery point,
   `AlternateLocation`, and the target **account** ARM ID. Full restore omitted ILR/configuration.
3. `Set-AzDataProtectionMSIPermission -RestoreRequest` for the same executing identity.
4. `Test-AzDataProtectionBackupInstanceRestore -Name ... -RestoreRequest ...`.
5. `Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName ... -Parameter ...`.
6. `Get-AzDataProtectionJob -Id ...` for that submission, followed by independent data checks.

Each positive case had a separate pre-existing, empty, owned NoSQL target account.
Only one restore was submitted at a time for this BI.

| ID / benchmark | Selection | Identity | Completed + verified result |
| --- | --- | --- | --- |
| R01 full baseline | Entire backed-up account; no ILR switch/configuration | SAMI | PASS: 3 databases / 7 containers / 14 documents |
| R02 G1 and G13 | `@('db1/cont1')` | SAMI | PASS: 1 database / 1 container / 2 documents |
| R03 G4 | `@('db2')` | SAMI | PASS: 1 database / 2 containers / 4 documents |
| R04 G3 | `@('db1/col1', 'db1/col2', 'db2')` | SAMI | PASS: 2 databases / 4 containers / 8 documents |
| R05 multiple containers | `@('db1/col1', 'db1/col2')` | SAMI | PASS: 1 database / 2 containers / 4 documents |
| R06 multiple databases | `@('db1', 'db2')` | SAMI | PASS: 2 databases / 6 containers / 12 documents |
| R07 attached UAMI | `@('db1/cont1')` with false system-identity flag and explicit UAMI ARM ID | UAMI | PASS: 1 database / 1 container / 2 documents |

G1 and G13 describe the same single-container alternate-location execution here;
they are not counted as two live runs. Full restore is an additional regression baseline.
The exact mixed-case sample `@('DB1/col1', 'Db1/col2', 'db2')` was tested offline for
preservation and serialization. The live fixture used lowercase names; live
case-variant lookup behavior is not certified by these results.

### Data and exclusion checks for every completed restore

- Required job status: `Completed`, not merely validation acceptance or HTTP 202.
- Exact database and container inventory, `/id` partition-key paths, document IDs,
  values, nested properties, and array order compared against the backup-time baseline.
- Service-generated document metadata excluded from application-content comparisons.
- Unselected sibling containers and databases absent; no unexpected extra resources.
- A container/document added under `db2` **after backup** absent from the restores,
  including database-only and mixed selections. Expansion did not use today's inventory.
- Source post-backup inventory/content remained unchanged by restores.

The final run checkpoint has every case verified. Full and early single-container
runs were not re-executed after the narrow typed-list compatibility change;
generated-payload equivalence and subsequent runtime regressions were checked offline.

## 5. Negatives: client rejection versus real service validation

Native service negatives below used **only**
`Test-AzDataProtectionBackupInstanceRestore`, with a valid request control first.
Malformed service models deliberately bypassed local guards to test the service
contract. No negative restore job was submitted.

| ID | Input / condition | Local public helper/initializer | Native validation observation |
| --- | --- | --- | --- |
| B1 | Missing `restoreCriteria` on the item-level target | Missing configuration rejected | HTTP 400 `UserErrorInvalidRequestParameter`; expected ARM rejection |
| B2 | Empty identifier list | PASS: rejected locally | **VALIDATION_GAP:** accepted by validation |
| B11 | `db1/cont1/item` | PASS: rejected locally | **VALIDATION_GAP:** accepted by validation |
| B14 | `@('db1', 'db1/cont1')` | PASS: overlapping scopes rejected | **VALIDATION_GAP:** accepted by validation |
| B15 | Nonexistent database/container | Membership left to the service | **VALIDATION_GAP:** accepted by validation |
| N06 | Exact duplicate identifier | PASS: rejected locally | Not submitted to the service |
| N07 | 51 identifiers | PASS: rejected locally; 50 accepted offline | Live service boundary not tested |
| N08 | ILR without restore configuration | PASS: rejected locally | Not submitted to the service |
| N09 | Unsupported restore-as-files mode for Cosmos | PASS: rejected locally | Not submitted to the service |
| N10 | Nonempty owned target account | Not an offline inventory check | Rejected: `RequestNotSupportedOnNonEmptyCosmosDBAccountUserError` |
| N11 | Nonexistent target account | Correct ARM-ID syntax can still name an absent resource | Rejected: `ResourceNotFound` |

Seven local benchmark negatives passed: empty, malformed, overlapping, duplicate,
51 entries, missing configuration, and invalid mode. The four validation gaps
are **findings, not passes** and do not establish what a restore job would do.
The native UAMI permission helper was also exercised with `-WhatIf`; it selected
the attached principal and performed no assignment on the tested restore path.

## 6. Offline and existing-test regression matrix

| Suite / existing file | Commands or contract exercised | Execution layer |
| --- | --- | --- |
| [CosmosRestoreConfiguration](../../../../src/DataProtection/DataProtection.Autorest/test/CosmosRestoreConfiguration.Tests.ps1) | Configuration helper, initializer, manifest, private selector validation; grammar, punctuation, case/order, counts, duplicates, overlap, malformed/mutated configurations, target/mode and identity combinations | Current source functions with real built models; no Azure calls |
| [CosmosRestoreRegression](../../../../src/DataProtection/DataProtection.Autorest/test/CosmosRestoreRegression.Tests.ps1) | Full and ILR requests, roundtrips, optional-object inspection/reference stability, AKS/eSAN scalar/array configuration, Blob prefix/range/rename paths | Generated serializer and local construction; no Azure calls |
| [CosmosRestorePermission](../../../../src/DataProtection/DataProtection.Autorest/test/CosmosRestorePermission.Tests.ps1) | `Set-AzDataProtectionMSIPermission`, SAMI/UAMI lookup, public/legacy precedence, ARM-ID casing, missing/ambiguous principals, scopes, existing roles, idempotence; Blob/ADLS/PGFlex/MySQL backup callers, AKS/eSAN restore datasource preview and PGFlex/MySQL cross-subscription file-target grants | Native custom module with Azure boundaries mocked; no universal WhatIf or live RBAC claim |
| [CosmosRestoreTransport](../../../../src/DataProtection/DataProtection.Autorest/test/CosmosRestoreTransport.Tests.ps1) | Exported helper/initializer, public validate/start; one validation wrapper versus raw trigger, API/JSON casing, selectors, identities, no new exports, zero HTTP sends under WhatIf | Actual generated HTTP requests intercepted before network; not recording playback |
| [CosmosRestoreSharedIdentity](../../../../src/DataProtection/DataProtection.Autorest/test/CosmosRestoreSharedIdentity.Tests.ps1) | Exported initializer for Disk, PostgreSQL, PG Flex, MySQL and ADLS; full/files/ADLS ILR and existing non-Cosmos identity behavior | Local exported commands and generated JSON; not live workload restores |
| [CosmosRestoreHarness](../../../../src/DataProtection/DataProtection.Autorest/test/CosmosRestoreHarness.Tests.ps1) | Owned-resource guards, checkpoints/no duplicate submission, identity, pending jobs, expected-inventory union, safe diagnostics, no destructive entrypoints | PowerShell 7.2+ mocked tooling behavior; Desktop AST contracts only |
| [Existing eSAN tests](../../../../src/DataProtection/DataProtection.Autorest/test/ElasticSanBackupRestoreConfiguration.Tests.ps1) | Backup/restore objects, single-volume restriction, overrides and foreign parameters | 14 unchanged local tests |
| [Existing auto-protection tests](../../../../src/DataProtection/DataProtection.Autorest/test/AutoProtectionBackupConfiguration.Tests.ps1) | Blob/ADLS automatic-protection configuration and exclusions | 5 unchanged local tests |
| [Existing retention tests](../../../../src/DataProtection/DataProtection.Autorest/test/Edit-AzDataProtectionPolicyRetentionRuleClientObject.Tests.ps1) | Blob retention plus AKS/Disk overwrite compatibility | 16 unchanged local tests |

| Runtime / group | Executed result |
| --- | --- |
| PowerShell 7.6.6 on Windows, six artifact-selected suites | 908 passed, no failures/skips/pending cases; Resources absent |
| Windows PowerShell 5.1, six artifact-selected files | 876 passed, no failures/skips/pending cases; Resources absent |
| PowerShell 7.6.7 on Linux, LF source / CRLF artifact | 908 passed, no failures/skips/pending cases; Resources absent, no persisted context, live HTTP blocked |
| Remote builds 361715/361716 at 4c282a54bf0 | All four platform module playback jobs: 940 passed / 0 failed / 241 existing skips; build and analysis passed |
| Guarded complete local Linux playback at 4c282a54bf0 | 940 passed / 0 failed / 241 existing skips; predates 32 new reviewer-follow-up cases |
| Independent tracked-input sandbox, source and artifact layouts | 864 passed in each PowerShell 7 run, no source-generation cache |
| Complete standard generated artifact playback, PowerShell 7 | 928 passed, 0 failed, 241 existing skips outside the six-suite gate |
| Existing three suites | 35 passed separately, no failures/skips/pending cases |

Current six-suite runtime totals contain the same **868 product/layout cases**; PowerShell 7 adds
40 behavioral tool cases and Desktop adds eight explicitly AST-only contracts.
Those runtime totals are not unique live scenarios and must not be added to the
seven live restores. The 15 added CI-follow-up cases cover source/artifact path
resolution and null-identity handling, including unchanged non-Cosmos behavior.
The next 12 cases verify LF/CRLF freshness equivalence without hiding real stale
content. The original Unix setup failure was reproduced under Linux before the
fix; the repaired suites execute all shared-identity cases there. The subsequent
remote runs at 4c282a54bf0 confirmed every platform as passing. This review then
added 32 permission-caller/identity-precedence cases without changing production;
their new-commit remote checks still require verification. Historical sandbox and
928-case full-run counts predate the later additions and are not claimed as new totals.
No existing six-suite assertions were removed or skipped. No new live AKS/Blob/eSAN/Disk/database-resource restore was
performed to claim cross-workload compatibility; the coverage above is offline.

## 7. Limitations and reproduction safety

The 50/51 boundary, literal punctuation, and case variants have offline coverage,
not live boundary/name certification. No CRR, CSR, other Cosmos API, overwrite,
rename, restore-as-files, negative restore execution, cleanup, or performance SLA
is certified. The [results report](../TEST_RESULTS.md) records repository static-analysis
and Markdown-validator blockers separately; this matrix is not a green-CI claim.

The [opt-in native scenario tool](../../../../src/DataProtection/DataProtection.Autorest/test/scenarios/CosmosRestore/Invoke-CosmosRestoreScenario.ps1)
and [validation-only negative tool](../../../../src/DataProtection/DataProtection.Autorest/test/scenarios/CosmosRestore/Invoke-CosmosRestoreNegativeTests.ps1)
remain distinct from offline Pester tests because they perform authorized live
operations and preserve run ownership/submission state. Use the feature guide's
explicit opt-in procedure rather than replaying example commands blindly.
No live operations were rerun merely to produce this matrix.

All raw run artifacts remain private and ignored. No resource/job/principal IDs
or credentials are needed in this public matrix. Resources were retained; the
unchanged native policy has 10-year vault retention and ongoing costs. Cleanup
requires separate owner authorization.