# Pester 4 runs these fixtures sequentially. Never use these helpers from parallel jobs.
# All live writes are confined to the registered owned plan; shared membership is read-only.
function Save-ROScenarioEnv {
    switch ($TestMode) {
        'playback' { return }
        'record' { $fileName = 'env.json' }
        'live' { $fileName = 'localEnv.json' }
        default { throw 'Environment persistence requires an explicit Record, Live, or Playback mode.' }
    }
    $directory = if ($ROScenarioEnvironmentDirectory) { $ROScenarioEnvironmentDirectory } else { $PSScriptRoot }
    $env | ConvertTo-Json -Depth 60 | Set-Content (Join-Path $directory $fileName)
}

function Assert-ROPlanOwnershipAvailable {
    if ($global:ROValidationPlanOutstanding -or $env.activeScenarioKey -or
        $env.standalonePlanOwnership.Outstanding) {
        throw 'An owned PowerShell plan is unresolved. Reconcile it before creating another.'
    }
}

function Start-ROStandalonePlanOwnership($FixtureEnv) {
    Assert-ROPlanOwnershipAvailable
    if (-not $FixtureEnv.reuseSharedSetup -or
        [string]::IsNullOrWhiteSpace($FixtureEnv.recoveryServiceGroupName) -or
        [string]::IsNullOrWhiteSpace($FixtureEnv.recoveryPlanName)) {
        throw 'Standalone CRUD requires its explicitly selected shared fixture and owned plan name.'
    }
    $ownership = [pscustomobject]@{
        PlanId = "/providers/Microsoft.Management/serviceGroups/$($FixtureEnv.recoveryServiceGroupName)/providers/Microsoft.AzureResilienceManagement/recoveryPlans/$($FixtureEnv.recoveryPlanName)"
        Outstanding = $true
    }
    if ($env -is [System.Collections.IDictionary]) {
        $env['standalonePlanOwnership'] = $ownership
    } else {
        $env | Add-Member -NotePropertyName standalonePlanOwnership -NotePropertyValue $ownership -Force
    }
    Set-ROValidationPlanOutstanding $true
    Save-ROScenarioEnv
}

function Complete-ROStandalonePlanOwnership($FixtureEnv) {
    $expected = "/providers/Microsoft.Management/serviceGroups/$($FixtureEnv.recoveryServiceGroupName)/providers/Microsoft.AzureResilienceManagement/recoveryPlans/$($FixtureEnv.recoveryPlanName)"
    if (-not $env.standalonePlanOwnership.Outstanding -or
        $env.standalonePlanOwnership.PlanId -ne $expected) {
        throw 'Cannot release standalone ownership for a different or unowned plan.'
    }
    $env.standalonePlanOwnership.Outstanding = $false
    Set-ROValidationPlanOutstanding $false
    Save-ROScenarioEnv
}

