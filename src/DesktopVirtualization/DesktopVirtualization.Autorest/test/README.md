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

## Separate Stable and Preview provisioning

The provisioning helpers require PowerShell 7+. They do not change cmdlets, API versions,
recordings, or the existing 72 live test scripts. The two fixed-profile entries share
[provision-common.ps1](provision-common.ps1); use the module build matching the selected
profile. Stable provisioning is not a way to run the Preview-only tests against Stable.

From this test directory, these commands are entirely offline and accept synthetic identity:

```powershell
./provision-stable.ps1 -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2 -PlanOnly
./provision-preview.ps1 -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2 -PlanOnly
```

`PlanOnly` returns before module discovery, context access, credentials, runtime IO or
process-environment changes. `WhatIf` suppresses provisioning mutations too, but use
`PlanOnly` for the explicit offline contract. No resources are provisioned by an offline check.

### Later authorized provisioning

Import installed Az.Accounts, Az.Resources, Az.Network, Az.KeyVault, Az.Compute, and the
matching Az.DesktopVirtualization module into the current PowerShell process first.
The Msix phase also requires Az.Storage. Authenticate and select the intended tenant and
subscription manually. The scripts never install dependencies or call Connect-AzAccount.
The account needs resource creation, role-assignment, Key Vault data-plane and, for App
Attach principal discovery, directory-read permissions. RBAC propagation failures stop the
phase; investigate and rerun later, without automatic sleeps or status-code guesses.
SHC/SHM discovery treats only the generated DesktopVirtualization `Runtime.RestException`
with `System.Net.HttpStatusCode.NotFound` as absence and proceeds to first-time creation.
All other errors propagate, including 401/403/429/5xx, network failures and untyped errors;
neither message text nor string status values establish absence. The local contract is
`generated/runtime/UndeclaredResponseException.cs` (`RestException.StatusCode`), emitted by
the generated SHC/SHM Get cmdlets' undeclared/default-response handlers.
App Attach walks `Get-AzStorageFile` listings, starting at the share root and passing returned
`ShareDirectoryClient` objects for existing directories. Missing entries permit directory
creation and VHDX upload; listing errors always stop dependent mutations. This uses the
local Storage `GetAzureStorageFile.cs` no-Path branch and avoids its Path branch's directory
403/404 fallback to a file lookup. No storage exception is converted to absence.

After separate authorization, use actual IDs with either entry:

```powershell
$identity = @{
	TenantId = '<tenant-id>'
	SubscriptionId = '<subscription-id>'
	ResourceGroupName = '<test-resource-group>'
	Location = '<azure-region>'
}
./provision-stable.ps1 @identity -Include ControlPlane
./provision-preview.ps1 @identity -Include ControlPlane
```

`Include` accepts `ControlPlane`, `SessionHosts`, `Msix`, or `All` (default). Provision the
control plane before requesting hosts. `VMSize` overrides quota-aware SKU selection.
`VMAdminCredential` accepts an in-memory PSCredential; otherwise the SessionHosts phase
reuses Key Vault `username`/`password` secrets or generates a credential for new fixtures.
Existing VMs without stored credentials require the matching credential explicitly.
Do not put credentials in command history, JSON, logs or recordings. No password or
registration token is returned by provisioning. `AvdDscConfigUrl` overrides the pinned
DSC artifact URL for Stable hosts; the VM extension retrieves it only during an authorized
online run. Existing registered Stable VMs are left alone; repair requires the explicit
`RepairSessionHosts` switch and can restart/reconfigure them.

For Msix, pass `MsixVhdxSourcePath` pointing to a prebuilt XmlNotepad 2.9.0.16 VHDX, with
the package under `apps` and the identity/path shown in the plan. Upload works from any
supported PowerShell platform. An existing uploaded image is reused. Automatic VHDX
building, tool downloads and elevation are intentionally unavailable: perform any required
MSIXMGR/Hyper-V build in a separate, manually authorized elevated Windows session.

### Pool isolation and pending readiness

Names and default state paths include a hash of profile, tenant, subscription and resource
group. Stable and Preview can share a resource group without sharing fixtures. Existing
incompatible pool management types, locations or identities are rejected.
Reused SHC must also match VM resource group, location, prefix, subnet and both credential URIs;
missing or mismatched fields require manual reconciliation before hosts are requested.

