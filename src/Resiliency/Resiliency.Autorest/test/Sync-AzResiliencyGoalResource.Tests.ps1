if(($null -eq $TestName) -or ($TestName -contains 'Sync-AzResiliencyGoalResource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Sync-AzResiliencyGoalResource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Sync-AzResiliencyGoalResource' {
    BeforeAll {
        $goalParameters = @{ ServiceGroupName = $env.serviceGroupName; GoalAssignmentName = $env.goalAssignmentName }
        $goalIdentity = @{ ServiceGroupName = $env.serviceGroupName; GoalAssignmentName = $env.goalAssignmentName }
        # Only one refresh can run per goal assignment, so a conflicting refresh is retried.
        $refreshInProgress = 'InvalidResourceOperation|Conflict|\(409\)'
        # The refresh has completed once the cmdlet returns; the goal resources must then be listable.
        function Assert-GoalResourcesListed {
            { Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalResource @goalParameters } } | Should -Not -Throw
        }
    }

    It 'Sync' {
        { Invoke-ResiliencyWithRetry -AlsoRetryOn $refreshInProgress { Sync-AzResiliencyGoalResource @goalParameters } } | Should -Not -Throw
        Assert-GoalResourcesListed
    }

    It 'SyncViaIdentityServiceGroup' {
        { Invoke-ResiliencyWithRetry -AlsoRetryOn $refreshInProgress { Sync-AzResiliencyGoalResource -ServiceGroupInputObject @{ ServiceGroupName = $env.serviceGroupName } -GoalAssignmentName $env.goalAssignmentName } } | Should -Not -Throw
        Assert-GoalResourcesListed
    }

    It 'SyncViaIdentity' {
        { Invoke-ResiliencyWithRetry -AlsoRetryOn $refreshInProgress { Sync-AzResiliencyGoalResource -InputObject $goalIdentity } } | Should -Not -Throw
        Assert-GoalResourcesListed
    }
}
