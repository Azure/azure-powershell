if(($null -eq $TestName) -or ($TestName -contains 'Test-AzResiliencyRecoveryPlanReadiness'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Historical'
  $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
  $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzResiliencyRecoveryPlanReadiness.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzResiliencyRecoveryPlanReadiness' {
    It 'Test' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'TestViaIdentityServiceGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'TestViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReturnsNativeReadinessJobIdAndCompletesThatExactJob' {
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        $key = 'Test.Readiness'
        $fixture = Get-ROScenario $key
        try {
            $resource = Initialize-ROOperationScenario $key
            $scope = Get-ROOperationScope $key
            $response = Test-AzResiliencyRecoveryPlanReadiness @scope -OperationId $fixture.OperationIds.Readiness -Confirm:$false
            $response.JobId | Should -Not -BeNullOrEmpty
            $name = Save-ROProducedJob $key 'Readiness' $response
            $job = Wait-ROExactJob $key $name
            $job.Status | Should -Be 'Completed'
            $job.Name | Should -Be $name
            $job.Operation | Should -Be 'CheckRecoveryPlanReadiness'
            $read = Get-AzResiliencyRecoveryResource @scope -Name $resource.Name
            $read.UniqueId | Should -Be $resource.UniqueId
            $read.InclusionState | Should -Be 'Included'
            $read.SelectedProtectionSolutionType | Should -Be 'CustomRunbook'
        } finally {
            Remove-ROOperationScenario $key
        }
    }
}
