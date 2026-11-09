if(($null -eq $TestName) -or ($TestName -contains 'Test-AzResiliencyRecoveryPlanOperationValidation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Historical'
  $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
  $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzResiliencyRecoveryPlanOperationValidation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzResiliencyRecoveryPlanOperationValidation' {
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

    It 'ValidatesFailoverOnItsReadinessPreparedOwnedPlanWithoutAssumingJobId' {
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        $key = 'Test.OperationValidation'
        $fixture = Get-ROScenario $key
        try {
            $resource = Initialize-ROOperationScenario $key
            $null = Invoke-ROFixtureReadiness $key
            $scope = Get-ROOperationScope $key
            $response = @(Test-AzResiliencyRecoveryPlanOperationValidation @scope -OperationId $fixture.OperationIds.OperationValidation `
                -OperationName Failover -Confirm:$false)
            $response.Count | Should -Be 1
            Assert-RONoActionError $response
            # This acknowledgement API emits one ErrorResponse (which may be null),
            # not JobId. Capturing the command pipeline directly distinguishes a
            # native null item from a call that emitted no result at all.
            $response[0].Code | Should -BeNullOrEmpty
            $response[0].Message | Should -BeNullOrEmpty
            $read = Get-AzResiliencyRecoveryPlan -ServiceGroupName $env.recoveryServiceGroupName -Name $fixture.PlanName -ErrorAction Stop
            $read.IdentityPrincipalId | Should -Be $fixture.PrincipalId
            $read.GroupUniqueId | Should -Be $fixture.GroupId
            $read.PlanState | Should -Be 'Ready'
        } finally {
            Remove-ROOperationScenario $key
        }
    }
}
