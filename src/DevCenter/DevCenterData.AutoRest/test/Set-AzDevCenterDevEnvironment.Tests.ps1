if(($null -eq $TestName) -or ($TestName -contains 'Set-AzDevCenterDevEnvironment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDevCenterDevEnvironment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}
# missing identity? 
Describe 'Set-AzDevCenterDevEnvironment' {
    It 'ReplaceExpanded' -skip {
        Set-AzDevCenterDevEnvironment -Endpoint $env.endpoint -Name <String> -ProjectName $env.projectName [-UserId <String>]
        -CatalogName <String> -EnvironmentDefinitionName <String> -EnvironmentType <String> [-Parameter <IAny>]
        }

    It 'Replace' -skip {
        Set-AzDevCenterDevEnvironment -Endpoint $env.endpoint -Name <String> -ProjectName $env.projectName [-UserId <String>] -Body
        <IEnvironment>    }
}
