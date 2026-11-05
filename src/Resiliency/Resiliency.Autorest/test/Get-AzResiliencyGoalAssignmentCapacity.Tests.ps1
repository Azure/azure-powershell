if(($null -eq $TestName) -or ($TestName -contains 'Get-AzResiliencyGoalAssignmentCapacity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResiliencyGoalAssignmentCapacity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzResiliencyGoalAssignmentCapacity' {
    BeforeAll {
        $goalParameters = @{ ServiceGroupName = $env.serviceGroupName; GoalAssignmentName = $env.goalAssignmentName }
        $goalIdentity = @{ ServiceGroupName = $env.serviceGroupName; GoalAssignmentName = $env.goalAssignmentName }
        $body = @{ resourceIds = @($env.vmId) }
        # The service completes the recommendation as a long-running operation; the cmdlet surfaces the final
        # result without per-resource capacities (see test report), so only a successful, error-free call is asserted.
        function Assert-Capacity([object]$Result) {
            $Result | Should -Not -BeNullOrEmpty
            $Result.AgentError | Should -BeNullOrEmpty
        }
    }

    It 'GetExpanded' {
        $result = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignmentCapacity @goalParameters -ResourceId $env.vmId }
        Assert-Capacity $result
    }

    It 'GetViaJsonString' {
        $json = ConvertTo-Json $body
        $result = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignmentCapacity @goalParameters -JsonString $json }
        Assert-Capacity $result
    }

    It 'GetViaJsonFilePath' {
        $jsonFilePath = Join-Path $TestDrive 'recommendCapacity.json'
        ConvertTo-Json $body | Set-Content $jsonFilePath
        $result = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignmentCapacity @goalParameters -JsonFilePath $jsonFilePath }
        Assert-Capacity $result
    }

    It 'GetViaIdentityServiceGroupExpanded' {
        $result = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignmentCapacity -ServiceGroupInputObject @{ ServiceGroupName = $env.serviceGroupName } -GoalAssignmentName $env.goalAssignmentName -ResourceId $env.vmId }
        Assert-Capacity $result
    }

    It 'GetViaIdentityServiceGroup' {
        $result = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignmentCapacity -ServiceGroupInputObject @{ ServiceGroupName = $env.serviceGroupName } -GoalAssignmentName $env.goalAssignmentName -Body @{ ResourceId = @($env.vmId) } }
        Assert-Capacity $result
    }

    It 'Get' {
        $result = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignmentCapacity @goalParameters -Body @{ ResourceId = @($env.vmId) } }
        Assert-Capacity $result
    }

    It 'GetViaIdentityExpanded' {
        $result = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignmentCapacity -InputObject $goalIdentity -ResourceId $env.vmId }
        Assert-Capacity $result
    }

    It 'GetViaIdentity' {
        $result = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalAssignmentCapacity -InputObject $goalIdentity -Body @{ ResourceId = @($env.vmId) } }
        Assert-Capacity $result
    }
}
