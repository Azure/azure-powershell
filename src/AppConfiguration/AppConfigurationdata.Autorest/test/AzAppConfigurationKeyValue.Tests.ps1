if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAppConfigurationKeyValue'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppConfigurationKeyValue.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAppConfigurationKeyValue' -Tag 'LiveOnly' {
    It 'Get' {
        {
            Get-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $env.key
            Set-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $env.key -Value "value2"
            Set-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $env.key -JsonString "{`"key`":`"$key`", `"value`":`"value3`"}"
        } | Should -Not -Throw
    }

    It 'List' {
        {
            Get-AzAppConfigurationKeyValue -Endpoint $env.endpoint
        } | Should -Not -Throw
    }
}
