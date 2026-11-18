if(($null -eq $TestName) -or ($TestName -contains 'New-AzResiliencyGoalAssignment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzResiliencyGoalAssignment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzResiliencyGoalAssignment' {
    BeforeAll {
        # The service allows a single goal assignment per service group, so every scenario creates the goal in the
        # dedicated service group, verifies it and deletes it again before the next scenario runs.
        $serviceGroupIdentity = @{ ServiceGroupName = $env.goalServiceGroupName }
        $body = @{ properties = @{ requireZonalResiliency = $true } }
        function Assert-NewGoalAssignment([object]$Goal, [string]$Name) {
            $Goal.Name | Should -Be $Name
            $Goal.RequireZonalResiliency | Should -BeTrue
            $Goal.ProvisioningState | Should -Be 'Succeeded'
            Invoke-ResiliencyWithRetry { Remove-AzResiliencyGoalAssignment -ServiceGroupName $env.goalServiceGroupName -Name $Name }
            $deadline = (Get-Date).AddMinutes(15)
            while (@(Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignment -ServiceGroupName $env.goalServiceGroupName }).Count -gt 0 -and (Get-Date) -lt $deadline) {
                Start-TestSleep -Seconds 15
            }
            @(Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignment -ServiceGroupName $env.goalServiceGroupName }).Name | Should -Not -Contain $Name
        }
    }

    It 'CreateExpanded' {
        $name = "$($env.goalAssignmentName)-new1"
        $goal = Invoke-ResiliencyWithRetry { New-AzResiliencyGoalAssignment -ServiceGroupName $env.goalServiceGroupName -Name $name -RequireZonalResiliency }
        Assert-NewGoalAssignment $goal $name
    }

    It 'CreateViaJsonString' {
        $name = "$($env.goalAssignmentName)-new2"
        $json = $body | ConvertTo-Json -Depth 5
        $goal = Invoke-ResiliencyWithRetry { New-AzResiliencyGoalAssignment -ServiceGroupName $env.goalServiceGroupName -Name $name -JsonString $json }
        Assert-NewGoalAssignment $goal $name
    }

    It 'CreateViaJsonFilePath' {
        $name = "$($env.goalAssignmentName)-new3"
        $jsonFilePath = Join-Path $TestDrive 'goalAssignment.json'
        $body | ConvertTo-Json -Depth 5 | Set-Content $jsonFilePath
        $goal = Invoke-ResiliencyWithRetry { New-AzResiliencyGoalAssignment -ServiceGroupName $env.goalServiceGroupName -Name $name -JsonFilePath $jsonFilePath }
        Assert-NewGoalAssignment $goal $name
    }

    It 'CreateViaIdentityServiceGroupExpanded' {
        $name = "$($env.goalAssignmentName)-new4"
        $goal = Invoke-ResiliencyWithRetry { New-AzResiliencyGoalAssignment -ServiceGroupInputObject $serviceGroupIdentity -Name $name -RequireZonalResiliency }
        Assert-NewGoalAssignment $goal $name
    }

    It 'CreateViaIdentityServiceGroup' {
        $name = "$($env.goalAssignmentName)-new5"
        $goal = Invoke-ResiliencyWithRetry { New-AzResiliencyGoalAssignment -ServiceGroupInputObject $serviceGroupIdentity -Name $name -Resource @{ RequireZonalResiliency = $true } }
        Assert-NewGoalAssignment $goal $name
    }

    It 'Create' {
        $name = "$($env.goalAssignmentName)-new6"
        $goal = Invoke-ResiliencyWithRetry { New-AzResiliencyGoalAssignment -ServiceGroupName $env.goalServiceGroupName -Name $name -Resource @{ RequireZonalResiliency = $true } }
        Assert-NewGoalAssignment $goal $name
    }

    It 'CreateViaIdentityExpanded' {
        $name = "$($env.goalAssignmentName)-new7"
        $identity = $serviceGroupIdentity + @{ GoalAssignmentName = $name }
        $goal = Invoke-ResiliencyWithRetry { New-AzResiliencyGoalAssignment -InputObject $identity -RequireZonalResiliency }
        Assert-NewGoalAssignment $goal $name
    }

    It 'CreateViaIdentity' {
        $name = "$($env.goalAssignmentName)-new8"
        $identity = $serviceGroupIdentity + @{ GoalAssignmentName = $name }
        $goal = Invoke-ResiliencyWithRetry { New-AzResiliencyGoalAssignment -InputObject $identity -Resource @{ RequireZonalResiliency = $true } }
        Assert-NewGoalAssignment $goal $name
    }
}
