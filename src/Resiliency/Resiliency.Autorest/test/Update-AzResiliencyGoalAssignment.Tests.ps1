if(($null -eq $TestName) -or ($TestName -contains 'Update-AzResiliencyGoalAssignment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzResiliencyGoalAssignment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzResiliencyGoalAssignment' {
    BeforeAll {
        $goalParameters = @{ ServiceGroupName = $env.serviceGroupName; Name = $env.goalAssignmentName }
        $serviceGroupIdentity = @{ ServiceGroupName = $env.serviceGroupName }
        $goalIdentity = @{ ServiceGroupName = $env.serviceGroupName; GoalAssignmentName = $env.goalAssignmentName }
        $body = @{ properties = @{ requireZonalResiliency = $true } }
        $operationInProgress = 'Conflict|\(409\)'
        # Users run Update- without -NoWait: the cmdlet waits for the PATCH (202) to finish and returns the goal
        # assignment read from the resource itself (final-state-via: original-uri), so these scenarios assert the
        # returned object.
        function Assert-GoalAssignment([object]$Goal) {
            $Goal.Name | Should -Be $env.goalAssignmentName
            $Goal.RequireZonalResiliency | Should -BeTrue
            $Goal.ProvisioningState | Should -Be 'Succeeded'
        }
        # UpdateViaIdentity covers the -NoWait path: it returns the operation, which is followed with
        # Get-AzResiliencyOperationStatus before the goal assignment itself is verified.
        function Assert-GoalUpdatedAsync([object]$Operation) {
            $Operation.Target | Should -Match '/operationStatuses/'
            $statusOperation = Get-ResiliencyOperationFromUrl $Operation.Target
            $deadline = (Get-Date).AddMinutes(20)
            do {
                $status = Invoke-ResiliencyWithRetry { Get-AzResiliencyOperationStatus -Location $statusOperation.Location -OperationId $statusOperation.OperationId }
                if ($status.Status -notin 'Accepted', 'Running', 'InProgress') {
                    break
                }
                Start-TestSleep -Seconds 10
            } while ((Get-Date) -lt $deadline)
            $status.Status | Should -Be 'Succeeded'
            Assert-GoalAssignment (Wait-ResiliencySucceeded -Command { Get-AzResiliencyGoalAssignment @goalParameters })
        }
    }

    It 'UpdateExpanded' {
        $goal = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment @goalParameters -RequireZonalResiliency }
        Assert-GoalAssignment $goal
    }

    It 'UpdateViaJsonString' {
        $json = $body | ConvertTo-Json -Depth 5
        $goal = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment @goalParameters -JsonString $json }
        Assert-GoalAssignment $goal
    }

    It 'UpdateViaJsonFilePath' {
        $jsonFilePath = Join-Path $TestDrive 'goalAssignmentUpdate.json'
        $body | ConvertTo-Json -Depth 5 | Set-Content $jsonFilePath
        $goal = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment @goalParameters -JsonFilePath $jsonFilePath }
        Assert-GoalAssignment $goal
    }

    It 'UpdateViaIdentityServiceGroupExpanded' {
        $goal = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment -ServiceGroupInputObject $serviceGroupIdentity -Name $env.goalAssignmentName -RequireZonalResiliency }
        Assert-GoalAssignment $goal
    }

    It 'UpdateViaIdentityServiceGroup' {
        $goal = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment -ServiceGroupInputObject $serviceGroupIdentity -Name $env.goalAssignmentName -Property @{ RequireZonalResiliency = $true } }
        Assert-GoalAssignment $goal
    }

    It 'Update' {
        $goal = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment @goalParameters -Property @{ RequireZonalResiliency = $true } }
        Assert-GoalAssignment $goal
    }

    It 'UpdateViaIdentityExpanded' {
        $goal = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment -InputObject $goalIdentity -RequireZonalResiliency }
        Assert-GoalAssignment $goal
    }

    It 'UpdateViaIdentity' {
        $operation = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment -InputObject $goalIdentity -Property @{ RequireZonalResiliency = $true } -NoWait }
        Assert-GoalUpdatedAsync $operation
    }
}
