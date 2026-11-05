if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzResiliencyGoalAssignment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzResiliencyGoalAssignment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzResiliencyGoalAssignment' {
    BeforeAll {
        # Only one goal assignment may exist per service group, so each scenario creates and deletes its own goal.
        function New-TestGoalAssignment([string]$Name) {
            # -NoWait: the generated create poller expects a Location header that the service does not return.
            $null = Invoke-ResiliencyWithRetry { New-AzResiliencyGoalAssignment -ServiceGroupName $env.goalServiceGroupName -Name $Name -RequireZonalResiliency -NoWait }
            $deadline = (Get-Date).AddMinutes(15)
            do {
                $goal = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignment -ServiceGroupName $env.goalServiceGroupName -Name $Name }
                if ($goal.ProvisioningState -in 'Succeeded', 'Failed', 'Canceled') {
                    break
                }
                Start-TestSleep -Seconds 15
            } while ((Get-Date) -lt $deadline)
            $goal.ProvisioningState | Should -Be 'Succeeded'
            return $goal
        }
        function Assert-GoalRemoved([string]$Name) {
            $deadline = (Get-Date).AddMinutes(15)
            while (@(Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignment -ServiceGroupName $env.goalServiceGroupName }).Name -contains $Name -and (Get-Date) -lt $deadline) {
                Start-TestSleep -Seconds 15
            }
            @(Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignment -ServiceGroupName $env.goalServiceGroupName }).Name | Should -Not -Contain $Name
        }
    }

    It 'Delete' {
        $name = "$($env.goalAssignmentName)-rm1"
        $null = New-TestGoalAssignment $name
        Invoke-ResiliencyWithRetry { Remove-AzResiliencyGoalAssignment -ServiceGroupName $env.goalServiceGroupName -Name $name -PassThru } | Should -BeTrue
        Assert-GoalRemoved $name
    }

    It 'DeleteViaIdentityServiceGroup' {
        $name = "$($env.goalAssignmentName)-rm2"
        $null = New-TestGoalAssignment $name
        Invoke-ResiliencyWithRetry { Remove-AzResiliencyGoalAssignment -ServiceGroupInputObject @{ ServiceGroupName = $env.goalServiceGroupName } -Name $name -PassThru } | Should -BeTrue
        Assert-GoalRemoved $name
    }

    It 'DeleteViaIdentity' {
        $name = "$($env.goalAssignmentName)-rm3"
        $goal = New-TestGoalAssignment $name
        Invoke-ResiliencyWithRetry { Remove-AzResiliencyGoalAssignment -InputObject $goal -PassThru } | Should -BeTrue
        Assert-GoalRemoved $name
    }
}
