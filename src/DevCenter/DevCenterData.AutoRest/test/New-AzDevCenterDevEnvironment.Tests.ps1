if(($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterDevEnvironment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterDevEnvironment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterDevEnvironment' {
    It 'CreateExpanded' -skip {
        New-AzDevCenterDevEnvironment -Endpoint <String> -Name <String> -ProjectName <String> [-UserId <String>]
        -CatalogName <String> -EnvironmentDefinitionName <String> -EnvironmentType <String> [-Parameter <IAny>]

        New-AzDevCenterDevEnvironment -DevCenter <String> -Name <String> -ProjectName <String> [-UserId <String>]
    -CatalogName <String> -EnvironmentDefinitionName <String> -EnvironmentType <String> [-Parameter <IAny>]
        }

    It 'Create' -skip {
        New-AzDevCenterDevEnvironment -Endpoint <String> -Name <String> -ProjectName <String> [-UserId <String>] -Body
        <IEnvironment>

        New-AzDevCenterDevEnvironment -DevCenter <String> -Name <String> -ProjectName <String> [-UserId <String>] -Body
        <IEnvironment>
        }

    It 'CreateViaIdentityExpanded' -skip {
        New-AzDevCenterDevEnvironment -Endpoint <String> -InputObject <IDevCenterdataIdentity> -Body <IEnvironment>
        New-AzDevCenterDevEnvironment -DevCenter <String> -InputObject <IDevCenterdataIdentity> -Body <IEnvironment>
        }

    It 'CreateViaIdentity' -skip {
        New-AzDevCenterDevEnvironment -Endpoint <String> -InputObject <IDevCenterdataIdentity> -CatalogName <String>
        -EnvironmentDefinitionName <String> -EnvironmentType <String>

        New-AzDevCenterDevEnvironment -DevCenter <String> -InputObject <IDevCenterdataIdentity> -CatalogName <String>
    -EnvironmentDefinitionName <String> -EnvironmentType <String> [-Parameter <IAny>]
        }
}
