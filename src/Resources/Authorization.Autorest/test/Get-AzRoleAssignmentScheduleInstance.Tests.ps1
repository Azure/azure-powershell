if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRoleAssignmentScheduleInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRoleAssignmentScheduleInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRoleAssignmentScheduleInstance' {
    It 'List' {
        { 
            $scope = "/subscriptions/" + $env.SubscriptionId
            $assignmentScheduleIntances = Get-AzRoleAssignmentScheduleInstance -Scope $scope 
        } | Should -Not -Throw
    }

    It 'List with filter' {
        { 
            $assignmentScheduleIntances = Get-AzRoleAssignmentScheduleInstance -Scope / -Filter "asTarget()"
        } | Should -Not -Throw
    }

    It 'Get' {
        { 
            $scope = "/providers/Microsoft.Management/managementGroups/MG-1/"
            $assignmentScheduleIntance = Get-AzRoleAssignmentScheduleInstance -Scope $scope -Name "529e4bba-621c-4309-a4b2-73e3364d4dd3"
            $assignmentScheduleIntance | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
