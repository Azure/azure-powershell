# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

#Requires -Version 7.2
<#
.SYNOPSIS
Opt-in, native Az.DataProtection Cosmos NoSQL full/ILR live scenario (PowerShell 7.2+).
.DESCRIPTION
Run EACH invocation in a fresh pwsh -NoProfile -File process. Authenticate beforehand
with Az.Accounts; this script never signs in interactively. ModulePath must name the
locally built Az.DataProtection.psd1 (the DataProtection.Autorest artifact), not an
installed Gallery module. Account provisioning uses New-AzCosmosDBAccount when it
exposes DisableLocalAuth and ContinuousTier; otherwise native Az.Resources New-AzResource provisions
the explicit AAD-only properties using the stable Cosmos API 2025-04-15.

Requires existing subscription, resource group, backup vault, and sufficient
management-plane rights to create Cosmos accounts, policies, backup instances, and
role assignments. The executing Entra USER needs directory resolution through
Get-AzADUser -SignedIn. The vault needs a system identity, or explicitly select an already
attached UAMI with UserAssignedIdentityArmId. No identity is added to the vault.

Costs: creates FIVE single-region Continuous7Days NoSQL accounts by default, up to
EIGHT with all three opt-in scenarios (excluding separately run negative tests). Continuous backup
is a prerequisite for native long-term protection. The low-RU fixture source uses
three shared 400-RU/s databases (not dedicated container throughput); restored throughput
is service-controlled. Uses the native policy template UNCHANGED (including its
retention). Resources and recovery points persist and can incur charges. There is
NO cleanup, delete, overwrite, vault update, firewall change, or safety-setting change.
Existing accounts are never migrated automatically, even if owned by this run. A
previous periodic source must be migrated separately by its owner before resuming;
the expanded ARM backup policy must show Continuous7Days before this script proceeds.
Do not run with Debug, Verbose, or token-capturing HTTP tracing/transcripts enabled.

Use the SAME six required arguments for every phase and retain the ignored output
directory. TestPrefix must contain a unique run suffix (for example cosmos-YYYYMMDD-
plus eight random hex digits). Losing state does NOT authorize adopting resources.
Prepare creates/seeds/protects; Backup submits one backup; Poll takes ONE snapshot of
each specific job and discovers a recovery point after backup completion; Restore
submits full, single-container, database-only, and mixed restores to four empty owned
accounts; Verify requires every selected job to be exactly Completed and checks complete
database/container inventory, /id partitioning, and canonical document equality.
AdditionalScenario opt-ins are containers (db1/col1 + db1/col2), multiDatabase
(whole db1 + db2), and uami (db1/cont1 with RestoreUserAssignedIdentityArmId).
Only requested cases are planned/provisioned. ScenarioOrder is persisted: existing
entries/selectors/identities never change, and explicit opt-ins append new cases.
Omitting opt-ins on later calls retains them; repeating them never reorders cases.
RestoreUserAssignedIdentityArmId is retained in state and cannot be changed after
selection. It must already be attached to the vault. ARM identity IDs are compared
case-insensitively; Cosmos database/container selectors remain case-sensitive.
The uami case alone uses this restore identity; it does not change the backup or
default cases, and no extra source-side identity roles are granted automatically.
Legacy UserAssignedIdentityArmId still selects the backup/default-case identity.
Optional Churn, ONLY after a Completed backup and confirmed recovery point and
before any restore intent, adds db2/afterBackup and one document to the OWNED source.
It never changes baseline SourceInventory or overwrites existing documents. Verify
compares the source with the completed mutation inventory, but restored targets
with the backup baseline (the post-backup container must be absent). All never churns.
All advances as far as possible, returning pending rather than waiting for jobs.
Restores are sequential: a submitted restore must complete before the next case.
The vault's location determines account, datasource, and restore locations. The
explicit subscription is selected in process scope, not the cached default.
State and RunReport.json retain job statuses and pending snapshots on every checkpoint.

Permission propagation can require rerunning the same phase later. No sleep/retry
loop is used. Native readiness, validation, account creation and trigger LROs may
wait naturally for their control-plane operation, NOT for the entire backup/restore.
Write-ahead intents prevent automatic duplicate submissions. If a process dies after
submission but before its job ID is saved, the script fails closed: inspect the vault
jobs and reconcile that intent in state after review; do not blindly reset it.
State must be treated as trusted run metadata, not edited to adopt existing resources.
.EXAMPLE
pwsh -NoProfile -File ./tools/Test/Invoke-CosmosRestoreScenario.ps1 -EnableLive -Phase Prepare -SubscriptionId $sub -ResourceGroupName $rg -VaultName $vault -ModulePath $builtManifest -TestPrefix $uniquePrefix -OutputDirectory $ignoredRunDirectory
.EXAMPLE
Use the same invocation with Phase Backup, Poll, Restore, Poll, then Verify.
Repeat Poll later while Pending is true; All is also resumable and never waits on jobs.
.EXAMPLE
After backup completion, use Phase Churn with -AdditionalScenario containers,multiDatabase,uami -RestoreUserAssignedIdentityArmId $attachedUami. Then use Restore, Poll, and Verify with the same run arguments; optional selections are retained.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory)] [guid] $SubscriptionId,
    [Parameter(Mandatory)] [ValidateNotNullOrEmpty()] [string] $ResourceGroupName,
    [Parameter(Mandatory)] [ValidateNotNullOrEmpty()] [string] $VaultName,
    [Parameter(Mandatory)] [ValidateNotNullOrEmpty()] [string] $ModulePath,
    [Parameter(Mandatory)] [ValidatePattern('^[a-z][a-z0-9-]{2,20}-[a-f0-9]{8}$')] [string] $TestPrefix,
    [Parameter(Mandatory)] [ValidateNotNullOrEmpty()] [string] $OutputDirectory,
    [ValidateSet('Prepare', 'Backup', 'Targets', 'Churn', 'Restore', 'Poll', 'Verify', 'VerifyCompleted', 'All')] [string] $Phase = 'Prepare',
    [string] $UserAssignedIdentityArmId,
    [ValidateSet('containers', 'multiDatabase', 'uami')] [string[]] $AdditionalScenario = @(),
    [ValidatePattern('^/subscriptions/[^/?#]+/resourceGroups/[^/?#]+/providers/Microsoft\.ManagedIdentity/userAssignedIdentities/[^/?#]+$')] [string] $RestoreUserAssignedIdentityArmId,
    [switch] $EnableLive
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$DebugPreference = 'SilentlyContinue'
$VerbosePreference = 'SilentlyContinue'
$InformationPreference = 'Continue'
$script:SafeFailure = $null
$script:Operation = 'Startup'

function Protect-FailureText([string] $Text) {
    if (-not $Text) { return $null }
    # Never retain HTTP request/response dumps or credential-bearing URL queries.
    $text = [regex]::Split($Text, '(?im)(?:^|\s)(?:Request\s*(?:Headers|Body|:)|Response\s*(?:Headers|Body)|Authorization\s*:|Headers\s*:)')[0]
    $text = [regex]::Split($text, '(?i)"(?:request|requestHeaders|requestBody|responseHeaders|responseBody)"\s*:')[0]
    $text = [regex]::Replace($text, '(?i)(https?://[^\s?]+)\?[^\s]+', '$1?[REDACTED]')
    $text = [regex]::Replace($text, '(?i)\b(?:Bearer|type=aad)\s*[^\r\n]*', '[REDACTED]')
    $text = [regex]::Replace($text, '(?i)["'']?(?:[\w-]*token|authorization|sig|signature|[\w-]*secret|password|accountkey|primarykey|secondarykey|credential)["'']?\s*[:=]\s*(?:"[^"]*"|''[^'']*''|[^\s,;}]+)', '[REDACTED]')
    $text = [regex]::Replace($text, '\beyJ[A-Za-z0-9_-]+(?:\.[A-Za-z0-9_-]+){1,2}\b|[A-Za-z0-9+/=_-]{80,}', '[REDACTED]')
    $text = [regex]::Replace($text, '[\r\n\t]+', ' ').Trim()
    return $text.Substring(0, [Math]::Min(2048, $text.Length))
}

