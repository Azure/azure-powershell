# Cosmos DB database and container recovery

This guide covers the native `Az.DataProtection` Cosmos DB item-level recovery (ILR)
implementation and its local and opt-in live tests. Here, **item-level** means
selecting databases and containers, not individual documents or query results.
The implementation reuses existing cmdlets, parameters, and generated models;
it introduces no new cmdlet or parameter and does not bump the API version.

**Validation status:** seven native restore scenarios completed with exact data and
exclusion verification. See [test results](TEST_RESULTS.md) for runtime test counts,
service-validation gaps, and repository-tool blockers; a full repository-gate pass
is not claimed.

## Scope and prerequisites

- Use a recovery point belonging to the source backup instance in `VaultStore`.
- Use `AlternateLocation` and a **pre-existing, completely empty Cosmos DB for
  NoSQL target account**. Zero databases are required, not merely absent selected
  containers. `FailIfExists` does not authorize deleting or overwriting resources.
- Renaming, overwrite, original-location restore, point-in-time restore,
  restore-as-files, and cross-region restore are not added by this change.
- The source for native long-term protection must use **Continuous Backup Mode**.
  Live readiness validation rejected a periodic-mode source. The current scenario
  runner provisions and requires `Continuous7Days`; this is distinct from vault
  retention and is not a claim that every continuous tier has been tested.
- Use an existing backup vault and explicitly select its system-assigned identity
  (SAMI), or a user-assigned identity (UAMI) already attached to that vault.
  Ensure that identity has the required source and target management-plane rights.
  The test operator separately needs provisioning, role-assignment, and Cosmos
  data-plane permissions for seeding and verification.
- Confirm service availability and account compatibility for the intended
  environment. This guide makes no service-wide GA, region, or Cosmos API claim.

See the [Cosmos datasource manifest](../../../src/DataProtection/DataProtection.Autorest/custom/manifests/AzureCosmosDB.json)
for client capabilities, permission roles, and the native policy template.

## Selector contract

Use the existing configuration helper with `-DatasourceType AzureCosmosDB` and
`-ResourceIdentifier`, passing a string array:

```powershell
$configuration = New-AzDataProtectionRestoreConfigurationClientObject `
  -DatasourceType AzureCosmosDB `
  -ResourceIdentifier @('DB1/col1', 'Db1/col2', 'db2')
```

| Input | Meaning or client behavior |
| --- | --- |
| `database/container` | Select that backed-up container. |
| `database` | Request all backed-up containers in that database at the selected recovery point. |
| Mixed database/container entries | Forward together in one criterion, in the supplied order. |
| Count | Require 1–50 identifiers; no truncation. |
| Case and order | Preserve exactly; do not trim, lowercase, decode, or enumerate the current source. |
| Exact duplicates | Reject using ordinal, case-sensitive comparison. |
| Parent/child overlap | Reject `db` together with `db/container`, in either order, using ordinal comparison. |
| Empty or whitespace-only entries/segments | Reject locally. |
| Structural separators | Allow at most one `/`, with nonempty database/container segments; reject backslash, `?`, `#`, and control characters. |
| Other valid Cosmos name punctuation | Accept literally, including `*`, commas, and braces; never expand wildcards or parse a comma/brace-delimited list. |

`DB1` and `Db1` are not merged by the client. A literal `*` is a name character,
not a request for all resources. Use a database-only selector for database scope.
URLs and ARM IDs are not database/container selectors. The target parameter,
however, takes the **account ARM ID**, not a database or container ARM ID.
The service remains authoritative for recovery-point membership and compatibility.

The helper creates one `GenericRestoreDatasourceCriteria` containing one
`ResourceListSelectionCriteria`. Public model properties are singular where
the generated wire names are plural:

```json
{
  "objectType": "GenericRestoreDatasourceCriteria",
  "resourceSelectors": {
    "objectType": "ResourceListSelectionCriteria",
    "resourceIdentifiers": ["DB1/col1", "Db1/col2", "db2"]
  }
}
```

The target's `RestoreCriterion` serializes as the `restoreCriteria` array;
`ResourceSelector` becomes the `resourceSelectors` **object**, and
`ResourceIdentifier` becomes the `resourceIdentifiers` array. There is only
one criterion for the entire mixed selection, with no name overrides.
See the [selector validator](../../../src/DataProtection/DataProtection.Autorest/custom/Helpers/RestoreHelpers.ps1)
and [configuration helper](../../../src/DataProtection/DataProtection.Autorest/custom/Cmdlets/Platform/Restore/New-AzDataProtectionRestoreConfigurationClientObject.ps1).

## Native initialize, validate, trigger, and poll

Run in a fresh PowerShell process and import the locally built module explicitly
when validating this checkout. Do not substitute an installed Gallery module or
stale binaries: the tracked unversioned models must come from the local artifact.
Run examples from the repository root. Replace every placeholder with an authorized
test resource or completed recovery point; establish context and permissions first.

