if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRoleEligibilityScheduleInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRoleEligibilityScheduleInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRoleEligibilityScheduleInstance' {
    It 'List' {
        { 
            $scope = "/subscriptions/" + $env.SubscriptionId
            $eligibilityScheduleIntances = Get-AzRoleEligibilityScheduleInstance -Scope $scope 
        } | Should -Not -Throw
    }

    It 'List with filter' {
        { 
            $eligibilityScheduleIntances = Get-AzRoleEligibilityScheduleInstance -Scope / -Filter "asTarget()"
        } | Should -Not -Throw
    }

    It 'Get' {
        { 
            $scope = "subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d"
            $eligibilityScheduleIntance = Get-AzRoleEligibilityScheduleInstance -Scope $scope -Name "74326403-05d9-49ae-907d-d94622df7ef3"
            $eligibilityScheduleIntance | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
