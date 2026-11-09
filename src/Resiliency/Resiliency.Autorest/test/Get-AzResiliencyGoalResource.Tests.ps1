if(($null -eq $TestName) -or ($TestName -contains 'Get-AzResiliencyGoalResource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResiliencyGoalResource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzResiliencyGoalResource' {
    BeforeAll {
        $goalParameters = @{ ServiceGroupName = $env.serviceGroupName; GoalAssignmentName = $env.goalAssignmentName }
        $goalIdentity = @{ ServiceGroupName = $env.serviceGroupName; GoalAssignmentName = $env.goalAssignmentName }
        function Assert-GoalResource([object]$Resource) {
            $Resource.Name | Should -Be $env.goalResourceName
            $Resource.ResourceArmId | Should -Be $env.vmId
        }
    }

    It 'List' {
        $resources = @(Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalResource @goalParameters })
        $resources.ResourceArmId | Should -Contain $env.vmId
    }

    It 'GetViaIdentityServiceGroup' {
        $resource = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalResource -ServiceGroupInputObject @{ ServiceGroupName = $env.serviceGroupName } -GoalAssignmentName $env.goalAssignmentName -Name $env.goalResourceName }
        Assert-GoalResource $resource
    }

    It 'Get' {
        $resource = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalResource @goalParameters -Name $env.goalResourceName }
        Assert-GoalResource $resource
    }

    It 'GetViaIdentityGoalAssignment' {
        $resource = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalResource -GoalAssignmentInputObject $goalIdentity -Name $env.goalResourceName }
        Assert-GoalResource $resource
    }

    It 'GetViaIdentity' {
        $identity = $goalIdentity + @{ GoalResourceName = $env.goalResourceName }
        $resource = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalResource -InputObject $identity }
        Assert-GoalResource $resource
    }
}