| Fixture | Stable | Preview |
| --- | --- | --- |
| StandardHostPoolPersistent | Standard, empty | Standard, empty for registration create/delete tests |
| HostPoolPersistent / AutomatedHostpoolPersistent | Standard, direct Entra/DSC host | Automated, system identity, SHC and SHM count 1 |
| SHMHostPoolPersistent | Standard, separate direct hosts | Separate Automated lifecycle pool, SHC and SHM count 3 |

Preview assigns Desktop Virtualization Virtual Machine Contributor and Key Vault Secrets
User to each Automated pool identity. It configures subnet, Marketplace image, credential
URIs and Trusted Launch before requesting SHM `ProvisioningInstanceCount`. It does not use
`New-AzWvdSessionHost` registrations or direct VMs as a substitute for service provisioning.
Three lifecycle instances allow expected suffixes `-1` and `-2` while leaving `-0` separate.
Actual service names, quota, authorization and convergence must still be verified live.

The result is **PendingLiveValidation**, not test readiness, or **Incomplete** when an operation
is declined or observation fails. `CompletedPhases`, `SkippedPhases` and `FailedPhases` reflect
actual outcomes. Required journal writes must commit before dependent mutations proceed.
It reports raw provisioning
status, active-configuration count and missing expected hosts. No invented service-success
enum is used. A later live phase must inspect errors/host health, establish active SHC,
and arrange lifecycle update scheduling. Healthy VMs alone do not prove SHC/SHM readiness.
`ObservationFailures` names failed queries without retaining response messages; failed reads
are unknown, not evidence of absent resources or successful readiness.

An Entra administrator must separately verify Windows Cloud Login remote connection
configuration. An authorized test user must be assigned the desktop and VM login roles
and sign in to the returned LoginHostPool/LoginHost. Interactive account role assignment is
attempted for the current user; service-principal runs need a separate user assignment.
Retrieve any needed VM administrator credential locally from the returned CredentialVault
without printing or recording secrets. The helpers never open an RDP session or create an
active user session. Existing hardcoded user-session IDs and destructive-test ordering remain
a follow-up; do not assume one login or one provisioning pass makes the whole suite runnable.

### State, runner handoff and cleanup

The entries set process-scoped `AVD_TEST_PROFILE`, `AVD_TEST_STATE_PATH`,
`AVD_TEST_RUNTIME_ENV_PATH` and `AVD_TEST_TENANT_ID`, `AVD_TEST_SUBSCRIPTION_ID`,
`AVD_TEST_RESOURCE_GROUP`, `AVD_TEST_LOCATION`. Run the later test runner from that same
PowerShell process, or explicitly select these values again. A state file does not authenticate
you. Identity overrides conflicting with the selected state are rejected; there are no legacy
tenant/resource-group defaults for setup.

`StatePath` and optional `RuntimeEnvPath` must be absolute, distinct JSON paths in existing
directories. By default, provisioning writes `provision-<profile>-<hash>.state.json`; setup
creates `avd-<profile>-<run-id>.runtime.json` beside it. The default files are ignored by git.
Keep custom paths outside tracked content or ignore them explicitly. State contains resource
names and identity, never credentials/tokens; it is not a recording. Writes to env.json,
localEnv.json or *.Recording.json are rejected.

Setup saves run identity and journals each owned resource before attempting creation. It
throws on failure. The loader requires a completed runtime whenever a profile, state or runtime
is explicitly selected for Record/Live. Missing runtime never falls back to legacy live targets.
Default Playback still uses env.json; default localEnv.json and parent-path
resolution remain supported when no profile/state/runtime is selected. Setup captures the returned Private
Endpoint Connection names for the existing shared name-pattern assertions.

Cleanup uses the saved run's tenant, subscription, resource group and ownership journal,
even if later selections changed. It removes only setup-owned endpoints/workspace/host pool,
not persistent provisioning fixtures or arbitrary test-created resources. Default runner cleanup
owns only the manifest successfully written by its current setup invocation; early failure never
adopts an older run. Standalone cleanup requires the explicit manifest path. For an interrupted run:

