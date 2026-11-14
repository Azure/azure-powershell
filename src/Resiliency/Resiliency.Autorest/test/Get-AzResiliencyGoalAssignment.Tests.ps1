if(($null -eq $TestName) -or ($TestName -contains 'Get-AzResiliencyGoalAssignment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResiliencyGoalAssignment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzResiliencyGoalAssignment' {
    BeforeAll {
        $serviceGroupIdentity = @{ ServiceGroupName = $env.serviceGroupName }
        function Assert-GoalAssignment([object]$Goal) {
            $Goal.Name | Should -Be $env.goalAssignmentName
            $Goal.RequireZonalResiliency | Should -BeTrue
            $Goal.ProvisioningState | Should -Be 'Succeeded'
        }
    }

    It 'List' {
        $goals = @(Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignment -ServiceGroupName $env.serviceGroupName })
        $goals.Name | Should -Contain $env.goalAssignmentName
    }

    It 'GetViaIdentityServiceGroup' {
        $goal = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignment -ServiceGroupInputObject $serviceGroupIdentity -Name $env.goalAssignmentName }
        Assert-GoalAssignment $goal
    }

    It 'Get' {
        $goal = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignment -ServiceGroupName $env.serviceGroupName -Name $env.goalAssignmentName }
        Assert-GoalAssignment $goal
    }

    It 'GetViaIdentity' {
        $identity = $serviceGroupIdentity + @{ GoalAssignmentName = $env.goalAssignmentName }
        $goal = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignment -InputObject $identity }
        Assert-GoalAssignment $goal
    }
}