# Pure local cache migration. Never use cleanup of one plan to clear another owner.
function Get-ROFutureRecordBaseline($Current, $Released, $CleanupProof) {
    if (-not $Current.reuseSharedSetup -or $Current.standalonePlanOwnership.Outstanding) {
        throw 'Future Record requires an explicitly shared baseline without unresolved standalone ownership.'
    }
    $releaseKey = $CleanupProof.Cleanup.Key
    foreach ($property in $Current.scenarioRegistry.psobject.Properties) {
        if (@($property.Value.OwnedRoleAssignments | Where-Object { $_ -and -not $_.Removed }).Count -or
            ($property.Name -ne $releaseKey -and $property.Value.FinalizeOutstanding)) {
            throw 'Unrelated or unresolved grant/operation ownership must be preserved, not cleared.'
        }
    }
    $needsRelease = $Current.activeScenarioKey -or $Current.scenarioRegistry.$releaseKey.FinalizeOutstanding
    if (-not $needsRelease) {
        return ($Current | ConvertTo-Json -Depth 80 | ConvertFrom-Json)
    }
    if (-not $releaseKey -or $Current.activeScenarioKey -ne $releaseKey -or
        $CleanupProof.Stage -ne 'CompletedSetupOnlyAndOwnedPlanAbsent' -or
        -not $CleanupProof.Cleanup.Absent -or
        $Current.scenarioRegistry.$releaseKey.PlanId -ne $CleanupProof.Cleanup.PlanId -or
        $CleanupProof.PlanId -ne $CleanupProof.Cleanup.PlanId -or
        [string]::IsNullOrWhiteSpace($Current.scenarioRegistry.$releaseKey.PrincipalId) -or
        $CleanupProof.PrincipalId -ne $Current.scenarioRegistry.$releaseKey.PrincipalId -or
        $Released.lastScenarioCleanup.PlanId -ne $CleanupProof.Cleanup.PlanId -or
        -not $Released.lastScenarioCleanup.Absent -or $Released.lastScenarioCleanup.Key -ne $releaseKey -or
        $Released.activeScenarioKey -or $Released.standalonePlanOwnership.Outstanding -or
        $Released.scenarioRegistry.$releaseKey.FinalizeOutstanding -or
        $Released.scenarioRegistry.$releaseKey.PlanId -ne $CleanupProof.Cleanup.PlanId -or
        $Current.scenarioRegistry.$releaseKey.PrincipalId -ne $Released.scenarioRegistry.$releaseKey.PrincipalId -or
        $CleanupProof.NativeReadinessJob.Status -ne 'Completed' -or
        $CleanupProof.NativeReadinessJob.Id -notlike "$($CleanupProof.Cleanup.PlanId)/recoveryJobs/*" -or
        -not $Released.reuseSharedSetup -or
        $Current.SubscriptionId -ne $Released.SubscriptionId -or $Current.Tenant -ne $Released.Tenant -or
        $Current.recoveryServiceGroupName -ne $Released.recoveryServiceGroupName) {
        throw 'Only the exact confirmed-deleted owned plan may be released into a future private baseline.'
    }
    foreach ($property in $Current.scenarioRegistry.psobject.Properties) {
        if ($property.Name -eq $releaseKey) { continue }
        if (($property.Value | ConvertTo-Json -Depth 60 -Compress) -ne
            ($Released.scenarioRegistry.($property.Name) | ConvertTo-Json -Depth 60 -Compress)) {
            throw 'Released baseline changed unrelated scenario state; do not discard it.'
        }
    }
    foreach ($property in $Released.scenarioRegistry.psobject.Properties) {
        if ($property.Value.FinalizeOutstanding -or
            @($property.Value.OwnedRoleAssignments | Where-Object { $_ -and -not $_.Removed }).Count) {
            throw 'Released baseline still contains unresolved operation or grant ownership.'
        }
    }
    # Retain CURRENT unrelated top-level metadata too. Only this proven owner and
    # its cleanup evidence come from the released setup ledger.
    $copy = $Current | ConvertTo-Json -Depth 80 | ConvertFrom-Json
    $copy.activeScenarioKey = $null
    $copy.scenarioRegistry.$releaseKey = $Released.scenarioRegistry.$releaseKey | ConvertTo-Json -Depth 60 | ConvertFrom-Json
    $copy | Add-Member -NotePropertyName lastScenarioCleanup -NotePropertyValue (
        $Released.lastScenarioCleanup | ConvertTo-Json -Depth 20 | ConvertFrom-Json) -Force
    $copy | Add-Member -NotePropertyName FutureRecordOwnershipReleaseEvidence -NotePropertyValue ([pscustomobject]@{
        PlanId = $CleanupProof.Cleanup.PlanId
        PrincipalId = $Released.scenarioRegistry.$releaseKey.PrincipalId
        NativeAbsenceVerified = $true
        ServiceCreatedAssignmentsNotOwned = @($CleanupProof.ServiceAssignmentsNotOwnedByThisScript)
    }) -Force
    return $copy
}

function Get-ROSeededGuid([string]$Seed, [string]$Key) {
    $hash = [System.Security.Cryptography.SHA256]::Create()
    try {
        $bytes = $hash.ComputeHash([System.Text.Encoding]::UTF8.GetBytes("$Seed|$Key"))
        return ([guid]::new([byte[]]$bytes[0..15])).ToString()
    } finally {
        $hash.Dispose()
    }
}

