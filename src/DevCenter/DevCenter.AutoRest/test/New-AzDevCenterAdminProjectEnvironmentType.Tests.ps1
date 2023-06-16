if(($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterAdminProjectEnvironmentType'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterAdminProjectEnvironmentType.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterAdminProjectEnvironmentType' {
    It 'CreateExpanded' -skip {
        New-AzDevCenterAdminProjectEnvironmentType -EnvironmentTypeName <String> -ProjectName <String> -ResourceGroupName
     [-CreatorRoleAssignmentRole <Hashtable>] [-DeploymentTargetId <String>]
    [-IdentityType <ManagedServiceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>] [-Location <String>]
    [-Status <EnvironmentTypeEnableStatus>] [-UserRoleAssignment <Hashtable>]
    }

    It 'Create' -skip {
        New-AzDevCenterAdminProjectEnvironmentType -EnvironmentTypeName <String> -ProjectName <String> -ResourceGroupName -Body 
    }

}
