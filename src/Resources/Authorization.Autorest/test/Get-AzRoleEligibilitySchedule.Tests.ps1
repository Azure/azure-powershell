if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRoleEligibilitySchedule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRoleEligibilitySchedule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRoleEligibilitySchedule' {
    It 'List' {
        { 
            $scope = "/subscriptions/" + $env.SubscriptionId
            $eligibilitySchedules = Get-AzRoleEligibilitySchedule -Scope $scope 
        } | Should -Not -Throw
    }

    It 'List with filter' {
        { 
            $eligibilitySchedules = Get-AzRoleEligibilitySchedule -Scope / -Filter "asTarget()"
        } | Should -Not -Throw
    }

    It 'Get' {
        { 
            $scope = "subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d"
            $eligibilitySchedules = Get-AzRoleEligibilitySchedule -Scope $scope -Name "f36571a6-9feb-47c1-9e13-7b0750640bec"
            $eligibilitySchedules | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }
    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
