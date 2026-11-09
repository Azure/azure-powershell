if(($null -eq $TestName) -or ($TestName -contains 'Get-AzResiliencyOperationStatus'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResiliencyOperationStatus.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzResiliencyOperationStatus' {
    BeforeAll {
        $refreshInProgress = 'InvalidResourceOperation|Conflict|\(409\)'
        # Starts a goal-resource refresh without waiting and returns the location and ID of its operation.
        function Start-RefreshOperation {
            $operation = Invoke-ResiliencyWithRetry -AlsoRetryOn $refreshInProgress {
                Sync-AzResiliencyGoalResource -ServiceGroupName $env.serviceGroupName -GoalAssignmentName $env.goalAssignmentName -NoWait
            }
            return Get-ResiliencyOperationFromUrl $operation.Target
        }
        # Polls the status cmdlet until the operation finishes (Status is Accepted while it runs) and checks that it succeeded.
        function Assert-OperationSucceeded([scriptblock]$GetStatus, [string]$OperationId) {
            $deadline = (Get-Date).AddMinutes(20)
            do {
                $status = Invoke-ResiliencyWithRetry $GetStatus
                $status.Name | Should -Be $OperationId
                if ($status.Status -notin 'Accepted', 'Running', 'InProgress') {
                    break
                }
                Start-TestSleep -Seconds 15
            } while ((Get-Date) -lt $deadline)
            $status.Status | Should -Be 'Succeeded'
        }
    }

    It 'Get' {
        $operation = Start-RefreshOperation
        Assert-OperationSucceeded { Get-AzResiliencyOperationStatus -Location $operation.Location -OperationId $operation.OperationId } $operation.OperationId
    }

    It 'GetViaIdentityLocation' {
        $operation = Start-RefreshOperation
        Assert-OperationSucceeded { Get-AzResiliencyOperationStatus -LocationInputObject @{ Location = $operation.Location } -OperationId $operation.OperationId } $operation.OperationId
    }

    It 'GetViaIdentity' {
        $operation = Start-RefreshOperation
        Assert-OperationSucceeded { Get-AzResiliencyOperationStatus -InputObject $operation } $operation.OperationId
    }
}
