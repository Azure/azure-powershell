if (($null -eq $TestName) -or ($TestName -contains 'Test-AzResiliencyRecoveryPlanFailoverValidation')) {
    . (Join-Path $PSScriptRoot 'loadEnv.ps1')
    $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\FailoverValidation'
    $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
    $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
    $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzResiliencyRecoveryPlanFailoverValidation.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzResiliencyRecoveryPlanFailoverValidation' {
    It 'TestExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'TestViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'TestViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'TestViaIdentityServiceGroupExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'TestViaIdentityServiceGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'Test' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'TestViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'TestViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReturnsNativeFailoverQualificationForItsExactSelectedProtectedStorage' {
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        $key = 'Test.FailoverValidation'
        $fixture = Get-ROScenario $key
        try {
            Assert-ROCustomRunbookSelection $env.fixtureRunbookId $env.fixtureRunbookId
            if (-not $env.fixtureStorageAccountId) { throw 'Qualification requires the explicitly approved storage fixture.' }
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
            $fixture | Add-Member -NotePropertyName FailoverQualificationObservation -NotePropertyValue ([pscustomobject]@{
                SelectedResource = $resource
                PrerequisiteAssignments = $assignments
                Stage = 'NativeQualificationStarted'
                StartedAtUtc = [DateTime]::UtcNow.ToString('o')
                Coverage = 'Qualification for the explicitly selected protected resource, not every discovered resource.'
            }) -Force
            $fixture | Add-Member -NotePropertyName QualificationOutstanding -NotePropertyValue $true -Force
            Save-ROScenarioEnv
            $entries = @(Test-AzResiliencyRecoveryPlanFailoverValidation @scope `
                -OperationId $fixture.OperationIds.FailoverValidation `
                -FailoverRequestPropertySourceLocation @() `
                -FailoverRequestPropertySelectedResourceId @($resource.Id) `
                -ExecutionConfigurationUserConsent Allowed -Confirm:$false)
            $fixture.FailoverQualificationObservation.Stage = 'NativeQualificationReturned'
            $fixture.QualificationOutstanding = $false
            $fixture.FailoverQualificationObservation | Add-Member -NotePropertyName NativeEntries -NotePropertyValue $entries -Force
            Save-ROScenarioEnv
            # Assert directly on the cmdlet's output, never decoded diagnostic responses.
            Assert-ROQualified $entries $resource
            $selected = @($entries | Where-Object { $_.RecoveryResource.Id -eq $resource.Id })
            $selected[0].RecoveryResource.InclusionState | Should -Be 'Included'
            $selected[0].RecoveryResource.ProtectionStatus | Should -Be 'Protected'
            $selected[0].RecoveryResource.AssociatedIdentityType | Should -Be 'SystemAssigned'
            $fixture.FailoverQualificationObservation.Stage = 'Completed'
            Save-ROScenarioEnv
        } finally {
            if ($fixture.QualificationOutstanding) {
                Write-Warning 'Native qualification is unresolved; retain the owned fixture for reconciliation.'
            } else {
                Remove-ROOperationScenario $key
            }
        }
    }
}
