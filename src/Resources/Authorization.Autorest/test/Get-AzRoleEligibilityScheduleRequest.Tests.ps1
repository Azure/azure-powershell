if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRoleEligibilityScheduleRequest'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRoleEligibilityScheduleRequest.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRoleEligibilityScheduleRequest' {
    It 'List' {
        { 
            $scope = "/subscriptions/" + $env.SubscriptionId
            $eligibilityScheduleRequests = Get-AzRoleEligibilityScheduleRequest -Scope $scope 
        } | Should -Not -Throw
    }

    It 'List with filter' {
        { 
            $eligibilityScheduleRequests = Get-AzRoleEligibilityScheduleRequest -Scope / -Filter "asTarget()"
        } | Should -Not -Throw
    }

    It 'Get' {
        { 
            $scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
            $eligibilityScheduleRequest = Get-AzRoleEligibilityScheduleRequest -Scope $scope -Name "0a4d3ef7-147b-4777-a958-ae9dfab3c331"
            $eligibilityScheduleRequest | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
