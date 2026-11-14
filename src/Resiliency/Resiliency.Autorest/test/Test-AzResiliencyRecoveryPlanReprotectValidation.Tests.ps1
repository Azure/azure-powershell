if(($null -eq $TestName) -or ($TestName -contains 'Test-AzResiliencyRecoveryPlanReprotectValidation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Historical'
  $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
  $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzResiliencyRecoveryPlanReprotectValidation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzResiliencyRecoveryPlanReprotectValidation' {
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

    It 'ReturnsDirectReprotectEligibilityEntriesForItsReadinessPreparedStorage' {
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        $key = 'Test.ReprotectValidation'
        $fixture = Get-ROScenario $key
        try {
            $resource = Initialize-ROOperationScenario $key
            $null = Invoke-ROFixtureReadiness $key
            $scope = Get-ROOperationScope $key
            $entries = @(Test-AzResiliencyRecoveryPlanReprotectValidation @scope -OperationId $fixture.OperationIds.ReprotectValidation `
                -ReprotectRequestPropertySelectedResourceId @($resource.Id) -Confirm:$false)
            # The live response proved this included, readiness-prepared no-op
            # fixture Qualified. Do not accept an unrelated ineligible result.
            Assert-ROQualified $entries $resource
            foreach ($other in @($entries | Where-Object { $_.RecoveryResource.Id -ne $resource.Id })) {
                $other.RecoveryResource.InclusionState | Should -Be 'Excluded'
                $other.OperationQualificationDetailQualificationState | Should -Be 'NotQualified'
                $other.OperationQualificationDetailNotQualifiedReason | Should -Contain 'ResourceNotIncludedInPlan'
            }
            $read = Get-AzResiliencyRecoveryResource @scope -Name $resource.Name
            $read.UniqueId | Should -Be $resource.UniqueId
            $read.SelectedProtectionSolutionSetting.ReprotectActionResourceId | Should -Be $env.fixtureRunbookId
        } finally {
            Remove-ROOperationScenario $key
        }
    }
}
