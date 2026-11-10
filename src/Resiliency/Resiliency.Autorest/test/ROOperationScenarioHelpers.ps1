# Test fixtures only. Dot-sourced by the appended canonical Pester4 scenarios.
# The existing registry, recorder and plan lifecycle remain authoritative.
. (Join-Path $PSScriptRoot 'ROScenarioHelpers.ps1')

function Get-ROOperationScope([string]$Key) {
    $entry = Get-ROScenario $Key
    $group = Get-ROScenarioGroup $Key
    $approvedGroups = @('roBCDRAzValidationSG3', 'roBCDRAzValidationSG5',
        'roBCDRAzValidationSG8', 'roBCDRAzValidationSG10', 'roBCDRAzValidationSG12')
    if ($TestMode -eq 'playback') {
        $approvedGroups += @('rotest-sg-3', 'rotest-sg-5', 'rotest-sg-8', 'rotest-sg-10', 'rotest-sg-12')
    }
    if ($group -notin $approvedGroups) {
        throw 'Operation scenarios require an explicitly approved PowerShell service group.'
    }
    if ($env.activeScenarioKey -ne $Key) { throw 'Operation requires the currently owned scenario.' }
    return @{ ServiceGroupName = $group; RecoveryPlanName = $entry.PlanName; ErrorAction = 'Stop' }
}

function Assert-RONoActionError($Result) {
    foreach ($item in @($Result)) {
        if ($null -ne $item -and (
            -not [string]::IsNullOrWhiteSpace($item.Code) -or
            -not [string]::IsNullOrWhiteSpace($item.Message))) {
            throw "Native action returned $($item.Code): $($item.Message)"
        }
    }
}

function Save-ROProducedJob([string]$Key, [string]$Stage, $Response) {
    $entry = Get-ROScenario $Key
    if ([string]::IsNullOrWhiteSpace($Response.JobId)) {
        throw "Native $Stage omitted JobId; no fallback is permitted."
    }
    $id = [string]$Response.JobId
    $name = $id.TrimEnd('/').Split('/')[-1]
    if ($id.Contains('/') -and $id -ne "$($entry.PlanId)/recoveryJobs/$name") {
        throw 'Native action returned a job outside the owned plan.'
    }
    if (-not $entry.ProducedJobs) {
        $entry | Add-Member -NotePropertyName ProducedJobs -NotePropertyValue ([pscustomobject]@{}) -Force
    }
    $entry.ProducedJobs | Add-Member -NotePropertyName $Stage -NotePropertyValue $id -Force
    Save-ROScenarioEnv
    return $name
}

function Wait-ROExactJob {
    param([string]$Key, [string]$Name, [string]$Expected = 'Completed',
        [ValidateRange(1,120)][int]$Attempts = 120, [switch]$AllowInitialFailed)
    $scope = Get-ROOperationScope $Key
    $entry = Get-ROScenario $Key
    $leftInitialFailure = $false
    for ($i = 0; $i -lt $Attempts; $i++) {
        $job = Get-AzResiliencyRecoveryJob @scope -Name $Name
        if ($job.Name -ne $Name -or $job.Id -ne "$($entry.PlanId)/recoveryJobs/$Name") {
            throw 'Native exact-job Get returned a different identity.'
        }
        if ($job.Status -eq $Expected) { return $job }
        $initialFailure = $AllowInitialFailed -and -not $leftInitialFailure -and $job.Status -eq 'Failed'
        if ($job.Status -ne 'Failed') { $leftInitialFailure = $true }
        if ($job.Status -in @('Completed', 'Failed', 'CompletedWithWarnings', 'Canceled', 'Cancelled') -and -not $initialFailure) {
            throw "Exact job $Name reached $($job.Status), expected $Expected."
        }
        if ($i + 1 -lt $Attempts) { Start-TestSleep -Seconds 5 }
    }
    throw "Exact job $Name did not reach $Expected within the bounded poll."
}

