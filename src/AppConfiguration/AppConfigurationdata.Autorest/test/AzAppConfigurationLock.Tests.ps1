if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAppConfigurationLock'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAppConfigurationLock.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAppConfigurationLock' -Tag 'LiveOnly' {
    It 'Lock' {
        {
            Set-AzAppConfigurationLock -Endpoint $env.endpoint -Key $env.key
        } | Should -Not -Throw
        {
            Remove-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $env.key
        } | Should -Throw
        {
            Remove-AzAppConfigurationLock -Endpoint $env.endpoint -Key $env.key
            Remove-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $env.key
        } | Should -Not -Throw
    }
}