function Initialize-ROScenarioRegistry {
    # Allocate the entire forthcoming batch now, never from an assertion or action.
    $keys = @(
        'New.SharedCrud', 'New.SystemIdentity', 'New.UserIdentity', 'New.CombinedIdentity', 'New.OmittedIdentity',
        'Update.OmittedIdentity', 'Update.SystemFalse', 'Update.SystemTrue', 'Update.UserEmpty',
        'Update.UserReplacement', 'Update.PreserveFields', 'Update.ClearActions',
        'Get.Plan', 'Get.Resource', 'Update.Resource', 'Update.ResourceCaseVariant',
        'Test.Readiness', 'Test.OperationValidation', 'Test.FailoverValidation', 'Test.ReprotectValidation',
        'Invoke.Failover', 'Invoke.Reprotect', 'Get.Job', 'Get.JobResource', 'Invoke.Finalize',
        'Invoke.Retry', 'Resume.Job'
    ) | Sort-Object
    $operationKeys = @(
        'ResourceUpdate', 'ResourceCaseVariant', 'Readiness', 'OperationValidation',
        'FailoverValidation', 'Failover', 'ReprotectValidation', 'Reprotect', 'Finalize', 'Retry', 'Resume'
    )
    if ($env.scenarioRegistry) {
        if ($env.scenarioSchema -ne 1 -or [string]::IsNullOrWhiteSpace($env.scenarioSeed)) {
            throw 'Saved scenario registry has an unsupported schema or missing seed; do not overwrite it.'
        }
        foreach ($key in $keys) {
            $entry = $env.scenarioRegistry.$key
            if (-not $entry -or -not $entry.PlanName -or -not $entry.GroupId -or -not $entry.PlanId) {
                throw "Saved scenario registry is incomplete at $key; preserve it for reconciliation."
            }
            foreach ($operation in $operationKeys) {
                if (-not $entry.OperationIds.$operation) {
                    throw "Saved scenario $key lacks $operation; do not regenerate cached IDs."
                }
            }
            if (-not $entry.PreActionName) {
                $entry | Add-Member -NotePropertyName PreActionName -NotePropertyValue ('pre-' + $entry.PreActionId.Replace('-', '').Substring(0,16))
            }
            if (-not $entry.PostActionName) {
                $entry | Add-Member -NotePropertyName PostActionName -NotePropertyValue ('post-' + $entry.PostActionId.Replace('-', '').Substring(0,16))
            }
            if (-not $entry.OperationValidationNegativeId) {
                $entry | Add-Member -NotePropertyName OperationValidationNegativeId -NotePropertyValue (Get-ROSeededGuid $env.scenarioSeed "$key/operation/OperationValidationNegative")
            }
        }
        return
    }
    if ($UsePreviousConfigForRecord) {
        throw 'Previous env has no batch registry. Do not mix sanitized/legacy env with private incremental Record.'
    }
    $env.scenarioSchema = 1
    $env.scenarioSeed = [guid]::NewGuid().ToString()
    $env.activeScenarioKey = $null
    $env.lastScenarioCleanup = $null
    $env.discoveredStorageMember = $null
    $registry = [ordered]@{}
    foreach ($key in $keys) {
        $name = 'ropsrec-' + (Get-ROSeededGuid $env.scenarioSeed "$key/plan").Replace('-', '').Substring(0, 16)
        $operations = [ordered]@{}
        foreach ($operation in $operationKeys) {
            $operations[$operation] = Get-ROSeededGuid $env.scenarioSeed "$key/operation/$operation"
        }
        $registry[$key] = [pscustomobject]@{
            PlanName = $name
            PlanId = "/providers/Microsoft.Management/serviceGroups/$($env.recoveryServiceGroupName)/providers/Microsoft.AzureResilienceManagement/recoveryPlans/$name"
            GroupId = Get-ROSeededGuid $env.scenarioSeed "$key/group"
            OperationIds = [pscustomobject]$operations
            PreActionId = Get-ROSeededGuid $env.scenarioSeed "$key/pre-action"
            PostActionId = Get-ROSeededGuid $env.scenarioSeed "$key/post-action"
            PreActionName = 'pre-' + (Get-ROSeededGuid $env.scenarioSeed "$key/pre-action").Replace('-', '').Substring(0,16)
            PostActionName = 'post-' + (Get-ROSeededGuid $env.scenarioSeed "$key/post-action").Replace('-', '').Substring(0,16)
            OperationValidationNegativeId = Get-ROSeededGuid $env.scenarioSeed "$key/operation/OperationValidationNegative"
            ReaderRoleAssignmentId = Get-ROSeededGuid $env.scenarioSeed "$key/reader"
            OperatorRoleAssignmentId = Get-ROSeededGuid $env.scenarioSeed "$key/operator"
            AutomationReaderRoleAssignmentId = Get-ROSeededGuid $env.scenarioSeed "$key/automation-reader"
            ResumeReason = "Resume approved owned manual action $name"
        }
    }
    $names = @($registry.Values | ForEach-Object PlanName)
    if (@($names | Select-Object -Unique).Count -ne $keys.Count) {
        throw 'Scenario name collision; no plan was created.'
    }
    $env.scenarioRegistry = [pscustomobject]$registry
}