function Wait-ROOwnedJobsTerminal([string]$Key) {
    $scope = Get-ROOperationScope $Key
    $entry = Get-ROScenario $Key
    for ($i = 0; $i -lt 120; $i++) {
        $jobs = @(Get-AzResiliencyRecoveryJob @scope)
        foreach ($job in $jobs) {
            if ($job.Id -ne "$($entry.PlanId)/recoveryJobs/$($job.Name)") { throw 'Cleanup observed a foreign job.' }
        }
        foreach ($known in @($entry.ProducedJobs.psobject.Properties.Value)) {
            if (-not $known) { continue }
            $knownName = ([string]$known).TrimEnd('/').Split('/')[-1]
            if (@($jobs | Where-Object Name -EQ $knownName).Count -ne 1) {
                throw 'Cleanup job inventory omitted a known native-produced job; retain ownership.'
            }
        }
        $active = @($jobs | Where-Object Status -NotIn @('Completed', 'Failed', 'CompletedWithWarnings', 'Canceled', 'Cancelled'))
        if ($active.Count -eq 0) { return }
        if ($i -lt 119) { Start-TestSleep -Seconds 5 }
    }
    throw 'Owned jobs remain unresolved; retain the plan and block the next scenario. Never Cancel/Stop.'
}

function Get-ROOwnedStorage([string]$Key, [string]$ApprovedResourceId) {
    $scope = Get-ROOperationScope $Key
    # This producer, not a manifest/hardcoded workload ID, selects the member.
    $all = @(Get-AzResiliencyRecoveryResource @scope)
    $storage = @($all | Where-Object ResourceId -Match '/providers/Microsoft.Storage/storageAccounts/[^/]+$' |
        Sort-Object ResourceId, Name)
    if ($ApprovedResourceId) {
        $storage = @($storage | Where-Object ResourceId -EQ $ApprovedResourceId)
        if ($storage.Count -ne 1) { throw 'Native inventory must contain exactly the explicitly approved storage account; no fallback is permitted.' }
    }
    if ($storage.Count -eq 0) { throw 'Native List contains no storage member; setup is blocked.' }
    $resource = Get-AzResiliencyRecoveryResource @scope -Name $storage[0].Name
    foreach ($property in 'Id', 'Name', 'UniqueId', 'ResourceId', 'ResourceLocation') {
        if ([string]::IsNullOrWhiteSpace($resource.$property) -or $resource.$property -ne $storage[0].$property) {
            throw "Native storage List/Get disagree or omit $property."
        }
    }
    $entry = Get-ROScenario $Key
    if ($resource.Id -ne "$($entry.PlanId)/recoveryResources/$($resource.Name)") { throw 'Foreign recovery resource.' }
    $entry | Add-Member -NotePropertyName StorageMember -NotePropertyValue $resource -Force
    Save-ROScenarioEnv
    return $resource
}

function Assert-ROCustomRunbookSelection([string]$FailoverRunbook, [string]$ReprotectRunbook, [switch]$Failure) {
    if (-not $env.fixtureRunbookId -or -not $env.fixtureAutomationAccountId) {
        throw 'Runbook fixture IDs must be seeded by setupEnv, not generated in a test.'
    }
    if ($env.fixtureFailureRunbookId -and $env.fixtureFailureRunbookId -eq $env.fixtureRunbookId) {
        throw 'The success-only no-op cannot stand in for an intentional-failure runbook.'
    }
    if ($Failure -and -not $env.fixtureFailureRunbookId) {
        throw 'An approved intentional-failure runbook is required for this Failure scenario before any mutation.'
    }
    if ([string]::IsNullOrWhiteSpace($FailoverRunbook) -or [string]::IsNullOrWhiteSpace($ReprotectRunbook)) {
        throw 'Selected runbook is missing; an absent intentional-failure fixture must never fall back to the success-only no-op.'
    }
    if ($FailoverRunbook -notin @($env.fixtureRunbookId, $env.fixtureFailureRunbookId)) {
        throw 'Only the approved published no-op/failure fixture may be selected.'
    }
    if ($ReprotectRunbook -notin @($env.fixtureRunbookId, $env.fixtureFailureRunbookId)) {
        throw 'Only the approved published no-op/failure Reprotect fixture may be selected.'
    }
    if ($Failure -and $FailoverRunbook -ne $env.fixtureFailureRunbookId -and $ReprotectRunbook -ne $env.fixtureFailureRunbookId) {
        throw 'Failure scenarios must select the explicitly approved intentional-failure runbook, not the success-only no-op.'
    }
}

