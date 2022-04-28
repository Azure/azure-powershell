if(($null -eq $TestName) -or ($TestName -contains 'New-AzManagedServicesAssignment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzManagedServicesAssignment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzManagedServicesAssignment' {
    It 'CreateExpanded' -skip {
        $permantAuth = New-AzManagedServicesAuthorizationObject -PrincipalId $env.PrincipalId -RoleDefinitionId $env.RoleDefinitionId -PrincipalIdDisplayName $env.PrincipalIdDisplayName
        $newDefinition = New-AzManagedServicesDefinition -Name $env.DefinitionId -RegistrationDefinitionName $env.DefinitionName -ManagedByTenantId $env.ManagedByTenantId -Authorization $permantAuth -Description $env.DefinitionName -Scope $env.Scope
        $newDefinition.ProvisioningState | Should -Be "Succeeded"

        $newAssignment = New-AzManagedServicesAssignment -Name $env.AssignmentId -Scope $env.Scope -RegistrationDefinitionId $newDefinition.Id

        $newAssignment.ProvisioningState | Should -Be "Succeeded"

        Remove-AzManagedServicesAssignment -InputObject $newAssignment
        Remove-AzManagedServicesDefinition -InputObject $newDefinition
    }
}
