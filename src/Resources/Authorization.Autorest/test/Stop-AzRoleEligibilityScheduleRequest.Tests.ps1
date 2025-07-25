if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzRoleEligibilityScheduleRequest'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzRoleEligibilityScheduleRequest.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzRoleEligibilityScheduleRequest' {
    It 'Cancel' {
        { 
            $guid = "47f8978c-5d8d-4fbf-b4b6-2f43eeb43fc5"
            $startTime = "2022-03-09T17:11:19.7711006-08:00" 
            $scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"

            New-AzRoleEligibilityScheduleRequest -Name $guid -Scope $scope -ExpirationDuration PT30M -ExpirationType AfterDuration -PrincipalId 5a4bdd72-ab3e-4d8e-ab0f-8dd8917481a2 -RequestType AdminAssign -RoleDefinitionId subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/providers/Microsoft.Authorization/roleDefinitions/c8d4ff99-41c3-41a8-9f60-21dfdad59608 -ScheduleInfoStartDateTime $startTime -Justification "Test"

            Stop-AzRoleEligibilityScheduleRequest -Scope $scope -Name $guid
        } | Should -Not -Throw
    }

    It 'CancelViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
