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

## October API validation

The October runner is separate from the legacy recording harness. It requires
PowerShell 7, Pester 5, and built Az.Accounts and Az.PrivateTrafficManager artifacts.
The legacy recordings also use October; all existing skipped scenarios remain unchanged.

From this directory, replay the sanitized October recording without Azure credentials:

```powershell
./Invoke-OctoberApiValidation.ps1 `
	-SubscriptionId 00000000-0000-0000-0000-000000000000 `
	-ResourceGroupName ptm-october-validation `
	-GatewayId /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/recording-gateways/providers/Microsoft.Network/probinggateways/recording-gateway `
	-VirtualNetworkId /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ptm-october-validation/providers/Microsoft.Network/virtualNetworks/validation-vnet `
	-Location global -Mode Playback
```

For an authorized live run, use `Invoke-OctoberLiveValidation.ps1` with an explicit
subscription, existing gateway ID, and new recording path outside the source tree.
It creates a unique tagged resource group and VNet, uses the gateway only as a
reference, and removes its owned PTM resources before deleting the group. Never
point the underlying API runner at a shared group: its final scenarios delete the
profiles and topology map that it creates.

Use `Convert-OctoberRecording.ps1` to sanitize a successful new recording before
adding it to source control. It filters authorization/cookies, replaces subscription,
resource, email and GUID identities, and rejects potential JWTs. Always replay the
sanitized output before publishing it. Raw recordings must not be committed.

### Validation evidence

On 2026-10-30, all eight scenarios passed against `2026-10-01-preview` in the
approved PTM development subscription. The sanitized recording contains 92 HTTP
exchanges and passes the same assertions in credential-free playback:

- Empty test scope and basic profile create/PATCH with preserved routing method.
- Gateway association create, get, list, PATCH, delete, and parent identity binding.
- Health-policy GET/PUT update preserving protocol, port, timing, custom headers,
  failure tolerance and expected status-code ranges.
- Weighted endpoint CRUD with preserved target and health-policy reference.
- VNet routing with assigned/fallback endpoints and preserved VNet assignment.
- Topology-map inline site creation, standalone Site create/get/list/PATCH,
  catch-all/tag PATCH and preserved sites.
- October DELETE operations and verified empty child/profile/topology lists.
- Verified deletion of the owned resource group after the run.

The two focused offline suites also passed: 44 tests, zero failures or skips.
Parent Markdown help was synchronized from generated docs; MAML has 24 command
entries. Scoped dependency/signature/help/UX/check-error analysis passed in a fresh
results directory. Nonblocking signature and shared-assembly warnings remain.

### Service caveats and gaps

Resource-group bulk deletion currently dispatches `2026-02-09-preview` for PTM
profiles. It fails for VNet-routing profiles, so cleanup must explicitly delete
those profiles with October cmdlets first. This was observed and recovered during
validation; all four temporary groups used by this validation were deleted.

Topology creation requires a properties object; a catch-all site requires a
nonempty sites list. The runner creates its initial catch-all site inline.

Live coverage does not yet include advanced-profile topology binding/mode
transitions, Priority/AAAA/CNAME routing variants, duplicate VNet/fallback rejection,
or DNS/probing data-plane behavior. The October runner is not automatically invoked
by the legacy `test-module.ps1` harness; run it explicitly as shown above.

## Legacy October re-recording

`Invoke-LegacyOctoberValidation.ps1` runs the existing legacy tests with CI's
Pester 4.10.1, PowerShell 7, and built Accounts/PTM artifacts. It excludes the
separate Model-Contract and Module-Validation suites. It does not call `utils.ps1`
or `setupEnv`, and never writes recordings directly into the source directory.

From this directory, run credential-free playback:

```powershell
./Invoke-LegacyOctoberValidation.ps1 -Mode Playback
```

For an approved live re-recording:

```powershell
./Invoke-LegacyOctoberValidation.ps1 -Mode Record `
	-SubscriptionId 6df253df-46b8-4dd6-908c-76be3e418edd `
	-GatewayId /subscriptions/6df253df-46b8-4dd6-908c-76be3e418edd/resourceGroups/ptm-synthetics-probingplane/providers/Microsoft.Network/probinggateways/ptm-syn-probe-westcentralus-pgw
```

The runner checks absence before creating a unique `ptm-pwsh-oct-<hex>` group
and a westcentralus VNet with address space `10.1.0.0/16`. Profiles and maps are
global. The existing gateway is reference-only. All calls use the explicit
subscription; Az context changes are process-only. Separate delete targets keep
Get/New/Update fixtures available. The subscription-wide profile List1 remains
read-only. Raw responses may include unrelated resources; the sanitizer retains
only genuine profiles in the owned group for that response.

Raw recordings and NUnit results stay under an isolated, ignored `artifacts`
directory. Successful runs stage sanitized recordings and matching environment
configuration under its `sanitized` subdirectory. Before promoting them, inspect
subscription-wide responses for unrelated resource names/tag identities, run
schema/secret scans, and replay the complete legacy suite against those sanitized
files. Never promote failed runs or relabel the February recordings as October.
The source environment must move with the matching recordings, using the zero
subscription GUID and `ptm-october-validation` resource group.

Cleanup runs in `finally`: October DELETE for profiles/maps in the owned group,
then resource-group deletion and an explicit absence check. Existing groups and
resources are never modified or deleted. Allow capacity for two fixture profiles
plus the profile-create scenario, and two fixture maps plus map-create.

### Validation evidence (2026-11-03)

Profile capacity was available on retry. The legacy live suite passed with
**117 passed, zero failures, 18 skipped**. Its 20 recordings contain 86 genuine
October HTTP exchanges. Sanitized recordings and matching environment configuration
were promoted only after privacy review and successful credential-free playback
with the same totals. Subscription-list responses retain the two owned fixture
profiles, excluding unrelated subscription resources.

The packaged `test-module.ps1 -Playback -NotIsolated` entrypoint also passed using
Pester 4.10.1, current generated proxies, and all current tests:
**161 passed, zero failures, 18 skipped**. Offline HTTP tests use an explicit
playback marker so proxy authentication checks do not require Azure credentials.
Topology create payloads include a catch-all site, and asynchronous profile and
endpoint updates are verified by reading back the resource and changed properties.
The focused Pester 5 offline suites also passed all 44 tests. A local Windows
PowerShell 5.1 run stopped before test execution because the built Az.Accounts
dependency `FuzzySharp` failed strong-name validation; that platform remains
unverified locally. No strong-name checks were bypassed.

The successful run's group `ptm-pwsh-oct-a3633cdd26` was deleted and its absence
verified. Failed retry groups were also deleted. Shared profiles and the existing
probing gateway were not modified or deleted. Never delete shared resources to
create quota headroom.