function Get-ROScenario([string]$Key) {
    $entry = $env.scenarioRegistry.$Key
    if (-not $entry -or -not $entry.PlanName -or -not $entry.GroupId) {
        throw "Scenario $Key must be allocated by setupEnv before execution."
    }
    return $entry
}

function Get-ROScenarioGroup([string]$Key) {
    $entry = Get-ROScenario $Key
    if ($entry.PlanId -notmatch '^/providers/Microsoft.Management/serviceGroups/([^/]+)/providers/Microsoft.AzureResilienceManagement/recoveryPlans/[^/]+$') {
        throw 'Registered scenario lacks an exact service-group plan scope.'
    }
    $group = $Matches[1]
    if ($TestMode -ne 'playback' -and $group -ne $env.recoveryServiceGroupName) {
        throw 'Live scenario scope differs from explicitly selected shared service group.'
    }
    return $group
}

function Renew-ROScenarioFixture([string]$Key) {
    if ($env.activeScenarioKey -or $global:ROValidationPlanOutstanding) {
        throw 'Cannot allocate a fresh attempt while an active scenario owns a plan.'
    }
    Assert-ROPlanOwnershipAvailable
    $entry = Get-ROScenario $Key
    if (@($entry.OwnedRoleAssignments | Where-Object { $_ -and -not $_.Removed }).Count -ne 0) {
        throw 'Cannot replace a fixture with unresolved owned role assignments.'
    }
    $attempt = 1 + [int]$entry.Attempt
    $prefix = "$Key/attempt/$attempt"
    $name = 'ropsrec-' + (Get-ROSeededGuid $env.scenarioSeed "$prefix/plan").Replace('-', '').Substring(0, 16)
    $entry.PlanName = $name
    $entry.PlanId = "/providers/Microsoft.Management/serviceGroups/$($env.recoveryServiceGroupName)/providers/Microsoft.AzureResilienceManagement/recoveryPlans/$name"
    $entry.GroupId = Get-ROSeededGuid $env.scenarioSeed "$prefix/group"
    foreach ($operation in @($entry.OperationIds.psobject.Properties.Name)) {
        $entry.OperationIds.$operation = Get-ROSeededGuid $env.scenarioSeed "$prefix/operation/$operation"
    }
    foreach ($purpose in @(
        @('PreActionId','pre-action'), @('PostActionId','post-action'),
        @('ReaderRoleAssignmentId','reader'), @('OperatorRoleAssignmentId','operator'),
        @('AutomationReaderRoleAssignmentId','automation-reader'),
        @('OperationValidationNegativeId','operation/OperationValidationNegative')
    )) {
        $entry | Add-Member -NotePropertyName $purpose[0] -NotePropertyValue (Get-ROSeededGuid $env.scenarioSeed "$prefix/$($purpose[1])") -Force
    }
    $entry.ResumeReason = "Resume approved owned manual action $name"
    $entry | Add-Member -NotePropertyName PreActionName -NotePropertyValue ('pre-' + $entry.PreActionId.Replace('-', '').Substring(0,16)) -Force
    $entry | Add-Member -NotePropertyName PostActionName -NotePropertyValue ('post-' + $entry.PostActionId.Replace('-', '').Substring(0,16)) -Force
    $entry | Add-Member -NotePropertyName Attempt -NotePropertyValue $attempt -Force
    foreach ($property in 'PrincipalId', 'StorageMember', 'ProducedJobs', 'OwnedRoleAssignments') {
        $entry.psobject.Properties.Remove($property)
    }
}

