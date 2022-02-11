if(($null -eq $TestName) -or ($TestName -contains 'New-AzRoleAssignmentScheduleRequest'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRoleAssignmentScheduleRequest.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzRoleAssignmentScheduleRequest' {
    It 'CreateExpanded' {
        { 
            $guid = "47f8978c-5d8d-4fbf-b4b6-2f43eeb43ec5"
            $startTime = Get-Date -Format o 
            $scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"

            $activationRequest = New-AzRoleAssignmentScheduleRequest -Name $guid -Scope $scope -ExpirationDuration PT30M -ExpirationType AfterDuration -PrincipalId 5a4bdd72-ab3e-4d8e-ab0f-8dd8917481a2 -RequestType AdminAssign -RoleDefinitionId subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/providers/Microsoft.Authorization/roleDefinitions/acdd72a7-3385-48ef-bd42-f606fba81ae7 -ScheduleInfoStartDateTime $startTime -Justification "Test"
        } | Should -Not -Throw
    }
}