function New-ROCustomSetting([string]$FailoverRunbook = $env.fixtureRunbookId,
    [string]$ReprotectRunbook = $env.fixtureRunbookId, [switch]$Failure) {
    Assert-ROCustomRunbookSelection $FailoverRunbook $ReprotectRunbook -Failure:$Failure
    $setting = [Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.ResourceCustomProtectionSetting]::new()
    $setting.ProtectionSolutionType = 'CustomRunbook'
    $setting.FailoverActionResourceId = $FailoverRunbook
    $setting.ReprotectActionResourceId = $ReprotectRunbook
    return $setting
}

function Get-ROProtectionUpdates([string]$Key, $Resource, [string]$FailoverRunbook,
    [string]$ReprotectRunbook = $env.fixtureRunbookId) {
    Assert-ROCustomRunbookSelection $FailoverRunbook $ReprotectRunbook
    $scope = Get-ROOperationScope $Key
    $entry = Get-ROScenario $Key
    $all = @(Get-AzResiliencyRecoveryResource @scope)
    if (@($all | Where-Object Id -EQ $Resource.Id).Count -ne 1) { throw 'Selected resource is no longer unique.' }
    foreach ($item in $all) {
        if ($item.Id -ne "$($entry.PlanId)/recoveryResources/$($item.Name)" -or -not $item.UniqueId) {
            throw 'Refusing to update/exclude a resource without exact owned-plan identity.'
        }
        # Mutate only writable fields on the exact native producer models.
        if ($item.Id -eq $Resource.Id) {
            $item.InclusionState = 'Included'
            $item.RecoveryGroupId = $entry.GroupId
            $item.AssociatedIdentityType = 'SystemAssigned'
            $item.SelectedProtectionSolutionType = 'CustomRunbook'
            $item.SelectedProtectionSolutionSetting = New-ROCustomSetting $FailoverRunbook $ReprotectRunbook
        } else {
            $item.InclusionState = 'Excluded'
        }
    }
    return $all
}

function Assert-ROProtectionReadback([string]$Key, $Resource, [string]$FailoverRunbook,
    [string]$ReprotectRunbook = $env.fixtureRunbookId) {
    $scope = Get-ROOperationScope $Key
    $entry = Get-ROScenario $Key
    $read = Get-AzResiliencyRecoveryResource @scope -Name $Resource.Name
    foreach ($property in 'Id', 'Name', 'UniqueId', 'ResourceId', 'ResourceLocation') {
        $read.$property | Should -Be $Resource.$property
    }
    $read.InclusionState | Should -Be 'Included'
    $read.RecoveryGroupId | Should -Be $entry.GroupId
    $read.AssociatedIdentityType | Should -Be 'SystemAssigned'
    $read.SelectedProtectionSolutionType | Should -Be 'CustomRunbook'
    $read.SelectedProtectionSolutionSettingProtectionSolutionType | Should -Be 'CustomRunbook'
    $read.SelectedProtectionSolutionSetting.FailoverActionResourceId | Should -Be $FailoverRunbook
    $read.SelectedProtectionSolutionSetting.ReprotectActionResourceId | Should -Be $ReprotectRunbook
    $all = @(Get-AzResiliencyRecoveryResource @scope)
    @($all | Where-Object InclusionState -EQ 'Included').Count | Should -Be 1
    foreach ($other in @($all | Where-Object Id -NE $Resource.Id)) {
        $other.InclusionState | Should -Be 'Excluded'
    }
    return $read
}

