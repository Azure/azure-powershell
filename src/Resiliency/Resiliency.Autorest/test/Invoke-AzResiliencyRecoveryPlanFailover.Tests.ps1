if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzResiliencyRecoveryPlanFailover'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Failover'
  $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
  $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzResiliencyRecoveryPlanFailover.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzResiliencyRecoveryPlanFailover' {
    It 'InvokeExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'InvokeViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'InvokeViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'InvokeViaIdentityServiceGroupExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'InvokeViaIdentityServiceGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Invoke' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'InvokeViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'InvokeViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReturnsNativeFailoverJobIdAndCompletesItsExactSelectedStorage' {
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        $key = 'Invoke.Failover'
        $fixture = Get-ROScenario $key
        try {
            Assert-ROCustomRunbookSelection $env.fixtureRunbookId $env.fixtureRunbookId
            if (-not $env.fixtureStorageAccountId) { throw 'Failover-only requires the explicitly approved storage fixture, not a retained recovery-resource ID.' }
            $plan = New-ROScenarioPlan $key -Properties @{PlanType='Zonal'}
            $plan.PlanType | Should -Be 'Zonal'
            $resource = Get-ROOwnedStorage $key -ApprovedResourceId $env.fixtureStorageAccountId
            # Let native service CheckOrApply establish required permissions.
            # Never adopt service-created or inherited bindings as test-owned.
            $resource = Set-ROOwnedProtection $key $resource $env.fixtureRunbookId
            $job = Invoke-ROFixtureFailover $key $resource -ReadinessOnly
            $fixture.NativeFailoverResponse.JobId | Should -Not -BeNullOrEmpty
            $fixture.NativeFailoverResponse.JobId.TrimEnd('/').Split('/')[-1] | Should -Be $job.Name
            $job.Id | Should -Be "$($fixture.PlanId)/recoveryJobs/$($job.Name)"
            $job.Operation | Should -Be 'Failover'
            $job.Status | Should -Be 'Completed'
            $fixture.ProducedJobs.Failover.TrimEnd('/').Split('/')[-1] | Should -Be $job.Name
            $null = Assert-ROCompletedWorkload $key $job.Name $resource
        } finally {
            Remove-ROOperationScenario $key
        }
    }
}
