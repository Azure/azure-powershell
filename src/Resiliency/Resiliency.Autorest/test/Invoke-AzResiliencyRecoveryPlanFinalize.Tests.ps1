if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzResiliencyRecoveryPlanFinalize')) {
    . (Join-Path $PSScriptRoot 'loadEnv.ps1')
    $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Finalize'
    $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
    $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
    $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzResiliencyRecoveryPlanFinalize.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzResiliencyRecoveryPlanFinalize' {
    It 'Invoke' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'InvokeViaIdentityServiceGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'InvokeViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RevalidatesItsExactReadyPlanWithNativeAcknowledgmentAndPreservedIdentity' {
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        $key = 'Invoke.Finalize'
        $fixture = Get-ROScenario $key
        try {
            Assert-ROCustomRunbookSelection $env.fixtureRunbookId $env.fixtureRunbookId
            if (-not $env.fixtureStorageAccountId) { throw 'Finalize requires the explicitly approved storage fixture.' }
            $plan = New-ROScenarioPlan $key -Properties @{ PlanType = 'Zonal' }
            $plan.PlanType | Should -Be 'Zonal'
            $resource = Get-ROOwnedStorage $key -ApprovedResourceId $env.fixtureStorageAccountId
            Add-ROOwnedFixtureRoles $key $resource
            $assignments = @($fixture.OwnedRoleAssignments | ForEach-Object { $_.psobject.Copy() })
            $resource = Set-ROOwnedProtection $key $resource $env.fixtureRunbookId
            Assert-ROSelectedStorage $key $resource
            $ready = Invoke-ROFixtureReadiness $key
            $ready.Status | Should -Be 'Completed'
            $scope = Get-ROOperationScope $key
            $before = Get-AzResiliencyRecoveryPlan -ServiceGroupName $scope.ServiceGroupName -Name $fixture.PlanName -ErrorAction Stop
            $before.Id | Should -Be $fixture.PlanId
            $before.PlanState | Should -Be 'Ready'
            $before.ProvisioningState | Should -Be 'Succeeded'
            $before.PlanType | Should -Be 'Zonal'
            $before.GroupUniqueId | Should -Be $fixture.GroupId
            $before.IdentityType | Should -Be 'SystemAssigned'
            $before.IdentityPrincipalId | Should -Be $fixture.PrincipalId
            $fixture | Add-Member -NotePropertyName FinalizeObservation -NotePropertyValue ([pscustomobject]@{
                BeforePlan = $before
                SelectedResourceId = $resource.ResourceId
                PrerequisiteAssignments = $assignments
                Stage = 'NativeFinalizeStarted'
                StartedAtUtc = [DateTime]::UtcNow.ToString('o')
                Coverage = 'Ready-state revalidation, not Warning-to-Ready transition.'
            }) -Force
            $fixture | Add-Member -NotePropertyName FinalizeOutstanding -NotePropertyValue $true -Force
            Save-ROScenarioEnv
            $response = @(Invoke-AzResiliencyRecoveryPlanFinalize @scope -OperationId $fixture.OperationIds.Finalize -Confirm:$false)
            Assert-ROFinalizeAcknowledgement $response
            $fixture.FinalizeObservation.Stage = 'NativeFinalizeReturned'
            $fixture.FinalizeObservation | Add-Member -NotePropertyName NativeResponse -NotePropertyValue $response -Force
            Save-ROScenarioEnv
            # Native GET verifies the outcome, not the acknowledgment's output contract.
            $after = $null
            for ($attempt = 0; $attempt -lt 60; $attempt++) {
                $after = Get-AzResiliencyRecoveryPlan -ServiceGroupName $scope.ServiceGroupName -Name $fixture.PlanName -ErrorAction Stop
                $after.Id | Should -Be $before.Id
                if ($after.ProvisioningState -eq 'Failed') { throw 'Native Finalize left the owned plan in Failed provisioning state.' }
                if ($after.PlanState -eq 'Ready' -and $after.ProvisioningState -eq 'Succeeded') { break }
                if ($attempt -lt 59) { Start-TestSleep -Seconds 5 }
            }
            $after.PlanState | Should -Be 'Ready'
            $after.ProvisioningState | Should -Be 'Succeeded'
            $after.PlanType | Should -Be $before.PlanType
            $after.GroupUniqueId | Should -Be $before.GroupUniqueId
            $after.IdentityType | Should -Be $before.IdentityType
            $after.IdentityPrincipalId | Should -Be $before.IdentityPrincipalId
            $fixture.FinalizeObservation | Add-Member -NotePropertyName AfterPlan -NotePropertyValue $after -Force
            $fixture.FinalizeObservation.Stage = 'Completed'
            $fixture.FinalizeOutstanding = $false
            Save-ROScenarioEnv
        } finally {
            if ($fixture.FinalizeOutstanding) {
                Write-Warning 'Native Finalize is unresolved; retain the owned plan and grants for reconciliation.'
            } else {
                Remove-ROOperationScenario $key
            }
        }
    }
}