function Set-ROOwnedProtection([string]$Key, $Resource, [string]$FailoverRunbook, [string]$OperationKey = 'ResourceUpdate',
    [string]$ReprotectRunbook = $env.fixtureRunbookId) {
    $scope = Get-ROOperationScope $Key
    $entry = Get-ROScenario $Key
    $updates = @(Get-ROProtectionUpdates $Key $Resource $FailoverRunbook $ReprotectRunbook)
    $failed = @(Update-AzResiliencyRecoveryPlanResource @scope -OperationId $entry.OperationIds.$OperationKey `
        -ResourcesToUpdate $updates -Confirm:$false)
    # The native pipeline is failed items, NOT an envelope.
    @($failed | Where-Object { $null -ne $_ }).Count | Should -Be 0
    return (Assert-ROProtectionReadback $Key $Resource $FailoverRunbook $ReprotectRunbook)
}

function Add-ROOwnedFixtureRoles([string]$Key, $Resource) {
    $entry = Get-ROScenario $Key
    $scope = Get-ROOperationScope $Key
    $plan = Get-AzResiliencyRecoveryPlan -ServiceGroupName $scope.ServiceGroupName -Name $entry.PlanName -ErrorAction Stop
    if ($plan.Id -ne $entry.PlanId -or -not $entry.PrincipalId -or
        $plan.IdentityPrincipalId -ne $entry.PrincipalId -or $plan.IdentityType -ne 'SystemAssigned') {
        throw 'Role principal does not match the owned system identity.'
    }
    if ($TestMode -eq 'playback') { return } # Unrecorded, live-only fixture authorization.
    if ($entry.OwnedRoleAssignments) { throw 'Unresolved owned role assignments; reconcile before setup.' }
    if ($Resource.ResourceId -notmatch '^/subscriptions/([^/]+)/') { throw 'Workload lacks a subscription scope.' }
    $workloadSubscription = $Matches[1]
    $roles = @(
        @{ Scope = $Resource.ResourceId; Subscription = $workloadSubscription
            Role = 'acdd72a7-3385-48ef-bd42-f606fba81ae7'; Assignment = $entry.ReaderRoleAssignmentId },
        @{ Scope = $env.fixtureAutomationAccountId; Subscription = $env.fixtureRunbookSubscriptionId
            Role = '4fe576fe-1146-4730-92eb-48519fa6bf9f'; Assignment = $entry.OperatorRoleAssignmentId },
        @{ Scope = $env.fixtureAutomationAccountId; Subscription = $env.fixtureRunbookSubscriptionId
            Role = 'acdd72a7-3385-48ef-bd42-f606fba81ae7'; Assignment = $entry.AutomationReaderRoleAssignmentId }
    )
    $entry | Add-Member -NotePropertyName OwnedRoleAssignments -NotePropertyValue @() -Force
    foreach ($role in $roles) {
        if (-not $role.Subscription -or -not $role.Scope -or -not $role.Assignment) { throw 'Unseeded role scope or ID.' }
        $path = "$($role.Scope)/providers/Microsoft.Authorization/roleAssignments/$($role.Assignment)?api-version=2022-04-01"
        $definition = "/subscriptions/$($role.Subscription)/providers/Microsoft.Authorization/roleDefinitions/$($role.Role)"
        # Resource configuration may already have provisioned this binding. Read it
        # without taking ownership; a borrowed grant must never be deleted by us.
        $filter = [uri]::EscapeDataString("principalId eq '$($plan.IdentityPrincipalId)'")
        $listed = Invoke-AzRestMethod -Method GET -Path "$($role.Scope)/providers/Microsoft.Authorization/roleAssignments?api-version=2022-04-01&`$filter=$filter" -ErrorAction Stop
        if ($listed.StatusCode -ne 200) { throw 'Could not inspect fixture role prerequisites.' }
        $matching = @(($listed.Content | ConvertFrom-Json).value | Where-Object {
            $_.properties.principalId -eq $plan.IdentityPrincipalId -and
            $_.properties.roleDefinitionId -eq $definition -and
            $_.properties.scope -eq $role.Scope
        })
        if ($matching.Count -gt 0) { continue }
        $existing = Invoke-AzRestMethod -Method GET -Path $path -ErrorAction Stop
        if ($existing.StatusCode -ne 404) {
            throw 'The seeded role path is not absent; never replace an existing assignment.'
        }
        # Persist intent before PUT: a response failure may follow a successful write.
        $assignment = [pscustomobject]@{ Path = $path; Scope = $role.Scope; PrincipalId = $plan.IdentityPrincipalId
            Definition = $definition; AssignmentId = $role.Assignment; Confirmed = $false; Removed = $false }
        $entry.OwnedRoleAssignments = @($entry.OwnedRoleAssignments) + @($assignment)
        Save-ROScenarioEnv
        $payload = @{ properties = @{ roleDefinitionId = $definition; principalId = $plan.IdentityPrincipalId
            principalType = 'ServicePrincipal' } } | ConvertTo-Json -Depth 5
        $response = Invoke-AzRestMethod -Method PUT -Path $path -Payload $payload -ErrorAction Stop
        if ($response.StatusCode -notin 200,201) { throw 'Owned role assignment PUT was not successful.' }
        $native = $response.Content | ConvertFrom-Json
        if ($native.id -ne $path.Split('?')[0] -or $native.properties.principalId -ne $plan.IdentityPrincipalId -or
            $native.properties.roleDefinitionId -ne $definition) { throw 'Owned role assignment response mismatched scope/principal/role.' }
        $assignment.Confirmed = $true
        Save-ROScenarioEnv
    }
    # Live-only propagation wait. Native readiness/qualification still decide whether execution is allowed.
    Start-TestSleep -Seconds 30
}

