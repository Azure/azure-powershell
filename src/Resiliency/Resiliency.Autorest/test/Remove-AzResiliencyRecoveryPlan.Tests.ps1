if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzResiliencyRecoveryPlan')) {
    . (Join-Path $PSScriptRoot 'loadEnv.ps1')
    $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Remove'
    $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
    $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzResiliencyRecoveryPlan.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzResiliencyRecoveryPlan' {
    It 'Delete' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'DeleteViaIdentityServiceGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeletesItsExactOwnedPlanWithNativePassThruAndVerifiedAbsence' {
        . (Join-Path $PSScriptRoot 'ROScenarioHelpers.ps1')
        $key = 'New.SharedCrud'
        $fixture = Get-ROScenario $key
        try {
            $plan = New-ROScenarioPlan $key -Properties @{ PlanType = 'Zonal' }
            $scope = @{ ServiceGroupName = Get-ROScenarioGroup $key; Name = $fixture.PlanName; ErrorAction = 'Stop' }
            $before = Get-AzResiliencyRecoveryPlan @scope
            $before.Id | Should -Be $fixture.PlanId
            $before.Name | Should -Be $plan.Name
            $before.IdentityPrincipalId | Should -Be $plan.IdentityPrincipalId
            $before.ProvisioningState | Should -Be 'Succeeded'
            $fixture | Add-Member -NotePropertyName RemoveObservation -NotePropertyValue ([pscustomobject]@{
                BeforePlan = $before
                PrerequisiteAssignments = @()
                Stage = 'NativeRemoveStarted'
                StartedAtUtc = [DateTime]::UtcNow.ToString('o')
            }) -Force
            $fixture | Add-Member -NotePropertyName RemoveOutstanding -NotePropertyValue $true -Force
            Save-ROScenarioEnv
            $response = @(Remove-AzResiliencyRecoveryPlan @scope -PassThru -Confirm:$false)
            $fixture.RemoveObservation | Add-Member -NotePropertyName NativeResponse -NotePropertyValue $response -Force
            $fixture.RemoveObservation.Stage = 'NativeRemoveReturned'
            Save-ROScenarioEnv
            $response.Count | Should -Be 1
            ($response[0] -is [bool]) | Should -Be $true
            $response[0] | Should -Be $true
            $absent = $false
            for ($attempt = 0; $attempt -lt 48; $attempt++) {
                $remaining = @(Get-AzResiliencyRecoveryPlan -ServiceGroupName $scope.ServiceGroupName -ErrorAction Stop)
                if (@($remaining | Where-Object Name -EQ $fixture.PlanName).Count -eq 0) {
                    $absent = $true
                    break
                }
                if ($attempt -lt 47) { Start-TestSleep -Seconds 5 }
            }
            $absent | Should -Be $true
            $fixture.RemoveObservation.Stage = 'Completed'
            $fixture.RemoveObservation | Add-Member -NotePropertyName NativeListConfirmedAbsent -NotePropertyValue $absent -Force
            $fixture.RemoveOutstanding = $false
            Save-ROScenarioEnv
        } finally {
            if ($fixture.RemoveOutstanding) {
                Write-Warning 'Native Remove is unresolved; retain its ownership ledger for reconciliation.'
            } else {
                # This only releases ownership after native List proves the plan absent.
                Remove-ROScenarioPlan $key
            }
        }
    }
}