```powershell
. ./utils.ps1
cleanupEnv -RuntimeEnvPath '<absolute-path-to-that-run.runtime.json>' -WhatIf
```

Only remove `WhatIf` after separate authorization. Cleanup may select the saved Azure context
but never logs in. Keep the manifest until cleanup succeeds. A new setup refuses to overwrite
an existing runtime manifest or its retained Playback snapshot. Persistent fixtures require separate manual cleanup.

Before removing resources from a completed setup, cleanup must save a secret-free recording
environment as `<absolute-runtime-path>.playback.json`. It retains the exact runtime environment
values and run identity, but no cleanup ownership list. Failed or declined snapshot writes stop
cleanup before removals. Partial cleanup retries retain that snapshot. Archive it with the matching
new recordings, not with historical recordings from another run. Snapshots are not live-target or
cleanup manifests; they do not depend on the original state file or Azure resources for Playback.

After separately authorized Record, cleanup and recording sanitization, explicitly select the
matching snapshot in the process launching the artifact-local Playback runner:

```powershell
$env:AVD_TEST_PLAYBACK_ENV_PATH = '<absolute-runtime-path>.playback.json'
```

Unset `AVD_TEST_PLAYBACK_ENV_PATH` to restore source-default grouped Playback. Explicit missing or
incomplete snapshots fail closed. Default snapshot names are ignored by git; custom paths must
be kept outside tracked content or ignored explicitly. No committed env.json or recording is
promoted or overwritten automatically by provisioning. Promotion must review the environment and its
matching sanitized recordings together.

The runner is artifact-local under
`artifacts/Debug/Az.DesktopVirtualization/DesktopVirtualization.Autorest/test-module.ps1`.
Before later real tests, refresh/copy these source test helpers with the normal module build
workflow. Do not hand-edit the generated runner or build artifacts. No build/codegen is needed
to validate the provisioning helpers offline.

### Source-default Preview recordings

The 2026-10-15 recording handoff contains genuine HTTP Record results for all 72 existing
test scripts (110 cases), followed by matching Playback. Recordings are copied byte-for-byte
from each script's latest fully successful evidence batch, not from the build artifact's
possibly overwritten test directory. JWT redaction was performed before this handoff; HTTP
requests, responses, resource IDs and API versions are not rewritten to manufacture a common
environment. DesktopVirtualization request URIs use `2026-09-01-preview`.

The existing `env.json` holds six `RecordingSets`. Each set contains the exact invoking
`*.Tests.ps1` filenames and its recorded `Environment`. Default Playback selects exactly one
set using the caller filename (the nearest test call-stack frame for indirect helper reloads);
missing or duplicate mappings fail closed. The top-level
fields retain the core batch's defaults for legacy consumers. Flat environments without
`RecordingSets` still work, and `AVD_TEST_PLAYBACK_ENV_PATH` retains precedence. Record/Live
runtime selection is unchanged. Only provisioning metadata (`Profile`, `StatePath`, `RunId`,
`SetupComplete`, `PlaybackSnapshot`) is omitted from the exported snapshots; request values
are retained. No temporary machine path or live resource is required for default Playback.

| Evidence batch / recording set | Winning scripts | Passed cases |
| --- | ---: | ---: |
| live-preview-20261015-core-061507 | 39 | 65 |
| live-preview-20261015-host-config-063138 | 10 | 13 |
| live-preview-20261015-lifecycle-064526 | 9 | 9 |
| live-preview-20261015-user-session-072416 | 3 | 5 |
| live-preview-20261015-usersession-remove-074058 | 1 | 1 |
| live-preview-20261015-msix-final-081203 | 10 | 17 |

The lifecycle batch supersedes the failed management-update-status case; the dedicated
user-session removal batch supersedes its earlier failed removal. Initial failure evidence
is retained outside the repository. Recording filenames follow each test's actual
`TestRecordingFile` assignment, including `Import-AzWvdAppAttachPackageInformation.Recording.json`
and `New-AzWvdMSIXPackage.Recording.json`.

After the normal no-restore AutoRest project build refreshes the artifact, run the complete
suite from the repository root in a fresh PowerShell process using installed dependencies only:

```powershell
$ErrorActionPreference = 'Stop'
$module = './artifacts/Debug/Az.DesktopVirtualization/DesktopVirtualization.Autorest'
Get-ChildItem Env: | Where-Object Name -Like 'AVD_TEST_*' | ForEach-Object { Remove-Item "Env:$($_.Name)" }
$env:AzPSAutorestTestPlaybackMode = 'true'
Import-Module ./artifacts/Debug/Az.Accounts/Az.Accounts.psd1
Import-Module ./artifacts/Debug/Az.DesktopVirtualization/Az.DesktopVirtualization.psd1
Import-Module "$module/generated/modules/Pester/4.10.1/Pester.psd1" -RequiredVersion 4.10.1
$TestMode = 'playback'
$result = Invoke-Pester -Script @(Get-ChildItem "$module/test" -Filter '*.Tests.ps1' | ForEach-Object FullName) -PassThru
if ($result.PassedCount -ne 110 -or $result.FailedCount -or $result.SkippedCount) { throw 'Full Playback failed' }
```

Do not run `check-dependencies.ps1` for offline replay: it can install dependencies or
authenticate. No Record/Live execution, authentication or cloud cleanup is part of this handoff.

### Offline checks and acceptance

From the repository root, with the existing pinned Pester installation:

```powershell
$ErrorActionPreference = 'Stop'
Import-Module Microsoft.PowerShell.Utility
Import-Module Microsoft.PowerShell.Management
$PSModuleAutoLoadingPreference = 'None'
if (Get-Module Az.*) { throw 'Loaded Az modules are forbidden for offline checks' }
Import-Module ./artifacts/Debug/Az.DesktopVirtualization/DesktopVirtualization.Autorest/generated/modules/Pester/4.10.1/Pester.psd1
$result = Invoke-Pester -Script ./src/DesktopVirtualization/DesktopVirtualization.Autorest/test/provisioning-checks.ps1 -PassThru
if ($result.FailedCount -or -not $result.PassedCount) { throw 'Offline checks failed' }
```

Use a fresh `pwsh -NonInteractive -NoProfile` process. The harness disables module autoloading,
refuses loaded Az modules, mocks online paths and writes only synthetic TestDrive state. Its
filename deliberately does not match `*.Tests.ps1`; it is not part of Record discovery.
Typed-boundary checks require the existing local Debug build's
`bin/Az.DesktopVirtualization.private.dll` and `bin/Azure.Core.dll`. The harness loads these
assemblies only to construct real exception objects with synthetic responses; it does not
import Az modules, execute cmdlets, authenticate or send HTTP requests. No build or install
is performed by the harness. The 90 offline cases retain the prior 82 and add eight grouped
loader checks, including indirect subscription-default helper calls. Prior coverage includes
typed SHC/SHM first creation, rejected errors,
missing storage entries and failed listings.
Coverage includes PlanOnly, identity/config separation, parameter contracts, quota, WhatIf,
existing-host reruns, Preview prerequisites/counts, credential reuse, prebuilt uploads,
partial setup/cleanup, runner-shaped early failures, required-write failures, nested declines,
SHC destination checks, discovery errors, exact connection-name patterns, fail-closed runtime
selection, cleanup-to-Playback snapshots and all existing test environment keys.

Offline checks are distinct from the completed batched real-HTTP Record and matching Playback
evidence above. Source-default full-suite Playback validates the exported recording handoff;
it does not claim release approval or authorize cloud cleanup.

### Implementation sources

Shared resource, quota, credential, Entra/DSC, role and App Attach patterns derive from
Azure/azure-powershell PR 30107 at `0b3ea194e9c17c6c11b10fb62b72225cb65f20de`.
Only test automation patterns were reused, not Stable product/API or test-body changes.
Preview management/identity/role/SHC inputs follow New-AzWvdSessionHostConfiguration.Tests.ps1;
SHM inputs follow New-AzWvdSessionHostManagement.Tests.ps1 and the current generated
New/Update-AzWvdSessionHostManagement `ProvisioningInstanceCount` contract. Observed status
is read from the generated SessionHostManagementProvisioningStatus.Status property without
matching fabricated status literals. Registration-test isolation follows New-AzWvdSessionHost.Tests.ps1.