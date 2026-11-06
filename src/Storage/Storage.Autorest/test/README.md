# Test
This directory contains the [Pester](https://www.powershellgallery.com/packages/Pester) tests to run for the module. We use Pester as it is the unofficial standard for PowerShell unit testing. Test stubs for custom cmdlets (created in `..\custom`) will be generated into this folder when `build-module.ps1` is ran. These test stubs will fail automatically, to indicate that tests should be written for custom cmdlets.

## Info
- Modifiable: yes
- Generated: partial
- Committed: yes
- Packaged: no

## Details
We allow three testing modes: *live*, *record*, and *playback*. These can be selected using the `-Live`, `-Record`, and `-Playback` switches respectively on the `test-module.ps1` script. This script will run through any `.Tests.ps1` scripts in the `test` folder. If you choose the *record* mode, it will create a `.Recording.json` file of the REST calls between the client and server. Then, when you choose *playback* mode, it will use the `.Recording.json` file to mock the communication between server and client. The *live* mode runs the same as the *record* mode; however, it doesn't create the `.Recording.json` file.

## Purpose
Custom cmdlets generally encompass additional functionality not described in the REST specification, or combines functionality generated from the REST spec. To validate this functionality continues to operate as intended, creating tests that can be ran and re-ran against custom cmdlets is part of the framework.

## Usage
To execute tests, run the `test-module.ps1`. To write tests, [this example](https://github.com/pester/Pester/blob/8b9cf4248315e44f1ac6673be149f7e0d7f10466/Examples/Planets/Get-Planet.Tests.ps1#L1) from the Pester repository is very useful for getting started.

## Management API upgrade coverage

The management API upgrade uses the existing Storage record/playback pattern,
not a separate mocked-transport unit suite:

| Coverage | Scenario |
| --- | --- |
| Shared-key policies, cross-tenant delegation SAS, user-bound SAS policies, Blob Access Point permission, omitted-field preservation | `TestStorageAccountManagementPolicy` in [StorageManagementPolicyTests](../../Storage.Management.Test/ScenarioTests/StorageManagementPolicyTests.cs) |
| Turbo-tier normalization, partial updates, range boundaries, and disabling without resending the existing target percentage | `TestStorageAccountTurboTier` in [StorageManagementPolicyTests](../../Storage.Management.Test/ScenarioTests/StorageManagementPolicyTests.cs) |
| Container attachment on create, metadata updates preserving the existing attachment, get/list projection | `TestStorageContainerBlobAccessPointAttachment` in [StorageManagementPolicyTests](../../Storage.Management.Test/ScenarioTests/StorageManagementPolicyTests.cs) |
| Metrics create/get/list/update/delete and filter preservation | [ManagementApiUpgrade.Metrics.Tests.ps1](ManagementApiUpgrade.Metrics.Tests.ps1) |
| Context cache CRUD, group/subscription lists, name availability, identity combinations and preservation | [ManagementApiUpgrade.ContextCache.Tests.ps1](ManagementApiUpgrade.ContextCache.Tests.ps1) |
| Cache container CRUD, immutable model/provider, default TTL, valid/invalid TTL boundaries | [ManagementApiUpgrade.ContextCache.Tests.ps1](ManagementApiUpgrade.ContextCache.Tests.ps1) |
| Qumulo-backed Blob Access Point configuration CRUD, proposed/existing connection tests, secret-safe display | [ManagementApiUpgrade.BlobAccessPoint.Tests.ps1](ManagementApiUpgrade.BlobAccessPoint.Tests.ps1) |
| File-service guardrail scalars | [Get-AzStorageFileServiceUsage.Tests.ps1](Get-AzStorageFileServiceUsage.Tests.ps1) |
| Inbound NSP service-tag projection | [ManagementApiUpgrade.NetworkSecurityPerimeter.Tests.ps1](ManagementApiUpgrade.NetworkSecurityPerimeter.Tests.ps1) |

Existing Storage scenarios already cover Smart tier, `AllowedCopyScope All`,
static website index paths, object-replication tags, and the task-assignment
`MockRun` trigger. Do not duplicate those workflows in a new unit suite.
The historical `TestAzureStorageAccountKeySASPolicy` also records the account GET
needed to preserve user-bound SAS settings when updates explicitly supply the
expiration action.

### Recording prerequisites

The new scenarios require recordings before their playback can pass. They are
not skipped when recordings or fixtures are missing. The C# entry points have
the normal `AcceptanceType=CheckIn` trait.

Use a dedicated test subscription/account. The metrics test requires an account
without a pre-existing capacity-metrics rule; it deletes the rule it creates.
Provision a Qumulo source, user-assigned managed identity,
and an NSP profile with at least one inbound service-tag rule
before recording. Cache and Blob Access Point tests create and delete their
own named child resources, not the pre-provisioned fixtures.
Cache identity scenarios follow the CLI/.NET fixture scope: they do not
configure customer-managed encryption or require a Key Vault key.
The Blob Access Point lifecycle uses one Qumulo source, matching the .NET live
scenario, rather than provisioning each service-supported backend.
As in the .NET scenario, Blob Access Point tests start the proposed-connection
operation without waiting, then require a successful completed connection test
against the stored configuration.

Set `AZURE_STORAGE_MANAGEMENT_TEST_FIXTURES` to a private JSON file with a
`ManagementApi` object. The AutoRest runner copies only its non-secret metadata
to `env.json`; C# attachment tests save their fixture identifiers in the
standard TestFx recording variables. Required fields are:

| Field | Value |
| --- | --- |
| `SubscriptionId` | Explicit test subscription for the new management recordings; must match the live Azure context |
| `ResourceGroupName`, `AccountName`, `Location` | Dedicated Storage fixtures in a region supporting the new APIs |
| `FileServiceUsage` | `ResourceGroupName` and `AccountName` of an empty provisioned-v2 file account |
| `NetworkSecurityPerimeter` | `ResourceGroupName` and `AccountName` of the account associated with the prepared NSP profile |
| `BlobAccessPoint` | `ResourceGroupName`, `AccountName`, and `Location` of a Blob Access Point-enabled account; it may be in a different region from the other fixtures |
| `MetricsContainers` | Names of existing containers to select in the capacity-metrics filter |
| `ModelName` | A supported context-cache model |
| `ContextCacheNamePrefix` | Fresh lowercase alphanumeric cache-name prefix, 1-20 characters; use a new prefix for each re-recording because deleted cache names can remain unavailable |
| `UserAssignedIdentityResourceId` | Existing user-assigned managed identity for the cache identity scenarios |
| `Sources.Qumulo` | Non-secret Qumulo source definition and credential environment-variable names |
| `Attachment` | `ResourceGroupName`, `AccountName`, `ConfigurationName`, and `UniqueId` for a pre-provisioned, attachable Blob Access Point configuration |

The `Sources.Qumulo` entry contains a complete non-secret REST-shaped `Source`
object, including its `sourceType`, `connection`, and `auth.authType`.
Use an `AccessKey` authentication object without credential values, and
provide `AccessKeyIdEnvironmentVariable` and
`SecretAccessKeyEnvironmentVariable` naming process environment variables
that hold that source's credentials. Never put access keys in the fixture
file, `env.json`, source code, or command-line arguments. The fixture loader
rejects literal `accessKeyId` and `secretAccessKey` fields.

The new scenarios use their explicit `ManagementApi` subscription and fixture
settings so historical recordings can retain their shared environment values.
Re-record the existing file-service usage scenario
against its provisioned-v2 file account to capture the new guardrail fields.

### Credential handling

The standard AutoRest recorder initially captures raw request bodies. Record
only in an access-controlled workspace with disposable source credentials,
without PowerShell tracing or verbose/debug request logging. Do not stage,
share, or commit captures while recording is in progress.

The Blob Access Point scenario registers cleanup before its first request and
calls `Protect-StorageManagementRecording` in `finally`; runner cleanup repeats
that protection even when a test fails. It replaces `accessKeyId` and
`secretAccessKey` values in request/response bodies with `REDACTED`, including
base64-encoded bodies. Playback uses synthetic credentials and does not read
credential environment variables.

If the recording process is interrupted or cleanup fails, the capture may
still contain credentials. Run `Protect-StorageManagementRecording` with
`TestMode` set to `record` before inspecting or sharing it. Always review all
new captures and scan for the actual credential values before staging them;
rotate disposable credentials after recording. Do not treat successful
playback as proof that a recording is safe to commit.

Use the packaged AutoRest runner with `-Record -TestName 'ManagementApiUpgrade.*'`,
then `-Playback -TestName 'ManagementApiUpgrade.*'`. Each feature has its own
recording file and can be selected independently, for example with
`-TestName ManagementApiUpgrade.Metrics`. Recording a feature replaces its
entire capture, so record all cases in that feature together.
Run the C# scenarios using the
existing TestFx recording configuration and the
`FullyQualifiedName~StorageManagementPolicyTests` filter. Recording and
playback results must be reported separately; discovery/build success is not
a substitute for service validation.