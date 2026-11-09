if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzResiliencyRecoveryPlanReprotect'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Historical'
  $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
  $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzResiliencyRecoveryPlanReprotect.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzResiliencyRecoveryPlanReprotect' {
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

    It 'ReturnsNativeReprotectJobIdAndCompletesItsQualifiedOwnedStorage' {
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        $key = 'Invoke.Reprotect'
        $fixture = Get-ROScenario $key
        try {
            $resource = Initialize-ROOperationScenario $key
            $null = Invoke-ROFixtureReadiness $key
            $scope = Get-ROOperationScope $key
            $qualification = @(Test-AzResiliencyRecoveryPlanReprotectValidation @scope `
                -OperationId $fixture.OperationIds.ReprotectValidation `
                -ReprotectRequestPropertySelectedResourceId @($resource.Id) -Confirm:$false)
            Assert-ROQualified $qualification $resource
            $response = Invoke-AzResiliencyRecoveryPlanReprotect @scope -OperationId $fixture.OperationIds.Reprotect `
                -ReprotectRequestPropertySelectedResourceId @($resource.Id) -Confirm:$false
            $name = Save-ROProducedJob $key 'Reprotect' $response
            $job = Wait-ROExactJob $key $name
            $job.Id | Should -Be "$($fixture.PlanId)/recoveryJobs/$name"
            $job.Operation | Should -Be 'Reprotect'
            $job.Status | Should -Be 'Completed'
            $workload = Assert-ROCompletedWorkload $key $name $resource
            $workload.ResourceId | Should -Be $resource.ResourceId
        } finally {
            Remove-ROOperationScenario $key
        }
    }

}
