if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzResiliencyRecoveryJobRetry'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Historical'
  $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
  $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzResiliencyRecoveryJobRetry.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzResiliencyRecoveryJobRetry' {
    It 'Retry' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RetryViaIdentityServiceGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RetryViaIdentityRecoveryPlan' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RetryViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RetriesItsExactFailedReprotectSeedAndRecordsCompletedRetryAttempt' {
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        $key = 'Invoke.Retry'
        $fixture = Get-ROScenario $key
        try {
            # Only the owned plan references the already-published failure fixture.
            $resource = Initialize-ROOperationScenario $key -ReprotectRunbook $env.fixtureFailureRunbookId
            $null = Invoke-ROFixtureReadiness $key
            $scope = Get-ROOperationScope $key
            $qualification = @(Test-AzResiliencyRecoveryPlanReprotectValidation @scope `
                -OperationId $fixture.OperationIds.ReprotectValidation `
                -ReprotectRequestPropertySelectedResourceId @($resource.Id) -Confirm:$false)
            Assert-ROQualified $qualification $resource
            $response = Invoke-AzResiliencyRecoveryPlanReprotect @scope -OperationId $fixture.OperationIds.Reprotect `
                -ReprotectRequestPropertySelectedResourceId @($resource.Id) -Confirm:$false
            $name = Save-ROProducedJob $key 'Reprotect' $response
            $seed = Wait-ROExactJob $key $name 'Failed'
            $seed.Operation | Should -Be 'Reprotect'
            $seedItems = @(Get-AzResiliencyRecoveryJobResource @scope -RecoveryJobName $name)
            $failure = @($seedItems | Where-Object {
                $_.ResourceId -eq $resource.ResourceId -and $_.ErrorDetailErrorCode -eq 'RHRORecoveryResourceReprotectFailed'
            })
            $failure.Count | Should -Be 1
            $failure[0].Status | Should -Be 'Failed'
            $priorMaximum = 0
            $priorAttempts = @($failure[0].RetryDetail | ForEach-Object RetryAttempt)
            if ($priorAttempts.Count -gt 0) { $priorMaximum = ($priorAttempts | Measure-Object -Maximum).Maximum }
            $fixture | Add-Member -NotePropertyName RetrySeedFailure -NotePropertyValue $failure[0] -Force
            Save-ROScenarioEnv
            $repaired = Set-ROOwnedProtection $key $resource $env.fixtureRunbookId 'ResourceCaseVariant'
            $repaired.SelectedProtectionSolutionSetting.ReprotectActionResourceId | Should -Be $env.fixtureRunbookId
            $result = @(Invoke-AzResiliencyRecoveryJobRetry @scope -RecoveryJobName $name `
                -OperationId $fixture.OperationIds.Retry -Confirm:$false)
            $result.Count | Should -Be 1
            Assert-RONoActionError $result
            # ErrorResponse has no promised JobId: track the exact native seed ID.
            $job = Wait-ROExactJob $key $name 'Completed' -AllowInitialFailed
            $job.Id | Should -Be $seed.Id
            $job.Operation | Should -Be 'Reprotect'
            $job.Status | Should -Be 'Completed'
            $workload = Assert-ROCompletedWorkload $key $name $resource
            $workload.Name | Should -Be $failure[0].Name
            $completedRetries = @($workload.RetryDetail | Where-Object {
                $_.RetryAttempt -gt $priorMaximum -and $_.RetryAttempt -gt 0 -and $_.Status -eq 'Completed'
            })
            $completedRetries.Count | Should -BeGreaterThan 0
        } finally {
            Remove-ROOperationScenario $key
        }
    }

}
