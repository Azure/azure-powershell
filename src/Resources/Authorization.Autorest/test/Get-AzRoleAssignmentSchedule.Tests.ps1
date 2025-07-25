if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRoleAssignmentSchedule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRoleAssignmentSchedule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRoleAssignmentSchedule' {
    It 'List' {
        { 
            $scope = "/subscriptions/" + $env.SubscriptionId
            $assignmentSchedules = Get-AzRoleAssignmentSchedule -Scope $scope 
        } | Should -Not -Throw
    }

    It 'List with filter' {
        { 
            $assignmentSchedules = Get-AzRoleAssignmentSchedule -Scope / -Filter "asTarget()"
        } | Should -Not -Throw
    }

    It 'Get' {
        { 
            $scope = "/providers/Microsoft.Management/managementGroups/MG-1/"
            $assignmentSchedules = Get-AzRoleAssignmentSchedule -Scope $scope -Name "529e4bba-621c-4309-a4b2-73e3364d4dd3"
            $assignmentSchedules | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -Skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