function Remove-ROOwnedFixtureRoles([string]$Key) {
    if ($TestMode -eq 'playback') { return }
    $entry = Get-ROScenario $Key
    foreach ($assignment in @($entry.OwnedRoleAssignments)) {
        if ($null -eq $assignment) { continue }
        if ($assignment.Removed) { continue }
        $allowed = @(
            "$($entry.StorageMember.ResourceId)/providers/Microsoft.Authorization/roleAssignments/$($entry.ReaderRoleAssignmentId)?api-version=2022-04-01",
            "$($env.fixtureAutomationAccountId)/providers/Microsoft.Authorization/roleAssignments/$($entry.OperatorRoleAssignmentId)?api-version=2022-04-01",
            "$($env.fixtureAutomationAccountId)/providers/Microsoft.Authorization/roleAssignments/$($entry.AutomationReaderRoleAssignmentId)?api-version=2022-04-01"
        )
        if ($assignment.Path -notin $allowed -or $assignment.PrincipalId -ne $entry.PrincipalId) {
            throw 'Refusing role cleanup outside exact seeded owned paths/principal.'
        }
        $roleScope = $assignment.Path.Split('/providers/Microsoft.Authorization/roleAssignments/')[0]
        if ($roleScope -notmatch '^/subscriptions/([^/]+)/') { throw 'Owned role scope lacks a subscription.' }
        $roleSubscription = $Matches[1]
        $roleGuid = 'acdd72a7-3385-48ef-bd42-f606fba81ae7'
        if ($assignment.Path -eq $allowed[1]) { $roleGuid = '4fe576fe-1146-4730-92eb-48519fa6bf9f' }
        $expectedDefinition = "/subscriptions/$roleSubscription/providers/Microsoft.Authorization/roleDefinitions/$roleGuid"
        if ($assignment.Scope -ne $roleScope -or $assignment.Definition -ne $expectedDefinition) {
            throw 'Cached role scope/definition differs from the seeded Reader/Operator binding.'
        }
        if (-not $assignment.Confirmed) {
            $unconfirmed = Invoke-AzRestMethod -Method GET -Path $assignment.Path -ErrorAction Stop
            if ($unconfirmed.StatusCode -eq 404) {
                $assignment.Removed = $true
                Save-ROScenarioEnv
                continue
            }
            throw 'Role PUT ownership was not confirmed by its native response; retain the plan for reconciliation, never delete an ambiguous assignment.'
        }
        $current = Invoke-AzRestMethod -Method GET -Path $assignment.Path -ErrorAction Stop
        if ($current.StatusCode -eq 404) {
            $assignment.Removed = $true
            Save-ROScenarioEnv
            continue
        }
        if ($current.StatusCode -ne 200) { throw 'Cannot verify own role before deletion.' }
        $role = $current.Content | ConvertFrom-Json
        if ($role.id -ne $assignment.Path.Split('?')[0] -or
            $role.properties.principalId -ne $entry.PrincipalId -or
            $role.properties.roleDefinitionId -ne $expectedDefinition -or
            $role.properties.scope -ne $roleScope) {
            throw 'Role binding changed; do not delete the conflicting assignment.'
        }
        $deleted = Invoke-AzRestMethod -Method DELETE -Path $assignment.Path -ErrorAction Stop
        if ($deleted.StatusCode -notin 200,204) { throw 'Owned role deletion unresolved; retain plan ownership.' }
        $assignment.Removed = $true
        Save-ROScenarioEnv
    }
    $entry | Add-Member -NotePropertyName OwnedRoleAssignments -NotePropertyValue @() -Force
    Save-ROScenarioEnv
}

