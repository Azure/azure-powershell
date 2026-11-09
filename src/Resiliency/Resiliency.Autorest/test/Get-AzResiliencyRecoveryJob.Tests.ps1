if(($null -eq $TestName) -or ($TestName -contains 'Get-AzResiliencyRecoveryJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Historical'
  $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
  $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResiliencyRecoveryJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzResiliencyRecoveryJob' {
    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityServiceGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityRecoveryPlan' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListsAndGetsItsExactNativeProducedJobWithMatchingStatusAndTasks' {
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        $key = 'Get.Job'
        $fixture = Get-ROScenario $key
        try {
            $resource = Initialize-ROOperationScenario $key
            # A native readiness job is sufficient to exercise job inventory.
            # Do not couple these getters to a separate failover qualification LRO.
            $produced = Invoke-ROFixtureReadiness $key
            $scope = Get-ROOperationScope $key
            $jobs = @(Get-AzResiliencyRecoveryJob @scope)
            @($jobs | Select-Object -ExpandProperty Id -Unique).Count | Should -Be $jobs.Count
            foreach ($item in $jobs) {
                $item.Id | Should -Be "$($fixture.PlanId)/recoveryJobs/$($item.Name)"
                $item.Status | Should -Not -BeNullOrEmpty
                $item.Operation | Should -Not -BeNullOrEmpty
            }
            $listed = @($jobs | Where-Object Name -EQ $produced.Name)
            $listed.Count | Should -Be 1
            $read = Get-AzResiliencyRecoveryJob @scope -Name $produced.Name
            $read.Id | Should -Be $produced.Id
            $read.Status | Should -Be 'Completed'
            $read.Operation | Should -Be 'CheckRecoveryPlanReadiness'
            $read.JobType | Should -Be 'RecoveryPlan'
            $tasks = @($read.JobExtendedInfoTasksList)
            $tasks.Count | Should -Be 4
            foreach ($taskName in 'ProtectionModificationTask', 'ApplicationModificationTask', 'PermissionValidationTask') {
                $task = @($tasks | Where-Object TaskName -EQ $taskName)
                $task.Count | Should -Be 1
                $task[0].Status | Should -Be 'Completed'
                $task[0].TaskId | Should -Not -BeNullOrEmpty
            }
            $sku = @($tasks | Where-Object TaskName -EQ 'ResourceSKUAvailabilityTask')
            $sku.Count | Should -Be 1
            $sku[0].Status | Should -Be 'NotApplicable'
            foreach ($property in 'Id', 'Name', 'Status', 'Operation', 'JobType', 'StartTime', 'EndTime', 'ErrorDetailErrorCode') {
                $read.$property | Should -Be $listed[0].$property
            }
            ($read.JobExtendedInfoTasksList | ConvertTo-Json -Depth 30 -Compress) |
                Should -Be ($listed[0].JobExtendedInfoTasksList | ConvertTo-Json -Depth 30 -Compress)
            $null = Assert-ROProtectionReadback $key $resource $env.fixtureRunbookId
        } finally {
            Remove-ROOperationScenario $key
        }
    }
}