function New-ROScenarioPlan {
    param([Parameter(Mandatory)][string]$Key, [hashtable]$Properties = @{})
    $entry = Get-ROScenario $Key
    $group = Get-ROScenarioGroup $Key
    Assert-ROPlanOwnershipAvailable
    foreach ($reserved in 'Name', 'ServiceGroupName', 'GroupUniqueId', 'ErrorAction') {
        if ($Properties.ContainsKey($reserved)) {
            throw "Fixture ownership parameter $reserved cannot be overridden."
        }
    }
    $plans = @(Get-AzResiliencyRecoveryPlan -ServiceGroupName $group -ErrorAction Stop)
    # Count is a capacity guard, not a concurrency-sensitive equality assertion.
    if ($plans.Count -ge 5 -or @($plans | Where-Object Name -Like 'ropsrec-*').Count -ne 0) {
        throw 'No safe owned-plan slot is available; no existing plan was modified.'
    }
    if (@($plans | Where-Object Name -EQ $entry.PlanName).Count -ne 0) {
        throw 'The scenario name already exists and is not owned by this invocation.'
    }
    $env.activeScenarioKey = $Key
    Set-ROValidationPlanOutstanding $true
    Save-ROScenarioEnv
    # Mark ownership BEFORE New: a transport failure can follow a successful server write.
    $description = "Owned default recovery group $Key"
    if ($description.Length -gt 50) { $description = $description.Substring(0,50) }
    $arguments = @{
        PlanType = 'Zonal'
        EnableSystemAssignedIdentity = $true
        PlanDescription = "Owned recorded scenario $Key"
        Description = $description
        OrderId = 0
    }
    foreach ($name in $Properties.Keys) { $arguments[$name] = $Properties[$name] }
    $plan = New-AzResiliencyRecoveryPlan -ServiceGroupName $group `
        -Name $entry.PlanName -GroupUniqueId $entry.GroupId @arguments -ErrorAction Stop
    if ($plan.Name -ne $entry.PlanName -or $plan.Id -ne $entry.PlanId) {
        throw 'Native New returned a different plan identity; retain ownership for teardown.'
    }
    # Principal IDs are server output, never seeded.
    $entry | Add-Member -NotePropertyName PrincipalId -NotePropertyValue $plan.IdentityPrincipalId -Force
    Save-ROScenarioEnv
    return $plan
}

function Remove-ROScenarioPlan {
    param([Parameter(Mandatory)][string]$Key)
    if (-not $env.activeScenarioKey) { return }
    if ($env.activeScenarioKey -ne $Key) {
        throw 'Refusing teardown of a scenario not owned by this invocation.'
    }
    $entry = Get-ROScenario $Key
    $group = Get-ROScenarioGroup $Key
    $plans = @(Get-AzResiliencyRecoveryPlan -ServiceGroupName $group -ErrorAction Stop)
    $owned = @($plans | Where-Object Name -EQ $entry.PlanName)
    if ($owned.Count -gt 1 -or ($owned.Count -eq 1 -and $owned[0].Id -ne $entry.PlanId)) {
        throw 'Native plan identity does not match registered ownership; refusing deletion.'
    }
    if ($owned.Count -eq 1) {
        # Cleanup is not the command under test. Use its native asynchronous option,
        # then require actual absence within the bounded native List poll below.
        Remove-AzResiliencyRecoveryPlan -ServiceGroupName $group `
            -Name $entry.PlanName -NoWait -Confirm:$false -ErrorAction Stop
    }
    $absent = $false
    for ($attempt = 0; $attempt -lt 48; $attempt++) {
        $remaining = @(Get-AzResiliencyRecoveryPlan -ServiceGroupName $group -ErrorAction Stop)
        if (@($remaining | Where-Object Name -EQ $entry.PlanName).Count -eq 0) {
            $absent = $true
            break
        }
        Start-TestSleep -Seconds 5
    }
    if (-not $absent) { throw 'Owned plan deletion did not become visible; stop the batch.' }
    $env.activeScenarioKey = $null
    Set-ROValidationPlanOutstanding $false
    $env.lastScenarioCleanup = [pscustomobject]@{ Key = $Key; PlanId = $entry.PlanId; Absent = $true }
    Save-ROScenarioEnv
}

function Save-ROResourceEvidence {
    param([string]$Key, [string]$Stage, [object]$ListResource, [object]$GetResource, [string]$Failure)
    if ($TestMode -eq 'playback') { return }
    # Local private producer output, not a replacement model or a passing-package recording.
    [ordered]@{
        Scenario = $Key
        Runtime = 'Az.Resiliency native test runtime'
        Cmdlet = 'Get-AzResiliencyRecoveryResource'
        Stage = $Stage
        PlanId = (Get-ROScenario $Key).PlanId
        ListResource = $ListResource
        GetResource = $GetResource
        Failure = $Failure
        Cleanup = $env.lastScenarioCleanup
        Outstanding = $global:ROValidationPlanOutstanding
    } | ConvertTo-Json -Depth 60 | Set-Content (Join-Path $PSScriptRoot 'Get-AzResiliencyRecoveryResource.private-evidence.json')
}
