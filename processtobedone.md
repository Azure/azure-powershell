### Phase 0 — Preconditions (already satisfied)

✅ Neon service retirement date defined: **13 March 2026**  
✅ No replacement / migration path  
✅ Azure CLI + SDKs already aligned for removal

***

### Phase 1 — Identify Neon footprint in azure‑powershell

Search and list:

*   `src/Neon/*`
*   `generated/Neon/*`
*   Any `Az.Neon` module references
*   Docs mentioning Neon

> This mirrors how `Logz` was scoped before removal.    [\[github.com\]](https://github.com/Azure/azure-powershell/pull/27164/files)

***

### Phase 2 — Remove module from public documentation

**File to update:**

*   `documentation/azure-powershell-modules.md`

**Actions:**

*   Remove the entire row for `Az.Neon`
*   Remove:
    *   Gallery link
    *   Changelog link
    *   Badge references

✅ This is **mandatory** — otherwise users still discover a dead module.

(Exact same edit done for Logz.)

***

### Phase 3 — Remove generated build artifacts (critical)

**Delete Neon generated projects**, for example:

*   `generated/Neon/Neon.Autorest/Az.Neon.csproj`
*   Any sibling Neon generated folders

**Why:**

*   Prevents:
    *   Build
    *   Packaging
    *   Accidental publishing
*   Signals hard retirement to engineering pipelines

(Directly aligned with Logz deletion of `Az.Logz.csproj`.)    [\[github.com\]](https://github.com/Azure/azure-powershell/pull/27164/files)

***

### Phase 4 — Remove changelog references

*   Remove `NeonChangeLog` references from:
    *   Module tables
    *   Link sections
*   **Do not** add new ChangeLog entries

Rationale:

> Retirement ≠ feature change  
> Azure PowerShell explicitly avoided ChangeLog updates for Logz.

***

### Phase 5 — Validate no runtime leftovers

Before submitting PR:

*   Ensure:
    *   No `Get‑AzNeon*` cmdlets remain
    *   No help files reference Neon
    *   No module manifests include Neon

This avoids “ghost cmdlets” and broken imports.

***

### Phase 6 — PR hygiene (match Azure PowerShell expectations)

**PR characteristics:**

*   1–2 commits max
*   Title format:
        [Neon] Retire Az.Neon
*   No version bumps
*   No test additions (service is gone)
*   No API compatibility shims

This matches the **approved minimal‑diff retirement pattern**.    [\[github.com\]](https://github.com/Azure/azure-powershell/pull/27164/files)

***

## 4. What *not* to do (based on reference PRs)

❌ Do **not** add warning messages or deprecated attributes  
→ Those are for *migratable* services, not retired ones

❌ Do **not** keep empty module shells  
→ Logz was fully removed, not stubbed

❌ Do **not** update ChangeLog.md  
→ Retirement PRs intentionally skip this

***

## 5. Final outcome (expected)

After merge:

*   `Az.Neon` no longer appears in:
    *   Docs
    *   Gallery listings
    *   Builds
*   Users cannot install or import Neon PowerShell modules
*   Azure PowerShell aligns with:
    *   CLI
    *   SDKs
    *   Service retirement policy

***

If you want, next I can:

*   Draft the **exact PR commit list**
*   Give you a **grep checklist** to confirm Neon is fully removed
*   Or produce a **PR description template** matching Azure PowerShell conventions