function Remove-ROOperationScenario([string]$Key) {
    if (-not $env.activeScenarioKey) { return }
    if ($env.activeScenarioKey -ne $Key) { throw 'Refusing cleanup of another scenario.' }
    $entry = Get-ROScenario $Key
    $present = @(Get-AzResiliencyRecoveryPlan -ServiceGroupName (Get-ROScenarioGroup $Key) -ErrorAction Stop |
        Where-Object Name -EQ $entry.PlanName)
    if ($present.Count -eq 1) {
        if ($present[0].Id -ne $entry.PlanId) { throw 'Cleanup identity mismatch.' }
        Wait-ROOwnedJobsTerminal $Key
    } elseif ($present.Count -gt 1) { throw 'Cleanup identity is ambiguous.' }
    # No removal of roles/plan until all owned jobs are terminal; any failure keeps max-one gate closed.
    Remove-ROOwnedFixtureRoles $Key
    Remove-ROScenarioPlan -Key $Key
}

function Initialize-ROOperationScenario([string]$Key, [string]$FailoverRunbook = $env.fixtureRunbookId,
    [string]$ReprotectRunbook = $env.fixtureRunbookId,
    [ValidateSet('Zonal','Regional')][string]$PlanType = 'Zonal',
    [switch]$AuthorizeBeforeProtection, [switch]$Failure) {
    Assert-ROCustomRunbookSelection $FailoverRunbook $ReprotectRunbook -Failure:($Failure -or $Key -eq 'Invoke.Retry')
    $plan = New-ROScenarioPlan -Key $Key -Properties @{ PlanType = $PlanType }
    $plan.PlanType | Should -Be $PlanType
    (Get-ROScenario $Key) | Add-Member -NotePropertyName PlanType -NotePropertyValue $plan.PlanType -Force
    $resource = Get-ROOwnedStorage $Key
    if ($AuthorizeBeforeProtection) { Add-ROOwnedFixtureRoles $Key $resource }
    $resource = Set-ROOwnedProtection $Key $resource $FailoverRunbook -ReprotectRunbook $ReprotectRunbook
    if (-not $AuthorizeBeforeProtection) { Add-ROOwnedFixtureRoles $Key $resource }
    return $resource
}

