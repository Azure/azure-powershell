if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRoleAssignmentScheduleRequest'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRoleAssignmentScheduleRequest.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRoleAssignmentScheduleRequest' {
    It 'List' {
        { 
            $scope = "/subscriptions/" + $env.SubscriptionId
            $assignmentScheduleRequests = Get-AzRoleAssignmentScheduleRequest -Scope $scope 
        } | Should -Not -Throw
    }

    It 'List with filter' {
        { 
            $assignmentScheduleRequests = Get-AzRoleAssignmentScheduleRequest -Scope / -Filter "asTarget()"
        } | Should -Not -Throw
    }

    It 'Get' {
        { 
            $scope = "/providers/Microsoft.Subscription/subscriptions/e842845b-02c9-4f05-8a65-2ac7086bc975/"
            $assignmentScheduleRequest = Get-AzRoleAssignmentScheduleRequest -Scope $scope -Name "84c74774-5eab-4c47-bfff-33d3c06118ee"
            $assignmentScheduleRequest | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }
    
    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
