if (($null -eq $TestName) -or ($TestName -contains 'Resume-AzResiliencyRecoveryJob')) {
    . (Join-Path $PSScriptRoot 'loadEnv.ps1')
    $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Resume'
    $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
    $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
    $TestRecordingFile = Join-Path $PSScriptRoot 'Resume-AzResiliencyRecoveryJob.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Resume-AzResiliencyRecoveryJob' {
    It 'ResumeExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'ResumeViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'ResumeViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'ResumeViaIdentityServiceGroupExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'ResumeViaIdentityServiceGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'ResumeViaIdentityRecoveryPlanExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'ResumeViaIdentityRecoveryPlan' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'Resume' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'ResumeViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'ResumeViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResumesItsExactManuallyPausedFailoverAndCompletesItsSelectedStorage' {
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        $key = 'Resume.Job'
        $fixture = Get-ROScenario $key
        try {
            Assert-ROCustomRunbookSelection $env.fixtureRunbookId $env.fixtureRunbookId
            if (-not $env.fixtureStorageAccountId) { throw 'Resume requires the explicitly approved storage fixture.' }
            $manual = [Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.RecoveryGroupManualAction]::new()
            $manual.Name = $fixture.PreActionName
            $manual.Description = 'Pause before the approved print-only runbook'
            $manual.TimeoutInMinute = 10
            $manual.Type = 'ManualAction'
            $plan = New-ROScenarioPlan $key -Properties @{ PlanType = 'Zonal'; PreAction = @($manual) }
            $plan.PlanType | Should -Be 'Zonal'
            $plan.GroupUniqueId | Should -Be $fixture.GroupId
            @($plan.PreAction).Count | Should -Be 1
            $plan.PreAction[0].Name | Should -Be $fixture.PreActionName
            $plan.PreAction[0].Type | Should -Be 'ManualAction'
            $plan.PreAction[0].TimeoutInMinute | Should -Be 10
            $resource = Get-ROOwnedStorage $key -ApprovedResourceId $env.fixtureStorageAccountId
            Add-ROOwnedFixtureRoles $key $resource
            $assignments = @($fixture.OwnedRoleAssignments | ForEach-Object { $_.psobject.Copy() })
            $resource = Set-ROOwnedProtection $key $resource $env.fixtureRunbookId
            Assert-ROSelectedStorage $key $resource
            $ready = Invoke-ROFixtureReadiness $key
            $ready.Status | Should -Be 'Completed'
            $scope = Get-ROOperationScope $key
            $seed = Invoke-AzResiliencyRecoveryPlanFailover @scope -OperationId $fixture.OperationIds.Failover `
                -FailoverRequestPropertySourceLocation @() `
                -FailoverRequestPropertySelectedResourceId @($resource.Id) `
                -ExecutionConfigurationUserConsent Unspecified -Confirm:$false
            $name = Save-ROProducedJob $key 'Failover' $seed
            $paused = Wait-ROExactJob $key $name -Expected Paused
            $paused.Operation | Should -Be 'Failover'
            $paused.Status | Should -Be 'Paused'
            $paused.Id | Should -Be "$($fixture.PlanId)/recoveryJobs/$name"
            $fixture | Add-Member -NotePropertyName ResumeObservation -NotePropertyValue ([pscustomobject]@{
                PausedJob = $paused
                SelectedResourceId = $resource.ResourceId
                PrerequisiteAssignments = $assignments
                Stage = 'NativeResumeStarted'
                StartedAtUtc = [DateTime]::UtcNow.ToString('o')
            }) -Force
            Save-ROScenarioEnv
            $response = @(Resume-AzResiliencyRecoveryJob @scope -Name $name `
                -OperationId $fixture.OperationIds.Resume -Description $fixture.ResumeReason -Confirm:$false)
            $acknowledgments = @($response | Where-Object { $null -ne $_ })
            if ($acknowledgments.Count -gt 1) { throw 'Native Resume returned multiple acknowledgments.' }
            foreach ($ack in $acknowledgments) {
                if ($ack -isnot [Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IErrorResponse]) {
                    throw 'Native Resume must return ErrorResponse or void, not job readback.'
                }
                foreach ($field in 'Code', 'Message', 'Target', 'Detail', 'AdditionalInfo') {
                    if ($ack.$field) { throw "Native Resume acknowledgment contains an error: $field." }
                }
            }
            $fixture.ResumeObservation.Stage = 'NativeResumeReturned'
            $fixture.ResumeObservation | Add-Member -NotePropertyName NativeResponse -NotePropertyValue $response -Force
            Save-ROScenarioEnv
            # Job GET proves completion independently, never replacing Resume's acknowledgment.
            $completed = Wait-ROExactJob $key $name
            $completed.Id | Should -Be $paused.Id
            $completed.Operation | Should -Be 'Failover'
            $completed.Status | Should -Be 'Completed'
            $workload = Assert-ROCompletedWorkload $key $name $resource
            $fixture.ResumeObservation.Stage = 'Completed'
            $fixture.ResumeObservation | Add-Member -NotePropertyName CompletedJob -NotePropertyValue $completed -Force
            $fixture.ResumeObservation | Add-Member -NotePropertyName CompletedWorkload -NotePropertyValue $workload -Force
            Save-ROScenarioEnv
        } finally {
            Remove-ROOperationScenario $key
        }
    }
}