```powershell
Import-Module ./artifacts/Debug/Az.DataProtection/DataProtection.Autorest/Az.DataProtection.psd1

$vault = @{
  SubscriptionId = '<subscription-id>'
  ResourceGroupName = '<vault-resource-group>'
  VaultName = '<vault-name>'
}
$backupInstanceName = '<source-backup-instance-name>'
$targetAccountId = '/subscriptions/<subscription-id>/resourceGroups/<target-resource-group>/providers/Microsoft.DocumentDB/databaseAccounts/<empty-target-account>'

$configuration = New-AzDataProtectionRestoreConfigurationClientObject `
  -DatasourceType AzureCosmosDB `
  -ResourceIdentifier @('DB1/col1', 'Db1/col2', 'db2')

$request = Initialize-AzDataProtectionRestoreRequest `
  -DatasourceType AzureCosmosDB -SourceDataStore VaultStore `
  -RestoreType AlternateLocation -RestoreLocation '<target-region>' `
  -TargetResourceId $targetAccountId -RecoveryPoint '<recovery-point-id>' `
  -ItemLevelRecovery -RestoreConfiguration $configuration `
  -UseSystemAssignedIdentity $true

Test-AzDataProtectionBackupInstanceRestore @vault `
  -Name $backupInstanceName -RestoreRequest $request

$result = Start-AzDataProtectionBackupInstanceRestore @vault `
  -BackupInstanceName $backupInstanceName -Parameter $request

# Resolve the specific job ID from this submission's native result.
# Do not choose the latest job from the vault or automatically resubmit.
$restoreJobId = '<job-id-resolved-from-this-submission>'
Get-AzDataProtectionJob @vault -Id $restoreJobId
```

For an attached UAMI, replace the initializer's identity argument with
`-UseSystemAssignedIdentity $false -UserAssignedIdentityArmId '<attached-uami-arm-id>'`.
Use the same identity when granting permissions; this example attaches no identity.
Omit both ILR arguments only for intentional full restore; selection configuration
without `-ItemLevelRecovery` is rejected, not ignored.

The validator uses `-Name -RestoreRequest` and wraps the request once as
`restoreRequestObject`. The trigger uses `-BackupInstanceName -Parameter` and
submits the raw typed request. Validation alone does not establish restore or
data-level success. Poll that specific job until terminal, with a bounded deadline;
require `Completed` and independently verify selected inventory and document content,
including the absence of excluded resources. Reconcile ambiguous submissions before retry.

Sources: [initializer](../../../src/DataProtection/DataProtection.Autorest/custom/Cmdlets/Platform/Restore/Initialize-AzDataProtectionRestoreRequest.ps1),
[validator](../../../src/DataProtection/DataProtection.Autorest/custom/Cmdlets/Platform/Restore/Test-AzDataProtectionBackupInstanceRestore.ps1),
and [trigger](../../../src/DataProtection/DataProtection.Autorest/custom/Cmdlets/Platform/Restore/Start-AzDataProtectionBackupInstanceRestore.ps1).

## Local tests

Build the tracked DataProtection module before testing. Use standard Pester 4.10.1
with explicit source-test file selection and the built artifact imported in a fresh
process. No separate Cosmos unit-test runner is required. The exact command and
test-placement rationale are in the [command-level test matrix](test-matrix/README.md).
Azure boundaries are mocked; no live provisioning or recording is needed.

| Suite | Coverage |
| --- | --- |
| [CosmosRestoreConfiguration](../../../src/DataProtection/DataProtection.Autorest/test/CosmosRestoreConfiguration.Tests.ps1) | Selectors, boundaries, case/order, punctuation, overlap, configuration, and identity construction. |
| [CosmosRestoreRegression](../../../src/DataProtection/DataProtection.Autorest/test/CosmosRestoreRegression.Tests.ps1) | Full restore, optional-object serialization stability, and other-workload regressions. |
| [CosmosRestorePermission](../../../src/DataProtection/DataProtection.Autorest/test/CosmosRestorePermission.Tests.ps1) | Identity resolution, permission scope, and mocked write-safety checks. |
| [CosmosRestoreTransport](../../../src/DataProtection/DataProtection.Autorest/test/CosmosRestoreTransport.Tests.ps1) | Generated wire JSON and native validation/trigger dispatch assertions. |
| [CosmosRestoreHarness](../../../src/DataProtection/DataProtection.Autorest/test/CosmosRestoreHarness.Tests.ps1) | Offline scenario/negative harness guards, identity handling, and sanitized failure reporting. |
| [CosmosRestoreSharedIdentity](../../../src/DataProtection/DataProtection.Autorest/test/CosmosRestoreSharedIdentity.Tests.ps1) | Exported initializer compatibility across Disk, PostgreSQL, PG Flex, MySQL, and ADLS. |

Read current counts from Pester's NUnit output and the separate results report.
Offline success is not live acceptance; playback alone does not certify serialization.

## Opt-in live scenario

The [scenario runner](../../../tools/Test/Invoke-CosmosRestoreScenario.ps1) requires
PowerShell 7.2+, an authenticated Entra user, existing subscription/resource group/
vault, appropriate permissions, and explicit `-EnableLive`. Every invocation must
be a **fresh `pwsh -NoProfile -File` process**, using the same six required arguments
and local manifest. Replace all placeholders; the prefix needs eight random lowercase
hex digits, and the output directory must be git-ignored.

```powershell
pwsh -NoProfile -File ./tools/Test/Invoke-CosmosRestoreScenario.ps1 `
  -EnableLive -Phase Prepare `
  -SubscriptionId '<subscription-id>' `
  -ResourceGroupName '<existing-resource-group>' -VaultName '<existing-vault>' `
  -ModulePath './artifacts/Debug/Az.DataProtection/DataProtection.Autorest/Az.DataProtection.psd1' `
  -TestPrefix 'cosmos-<eight-random-hex-digits>' `
  -OutputDirectory './artifacts/CosmosLive/<unique-run-directory>'