function Get-SafeNativeFailure($ErrorRecord) {
    if ($ErrorRecord.Exception.Data.Contains('SafeFailure')) { return $ErrorRecord.Exception.Data['SafeFailure'] }
    $errors = [System.Collections.Generic.List[object]]::new()
    $failure = [ordered]@{
        ExceptionType = $ErrorRecord.Exception.GetType().FullName
        ErrorId = Protect-FailureText ([string]$ErrorRecord.FullyQualifiedErrorId)
        Code = $null; RequestId = $null; StatusCode = $null
        Message = Protect-FailureText ([string]$ErrorRecord.Exception.Message)
        InnerCodes = @(); Errors = @()
    }
    function Read-NativeError($Node, [int] $Depth = 0) {
        if ($null -eq $Node -or $Depth -gt 16) { return }
        if ($Node -is [System.Collections.IDictionary]) {
            $code = [string]$Node['code']
            if ($code -cmatch '^[A-Za-z][A-Za-z0-9_.-]{0,199}$') {
                $errors.Add([ordered]@{ Code = $code; Message = Protect-FailureText ([string]$Node['message']) })
            }
            # Allowlisted error paths only; never walk request, headers, or tokens.
            foreach ($key in @('error', 'innerError', 'additionalInfo', 'details')) {
                if ($Node.Contains($key)) { Read-NativeError $Node[$key] ($Depth + 1) }
            }
        } elseif ($Node -is [System.Collections.IEnumerable] -and $Node -isnot [string]) {
            foreach ($item in $Node) { Read-NativeError $item ($Depth + 1) }
        } elseif ($Node -is [string] -and $Node.TrimStart().StartsWith('{')) {
            # Some native additionalInfo.innerError values are JSON strings.
            try { Read-NativeError (ConvertFrom-Json -InputObject $Node -AsHashtable -ErrorAction Stop) ($Depth + 1) } catch { }
        }
    }
    $exception = $ErrorRecord.Exception
    for ($depth = 0; $null -ne $exception -and $depth -lt 8; $depth++) {
        foreach ($name in @('ResponseBody', 'Body')) {
            $property = $exception.PSObject.Properties[$name]
            if ($null -ne $property -and $null -ne $property.Value) {
                try {
                    $node = if ($property.Value -is [string]) { ConvertFrom-Json -InputObject $property.Value -AsHashtable -ErrorAction Stop } else {
                        $property.Value | ConvertTo-Json -Depth 30 | ConvertFrom-Json -AsHashtable
                    }
                    Read-NativeError $node
                } catch { } # Non-JSON bodies are deliberately never emitted.
            }
        }
        foreach ($name in @('RequestId', 'StatusCode')) {
            $property = $exception.PSObject.Properties[$name]
            if ($null -ne $property -and [string]$property.Value -cmatch '^[A-Za-z0-9_.:-]{1,100}$') { $failure[$name] = [string]$property.Value }
        }
        foreach ($name in @('Code', 'ErrorCode')) {
            $property = $exception.PSObject.Properties[$name]
            if ($null -ne $property -and [string]$property.Value -cmatch '^[A-Za-z][A-Za-z0-9_.-]{0,199}$') {
                if (-not $failure.Code) { $failure.Code = [string]$property.Value }
            }
        }
        $responseProperty = $exception.PSObject.Properties['Response']
        if ($null -ne $responseProperty -and $null -ne $responseProperty.Value) {
            $response = $responseProperty.Value
            $status = $response.PSObject.Properties['StatusCode']
            if ($null -ne $status -and [string]$status.Value -cmatch '^[A-Za-z0-9]{1,60}$') { $failure.StatusCode = [string]$status.Value }
            $headersProperty = $response.PSObject.Properties['Headers']
            if ($null -ne $headersProperty -and $null -ne $headersProperty.Value) {
                # Read only correlation IDs, never enumerate/serialize headers.
                foreach ($header in @('x-ms-request-id', 'x-ms-activity-id')) {
                    try {
                        $values = @($headersProperty.Value.GetValues($header))
                        if ($values.Count -eq 1 -and [string]$values[0] -cmatch '^[A-Za-z0-9_.:-]{1,100}$') {
                            $failure.RequestId = [string]$values[0]
                            break
                        }
                    } catch { }
                }
            }
        }
        $exception = $exception.InnerException
    }
    if ($null -ne $ErrorRecord.ErrorDetails) {
        try { Read-NativeError (ConvertFrom-Json -InputObject $ErrorRecord.ErrorDetails.Message -AsHashtable -ErrorAction Stop) } catch { }
    }
    $failure.Errors = @($errors.ToArray())
    if ($errors.Count -gt 0) {
        $failure.Code = $errors[0].Code
        $failure.InnerCodes = @($errors | Select-Object -Skip 1 | ForEach-Object { $_['Code'] } | Select-Object -Unique)
    }
    return $failure
}

function Save-State {
    $script:State.UpdatedUtc = [datetime]::UtcNow.ToString('o')
    $script:State.RunReport = Get-RunReport
    $json = ConvertTo-Json -InputObject $script:State -Depth 100
    # Same-volume atomic replacement. Do not truncate the last valid checkpoint.
    $temporary = "$script:StatePath.$PID.tmp"
    [IO.File]::WriteAllText($temporary, $json, [Text.UTF8Encoding]::new($false))
    [IO.File]::Move($temporary, $script:StatePath, $true)
    $reportPath = Join-Path $OutputDirectory 'RunReport.json'
    $reportTemporary = "$reportPath.$PID.tmp"
    [IO.File]::WriteAllText($reportTemporary, (ConvertTo-Json -InputObject $script:State.RunReport -Depth 20), [Text.UTF8Encoding]::new($false))
    [IO.File]::Move($reportTemporary, $reportPath, $true)
}

function Get-RunReport {
    [ordered]@{
        Phase = $Phase; PhaseStatus = $script:PhaseStatus; UpdatedUtc = $script:State.UpdatedUtc
        StatePath = $script:StatePath; RestoreLocation = $script:RestoreLocation
        Prepared = $script:State.Prepared; Verified = $script:State.Verified
        Pending = -not $script:State.Verified; BackupJobId = $script:State.Backup.JobId; BackupStatus = $script:State.Backup.Status
        RecoveryPointId = $script:State.RecoveryPointId
        SafeFailure = $script:SafeFailure
        SourceInventory = $script:State.SourceInventory
        SourceInventoryUtc = $script:State['SourceInventoryUtc']
        CurrentSourceInventory = $script:State['CurrentSourceInventory']
        CurrentSourceInventoryUtc = $script:State['CurrentSourceInventoryUtc']
        BackupInventoryCheckedUtc = $script:State.Backup['InventoryCheckedUtc']
        PolicyFailure = $script:State.Policy['Failure']
        ScenarioOrder = @(Get-ScenarioKeys)
        Mutation = $script:State['Mutation']
        Accounts = @(foreach ($key in (@('source') + @(Get-ScenarioKeys))) {
            [ordered]@{ Scenario = $key; Name = $script:State.Accounts[$key].Name; Id = $script:State.Accounts[$key].Id; Status = $script:State.Accounts[$key].Status }
        })
        Restores = @(foreach ($key in (Get-ScenarioKeys)) {
            [ordered]@{ Scenario = $key; TargetId = $script:State.Accounts[$key].Id; JobId = $script:State.Restores[$key].JobId; Status = $script:State.Restores[$key].Status; Selectors = @($script:State.Restores[$key].Selectors); Identity = $script:State.Restores[$key].Identity; VerifiedUtc = $script:State.Restores[$key]['VerifiedUtc'] }
        })
    }
}

function Get-ScenarioKeys {
    # Emit individual keys; callers explicitly capture arrays, including one key.
    foreach ($key in $script:State.ScenarioOrder) { [string]$key }
}

function Resolve-ScenarioIdentity($Vault, [string] $ArmId) {
    if (-not $ArmId) {
        if (-not $Vault.IdentityPrincipalId) { throw 'Vault has no system-assigned identity; explicitly select an attached UAMI.' }
        return @{ UseSystemAssignedIdentity = $true; UserAssignedIdentityArmId = $null; PrincipalId = [string]$Vault.IdentityPrincipalId }
    }
    if ($ArmId -notmatch '^/subscriptions/[^/?#]+/resourceGroups/[^/?#]+/providers/Microsoft\.ManagedIdentity/userAssignedIdentities/[^/?#]+$') { throw 'Identity must be a user-assigned identity ARM ID.' }
    $map = $Vault.IdentityUserAssignedIdentity
    $keys = @()
    if ($null -ne $map) {
        $isDictionary = ($map -is [System.Collections.IDictionary]) -or ($null -ne $map.PSObject.Methods['ContainsKey'])
        $keys = if ($isDictionary) { @($map.Keys) } else { @($map.PSObject.Properties.Name) }
    }
    $matchingKeys = @($keys | Where-Object { [StringComparer]::OrdinalIgnoreCase.Equals([string]$_, $ArmId) })
    if ($matchingKeys.Count -ne 1) { throw 'Explicit UAMI must match exactly one already attached vault identity. No vault identity is added.' }
    $attachedId = [string]$matchingKeys[0]
    $entry = if ($isDictionary) { $map[$attachedId] } else { $map.PSObject.Properties[$attachedId].Value }
    $principal = $null
    if ($null -ne $entry) {
        $property = $entry.PSObject.Properties['PrincipalId']
        if ($entry -is [System.Collections.IDictionary]) { $principal = [string]$entry['PrincipalId'] }
        elseif ($null -ne $property) { $principal = [string]$property.Value }
    }
    if (-not $principal) {
        # Read-only resolution; do not patch public helpers or manufacture vault map
        # values. Native Set-MSI errors remain observable if its map is incomplete.
        $lookup = Get-Command Get-AzUserAssignedIdentity -ErrorAction SilentlyContinue
        if ($null -ne $lookup) {
            $parts = $attachedId -split '/'
            $identity = Get-AzUserAssignedIdentity -SubscriptionId $parts[2] -ResourceGroupName $parts[4] -Name $parts[8]
            if ($identity.Id -ine $attachedId) { throw 'Resolved identity ARM ID differs from the attached identity.' }
            $principal = [string]$identity.PrincipalId
        } else {
            $identity = Get-AzResource -ResourceId $attachedId -ApiVersion '2023-01-31' -ExpandProperties
            if ($identity.Id -ine $attachedId) { throw 'Resolved identity ARM ID differs from the attached identity.' }
            $properties = $identity.Properties | ConvertTo-Json -Depth 10 | ConvertFrom-Json -AsHashtable
            $principal = [string]$properties['principalId']
        }
    }
    if ([string]::IsNullOrWhiteSpace($principal)) { throw 'Attached UAMI principal could not be resolved with native read-only identity lookup.' }
    return @{ UseSystemAssignedIdentity = $false; UserAssignedIdentityArmId = $attachedId; PrincipalId = $principal }
}

