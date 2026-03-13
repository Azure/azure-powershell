# Azure Policy Change Safety (Preview)

Azure Policy Change Safety introduces *policy evaluation tokens* that must accompany certain state-changing (write) operations to Azure Resource Manager (ARM). These short‑lived, signed tokens prove that any required external validators (approvals, safety checks, etc.) have run before the change is submitted.

## Status
This feature is behind a configuration flag and requires a corresponding update to the shared `azure-powershell-common` library. Until that dependency is updated, enabling the flag has no effect.

## Phased Rollout
| Phase | Scope | Visible Parameter(s) | Notes |
|-------|-------|----------------------|-------|
| Phase 1 (current) | Token acquisition only | `-AcquirePolicyToken` | `-ChangeReference` is suppressed/hidden. |
| Phase 2 (planned) | Adds change reference association | `-AcquirePolicyToken`, `-ChangeReference` | `-ChangeReference` implies token acquisition. |

If you see references to `-ChangeReference` below, they describe future behavior (Phase 2) and are not yet active.

## Enabling the Feature
```powershell
Update-AzConfig -EnablePolicyToken $true
```

You can also disable it later:
```powershell
Update-AzConfig -EnablePolicyToken $false
```

Environment variable override (session only):
```powershell
$env:AZ_ENABLE_POLICY_TOKEN = "true"
```

## Parameters (write cmdlets; conditional & phased)
| Parameter | Type | Phase | Purpose |
|----------|------|-------|---------|
| `-AcquirePolicyToken` | Switch | 1+ | Force acquisition of a change-safety policy token for the operation. |
| `-ChangeReference <string>` | String | 2 | (Planned) Associates the operation with an external change record (e.g., a ChangeState resource ID); implies token acquisition. Not yet surfaced. |

Read-only (GET/list/show) cmdlets will not expose these parameters.

## Example Usage (Phase 1)
```powershell
# Acquire a token automatically for a write operation
New-AzResourceGroup -Name rg-change -Location eastus -AcquirePolicyToken
```

### Phase 2 (Planned) Example (Not Yet Active)
```powershell
# This will only work once Phase 2 ships
New-AzVm -Name web01 -ResourceGroupName rg-change -ChangeReference \
  "/providers/Microsoft.Change/changes/abc123/changeStates/state456" -Image UbuntuLTS -Location eastus
```

## How It Works (Conceptual)
1. You provide `-AcquirePolicyToken` (Phase 1) or later `-ChangeReference` (Phase 2) on a write cmdlet.
2. The client calls `Microsoft.Authorization/acquirePolicyToken` (synchronously) with method, URI and body of the impending request plus optional change reference (Phase 2).
3. Service returns a signed token; it is attached as `x-ms-policy-external-evaluations` header on the actual ARM call.
4. ARM validates token; if missing or invalid and required policies exist, the request is rejected.

## Troubleshooting
| Symptom | Possible Cause | Mitigation |
|--------|----------------|-----------|
| Parameters not visible | Feature flag not enabled or common library not updated | Run `Update-AzConfig -EnablePolicyToken $true` and ensure you have a version that includes the handler. |
| Error: failed to acquire policy token | Network / permission / unsupported scope | Re-run with `-Debug`; confirm subscription context and that the operation is write. |
| ARM denies request citing policy token | Missing `-AcquirePolicyToken` / `-ChangeReference` where a policy now requires it | Re-run with one of the parameters enabled. |

## Logging & Privacy
The token is sensitive and should not appear in logs. The implementation sanitizes the header value in debug traces.

## Roadmap (Subject to Change)
* Support asynchronous (202 Accepted) acquisition mode
* Retry and token reuse for identical retried writes
* Warning decoration for policy-denied responses when the feature is disabled

---
Feedback welcome—file an issue with `[ChangeSafety]` in the title. Please specify "Phase 1" in the issue if `-ChangeReference` is not yet available in your build.
