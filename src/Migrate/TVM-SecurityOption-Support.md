# Az.Migrate: `SecurityOption` (Trusted Launch / TVM) support for Azure Local replication

## Goal

Expose the ASR `SecurityOption` input on the two Azure Local (AzStackHCI) replication cmdlets so
callers can request Secure Boot / Trusted Launch on the migrated target VM:

- `New-AzMigrateLocalServerReplication` (enable protection)
- `Set-AzMigrateLocalServerReplication` (update protection)

This is required to unblock E2E CI for the feature. The ASR service change is already merged
(`Azure-SiteRecovery-MgmtService` @ `3dd28f3ef`, PR 16760406).

---

# IMPLEMENTED SURFACE — read this if you call the cmdlets

Shipped in the private build **`Az.Migrate 3.0.20`**
(`\\azlabs.redmond.corp.microsoft.com\testfiles$\vmMigrate\Az.Migrate\Az.Migrate.3.0.20.nupkg`,
surfaced on the DVM as `C:\TESTARTIFACTSSHARE\vmMigrate\Az.Migrate\`). Set
`"AzMigrateVersion": "3.0.20"` in the `Inputs\*.json` config the run uses, or the private package
is skipped and the cmdlets will not have these parameters.

> Do **not** use `3.0.19`. That version number was already consumed by an earlier private build
> carrying a different, now-superseded parameter shape (a single `-TargetVMSecurityOption` taking
> `None` / `SecureBootEnabled` / `TrustedLaunch`). `3.0.20` is the first build with the parameters
> described here.

## Parameters

Both cmdlets gain the same two optional parameters. Both are `[System.String]` with a `ValidateSet`,
matching the existing `IsDynamicMemoryEnabled` / `MigrateAsArcVM` convention in this module.

| Parameter | Accepts | Meaning |
| --- | --- | --- |
| `-TargetVMSecurityOption` | `Standard`, `TrustedLaunch` | Security **type** of the target VM. `TrustedLaunch` = Secure Boot + vTPM. |
| `-EnableSecureBoot` | `"true"`, `"false"` | Whether Secure Boot is enabled on the target VM. |

The string type is deliberate: it preserves the difference between *not supplied* and *explicitly
`false`*, which the behaviour below depends on. Passing a PowerShell `[bool]` works via coercion
(`$true` -> `"True"`, matched case-insensitively), which is what the existing automation already does
for `MigrateAsArcVM`.

## Valid combinations

Target VM generation is derived from the source: Hyper-V generation, or for VMware `firmware = bios`
-> Gen 1, otherwise Gen 2. Secure Boot requires UEFI, so BIOS sources never have it enabled.

| BootType | Source Secure Boot | `-TargetVMSecurityOption` | `-EnableSecureBoot` | Result |
| --- | --- | --- | --- | --- |
| BIOS (Gen 1) | Off | `Standard` | `false` | **OK** |
| BIOS (Gen 1) | Off | `Standard` | `true` | rejected — client |
| BIOS (Gen 1) | Off | `TrustedLaunch` | `false` | rejected — client |
| BIOS (Gen 1) | Off | `TrustedLaunch` | `true` | rejected — client |
| UEFI (Gen 2) | Off | `Standard` | `false` | **OK** |
| UEFI (Gen 2) | Off | `Standard` | `true` | **OK** |
| UEFI (Gen 2) | Off | `TrustedLaunch` | `false` | rejected — client |
| UEFI (Gen 2) | Off | `TrustedLaunch` | `true` | **OK** |
| UEFI (Gen 2) | **On** | `Standard` | `false` | rejected — **client**, with service (2109019) as backstop |
| UEFI (Gen 2) | On | `Standard` | `true` | **OK** |
| UEFI (Gen 2) | On | `TrustedLaunch` | `false` | rejected — client |
| UEFI (Gen 2) | On | `TrustedLaunch` | `true` | **OK** |

## Partial and omitted parameters

| Supplied | Behaviour |
| --- | --- |
| Neither | Property omitted. Target inherits the source Secure Boot setting, no vTPM. **Unchanged from today** — existing automation keeps working untouched. |
| `-TargetVMSecurityOption TrustedLaunch` only | Secure Boot is implied. Sends `TrustedLaunch`. |
| `-EnableSecureBoot` only | Security type defaults to `Standard`. |
| `-TargetVMSecurityOption Standard` only, on `New-` | Property omitted — target inherits the source. |
| `-TargetVMSecurityOption Standard` only, on `Set-` | Sends `SecureBootEnabled` on a Gen 2 target. Leaving Trusted Launch drops vTPM but keeps Secure Boot, matching the portal. On a Gen 1 target there is no Secure Boot to inherit, so it sends `None` rather than failing. |

## What gets sent on the wire

The two parameters collapse onto the single service field `securityOption`. There is no separate
`enableSecureBoot` field in the API.

| Resolved state | `securityOption` |
| --- | --- |
| Gen 1 | `None` |
| Gen 2, `TrustedLaunch` | `TrustedLaunch` |
| Gen 2, `Standard` + Secure Boot on | `SecureBootEnabled` |
| Gen 2, `Standard` + Secure Boot off | `None` |

This matches the portal's `getSecurityOptionForProtectedItem` mapping exactly.

## Where validation happens

Rejected **client-side**, before any service call:

1. `-TargetVMSecurityOption TrustedLaunch` with `-EnableSecureBoot "false"` — a pure parameter
   contradiction, thrown before any Azure lookup:
   > `-EnableSecureBoot 'false' cannot be used with -TargetVMSecurityOption 'TrustedLaunch'. Trusted Launch requires Secure Boot.`
2. Gen 1 target with Secure Boot or Trusted Launch requested (thrown after the generation is derived):
   > `Secure Boot and Trusted Launch require a Generation 2 target VM. ...`
3. Any value outside the `ValidateSet` — fails at parameter binding.
4. A Gen 2 source that **has** Secure Boot enabled, asked to migrate with `-EnableSecureBoot "false"`:
   > `Source server '<name>' has Secure Boot enabled, so it cannot be migrated with -EnableSecureBoot 'false'. Omit -EnableSecureBoot to keep Secure Boot enabled on the target VM, or disable Secure Boot on the source server first.`

`secureBootEnabled` is absent from the OffAzure `2020-01-01` models this module is generated
against, so check 4 reads that one field directly at `2024-12-01-preview`
(`$ApiVersions.OffAzureMachineRead`) through `Get-AzMigrateSourceSecureBootState`, which wraps a
single `Invoke-AzRestMethod` GET. Regenerating the module against a newer OffAzure version was
considered and rejected — see below.

**Check 4 fails open.** When the field is absent (older appliances, clouds still serving the GA
contract), the call throws, or a non-200 comes back, the helper returns `$null` and the request
proceeds untouched. A pre-check that blocked a legitimate migration would be worse than the error
it replaces, so `AzStackHCISecurityOptionDowngradeNotAllowed` (2109019) remains the backstop and
the service stays the authority.

### Why not regenerate against a newer OffAzure version

| Version | Paths | Ops | `secureBootEnabled` on | Old ops surviving |
| --- | --- | --- | --- | --- |
| `stable/2020-01-01` *(pinned)* | 31 | 41 | — | — |
| `stable/2023-06-06` | 158 | 199 | `HypervMachineProperties` only | 1 / 41 |
| `preview/2024-12-01-preview` | 164 | 205 | Hyperv + Vmware + `ServerProperties` | 2 / 41 |

Every operationId was renamed to a `*Controller_*` convention after `2020-01-01`
(`Machines_GetMachine` → `MachinesController_Get`), including a `HyperV` → `Hyperv` casing change.
A bump would invalidate all six OffAzure `operationId` directives in `Migrate.Autorest/README.md`,
re-key every `remove: true` directive, expose ~164 new operations that would each become supported
GA surface unless suppressed, break every `Az.Migrate.Internal\Get-AzMigrate*` call site across the
ten custom files, and require re-recording. The newest **stable** version only carries the field for
Hyper-V, so covering VMware as well would mean shipping a `-preview` contract in a GA module.

`EnablevTPM` is intentionally unreachable — it means vTPM *without* Secure Boot, which the service
always rejects (2109020).

## Examples

```powershell
# Trusted Launch (Secure Boot + vTPM). -EnableSecureBoot is implied.
New-AzMigrateLocalServerReplication `
    -MachineId $machineId -TargetStoragePathId $storagePathId `
    -TargetResourceGroupId $rgId -TargetVMName $name `
    -SourceApplianceName $src -TargetApplianceName $tgt `
    -TargetVirtualSwitchId $switchId -OSDiskID $osDiskId `
    -TargetVMSecurityOption TrustedLaunch

# Secure Boot only, no vTPM.
New-AzMigrateLocalServerReplication ... -TargetVMSecurityOption Standard -EnableSecureBoot "true"

# Change an in-flight replication (before Start-AzMigrateLocalServerMigration).
Set-AzMigrateLocalServerReplication -TargetObjectID $protectedItemId `
    -TargetVMSecurityOption TrustedLaunch
```

`Set-` only works between replication starting and cutover: it requires `DisableProtection` in
`AllowedJob` and rejects the call once `CommitFailover` is present.

---

## Background: what the service now accepts

`SecurityOption` is a nullable, string-serialized enum on the AzStackHCI enable/update protection
input, and it is echoed back on GET in the protection details.

| Value | Behavior |
| --- | --- |
| *(omitted / null)* | Legacy. Target Secure Boot mirrors the discovered source VM; no vTPM. |
| `None` | Secure Boot off, no vTPM. Rejected if the source VM has Secure Boot enabled. |
| `SecureBootEnabled` | Secure Boot on, **no** vTPM, `securityType` unset. |
| `EnablevTPM` | **Always rejected** by the service. Reserved for future use. |
| `TrustedLaunch` | Secure Boot on, vTPM on, `securityType = TrustedLaunch`. |

Service-side validation (`AzStackHCIUtils.ApplySecurityOption`):

| Error code | Name | Trigger |
| --- | --- | --- |
| 2109018 | `AzStackHCISecurityOptionNotSupportedForGeneration` | Gen1 target + option other than `None` |
| 2109019 | `AzStackHCISecurityOptionDowngradeNotAllowed` | Gen2 + `None` while the source has Secure Boot on |
| 2109020 | `AzStackHCISecurityOptionEnablevTPMNotAllowed` | `EnablevTPM` |
| 2109021 | `AzStackHCIHyperVGenerationChangeNotAllowed` | update that changes `HyperVGeneration` |
| 2109022 | `AzStackHCISecurityOptionInvalid` | unrecognized value |

Note that `HyperVGeneration` is now **immutable after enable protection**. `Set-AzMigrateLocalServerReplication`
does not send it today, so no change is needed there — but do not add it.

## What is already done

**No Autorest regeneration and no swagger pin bump are required.** The generated models already carry
the property:

| File | Member |
| --- | --- |
| `Migrate.Autorest/generated/api/Models/HyperVToAzStackHciprotectedItemModelCustomProperties.cs` | `string SecurityOption` (L247-252), `SerializedName = "securityOption"` (L669) |
| `Migrate.Autorest/generated/api/Models/HyperVToAzStackHciprotectedItemModelCustomPropertiesUpdate.cs` | `string SecurityOption` (L69-74) |
| `Migrate.Autorest/generated/api/Models/VMwareToAzStackHciprotectedItemModelCustomProperties.cs` | same |
| `Migrate.Autorest/generated/api/Models/VMwareToAzStackHciprotectedItemModelCustomPropertiesUpdate.cs` | same |

Only the hand-written custom cmdlet layer needs wiring.

## Work items — COMPLETED (historical plan, superseded)

> The plan below described a **single** `-TargetVMSecurityOption` parameter taking the raw service
> values `None` / `SecureBootEnabled` / `TrustedLaunch`. The shipped design instead splits this into
> `-TargetVMSecurityOption` (`Standard` / `TrustedLaunch`) plus `-EnableSecureBoot`, to match the
> portal's Security tab. See **IMPLEMENTED SURFACE** above for what actually shipped. Retained for
> the file/line references, which are still accurate.

Throughout, **`MigrateAsArcVM` is the exact precedent to copy.** Match its shape (param placement,
`$Has*` flag, `Remove` from `$PSBoundParameters`, conditional assignment) so the diff reads
consistently with the surrounding code.

### 1. `Migrate.Autorest/custom/Helper/AzLocalCommonSettings.ps1`

Add a constant table next to the existing `$OsTypes` / `$PowerStatus` tables:

```powershell
$SecurityOptions = @{
    None              = "None"
    SecureBootEnabled = "SecureBootEnabled"
    TrustedLaunch     = "TrustedLaunch"
}
```

`EnablevTPM` is deliberately excluded — the service always rejects it, so it must not be part of the
public cmdlet surface.

### 2. `Migrate.Autorest/custom/New-AzMigrateLocalServerReplication.ps1`

**2a. Parameter** — add immediately after `${MigrateAsArcVM}` (currently ends L74):

```powershell
        [Parameter()]
        [ValidateSet("None", "SecureBootEnabled", "TrustedLaunch")]
        [ArgumentCompleter( { "None", "SecureBootEnabled", "TrustedLaunch" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the security configuration of the target VM. 'SecureBootEnabled' enables Secure Boot. 'TrustedLaunch' enables Secure Boot and vTPM. Only supported for Generation 2 target VMs.
        ${TargetVMSecurityOption},
```

**2b. Bound-parameter flag** — after the `$HasMigrateAsArcVM` block (L193-196):

```powershell
        $HasTargetVMSecurityOption = $PSBoundParameters.ContainsKey('TargetVMSecurityOption')
```

**2c. Removal** — after L210 (`$null = $PSBoundParameters.Remove('MigrateAsArcVM')`):

```powershell
        $null = $PSBoundParameters.Remove('TargetVMSecurityOption')
```

**2d. Assignment** — this must go **after** the `HyperVGeneration` derivation block (L726-733), because
the client-side Gen1 guard depends on it. Insert right after that `if/else`:

```powershell
        # Gen 1 target VMs do not support Secure Boot or vTPM; fail before the service round-trip.
        if ($HasTargetVMSecurityOption) {
            if ($customProperties.HyperVGeneration -eq "1" -and
                $TargetVMSecurityOption -ne $SecurityOptions.None) {
                throw "-TargetVMSecurityOption '$TargetVMSecurityOption' requires a Generation 2 target VM. The source server '$MachineName' maps to a Generation 1 target VM."
            }

            $customProperties.SecurityOption = $TargetVMSecurityOption
        }
```

Do **not** set the property when the parameter is absent — a null `SecurityOption` is what selects the
legacy source-mirroring behavior on the service, and existing callers must keep getting it.

### 3. `Migrate.Autorest/custom/Set-AzMigrateLocalServerReplication.ps1`

**3a. Parameter** — same block as above, placed after `${OsType}` (ends L72).

**3b. Flag** — after `$HasOsType` (L147):

```powershell
        $HasTargetVMSecurityOption = $PSBoundParameters.ContainsKey('TargetVMSecurityOption')
```

**3c. Removal** — after L155 (`$null = $PSBoundParameters.Remove('OsType')`).

**3d. Assignment** — after the `$customPropertiesUpdate` construction (L203-210) and before the
`TargetCpuCore` block at L218. The existing protected item's generation is available as
`$customProperties.HyperVGeneration`:

```powershell
        # Gen 1 target VMs do not support Secure Boot or vTPM; fail before the service round-trip.
        if ($HasTargetVMSecurityOption) {
            if ($customProperties.HyperVGeneration -eq "1" -and
                $TargetVMSecurityOption -ne $SecurityOptions.None) {
                throw "-TargetVMSecurityOption '$TargetVMSecurityOption' requires a Generation 2 target VM. Protected item '$TargetObjectID' has a Generation 1 target VM."
            }

            $customPropertiesUpdate.SecurityOption = $TargetVMSecurityOption
        }
```

### 4. Regenerate the wrappers and docs

`exports/New-AzMigrateLocalServerReplication.ps1` and `exports/Set-AzMigrateLocalServerReplication.ps1`
are generated proxies of the custom cmdlets (`${MigrateAsArcVM}` sits at L119 in the New export) and
must be regenerated, not hand-patched:

```powershell
cd src/Migrate/Migrate.Autorest
./build-module.ps1
```

Then refresh:

- `Migrate.Autorest/docs/New-AzMigrateLocalServerReplication.md` and `Set-…md`
- `Migrate/help/New-AzMigrateLocalServerReplication.md` and `Set-…md`
- `Migrate.Autorest/examples/New-AzMigrateLocalServerReplication.md` — add a Trusted Launch example

### 5. Version bump and changelog

- `src/Migrate/Migrate/Az.Migrate.psd1` — `ModuleVersion`. `FunctionsToExport` already lists both
  cmdlets; no change needed there. **Shipped as `3.0.20`.**
- `src/Migrate/Migrate/ChangeLog.md` — note the new `-TargetVMSecurityOption` parameter on both cmdlets.

### 6. Tests

Add cases to `Migrate.Autorest/test/New-AzMigrateLocalServerReplication.Tests.ps1` and
`Set-AzMigrateLocalServerReplication.Tests.ps1` (re-record):

- `-TargetVMSecurityOption TrustedLaunch` against a Gen2 source → request body contains
  `"securityOption": "TrustedLaunch"`.
- `-TargetVMSecurityOption SecureBootEnabled` → body contains `"securityOption": "SecureBootEnabled"`.
- Parameter omitted → `securityOption` **absent** from the request body (legacy behavior preserved).
- `-TargetVMSecurityOption TrustedLaunch` against a Gen1 / BIOS source → client-side throw, no HTTP call.
- Invalid value (e.g. `EnablevTPM`) → `ValidateSet` binding failure.

### 7. Deliverable for CI

The ASZ E2E automation consumes a private build from a fixed share. After the version bump, pack and
publish:

```
C:\TESTARTIFACTSSHARE\vmMigrate\Az.Migrate\Az.Migrate.3.0.20.nupkg
```

Note the ASZ pipelines override the lookup path — `agent-setup-steps.yml` always passes
`-AzMigrateNugetPath "$(Agent.BuildDirectory)\AzMigratePowerShell"`, populated by a `CopyFiles@2`
step from `$(TestBinPath)`. The nupkg must therefore live at `<TestBinPath>\AzMigratePowerShell\`,
not at the `C:\TESTARTIFACTSSHARE\vmMigrate\Az.Migrate\` default in `InstallAzModules.ps1`.
`AzMigrateVersion` is set as a queue-time pipeline variable rather than pinned in the test config.

## Naming decision

`TargetVMSecurityOption`, not `SecurityOption`. It matches the existing `TargetVM*` family
(`TargetVMName`, `TargetVMCPUCore`, `TargetVMRam`) and makes it unambiguous that the setting applies
to the migrated target VM rather than to the source.

## Out of scope

- `EnablevTPM` — service always rejects it; not exposed.
- Changing `HyperVGeneration` on update — now blocked by the service (2109021); `Set-…` must continue
  not to send it.
- Any change to the Azure Migrate (non-Local) replication cmdlets.

## Follow-up defect found in E2E (not TVM-specific)

Observed on Hyper-V E2E build 181286983 (2026-09-16) with `Az.Migrate 3.0.19`. **Not caused by
`-TargetVMSecurityOption`** — it affects every caller of this cmdlet, including the existing
`MigrateAsArcVM` path. Recorded here only because this is where it surfaced. Fix if it recurs.

`New-AzMigrateLocalServerReplication.ps1` L940-946:

```powershell
$null = $PSBoundParameters.Remove('ErrorVariable')   # L931
$null = $PSBoundParameters.Remove('ErrorAction')     # L932
...
$null = $PSBoundParameters.Add('NoWait', $true)
$operation = Az.Migrate.Internal\New-AzMigrateProtectedItem @PSBoundParameters   # L940
$jobName = $operation.Target.Split("/")[-1].Split("?")[0].Split("_")[0]          # L946
```

**Symptom.** `You cannot call a method on a null-valued expression.`

**Why.** `ErrorAction` is removed before the PUT, so a failed `New-AzMigrateProtectedItem` writes a
non-terminating error and leaves `$operation` null. L946 then dereferences it. The real ARM error is
lost and replaced by an opaque null-reference exception.

**What triggered it.** The enable-protection PUT is long-running. When the response is slow the SDK
HTTP pipeline retries it; the retried create collides with its own still-running workflow and the RP
fails the duplicate. The cmdlet sees that failure and null-refs. In the observed run the *first*
workflow went on to succeed — protected item created, initial replication completed — so the only
real damage was an unreadable error and a falsely failed test.

Two separable issues:

1. **Null guard (cheap, high value).** Check `$operation` / `$operation.Target` before L946 and throw
   the underlying error instead. This alone would have made the failure self-explanatory.
2. **Non-idempotent create under retry (root cause).** A retried PUT for the same machine conflicts
   with the in-flight workflow. Either make the create idempotent server-side, or suppress SDK retry
   for this long-running PUT.