function Initialize-ScenarioSelection($Vault) {
    $defaults = @('full', 'single', 'database', 'mixed')
    $selections = @{ full = @(); single = @('db1/cont1'); database = @('db2'); mixed = @('db1/col1', 'db1/col2', 'db2'); containers = @('db1/col1', 'db1/col2'); multiDatabase = @('db1', 'db2'); uami = @('db1/cont1') }
    if (-not $script:State.ContainsKey('ScenarioOrder')) {
        # Migrate only known persisted cases; never invent/adopt an old target.
        $order = @($defaults | Where-Object { $script:State.Restores.Contains($_) })
        foreach ($key in @('containers', 'multiDatabase', 'uami')) {
            if ($script:State.Restores.Contains($key)) { $order += $key }
        }
        if ($order.Count -ne $script:State.Restores.Count) { throw 'Unrecognized legacy restore keys; refusing scenario migration.' }
        $script:State.ScenarioOrder = @($order)
    }
    $order = @(Get-ScenarioKeys)
    if ($order.Count -lt 4 -or (@($order | Select-Object -Unique)).Count -ne $order.Count) { throw 'Persisted scenario order is incomplete or duplicated.' }
    Assert-Equal @($order | Select-Object -First 4) $defaults 'immutable default scenario order'
    if ($script:State.Restores.Count -ne $order.Count -or $script:State.Accounts.Count -ne ($order.Count + 1)) { throw 'Persisted scenario/account keys do not match scenario order.' }
    foreach ($key in $order) {
        if ($key -cnotin @($selections.Keys) -or -not $script:State.Restores.Contains($key) -or -not $script:State.Accounts.Contains($key)) { throw 'Persisted scenario order contains an unknown or missing case.' }
        Assert-Equal @($script:State.Restores[$key].Selectors) @($selections[$key]) "immutable $key selectors"
        $record = $script:State.Restores[$key]
        $accountRecord = $script:State.Accounts[$key]
        if ($accountRecord.Name -cne $accountRecord.Name.ToLowerInvariant()) {
            # Correct only an uncreated, unsubmitted legacy plan, never an account.
            if ($accountRecord.Status -ne 'Planned' -or $record.JobId -or $record.RequestJson) {
                throw 'Persisted account name contains uppercase letters after creation/submission; reconcile before proceeding.'
            }
            $accountRecord.Name = $accountRecord.Name.ToLowerInvariant()
            $accountRecord.Id = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/$($accountRecord.Name)"
        }
        if (-not $record.ContainsKey('Identity')) {
            if ($key -eq 'uami') { throw 'Persisted UAMI case lacks its explicit identity; reconcile state before resuming.' }
            $record.Identity = @{ UseSystemAssignedIdentity = [string]::IsNullOrEmpty($script:State.UserAssignedIdentityArmId); UserAssignedIdentityArmId = $script:State.UserAssignedIdentityArmId; PrincipalId = $script:State.VaultPrincipalId }
        }
        $resolved = Resolve-ScenarioIdentity $Vault $record.Identity.UserAssignedIdentityArmId
        if ($resolved.UseSystemAssignedIdentity -ne $record.Identity.UseSystemAssignedIdentity -or $resolved.PrincipalId -ine $record.Identity.PrincipalId) { throw 'Persisted case identity changed; refusing to change restore intent.' }
    }
    $persistedArmId = [string]$script:State['RestoreUserAssignedIdentityArmId']
    if ($RestoreUserAssignedIdentityArmId -and $persistedArmId -and $RestoreUserAssignedIdentityArmId -ine $persistedArmId) { throw 'Restore UAMI differs from the persisted identity.' }
    $selectedArmId = if ($persistedArmId) { $persistedArmId } else { $RestoreUserAssignedIdentityArmId }
    $requested = @(foreach ($key in @('containers', 'multiDatabase', 'uami')) { if ($key -in $AdditionalScenario) { $key } })
    if ('uami' -in $requested -and -not $selectedArmId) { throw 'The uami scenario requires RestoreUserAssignedIdentityArmId (or its persisted value).' }
    $restoreIdentity = if ($selectedArmId) { Resolve-ScenarioIdentity $Vault $selectedArmId } else { $null }
    if ($order -ccontains 'uami' -and $script:State.Restores['uami'].Identity.UserAssignedIdentityArmId -ine $selectedArmId) { throw 'Persisted UAMI case and restore identity selection disagree.' }
    $newKeys = @($requested | Where-Object { $_ -cnotin $order })
    if ($newKeys.Count -gt 0) {
        # Check every appended target name before changing the selected case set.
        $existingNames = @(Get-Accounts | ForEach-Object Name)
        foreach ($key in $newKeys) {
            if ("$TestPrefix-$($key.ToLowerInvariant())" -in $existingNames) { throw 'An optional target name already exists. Refusing to adopt it.' }
        }
        foreach ($key in $newKeys) {
            $name = "$TestPrefix-$($key.ToLowerInvariant())"
            if ($name.Length -gt 64) { throw 'Optional Cosmos account name exceeds 64 characters.' }
            $script:State.Accounts[$key] = @{ Name = $name; Id = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/$name"; Status = 'Planned'; DataRoleId = [guid]::NewGuid().ToString() }
            $identity = if ($key -eq 'uami') { $restoreIdentity } else { @{ UseSystemAssignedIdentity = [string]::IsNullOrEmpty($script:State.UserAssignedIdentityArmId); UserAssignedIdentityArmId = $script:State.UserAssignedIdentityArmId; PrincipalId = $script:State.VaultPrincipalId } }
            $script:State.Restores[$key] = @{ Status = 'Planned'; JobId = $null; RequestJson = $null; Selectors = @($selections[$key]); Identity = $identity }
        }
        # Append-only: never reorder or replace a previously selected case.
        $script:State.ScenarioOrder = @($order) + @($newKeys)
        $script:State.Verified = $false
    }
    if ($restoreIdentity) { $script:State.RestoreUserAssignedIdentityArmId = $restoreIdentity.UserAssignedIdentityArmId }
}

function Get-WireJson($Model) {
    # Exactly the generated transport's create/update serializer, not IncludeAll.
    $Model.ToJson($null, [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode]::IncludeCreateOrUpdate).ToString()
}

function Get-CanonicalValue($Value) {
    if ($null -eq $Value) { return $null }
    if ($Value -is [System.Collections.IDictionary]) {
        $result = [System.Collections.Specialized.OrderedDictionary]::new([StringComparer]::Ordinal)
        [string[]] $keys = @($Value.Keys)
        [Array]::Sort($keys, [StringComparer]::Ordinal)
        foreach ($key in $keys) { $result[$key] = Get-CanonicalValue $Value[$key] }
        return $result
    }
    if ($Value -is [System.Management.Automation.PSCustomObject]) {
        $map = [System.Collections.Generic.Dictionary[string, object]]::new([StringComparer]::Ordinal)
        foreach ($property in $Value.PSObject.Properties) { $map[$property.Name] = $property.Value }
        return Get-CanonicalValue $map
    }
    if ($Value -is [System.Collections.IEnumerable] -and $Value -isnot [string]) {
        return ,@(foreach ($item in $Value) { Get-CanonicalValue $item })
    }
    return $Value
}

function Get-CanonicalJson($Value) {
    ConvertTo-Json -InputObject (Get-CanonicalValue $Value) -Depth 100 -Compress
}

function Assert-Equal($Actual, $Expected, [string] $Description) {
    if ((Get-CanonicalJson $Actual) -cne (Get-CanonicalJson $Expected)) {
        throw "Verification mismatch: $Description. No target will be overwritten."
    }
}

function Assert-Context {
    $context = Get-AzContext
    if ($null -eq $context -or $context.Subscription.Id -ne [string]$SubscriptionId -or
        $context.Tenant.Id -ne $script:State.TenantId -or $context.Account.Id -ne $script:State.AccountId) {
        throw 'Azure context changed or does not match persisted subscription/tenant/executing account.'
    }
}

function Get-Accounts {
    Assert-Context
    # Native list, not an error-suppressed GET: authorization/network failures must not
    # be mistaken for absence and lead to a create/update of an existing account.
    @(Get-AzCosmosDBAccount -ResourceGroupName $ResourceGroupName)
}

function Assert-OwnedAccount($Account, $Record) {
    Assert-Context
    # Older Cosmos public models omit DisableLocalAuth. Read the actual ARM
    # resource with the same stable API used for provisioning, never a missing getter.
    $resource = Get-AzResource -ResourceId $Record.Id -ApiVersion '2025-04-15' -ExpandProperties
    $properties = $resource.Properties | ConvertTo-Json -Depth 30 | ConvertFrom-Json -AsHashtable
    $tags = $resource.Tags | ConvertTo-Json -Depth 10 | ConvertFrom-Json -AsHashtable
    if ($Account.Id -ine $Record.Id -or $Account.Name -ine $Record.Name -or
        $resource.Id -ine $Record.Id -or $resource.Name -ine $Record.Name -or
        $resource.Location.Replace(' ', '') -ine $script:RestoreLocation.Replace(' ', '') -or
        $null -eq $tags -or $tags['CosmosRestoreRun'] -cne $script:State.RunId -or
        $properties['disableLocalAuth'] -cne $true -or $resource.Kind -ine 'GlobalDocumentDB' -or
        $null -eq $properties['backupPolicy'] -or $properties['backupPolicy']['type'] -ine 'Continuous') {
        throw 'Account context, ownership, AAD-only, NoSQL, location, or Continuous backup assertion failed. Long Term Protection requires Continuous Backup Mode. No account is migrated automatically; separately migrate only the owned source before resuming.'
    }
    $continuous = $properties['backupPolicy']['continuousModeProperties']
    if ($null -eq $continuous -or $continuous['tier'] -ine 'Continuous7Days' -or
        $properties['enableFreeTier'] -cne $false) { throw 'Account Continuous7Days or free-tier settings differ from the scenario. No automatic migration or update is permitted.' }
}

function Initialize-ScenarioAccount([string] $Key) {
    $record = $script:State.Accounts[$Key]
    $accounts = @(Get-Accounts | Where-Object Name -IEQ $record.Name)
    if ($accounts.Count -gt 1) { throw 'Account lookup was not unique.' }
    if ($accounts.Count -eq 1) {
        if ($record.Status -eq 'Planned') { throw "Account name already exists: $($record.Name). Use a new run prefix." }
        Assert-OwnedAccount $accounts[0] $record
        $record.Status = 'Created'
        Save-State
        return $accounts[0]
    }
    if ($record.Status -eq 'Created') { throw 'Previously recorded account is missing; refusing to recreate it.' }
    if ($record.Status -eq 'Creating') { throw 'Account creation outcome is still ambiguous. Rerun later or reconcile the persisted run tag; never update an existing account.' }
    $record.Status = 'Creating'
    Save-State
    Assert-Context
    $create = Get-Command New-AzCosmosDBAccount
    $tags = @{ CosmosRestoreRun = $script:State.RunId }
    if ($create.Parameters.ContainsKey('DisableLocalAuth') -and $create.Parameters.ContainsKey('ContinuousTier')) {
        $optional = @{}
        # Splatting false supports both Boolean and SwitchParameter versions.
        if ($create.Parameters.ContainsKey('EnableFreeTier')) { $optional.EnableFreeTier = $false }
        $null = New-AzCosmosDBAccount -ResourceGroupName $ResourceGroupName -Name $record.Name `
            -ApiKind Sql -Location @($script:RestoreLocation) -DefaultConsistencyLevel Session `
            -BackupPolicyType Continuous -ContinuousTier Continuous7Days `
            -DisableLocalAuth:$true @optional -Tag $tags -Confirm:$false
    } else {
        # This fallback is ONLY account provisioning. DPP remains native under test.
        $properties = @{
            databaseAccountOfferType = 'Standard'
            locations = @(@{ locationName = $script:RestoreLocation; failoverPriority = 0; isZoneRedundant = $false })
            disableLocalAuth = $true
            consistencyPolicy = @{ defaultConsistencyLevel = 'Session' }
            backupPolicy = @{ type = 'Continuous'; continuousModeProperties = @{ tier = 'Continuous7Days' } }
            enableFreeTier = $false
        }
        $null = New-AzResource -ResourceType 'Microsoft.DocumentDB/databaseAccounts' -ApiVersion '2025-04-15' `
            -Location $script:RestoreLocation -ResourceName $record.Name -ResourceGroupName $ResourceGroupName `
            -Kind GlobalDocumentDB -PropertyObject $properties -Tag $tags -Force
    }
    $account = Get-AzCosmosDBAccount -ResourceGroupName $ResourceGroupName -Name $record.Name
    Assert-OwnedAccount $account $record
    $record.Status = 'Created'
    Save-State
    return $account
}

function Set-ScenarioDataRole([string] $Key) {
    $record = $script:State.Accounts[$Key]
    # This is Cosmos native DATA-plane RBAC. ARM Reader/Cosmos DB Operator does not
    # authorize queries. Do not grant the executing user extra management-plane roles.
    $definition = "$($record.Id)/sqlRoleDefinitions/00000000-0000-0000-0000-000000000002"
    $roles = @(Get-AzCosmosDBSqlRoleAssignment -ResourceGroupName $ResourceGroupName -AccountName $record.Name)
    $role = @($roles | Where-Object { ($_.Id -split '/')[-1] -eq $record.DataRoleId })
    if ($role.Count -eq 0) {
        Assert-Context
        $null = New-AzCosmosDBSqlRoleAssignment -ResourceGroupName $ResourceGroupName -AccountName $record.Name `
            -Id $record.DataRoleId -PrincipalId $script:State.PrincipalId -RoleDefinitionId $definition -Scope $record.Id -Confirm:$false
    } elseif ($role.Count -ne 1 -or $role[0].PrincipalId -ne $script:State.PrincipalId -or
        $role[0].Scope -ine $record.Id -or $role[0].RoleDefinitionId -ine $definition) {
        throw 'Persisted native Cosmos SQL role assignment does not match this run.'
    }
    $record.DataRoleAssigned = $true
    Save-State
}

function Invoke-DocumentRequest {
    param([string] $AccountName, [string] $Database, [string] $Container, $Document, [string] $Continuation)
    Assert-Context
    $token = Get-AzAccessToken -ResourceUrl 'https://cosmos.azure.com'
    $clearToken = $null
    try {
        $clearToken = if ($token.Token -is [securestring]) {
            [System.Net.NetworkCredential]::new('', $token.Token).Password
        } else { [string]$token.Token }
        $headers = @{
            Authorization = [uri]::EscapeDataString("type=aad&ver=1.0&sig=$clearToken")
            'x-ms-date' = [datetime]::UtcNow.ToString('r', [Globalization.CultureInfo]::InvariantCulture)
            'x-ms-version' = '2018-12-31'
        }
        $body = '{"query":"SELECT * FROM c"}'
        $contentType = 'application/query+json'
        if ($null -ne $Document) {
            $body = ConvertTo-Json -InputObject $Document -Depth 50 -Compress
            $headers['x-ms-documentdb-partitionkey'] = ConvertTo-Json -InputObject @($Document.id) -Compress
            $contentType = 'application/json'
        } else {
            $headers['x-ms-documentdb-isquery'] = 'true'
            $headers['x-ms-documentdb-query-enablecrosspartition'] = 'true'
            $headers['x-ms-max-item-count'] = '100'
            if ($Continuation) { $headers['x-ms-continuation'] = $Continuation }
        }
        $uri = "https://$AccountName.documents.azure.com/dbs/$([uri]::EscapeDataString($Database))/colls/$([uri]::EscapeDataString($Container))/docs"
        # No upsert header: seeding cannot overwrite documents, even after a crash.
        Invoke-WebRequest -Uri $uri -Method Post -Headers $headers -ContentType $contentType -Body $body -ErrorAction Stop
    } catch {
        # Retain useful native codes without propagating credential-bearing requests.
        $safe = Get-SafeNativeFailure $_
        $sanitized = [System.InvalidOperationException]::new('Cosmos AAD document request failed; see SafeFailure for sanitized native diagnostics.')
        $sanitized.Data['SafeFailure'] = $safe
        throw $sanitized
    } finally {
        $clearToken = $null
        $token = $null
        if ($null -ne (Get-Variable headers -ErrorAction SilentlyContinue)) { $headers.Clear() }
    }
}

function Get-Documents([string] $AccountName, [string] $Database, [string] $Container) {
    $continuation = $null
    $documents = [System.Collections.Generic.List[object]]::new()
    $seen = [System.Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    do {
        $response = Invoke-DocumentRequest -AccountName $AccountName -Database $Database -Container $Container -Continuation $continuation
        $page = ConvertFrom-Json -InputObject $response.Content -AsHashtable
        foreach ($document in $page.Documents) {
            # Only remove Cosmos SYSTEM metadata at the document root. Preserve all
            # user nested properties and array order, including nested _etag fields.
            foreach ($key in @('_rid', '_self', '_etag', '_attachments', '_ts')) { $document.Remove($key) | Out-Null }
            if (-not $seen.Add([string]$document.id)) { throw 'Duplicate document id in /id-partitioned query result.' }
            $documents.Add($document)
        }
        $continuation = if ($response.Headers.ContainsKey('x-ms-continuation')) { [string](@($response.Headers['x-ms-continuation'])[0]) } else { $null }
    } while ($continuation)
    # Stable document ordering is separate from canonical property ordering.
    [string[]] $ids = @($documents | ForEach-Object { [string]$_.id })
    [Array]::Sort($ids, [StringComparer]::Ordinal)
    return ,@(foreach ($id in $ids) { $documents | Where-Object { $_.id -ceq $id } })
}

function Get-Inventory([string] $Key) {
    Assert-Context
    $name = $script:State.Accounts[$Key].Name
    $databases = @(Get-AzCosmosDBSqlDatabase -ResourceGroupName $ResourceGroupName -AccountName $name)
    return ,@(foreach ($db in @($databases | Sort-Object { $_.Resource.Id } -CaseSensitive)) {
        $containers = @(Get-AzCosmosDBSqlContainer -ResourceGroupName $ResourceGroupName -AccountName $name -DatabaseName $db.Resource.Id)
        [ordered]@{
            Database = $db.Resource.Id
            Containers = @(foreach ($container in @($containers | Sort-Object { $_.Resource.Id } -CaseSensitive)) {
                [ordered]@{
                    Name = $container.Resource.Id
                    PartitionKey = @($container.Resource.PartitionKey.Paths)
                    Documents = Get-Documents $name $db.Resource.Id $container.Resource.Id
                }
            })
        }
    })
}

function Get-ExpectedInventory([string] $Key) {
    $selectors = @($script:State.Restores[$Key].Selectors)
    return ,@(foreach ($db in $script:State.SourceInventory) {
        $containers = @($db.Containers | Where-Object {
            $Key -eq 'full' -or $db.Database -cin $selectors -or "$($db.Database)/$($_.Name)" -cin $selectors
        })
        if ($containers.Count -gt 0) { [ordered]@{ Database = $db.Database; Containers = $containers } }
    })
}

function Invoke-Prepare {
    $script:Operation = 'Prepare'
    $source = Initialize-ScenarioAccount 'source'
    Set-ScenarioDataRole 'source'
    if (-not $script:State.Seeded) {
        $fixture = [ordered]@{ db1 = @('cont1', 'col1', 'col2', 'excluded'); db2 = @('c1', 'c2'); unselectedDB = @('control') }
        foreach ($database in $fixture.Keys) {
            Assert-Context
            $databases = @(Get-AzCosmosDBSqlDatabase -ResourceGroupName $ResourceGroupName -AccountName $source.Name)
            if ($database -cnotin @($databases | ForEach-Object { $_.Resource.Id })) {
                $null = New-AzCosmosDBSqlDatabase -ResourceGroupName $ResourceGroupName -AccountName $source.Name -Name $database -Throughput 400 -Confirm:$false
                $script:State.SeedCheckpoint = "database:$database"
                Save-State
            }
            foreach ($container in $fixture[$database]) {
                $containers = @(Get-AzCosmosDBSqlContainer -ResourceGroupName $ResourceGroupName -AccountName $source.Name -DatabaseName $database)
                if ($container -cnotin @($containers | ForEach-Object { $_.Resource.Id })) {
                    $null = New-AzCosmosDBSqlContainer -ResourceGroupName $ResourceGroupName -AccountName $source.Name -DatabaseName $database -Name $container -PartitionKeyKind Hash -PartitionKeyPath @('/id') -Confirm:$false
                    $script:State.SeedCheckpoint = "container:$database/$container"
                    Save-State
                }
                $expected = @(foreach ($number in 1..2) {
                    @{ id = "doc$number"; run = $script:State.RunId; database = $database; container = $container; value = $number; nested = @{ preserved = @('a', 'b'); flag = $true } }
                })
                $existing = Get-Documents $source.Name $database $container
                foreach ($document in $existing) {
                    $match = @($expected | Where-Object { $_.id -ceq $document.id })
                    if ($match.Count -ne 1) { throw 'Unexpected source document; refusing to overwrite.' }
                    Assert-Equal $document $match[0] 'existing seed document'
                }
                foreach ($document in $expected) {
                    if ($document.id -cnotin @($existing | ForEach-Object { $_.id })) {
                        $null = Invoke-DocumentRequest -AccountName $source.Name -Database $database -Container $container -Document $document
                        $script:State.SeedCheckpoint = "document:$database/$container/$($document.id)"
                        Save-State
                    }
                }
                Assert-Equal (Get-Documents $source.Name $database $container) $expected "seed $database/$container"
            }
        }
        $script:State.SourceInventory = Get-Inventory 'source'
        $script:State.SourceInventoryUtc = [datetime]::UtcNow.ToString('o')
        Assert-Equal @($script:State.SourceInventory | ForEach-Object { $_.Database }) @('db1', 'db2', 'unselectedDB') 'source database inventory'
        foreach ($db in $script:State.SourceInventory) {
            Assert-Equal @($db.Containers | ForEach-Object { $_.Name } | Sort-Object -CaseSensitive) @($fixture[$db.Database] | Sort-Object -CaseSensitive) "source container inventory $($db.Database)"
            foreach ($container in $db.Containers) {
                Assert-Equal $container.PartitionKey @('/id') 'source partition key'
            }
        }
        $script:State.Seeded = $true
        Save-State
    }
    $script:Operation = 'Policy'
    $policies = @(Get-AzDataProtectionBackupPolicy @script:VaultArguments)
    $policy = @($policies | Where-Object Name -IEQ $script:State.Policy.Name)
    if ($policy.Count -eq 0) {
        if ($script:State.Policy.Status -eq 'Created') { throw 'Recorded policy is missing.' }
        $template = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureCosmosDB
        $script:State.Policy.WireJson = Get-WireJson $template
        $script:State.Policy.Status = 'Creating'
        Save-State
        $policy = @(New-AzDataProtectionBackupPolicy @script:VaultArguments -Name $script:State.Policy.Name -Policy $template -Confirm:$false)
    } elseif ($script:State.Policy.Status -eq 'Planned') { throw 'Policy name collision; refusing to adopt existing policy.' }
    if ($policy.Count -ne 1 -or $policy[0].Id -ine $script:State.Policy.Id) { throw 'Policy ID mismatch.' }
    Assert-Equal ((Get-WireJson $policy[0].Property) | ConvertFrom-Json -AsHashtable) ($script:State.Policy.WireJson | ConvertFrom-Json -AsHashtable) 'owned policy template'
    $script:State.Policy.Status = 'Created'
    $null = $script:State.Policy.Remove('Failure')
    Save-State
    $script:Operation = 'BackupInstance'
    $identity = @{ UseSystemAssignedIdentity = [string]::IsNullOrEmpty($UserAssignedIdentityArmId) }
    $permissionIdentity = @{}
    if ($UserAssignedIdentityArmId) {
        $identity.UserAssignedIdentityArmId = $UserAssignedIdentityArmId
        $permissionIdentity.UserAssignedIdentityARMId = $UserAssignedIdentityArmId
    }
    if (-not $script:State.BackupInstance.Name) {
        $instance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureCosmosDB -DatasourceLocation $script:RestoreLocation -DatasourceId $source.Id -PolicyId $script:State.Policy.Id @identity
        # The client initializer sets BackupInstanceName, NOT the read-only ARM
        # Name. IncludeCreateOrUpdate also omits both names on serialization.
        $script:State.BackupInstance.Name = $instance.BackupInstanceName
        if (-not $script:State.BackupInstance.Name) { throw 'Native initializer returned no BackupInstanceName.' }
        $script:State.BackupInstance.Id = "$($script:State.VaultId)/backupInstances/$($instance.BackupInstanceName)"
        $script:State.BackupInstance.WireJson = Get-WireJson $instance
        Save-State
    } else {
        $instance = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.BackupInstanceResource]::FromJsonString($script:State.BackupInstance.WireJson)
        $instance.BackupInstanceName = $script:State.BackupInstance.Name
    }
    $existingInstances = @(Get-AzDataProtectionBackupInstance @script:VaultArguments)
    $existing = @($existingInstances | Where-Object Name -IEQ $script:State.BackupInstance.Name)
    if ($existing.Count -eq 0) {
        if ($script:State.BackupInstance.Status -eq 'Created') { throw 'Recorded backup instance is missing.' }
        # Resource scope yields Cosmos DB Operator on source plus Reader on its RG.
        # No executing-user ARM roles or broader vault identity grants are added.
        Set-AzDataProtectionMSIPermission -BackupInstance $instance -VaultResourceGroup $ResourceGroupName -VaultName $VaultName -PermissionsScope Resource @permissionIdentity -Confirm:$false | Out-Null
        $script:State.BackupInstance.PermissionsAssigned = $true
        Save-State
        $script:Operation = 'Readiness'
        Test-AzDataProtectionBackupInstanceReadiness @script:VaultArguments -BackupInstance $instance.Property -Confirm:$false | Out-Null
        $script:Operation = 'BackupInstance'
        $script:State.BackupInstance.Status = 'Creating'
        Save-State
        $existing = @(New-AzDataProtectionBackupInstance @script:VaultArguments -BackupInstance $instance -Confirm:$false)
    } elseif ($script:State.BackupInstance.Status -eq 'Planned') { throw 'Backup instance collision before submission.' }
    if ($existing.Count -ne 1 -or $existing[0].Id -ine $script:State.BackupInstance.Id -or
        $existing[0].Property.DatasourceInfo.ResourceId -ine $source.Id -or
        $existing[0].Property.PolicyInfo.PolicyId -ine $script:State.Policy.Id) { throw 'Backup instance context mismatch.' }
    $script:State.BackupInstance.Status = 'Created'
    $script:State.Prepared = $true
    Save-State
}

function Save-SubmittedJob($Response, $Record) {
    $id = [string]$Response.JobId
    $name = ($id.TrimEnd('/') -split '/')[-1]
    if ($name -notmatch '^[a-zA-Z0-9-]+$') { throw 'Native trigger did not return a usable JobId; submission remains ambiguous.' }
    if ($id.Contains('/') -and $id -ine "$($script:State.VaultId)/backupJobs/$name") { throw 'Native trigger returned a job from a different vault.' }
    $Record.JobId = $name
    $Record.JobResourceId = "$($script:State.VaultId)/backupJobs/$name"
    $Record.Status = 'Submitted'
    Save-State
}

function Invoke-Backup {
    $script:Operation = 'Backup'
    if (-not $script:State.Prepared) { throw 'Run Prepare first.' }
    if ($script:State.Backup.JobId) { return }
    if ($script:State.Backup.Status -eq 'Submitting') { throw 'Backup submission outcome is ambiguous. Reconcile the persisted intent with vault jobs before proceeding.' }
    $instance = Get-AzDataProtectionBackupInstance @script:VaultArguments -Name $script:State.BackupInstance.Name
    if ($instance.Property.CurrentProtectionState -ne 'ProtectionConfigured') { throw 'Protection is not configured yet. Rerun Backup later.' }
    $source = @(Get-Accounts | Where-Object Name -IEQ $script:State.Accounts['source'].Name)
    if ($source.Count -ne 1) { throw 'Recorded source account is missing.' }
    Assert-OwnedAccount $source[0] $script:State.Accounts['source']
    $script:State.CurrentSourceInventory = Get-Inventory 'source'
    $script:State.CurrentSourceInventoryUtc = [datetime]::UtcNow.ToString('o')
    Save-State
    Assert-Equal $script:State.CurrentSourceInventory $script:State.SourceInventory 'source unchanged before backup (complete database/container/partition-key/document inventory; compare SourceInventory and CurrentSourceInventory in RunReport)'
    $script:State.Backup.InventoryCheckedUtc = $script:State.CurrentSourceInventoryUtc
    $rules = @((ConvertFrom-Json $script:State.Policy.WireJson).policyRules | Where-Object objectType -EQ 'AzureBackupRule')
    if ($rules.Count -ne 1) { throw 'Expected one backup rule in the native policy template.' }
    $script:State.Backup.Status = 'Submitting'
    $script:State.Backup.SubmittedUtc = [datetime]::UtcNow.ToString('o')
    Save-State
    $response = Backup-AzDataProtectionBackupInstanceAdhoc @script:VaultArguments -BackupInstanceName $script:State.BackupInstance.Name -BackupRuleOptionRuleName $rules[0].name -TriggerOptionRetentionTagOverride Default -Confirm:$false
    Save-SubmittedJob $response $script:State.Backup
}

function Update-Job($Record, [string] $ExpectedCategory) {
    if (-not $Record.JobId) { return }
    $job = Get-AzDataProtectionJob @script:VaultArguments -Id $Record.JobId
    if ($job.BackupInstanceId -ine $script:State.BackupInstance.Id -or $job.OperationCategory -ine $ExpectedCategory) {
        throw 'Specific job does not match persisted backup instance and operation category.'
    }
    $Record.Status = [string]$job.Status
    if ($ExpectedCategory -eq 'Backup' -and $job.TargetRecoverPointRecoveryPointId) {
        $Record.RecoveryPointId = [string]$job.TargetRecoverPointRecoveryPointId
    }
    if ($ExpectedCategory -eq 'Restore' -and $job.SourceRecoverPointRecoveryPointId -and
        $job.SourceRecoverPointRecoveryPointId -cne $Record.RecoveryPointId) {
        throw 'Specific restore job reports a different source recovery point.'
    }
    $Record.LastSnapshotUtc = [datetime]::UtcNow.ToString('o')
    Save-State
}

function Assert-JobNotFailed($Record) {
    if ($Record.Status -in @('Failed', 'Canceled', 'Cancelled', 'CompletedWithWarnings', 'PartiallySucceeded')) {
        throw "Job $($Record.JobId) ended in $($Record.Status); this scenario requires Completed. Inspect the specific native job."
    }
}

function Get-RecoveryPointSnapshot($Point) {
    # Generated AzureBackupRecoveryPointResource exposes Name/Id. Its polymorphic
    # Property is AzureBackupDiscreteRecoveryPoint for Cosmos, with a public
    # RecoveryPointId/RecoveryPointTime (not fields on the base recovery-point type).
    $name = [string]$Point.Name
    $expectedId = "$($script:State.BackupInstance.Id)/recoveryPoints/$name"
    if (-not $name -or $Point.Id -ine $expectedId) { throw 'Recovery point resource identity does not match this backup instance.' }
    $property = $Point.Property
    if ($null -eq $property.PSObject.Properties['RecoveryPointTime']) { return }
    $idProperty = $property.PSObject.Properties['RecoveryPointId']
    if ($null -ne $idProperty -and $idProperty.Value -and $idProperty.Value -cne $name) {
        throw 'Recovery point resource Name and discrete RecoveryPointId disagree.'
    }
    [pscustomobject]@{ Name = $name; Id = [string]$Point.Id; Time = [datetime]$property.RecoveryPointTime }
}

function Invoke-Poll {
    $script:Operation = 'Poll'
    Update-Job $script:State.Backup 'Backup'
    foreach ($key in (Get-ScenarioKeys)) { Update-Job $script:State.Restores[$key] 'Restore' }
    if ($script:State.Backup.Status -eq 'Completed' -and -not $script:State.RecoveryPointId) {
        $points = @(Get-AzDataProtectionRecoveryPoint @script:VaultArguments -BackupInstanceName $script:State.BackupInstance.Name |
            ForEach-Object { Get-RecoveryPointSnapshot $_ })
        if ($script:State.Backup.RecoveryPointId) {
            $points = @($points | Where-Object { $_.Name -ceq $script:State.Backup.RecoveryPointId })
        } else {
            $points = @($points | Where-Object { $_.Time -ge [datetime]$script:State.Backup.SubmittedUtc })
        }
        if ($points.Count -gt 1) { throw 'Recovery point discovery is ambiguous; refusing to choose a point from another backup.' }
        if ($points.Count -gt 0) {
            $script:State.RecoveryPointId = [string]$points[0].Name
            $script:State.RecoveryPointResourceId = [string]$points[0].Id
            $script:State.RecoveryPointTime = $points[0].Time.ToUniversalTime().ToString('o')
            if (-not $script:State.RecoveryPointId) { throw 'Completed backup recovery point has no ID.' }
            Save-State
        }
    }
    Assert-JobNotFailed $script:State.Backup
    foreach ($key in (Get-ScenarioKeys)) { Assert-JobNotFailed $script:State.Restores[$key] }
}

function Get-MutationInventory([switch] $IncludeDocument) {
    # A detached baseline copy; NEVER mutate the recovery-point inventory.
    $inventory = ConvertFrom-Json -InputObject (ConvertTo-Json -InputObject @($script:State.SourceInventory) -Depth 100) -AsHashtable -NoEnumerate
    $database = @($inventory | Where-Object { $_.Database -ceq 'db2' })
    if ($database.Count -ne 1 -or 'afterBackup' -cin @($database[0].Containers | ForEach-Object { $_.Name })) { throw 'Mutation fixture requires baseline db2 without afterBackup.' }
    $documents = @()
    if ($IncludeDocument) { $documents = @($script:State.Mutation.Document) }
    $container = @{ Name = 'afterBackup'; PartitionKey = @('/id'); Documents = @($documents) }
    $database[0].Containers = @((@($database[0].Containers) + @($container)) | Sort-Object Name -CaseSensitive)
    return ,@($inventory)
}

function Invoke-Churn {
    $script:Operation = 'Churn'
    if ($script:State.Backup.Status -ne 'Completed' -or -not $script:State.RecoveryPointId -or -not $script:State['RecoveryPointResourceId']) {
        throw 'Churn requires a Completed backup and its confirmed recovery point. Run Poll first.'
    }
    $source = @(Get-Accounts | Where-Object Name -IEQ $script:State.Accounts['source'].Name)
    if ($source.Count -ne 1) { throw 'Recorded source account is missing.' }
    Assert-OwnedAccount $source[0] $script:State.Accounts['source']
    $mutation = $script:State['Mutation']
    if ($null -ne $mutation -and $mutation.Status -eq 'Completed') {
        if ($mutation.RecoveryPointId -cne $script:State.RecoveryPointId) { throw 'Mutation is bound to a different recovery point.' }
        Assert-Equal (Get-Inventory 'source') (Get-MutationInventory -IncludeDocument) 'completed post-backup mutation'
        return
    }
    foreach ($key in (Get-ScenarioKeys)) {
        $record = $script:State.Restores[$key]
        if ($record.JobId -or $record.RequestJson -or $record.Status -ne 'Planned') { throw 'Churn is allowed only before the first restore intent; no selected restore may have started.' }
    }
    $actual = Get-Inventory 'source'
    if ($null -eq $mutation) {
        Assert-Equal $actual $script:State.SourceInventory 'source unchanged before post-backup mutation'
        $baselineDatabase = @($script:State.SourceInventory | Where-Object { $_.Database -ceq 'db2' })
        if ($baselineDatabase.Count -ne 1 -or 'afterBackup' -cin @($baselineDatabase[0].Containers | ForEach-Object { $_.Name })) { throw 'Mutation fixture requires baseline db2 without afterBackup; no source writes were attempted.' }
        $script:State.Mutation = @{
            Status = 'Planned'; RecoveryPointId = $script:State.RecoveryPointId
            Database = 'db2'; Container = 'afterBackup'; StartedUtc = [datetime]::UtcNow.ToString('o')
            ContainerStatus = 'Planned'; DocumentStatus = 'Planned'
            Document = @{ id = 'afterBackup'; run = $script:State.RunId; database = 'db2'; container = 'afterBackup'; value = 'post-backup-only' }
        }
        $mutation = $script:State.Mutation
        Save-State
    }
    if ($mutation.RecoveryPointId -cne $script:State.RecoveryPointId -or $mutation.Database -cne 'db2' -or $mutation.Container -cne 'afterBackup') { throw 'Persisted mutation context differs from this fixture/recovery point.' }
    $hasContainer = 'afterBackup' -cin @($actual | Where-Object { $_.Database -ceq 'db2' } | ForEach-Object { $_.Containers } | ForEach-Object { $_.Name })
    if (-not $hasContainer) {
        if ($mutation.ContainerStatus -eq 'Created') { throw 'Recorded mutation container is missing; refusing to recreate.' }
        Assert-Equal $actual $script:State.SourceInventory 'source before new mutation container'
        $mutation.Status = 'InProgress'
        $mutation.ContainerStatus = 'Creating'
        Save-State
        Assert-Context
        $null = New-AzCosmosDBSqlContainer -ResourceGroupName $ResourceGroupName -AccountName $source[0].Name -DatabaseName 'db2' -Name 'afterBackup' -PartitionKeyKind Hash -PartitionKeyPath @('/id') -Confirm:$false
        $actual = Get-Inventory 'source'
    } elseif ($mutation.ContainerStatus -eq 'Planned') {
        throw 'Mutation container appeared before its write-ahead intent; refusing to adopt it.'
    }
    # Get-Documents already returns a non-enumerated array; @() around its call
    # would wrap even an empty result in another array and incorrectly count one.
    $documents = Get-Documents $source[0].Name 'db2' 'afterBackup'
    if ($documents.Count -eq 0) {
        if ($mutation.DocumentStatus -eq 'Created') { throw 'Recorded mutation document is missing; refusing to recreate.' }
        Assert-Equal $actual (Get-MutationInventory) 'source with only the new empty container'
        $mutation.ContainerStatus = 'Created'
        $mutation.Checkpoint = 'container:db2/afterBackup'
        Save-State
        $mutation.DocumentStatus = 'Creating'
        Save-State
        # Native AAD document create without upsert. Never modify baseline docs.
        $null = Invoke-DocumentRequest -AccountName $source[0].Name -Database 'db2' -Container 'afterBackup' -Document $mutation.Document
    } elseif ($mutation.DocumentStatus -eq 'Planned') {
        throw 'Mutation document appeared before its write-ahead intent; refusing to adopt it.'
    }
    $script:State.CurrentSourceInventory = Get-Inventory 'source'
    $script:State.CurrentSourceInventoryUtc = [datetime]::UtcNow.ToString('o')
    Assert-Equal $script:State.CurrentSourceInventory (Get-MutationInventory -IncludeDocument) 'complete post-backup source inventory'
    $mutation.ContainerStatus = 'Created'
    $mutation.DocumentStatus = 'Created'
    $mutation.Checkpoint = 'document:db2/afterBackup/afterBackup'
    $mutation.Status = 'Completed'
    $mutation.CompletedUtc = $script:State.CurrentSourceInventoryUtc
    Save-State
}

function Invoke-Restore {
    $script:Operation = 'Restore'
    if ($script:State.Backup.Status -ne 'Completed' -or -not $script:State.RecoveryPointId) { throw 'Run Poll after the backup completes to discover its recovery point.' }
    if ($script:State['Mutation'] -and $script:State.Mutation.Status -ne 'Completed') { throw 'Complete the persisted Churn intent before restoring; no restore will be submitted.' }
    $pending = $false
    foreach ($key in (Get-ScenarioKeys)) {
        $record = $script:State.Restores[$key]
        if ($record.JobId) {
            # Snapshot every previously submitted job before creating any target,
            # including checkpoints written by an older non-sequential harness.
            Update-Job $record 'Restore'
            Assert-JobNotFailed $record
            if ($record.Status -ne 'Completed') { $pending = $true }
        } elseif ($record.Status -eq 'Submitting') {
            throw "Restore $key submission outcome is ambiguous; reconcile the persisted intent first."
        }
    }
    # Unknown, paused, cancelling and in-progress states all block the next case.
    if ($pending) { return }
    foreach ($key in (Get-ScenarioKeys)) {
        $record = $script:State.Restores[$key]
        if ($record.JobId) { continue }
        $account = Initialize-ScenarioAccount $key
        Set-ScenarioDataRole $key
        # Entire account must be empty, not only selected containers. Native ARM
        # inventory does not depend on Cosmos data-role propagation.
        if (@(Get-AzCosmosDBSqlDatabase -ResourceGroupName $ResourceGroupName -AccountName $account.Name).Count -ne 0) { throw "Target $key is not empty. Refusing to overwrite or retrigger." }
        $arguments = @{
            DatasourceType = 'AzureCosmosDB'; SourceDataStore = 'VaultStore'; RestoreLocation = $script:RestoreLocation
            RestoreType = 'AlternateLocation'; TargetResourceId = $account.Id; RecoveryPoint = $script:State.RecoveryPointId
            UseSystemAssignedIdentity = [bool]$record.Identity.UseSystemAssignedIdentity
        }
        if (-not $record.Identity.UseSystemAssignedIdentity) { $arguments.UserAssignedIdentityArmId = $record.Identity.UserAssignedIdentityArmId }
        if ($key -ne 'full') {
            $arguments.ItemLevelRecovery = $true
            $arguments.RestoreConfiguration = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier $record.Selectors
        }
        $request = Initialize-AzDataProtectionRestoreRequest @arguments
        $wire = Get-WireJson $request
        if ($record.RequestJson -and $record.RequestJson -cne $wire) { throw 'Generated request differs from the persisted restore intent.' }
        $record.RequestJson = $wire
        $record.TargetResourceId = $account.Id
        $record.RecoveryPointId = $script:State.RecoveryPointId
        $record.Status = 'Initialized'
        Save-State
        $permission = @{}
        if (-not $record.Identity.UseSystemAssignedIdentity) { $permission.UserAssignedIdentityARMId = $record.Identity.UserAssignedIdentityArmId }
        Set-AzDataProtectionMSIPermission -SubscriptionId $SubscriptionId -VaultResourceGroup $ResourceGroupName -VaultName $VaultName -RestoreRequest $request -DatasourceType AzureCosmosDB -PermissionsScope Resource @permission -Confirm:$false | Out-Null
        $record.Status = 'PermissionsAssigned'
        Save-State
        Test-AzDataProtectionBackupInstanceRestore @script:VaultArguments -Name $script:State.BackupInstance.Name -RestoreRequest $request -Confirm:$false | Out-Null
        $record.Status = 'Validated'
        Save-State
        # Save exact transport JSON AND mapping before submission; never use raw DPP REST.
        [IO.File]::WriteAllText((Join-Path $OutputDirectory "$key.restore.create-update.json"), $wire, [Text.UTF8Encoding]::new($false))
        $record.Status = 'Submitting'
        $record.SubmittedUtc = [datetime]::UtcNow.ToString('o')
        Save-State
        $response = Start-AzDataProtectionBackupInstanceRestore @script:VaultArguments -BackupInstanceName $script:State.BackupInstance.Name -Parameter $request -Confirm:$false
        Save-SubmittedJob $response $record
        Update-Job $record 'Restore'
        Assert-JobNotFailed $record
        if ($record.Status -ne 'Completed') { return }
    }
}

function Invoke-Verify {
    param([switch] $CompletedOnly)
    Invoke-Poll
    $script:Operation = 'Verify'
    foreach ($key in (Get-ScenarioKeys)) {
        if (-not $CompletedOnly -and $script:State.Restores[$key].Status -ne 'Completed') { throw "Restore $key is not Completed; call Poll later." }
    }
    $expectedSource = $script:State.SourceInventory
    if ($script:State['Mutation']) {
        if ($script:State.Mutation.Status -ne 'Completed' -or $script:State.Mutation.RecoveryPointId -cne $script:State.RecoveryPointId) { throw 'Source mutation is incomplete or bound to a different recovery point.' }
        $expectedSource = Get-MutationInventory -IncludeDocument
        Assert-Equal $script:State.CurrentSourceInventory $expectedSource 'persisted completed mutation inventory'
    }
    $source = @(Get-Accounts | Where-Object Name -IEQ $script:State.Accounts['source'].Name)
    if ($source.Count -ne 1) { throw 'Recorded source account is missing.' }
    Assert-OwnedAccount $source[0] $script:State.Accounts['source']
    Assert-Equal (Get-Inventory 'source') $expectedSource 'source unchanged after restore (including optional post-backup mutation)'
    foreach ($key in (Get-ScenarioKeys)) {
        if ($CompletedOnly -and $script:State.Restores[$key].Status -ne 'Completed') { continue }
        $accounts = @(Get-Accounts | Where-Object Name -IEQ $script:State.Accounts[$key].Name)
        if ($accounts.Count -ne 1) { throw 'Recorded target account is missing.' }
        Assert-OwnedAccount $accounts[0] $script:State.Accounts[$key]
        Set-ScenarioDataRole $key
        $actual = Get-Inventory $key
        $expected = Get-ExpectedInventory $key
        Assert-Equal $actual $expected "$key complete database/container/document inventory"
        $script:State.Restores[$key].VerifiedUtc = [datetime]::UtcNow.ToString('o')
        $script:State.Restores[$key].Inventory = $actual
        Save-State
    }
    $script:State.Verified = @((Get-ScenarioKeys) | Where-Object { -not $script:State.Restores[$_].ContainsKey('VerifiedUtc') }).Count -eq 0
    Save-State
}

# Nothing above performs I/O until explicitly invoked. This also permits isolated
# offline AST/function tests without importing modules or contacting Azure.
try {
    $script:PhaseStatus = 'Running'
    if (-not $EnableLive) { throw 'Explicit -EnableLive is required; no Azure operations were performed.' }
    if ($PSBoundParameters.ContainsKey('Debug') -or $PSBoundParameters.ContainsKey('Verbose')) { throw 'Debug/Verbose are not permitted for this live script.' }
    if (Get-Module Az.DataProtection) { throw 'Use a fresh pwsh -NoProfile -File process; Az.DataProtection is already imported.' }
    if ([AppDomain]::CurrentDomain.GetAssemblies().GetName().Name -match '^Az\.DataProtection\.') { throw 'A DataProtection assembly is already loaded; use a fresh process.' }
    $repoRoot = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)
    $ModulePath = (Resolve-Path -LiteralPath $ModulePath).Path
    $moduleRoot = Split-Path -Parent $ModulePath
    $artifactRoot = [IO.Path]::GetFullPath((Join-Path $repoRoot 'artifacts')) + [IO.Path]::DirectorySeparatorChar
    if (-not $ModulePath.StartsWith($artifactRoot, [StringComparison]::OrdinalIgnoreCase) -or
        [IO.Path]::GetFileName($ModulePath) -ne 'Az.DataProtection.psd1') { throw 'ModulePath must be a locally built Az.DataProtection manifest under this checkout artifacts directory.' }
    $OutputDirectory = [IO.Path]::GetFullPath($OutputDirectory)
    if ($OutputDirectory -eq $moduleRoot -or $OutputDirectory.StartsWith($moduleRoot + [IO.Path]::DirectorySeparatorChar, [StringComparison]::OrdinalIgnoreCase)) { throw 'OutputDirectory cannot be inside the module artifact.' }
    $probe = Join-Path $OutputDirectory 'state.json'
    $null = Get-Command git -ErrorAction Stop
    & git -C $repoRoot check-ignore --quiet --no-index -- $probe
    if ($LASTEXITCODE -ne 0) { throw 'OutputDirectory must be git-ignored by this checkout (use a directory under artifacts).' }
    $null = New-Item -ItemType Directory -Path $OutputDirectory -Force
    # A file lease prevents two phase processes from racing on one run's state.
    $script:Lease = [IO.File]::Open((Join-Path $OutputDirectory 'scenario.lock'), [IO.FileMode]::OpenOrCreate, [IO.FileAccess]::ReadWrite, [IO.FileShare]::None)
    $script:StatePath = $probe
    Import-Module Az.Accounts -MinimumVersion 5.5.3
    Import-Module Az.Resources
    Import-Module Az.CosmosDB
    Import-Module $ModulePath
    $type = 'Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.GenericRestoreDatasourceCriteria' -as [type]
    $assembly = Join-Path $moduleRoot 'bin/Az.DataProtection.private.dll'
    if ($null -eq $type -or $type.Namespace -ne 'Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models' -or
        [IO.Path]::GetFullPath($type.Assembly.Location) -ne [IO.Path]::GetFullPath($assembly)) { throw 'Wrong or versioned API model/assembly loaded; rebuild the tracked module and use a fresh process.' }
    foreach ($commandName in @('Initialize-AzDataProtectionRestoreRequest', 'New-AzDataProtectionRestoreConfigurationClientObject', 'Start-AzDataProtectionBackupInstanceRestore', 'Test-AzDataProtectionBackupInstanceRestore')) {
        $command = Get-Command $commandName
        if (-not $command.Module.ModuleBase.StartsWith($moduleRoot, [StringComparison]::OrdinalIgnoreCase)) { throw 'A DataProtection command resolved outside the supplied local module.' }
    }
    $context = Get-AzContext
    $selection = @{ SubscriptionId = [string]$SubscriptionId; Scope = 'Process' }
    if ($null -ne $context -and $null -ne $context.Tenant -and $context.Tenant.Id) { $selection.Tenant = $context.Tenant.Id }
    $null = Set-AzContext @selection
    $context = Get-AzContext
    if ($null -eq $context -or $context.Subscription.Id -ne [string]$SubscriptionId -or $context.Account.Type -ne 'User') { throw 'Sign in as the executing Entra user with access to the explicit subscription before launching a fresh process.' }
    $script:VaultArguments = @{ SubscriptionId = [string]$SubscriptionId; ResourceGroupName = $ResourceGroupName; VaultName = $VaultName }
    $vault = Get-AzDataProtectionBackupVault @script:VaultArguments
    $vaultId = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.DataProtection/backupVaults/$VaultName"
    if ($vault.Id -ine $vaultId -or [string]::IsNullOrWhiteSpace($vault.Location)) { throw 'Expected existing vault context or location does not match.' }
    $script:RestoreLocation = [string]$vault.Location
    $backupIdentity = Resolve-ScenarioIdentity $vault $UserAssignedIdentityArmId
    $vaultPrincipalId = $backupIdentity.PrincipalId
    $fingerprint = (Get-FileHash -LiteralPath $assembly -Algorithm SHA256).Hash
    if (Test-Path -LiteralPath $script:StatePath) {
        $script:State = Get-Content -LiteralPath $script:StatePath -Raw | ConvertFrom-Json -AsHashtable
        if ($script:State.SchemaVersion -ne 1 -or $script:State.SubscriptionId -ne [string]$SubscriptionId -or
            $script:State.ResourceGroupName -cne $ResourceGroupName -or $script:State.VaultName -cne $VaultName -or
            $script:State.TestPrefix -cne $TestPrefix -or $script:State.ModulePath -cne $ModulePath -or
            $script:State.AssemblySha256 -cne $fingerprint -or $script:State.UserAssignedIdentityArmId -ine $UserAssignedIdentityArmId -or
            $script:State.VaultPrincipalId -cne $vaultPrincipalId) { throw 'Persisted state/context/module fingerprint mismatch. Refusing to change or adopt resources.' }
        Assert-Context
        # Compatible old checkpoints have no location; bind them to the existing
        # vault only after subscription, tenant, principal and fingerprint checks.
        if ($script:State.ContainsKey('RestoreLocation') -and $script:State.RestoreLocation -ine $script:RestoreLocation) {
            throw 'Persisted run location differs from the existing vault.'
        }
        $script:State.RestoreLocation = $script:RestoreLocation
    } else {
        if ($Phase -notin @('Prepare', 'All')) { throw 'No state exists. Start with Prepare in a unique ignored output directory.' }
        $user = @(Get-AzADUser -SignedIn)
        if ($user.Count -ne 1 -or -not $user[0].Id) { throw 'Could not uniquely resolve executing Entra user object ID.' }
        $script:State = @{
            SchemaVersion = 1; RunId = [guid]::NewGuid().ToString(); CreatedUtc = [datetime]::UtcNow.ToString('o')
            SubscriptionId = [string]$SubscriptionId; ResourceGroupName = $ResourceGroupName; VaultName = $VaultName; VaultId = $vaultId
            RestoreLocation = $script:RestoreLocation
            TenantId = $context.Tenant.Id; AccountId = $context.Account.Id; PrincipalId = $user[0].Id
            TestPrefix = $TestPrefix; ModulePath = $ModulePath; AssemblyPath = $assembly; AssemblySha256 = $fingerprint
            ModuleVersion = (Get-Module Az.DataProtection).Version.ToString(); CosmosModuleVersion = (Get-Module Az.CosmosDB).Version.ToString()
            UserAssignedIdentityArmId = $UserAssignedIdentityArmId; VaultPrincipalId = $vaultPrincipalId
            Prepared = $false; Seeded = $false; Verified = $false
            ScenarioOrder = @('full', 'single', 'database', 'mixed')
            RecoveryPointId = $null; SourceInventory = @(); Accounts = [ordered]@{}; Restores = [ordered]@{}
            Policy = @{ Name = "$TestPrefix-policy"; Id = "$vaultId/backupPolicies/$TestPrefix-policy"; Status = 'Planned'; WireJson = $null }
            BackupInstance = @{ Name = $null; Id = $null; Status = 'Planned' }
            Backup = @{ Status = 'Planned'; JobId = $null; RecoveryPointId = $null }
        }
        foreach ($key in (@('source') + @(Get-ScenarioKeys))) {
            $name = "$TestPrefix-$key"
            $script:State.Accounts[$key] = @{
                Name = $name; Id = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/$name"
                Status = 'Planned'; DataRoleId = [guid]::NewGuid().ToString()
            }
        }
        $selections = @{ full = @(); single = @('db1/cont1'); database = @('db2'); mixed = @('db1/col1', 'db1/col2', 'db2') }
        foreach ($key in (Get-ScenarioKeys)) {
            $script:State.Restores[$key] = @{ Status = 'Planned'; JobId = $null; RequestJson = $null; Selectors = $selections[$key] }
        }
        # Check ALL names before provisioning anything. A partial resume can only
        # adopt an account carrying this run's previously persisted ownership tag.
        $existingNames = @(Get-Accounts | ForEach-Object Name)
        foreach ($record in $script:State.Accounts.Values) {
            if ($record.Name -in $existingNames) { throw 'A planned source/target name already exists. Choose a new unique prefix.' }
        }
    }
    Assert-Context
    Initialize-ScenarioSelection $vault
    $script:StateValidated = $true
    Save-State
    switch ($Phase) {
        'Prepare' { Invoke-Prepare }
        'Backup' { Invoke-Backup }
        'Targets' {
            foreach ($key in @(Get-ScenarioKeys)) {
                if ($script:State.Restores[$key].JobId) { continue }
                $account = Initialize-ScenarioAccount $key
                Set-ScenarioDataRole $key
                if (@(Get-AzCosmosDBSqlDatabase -ResourceGroupName $ResourceGroupName -AccountName $account.Name).Count -ne 0) {
                    throw "Target $key is not empty; no data or account will be modified."
                }
            }
        }
        'Churn' { Invoke-Churn }
        'Poll' { Invoke-Poll }
        'Restore' { Invoke-Restore }
        'Verify' { Invoke-Verify }
        'VerifyCompleted' { Invoke-Verify -CompletedOnly }
        'All' {
            Invoke-Prepare
            Invoke-Backup
            Invoke-Poll
            if ($script:State.Backup.Status -eq 'Completed' -and $script:State.RecoveryPointId) {
                Invoke-Restore
                Invoke-Poll
                if (@((Get-ScenarioKeys) | Where-Object { $script:State.Restores[$_].Status -ne 'Completed' }).Count -eq 0) { Invoke-Verify }
            }
        }
    }
    $script:PhaseStatus = 'Returned'
    Save-State
    $script:State.RunReport | ConvertTo-Json -Depth 20
} catch {
    $script:SafeFailure = Get-SafeNativeFailure $_
    # Preserve native diagnostics separately from job statuses. Never serialize an
    # ErrorRecord/Exception or raw HTTP request/response. Do not rewrite unvalidated state.
    if ((Get-Variable StateValidated -Scope Script -ErrorAction SilentlyContinue) -and $script:StateValidated) {
        $script:PhaseStatus = 'Stopped'
        if ($script:Operation -eq 'Policy') { $script:State.Policy.Failure = $script:SafeFailure }
        try {
            Save-State
            $failureReport = [ordered]@{
                Phase = $Phase; Operation = $script:Operation; Utc = [datetime]::UtcNow.ToString('o')
                SafeFailure = $script:SafeFailure
            }
            # Timestamped failures survive later successful checkpoints (including
            # standalone policy failures); they cannot be confused with a job result.
            $failurePath = Join-Path $OutputDirectory ("Failure-{0}-{1}.json" -f [datetime]::UtcNow.ToString('yyyyMMddTHHmmssfffffffZ'), $PID)
            [IO.File]::WriteAllText($failurePath, (ConvertTo-Json -InputObject $failureReport -Depth 20), [Text.UTF8Encoding]::new($false))
        } catch { Write-Warning 'Could not persist the stopped run/failure report; retain the last valid checkpoint.' }
    }
    Write-Error -Message ("Scenario phase '$Phase' stopped during '$script:Operation'. Sanitized native failure: " + (ConvertTo-Json -InputObject $script:SafeFailure -Depth 20 -Compress) + ' Reconcile any Submitting intent with specific vault jobs before resuming.') -ErrorAction Continue
    exit 1
} finally {
    if ((Get-Variable Lease -Scope Script -ErrorAction SilentlyContinue) -and $null -ne $script:Lease) { $script:Lease.Dispose() }
}