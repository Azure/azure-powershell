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
        # The PATCH is accepted asynchronously (202). -NoWait returns the operation, which is then
        # followed with Get-AzResiliencyOperationStatus before the goal assignment itself is verified.
        function Assert-GoalUpdated([object]$Operation) {
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
            $goal = Wait-ResiliencySucceeded -Command { Get-AzResiliencyGoalAssignment @goalParameters }
            $goal.Name | Should -Be $env.goalAssignmentName
            $goal.RequireZonalResiliency | Should -BeTrue
        }
    }

    It 'UpdateExpanded' {
        $operation = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment @goalParameters -RequireZonalResiliency -NoWait }
        Assert-GoalUpdated $operation
    }

    It 'UpdateViaJsonString' {
        $json = $body | ConvertTo-Json -Depth 5
        $operation = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment @goalParameters -JsonString $json -NoWait }
        Assert-GoalUpdated $operation
    }

    It 'UpdateViaJsonFilePath' {
        $jsonFilePath = Join-Path $TestDrive 'goalAssignmentUpdate.json'
        $body | ConvertTo-Json -Depth 5 | Set-Content $jsonFilePath
        $operation = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment @goalParameters -JsonFilePath $jsonFilePath -NoWait }
        Assert-GoalUpdated $operation
    }

    It 'UpdateViaIdentityServiceGroupExpanded' {
        $operation = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment -ServiceGroupInputObject $serviceGroupIdentity -Name $env.goalAssignmentName -RequireZonalResiliency -NoWait }
        Assert-GoalUpdated $operation
    }

    It 'UpdateViaIdentityServiceGroup' {
        $operation = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment -ServiceGroupInputObject $serviceGroupIdentity -Name $env.goalAssignmentName -Property @{ RequireZonalResiliency = $true } -NoWait }
        Assert-GoalUpdated $operation
    }

    It 'Update' {
        $operation = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment @goalParameters -Property @{ RequireZonalResiliency = $true } -NoWait }
        Assert-GoalUpdated $operation
    }

    It 'UpdateViaIdentityExpanded' {
        $operation = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment -InputObject $goalIdentity -RequireZonalResiliency -NoWait }
        Assert-GoalUpdated $operation
    }

    It 'UpdateViaIdentity' {
        $operation = Invoke-ResiliencyWithRetry -AlsoRetryOn $operationInProgress { Update-AzResiliencyGoalAssignment -InputObject $goalIdentity -Property @{ RequireZonalResiliency = $true } -NoWait }
        Assert-GoalUpdated $operation
    }
}