```

Use **Prepare → Backup → Poll → Restore → Poll → Verify** with the same run arguments.
`Poll` takes one snapshot rather than waiting; repeat later while jobs are pending.
After backup completion and recovery-point discovery, alternate `Restore` and `Poll`.
Restores are **sequential**: a pending case blocks the next submission. The four
defaults are full account, single container, database only, and mixed selectors.
`Verify` requires every selected job to be `Completed` and compares complete inventory,
partitioning, and canonical documents. Target account compatibility must be verified
for the intended environment; provisioning alone does not establish restore support.
- Optional `-Phase Targets` precreates owned empty targets and verification data roles
  without submitting restores; `Restore` can create its targets without this phase.
- Optional `-AdditionalScenario containers,multiDatabase,uami` appends three cases:
  two containers, two whole databases, and a restore-specific UAMI. Select any subset.
  The `uami` case requires `-RestoreUserAssignedIdentityArmId '<attached-uami-arm-id>'`;
  that identity must already be attached to the vault. Selections and identity persist.
- `-UserAssignedIdentityArmId '<attached-uami-arm-id>'` selects the backup/default-case
  identity instead; repeat it consistently. The restore-specific UAMI changes neither
  the backup identity nor default cases and grants no source-side roles automatically.
- Optional `-Phase Churn`, after a completed backup and confirmed recovery point but
  **before any restore intent**, adds `db2/afterBackup` and one document to the owned
  source. Verification checks their exclusion from restored targets against the unchanged
  backup baseline, while checking the source against its mutation inventory.
  `All` never performs churn and returns pending rather than waiting for jobs.

## Native negative validation

The [negative runner](../../../tools/Test/Invoke-CosmosRestoreNegativeTests.ps1)
requires `-EnableLive`, the local `-ModulePath`, trusted positive-run `-StatePath`,
and a separate ignored `-OutputDirectory` outside the positive run directory.
Without `-ServiceValidation`, it tests only public local object helpers: no Azure
context, inventory, validation, or job calls. Client rejection is not service proof.

Optional `-ServiceValidation -TargetAccountId '<owned-empty-account-arm-id>'` requires
a saved completed backup/recovery point and matching subscription, tenant, and account.
The target must be a recorded, created, ownership-tagged account, distinct from the
source, completely empty, with its restore unsubmitted in a known pre-submission state.
The runner holds the positive run's exclusive lease while loading state and reporting.
It checks inventory and calls only native `Test-AzDataProtectionBackupInstanceRestore`,
starting with a valid control; rejected controls abort the service negatives.
It **never calls `Start-AzDataProtectionBackupInstanceRestore`**, even if an invalid
request is accepted. Accepted negatives are **`VALIDATION_GAP`**, not passes: validation
may defer selector or recovery-point checks. Unexpected errors are observations, not
proof of expected rejection. This does not establish full service or restore behavior.

## Costs, retention, and ownership

A complete default run creates **five** single-region `Continuous7Days` accounts
(one source, four targets); all three optional cases add **three** targets, for eight.
The source has three shared-throughput databases at **400 RU/s each**, not per container.
Restored throughput is service-controlled. The native policy template is unchanged,
including **10-year (`P10Y`) vault retention**. Accounts, continuous backups, protected
data, and recovery points persist and can incur charges; review costs before opting in.

There is **no automatic cleanup**, overwrite, account migration, vault safety-setting
change, or raw Data Protection REST fallback. State, ownership tags, module/context
checks, and write-ahead intents prevent adoption and blind duplicate submissions.
Preserve state; ambiguous `Submitting` intents require reviewed job reconciliation,
not resets. Only the owner may authorize a separate periodic-source migration or
cleanup. Keep artifacts private and ignored; never publish tokens, keys, principal
identifiers, actual resource/job IDs, or unredacted state.