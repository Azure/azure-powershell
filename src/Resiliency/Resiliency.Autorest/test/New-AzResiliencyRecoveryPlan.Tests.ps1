if (($null -eq $TestName) -or ($TestName -contains 'New-AzResiliencyRecoveryPlan')) {
    . (Join-Path $PSScriptRoot 'loadEnv.ps1')
    $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Historical'
    $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
    $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzResiliencyRecoveryPlan.Recording.json'
    . (Join-Path $PSScriptRoot '..\generated\runtime\HttpPipelineMocking.ps1')
}

Describe 'New-AzResiliencyRecoveryPlan' {
    It 'CreatesReadsUpdatesAndDeletesAnOwnedPlanInSharedSetup' {
        $fixtureEnv = $env
        if ($TestMode -eq 'playback' -and $env.priorPassingSetup) { $fixtureEnv = $env.priorPassingSetup }
        $fixtureEnv.reuseSharedSetup | Should -Be $true
        $scope = @{
            ServiceGroupName = $fixtureEnv.recoveryServiceGroupName
            Name = $fixtureEnv.recoveryPlanName
            ErrorAction = 'Stop'
        }
        $created = $false
        # Acquire before entering teardown: a rejected acquisition must never read
        # or clear another scenario's ownership. This adds no native HTTP requests.
        Start-ROStandalonePlanOwnership $fixtureEnv
        $ownedId = $env.standalonePlanOwnership.PlanId
        try {
            $plan = New-AzResiliencyRecoveryPlan @scope -PlanType Zonal `
                -PlanDescription 'Recorded PowerShell recovery plan' -EnableSystemAssignedIdentity `
                -GroupUniqueId $fixtureEnv.recoveryGroupId -OrderId 0 -Description 'Default recovery group'
            $created = $true
            $plan.Name | Should -Be $fixtureEnv.recoveryPlanName
            $plan.Id | Should -Be $ownedId
            $plan.PlanType | Should -Be 'Zonal'
            $plan.PlanDescription | Should -Be 'Recorded PowerShell recovery plan'
            $plan.IdentityType | Should -Be 'SystemAssigned'
            $plan.IdentityPrincipalId | Should -Not -BeNullOrEmpty
            $plan.GroupUniqueId | Should -Be $fixtureEnv.recoveryGroupId
            $principal = $plan.IdentityPrincipalId

            $read = Get-AzResiliencyRecoveryPlan @scope
            $read.Name | Should -Be $fixtureEnv.recoveryPlanName
            $read.PlanType | Should -Be 'Zonal'
            $read.ProvisioningState | Should -Be 'Succeeded'
            $read.IdentityPrincipalId | Should -Be $principal
            $plans = @(Get-AzResiliencyRecoveryPlan -ServiceGroupName $fixtureEnv.recoveryServiceGroupName -ErrorAction Stop)
            $owned = @($plans | Where-Object Name -EQ $fixtureEnv.recoveryPlanName)
            $owned.Count | Should -Be 1
            $owned[0].PlanType | Should -Be 'Zonal'
            $owned[0].GroupUniqueId | Should -Be $fixtureEnv.recoveryGroupId

            $updated = Update-AzResiliencyRecoveryPlan @scope -PlanDescription 'Updated recorded PowerShell recovery plan'
            $updated.PlanDescription | Should -Be 'Updated recorded PowerShell recovery plan'
            $updated.PlanType | Should -Be 'Zonal'
            $updated.IdentityPrincipalId | Should -Be $principal
            $updated.GroupUniqueId | Should -Be $fixtureEnv.recoveryGroupId
            $read = Get-AzResiliencyRecoveryPlan @scope
            $read.PlanDescription | Should -Be 'Updated recorded PowerShell recovery plan'
            $read.PlanType | Should -Be 'Zonal'
            $read.IdentityPrincipalId | Should -Be $principal
            $read.GroupUniqueId | Should -Be $fixtureEnv.recoveryGroupId
        } finally {
            if (-not $created) {
                $observed = @(Get-AzResiliencyRecoveryPlan -ServiceGroupName $fixtureEnv.recoveryServiceGroupName -ErrorAction Stop |
                    Where-Object Name -EQ $fixtureEnv.recoveryPlanName)
                if ($observed.Count -eq 0) {
                    Complete-ROStandalonePlanOwnership $fixtureEnv
                }
            }
            if ($created) {
                if ($owned.Count -ne 1 -or $owned[0].Id -ne $ownedId) {
                    throw 'Standalone CRUD did not establish exact native ownership; retain the plan.'
                }
                Remove-AzResiliencyRecoveryPlan @scope -Confirm:$false
                $remaining = @(Get-AzResiliencyRecoveryPlan -ServiceGroupName $fixtureEnv.recoveryServiceGroupName -ErrorAction Stop)
                @($remaining | Where-Object Name -EQ $fixtureEnv.recoveryPlanName).Count | Should -Be 0
                Complete-ROStandalonePlanOwnership $fixtureEnv
            }
        }
    }
}