function Get-RORegionalSourceLocation([string]$Key, $Resource) {
    if ((Get-ROScenario $Key).PlanType -ne 'Regional' -or
        [string]::IsNullOrWhiteSpace($Resource.ResourceLocation) -or
        $Resource.ResourceLocation -notmatch '^[a-z][a-z0-9]+$') {
        throw 'Regional failover requires a native resource region, never a fabricated physical zone.'
    }
    return [string]$Resource.ResourceLocation
}

function Invoke-ROFixtureReadiness([string]$Key, [ValidateRange(1,120)][int]$Attempts = 120) {
    $scope = Get-ROOperationScope $Key
    $entry = Get-ROScenario $Key
    $response = Test-AzResiliencyRecoveryPlanReadiness @scope -OperationId $entry.OperationIds.Readiness -Confirm:$false
    $name = Save-ROProducedJob $Key 'Readiness' $response
    return (Wait-ROExactJob $Key $name -Attempts $Attempts)
}

function Assert-ROQualified($Entries, $Resource) {
    $matching = @($Entries | Where-Object { $_.RecoveryResource.Id -eq $Resource.Id })
    $matching.Count | Should -Be 1
    $matching[0].RecoveryResource.UniqueId | Should -Be $Resource.UniqueId
    $matching[0].RecoveryResource.ResourceId | Should -Be $Resource.ResourceId
    $matching[0].OperationQualificationDetailQualificationState | Should -Be 'Qualified'
    @($matching[0].OperationQualificationDetailNotQualifiedReason | Where-Object { $null -ne $_ }).Count | Should -Be 0
}

function Assert-ROFailoverPrerequisites([string]$Key, $Resource) {
    $scope = Get-ROOperationScope $Key
    $entry = Get-ROScenario $Key
    Assert-ROSelectedStorage $Key $Resource
    $null = Invoke-ROFixtureReadiness $Key
    $validation = Test-AzResiliencyRecoveryPlanOperationValidation @scope -OperationId $entry.OperationIds.OperationValidation `
        -OperationName Failover -Confirm:$false
    Assert-RONoActionError $validation
    $qualification = @(Test-AzResiliencyRecoveryPlanFailoverValidation @scope -OperationId $entry.OperationIds.FailoverValidation `
        -FailoverRequestPropertySourceLocation @() `
        -FailoverRequestPropertySelectedResourceId @($Resource.Id) `
        -ExecutionConfigurationUserConsent Allowed -Confirm:$false)
    Assert-ROQualified $qualification $Resource
}

