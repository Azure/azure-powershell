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
The existing February recordings and skipped scenarios remain unchanged.

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