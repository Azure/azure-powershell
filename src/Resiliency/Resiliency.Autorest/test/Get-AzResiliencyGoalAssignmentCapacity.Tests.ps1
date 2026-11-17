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
        # The service returns the recommendation as an operation-status record whose properties are a JSON-encoded
        # string; the module decodes it (dcabe291). For this VM the service returns no capacities or recommendations,
        # so the lists are empty: assert they were decoded (an empty list, not null) and that there is no agent error.
        function Assert-Capacity([object]$Result) {
            $Result | Should -Not -BeNullOrEmpty
            $null -ne $Result.ResourceCapacity | Should -BeTrue -Because 'resourceCapacities is decoded from the string-encoded properties'
            $null -ne $Result.Recommendation | Should -BeTrue -Because 'recommendations is decoded from the string-encoded properties'
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