function Invoke-ROFixtureFailover([string]$Key, $Resource, [string]$Expected = 'Completed', [switch]$ReadinessOnly) {
    $scope = Get-ROOperationScope $Key
    $entry = Get-ROScenario $Key
    Assert-ROSelectedStorage $Key $Resource
    if ($ReadinessOnly) {
        $ready = Invoke-ROFixtureReadiness $Key
        $ready.Status | Should -Be 'Completed'
        $plan = Get-AzResiliencyRecoveryPlan -ServiceGroupName $scope.ServiceGroupName -Name $entry.PlanName -ErrorAction Stop
        $plan.Id | Should -Be $entry.PlanId
        $plan.PlanState | Should -Be 'Ready'
        $plan.ProvisioningState | Should -Be 'Succeeded'
    } else {
        Assert-ROFailoverPrerequisites $Key $Resource
    }
    $response = Invoke-AzResiliencyRecoveryPlanFailover @scope -OperationId $entry.OperationIds.Failover `
        -FailoverRequestPropertySourceLocation @() `
        -FailoverRequestPropertySelectedResourceId @($Resource.Id) `
        -ExecutionConfigurationUserConsent Allowed -Confirm:$false
    # Preserve the actual command acknowledgement independently of job GETs.
    $entry | Add-Member -NotePropertyName NativeFailoverResponse -NotePropertyValue $response -Force
    Save-ROScenarioEnv
    $name = Save-ROProducedJob $Key 'Failover' $response
    return (Wait-ROExactJob $Key $name $Expected)
}

function Assert-ROSelectedStorage([string]$Key, $Resource) {
    $entry = Get-ROScenario $Key
    if (-not $Resource.Name -or -not $Resource.UniqueId -or
        $Resource.Id -ne "$($entry.PlanId)/recoveryResources/$($Resource.Name)" -or
        $Resource.ResourceId -notmatch '/providers/Microsoft.Storage/storageAccounts/[^/]+$' -or
        $Resource.InclusionState -ne 'Included' -or $Resource.ProtectionStatus -ne 'Protected' -or
        $Resource.AssociatedIdentityType -ne 'SystemAssigned') {
        throw 'Selected-resource failover requires an exact native included protected owned storage resource.'
    }
    # Public 2026-10-01 requires sourceLocations, with no minItems:
    # selected-only uses explicit [] plus this exact owned recovery-resource ID.
    # This is not omission/null and does NOT claim physical-zone filtering.
}

function Assert-ROFinalizePreState($Before, $Fixture) {
    if ($Before.Id -ne $Fixture.PlanId -or $Before.PlanState -ne 'Warning' -or
        $Before.ProvisioningState -ne 'Succeeded' -or -not $Before.SystemDataLastModifiedAt) {
        throw 'Finalize requires its exact naturally Warning plan; an already Ready or unconfirmed plan is not a transition fixture.'
    }
}

function Assert-ROFinalizeAcknowledgement($Result) {
    $values = @($Result | Where-Object { $null -ne $_ })
    if ($values.Count -gt 1) { throw 'Finalize must return a single public ErrorResponse acknowledgement or void.' }
    foreach ($value in $values) {
        if ($value.GetType().FullName -ne 'Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.ErrorResponse') {
            throw 'Finalize public acknowledgement is ErrorResponse or void, never a substituted RecoveryPlan.'
        }
        foreach ($field in 'Code','Message','Target','Detail','AdditionalInfo') {
            if ($value.$field) { throw "Finalize acknowledgement contains an error field: $field." }
        }
    }
}

function Test-ROFinalizeCompletedState($Before, $After, $Fixture) {
    Assert-ROFinalizePreState $Before $Fixture
    if ($After.Id -ne $Fixture.PlanId -or $After.ProvisioningState -eq 'Failed') {
        throw 'Native Finalize plan is foreign or entered Failed provisioning state.'
    }
    return ($After.PlanState -eq 'Ready' -and $After.ProvisioningState -eq 'Succeeded' -and
        $After.SystemDataLastModifiedAt -and
        ([DateTimeOffset]$After.SystemDataLastModifiedAt) -gt ([DateTimeOffset]$Before.SystemDataLastModifiedAt))
}

function Assert-ROCompletedWorkload([string]$Key, [string]$JobName, $Resource) {
    $scope = Get-ROOperationScope $Key
    $items = @(Get-AzResiliencyRecoveryJobResource @scope -RecoveryJobName $JobName)
    $workload = @($items | Where-Object ResourceId -EQ $Resource.ResourceId)
    @($items | Where-Object { $_.Status -in @('Failed','Warnings','CompletedWithWarnings') }).Count | Should -Be 0
    $workload.Count | Should -Be 1
    $workload[0].Status | Should -Be 'Completed'
    $workload[0].ProtectionSolutionType | Should -Be 'CustomRunbook'
    $workload[0].JobId.TrimEnd('/').Split('/')[-1] | Should -Be $JobName
    return $workload[0]
}
