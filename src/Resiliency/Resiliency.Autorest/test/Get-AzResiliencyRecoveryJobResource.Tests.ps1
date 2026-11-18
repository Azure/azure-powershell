if(($null -eq $TestName) -or ($TestName -contains 'Get-AzResiliencyRecoveryJobResource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Historical'
  $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
  $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResiliencyRecoveryJobResource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzResiliencyRecoveryJobResource' {
    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityServiceGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityRecoveryPlan' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityRecoveryJob' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListsAndGetsNativeWorkloadResourceForItsExactProducedJob' {
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        $key = 'Get.JobResource'
        $fixture = Get-ROScenario $key
        try {
            $resource = Initialize-ROOperationScenario $key
            $job = Invoke-ROFixtureReadiness $key
            $scope = Get-ROOperationScope $key
            $items = @(Get-AzResiliencyRecoveryJobResource @scope -RecoveryJobName $job.Name)
            @($items | Select-Object -ExpandProperty Id -Unique).Count | Should -Be $items.Count
            foreach ($item in $items) {
                $item.Name | Should -Not -BeNullOrEmpty
                $item.Id | Should -Be "$($fixture.PlanId)/recoveryJobs/$($job.Name)/recoveryJobResources/$($item.Name)"
                $item.JobId.TrimEnd('/').Split('/')[-1] | Should -Be $job.Name
                $item.Status | Should -Not -BeNullOrEmpty
            }
            $listed = @($items | Where-Object ResourceId -EQ $resource.ResourceId)
            $listed.Count | Should -Be 1
            $read = Get-AzResiliencyRecoveryJobResource @scope -RecoveryJobName $job.Name -Name $listed[0].Name
            $read.ResourceId | Should -Be $resource.ResourceId
            $read.Status | Should -Be 'Completed'
            $read.ProtectionSolutionType | Should -Be 'CustomRunbook'
            foreach ($property in 'Id', 'Name', 'JobId', 'ResourceId', 'Status', 'Operation', 'ProtectionSolutionType',
                'TaskId', 'TaskName', 'JobResourceType', 'RecoveryGroupActionSettingActionName',
                'RecoveryGroupActionSettingActionSequence', 'ErrorDetailErrorCode') {
                $read.$property | Should -Be $listed[0].$property
            }
        } finally {
            Remove-ROOperationScenario $key
        }
    }
}
