if(($null -eq $TestName) -or ($TestName -contains 'Set-AzAppConfigurationKeyValue'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzAppConfigurationKeyValue.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzAppConfigurationKeyValue' {
    It 'PutExpanded' {
        $setKey = "settest-key1"
        $result = Set-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $setKey -Value "test-value"
        $result | Should -Not -BeNullOrEmpty
        $result.Key | Should -Be $setKey
        $result.Value | Should -Be "test-value"
        # Cleanup
        Remove-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $setKey
    }

    It 'PutViaJsonString' {
        $setKey = "setjson-key1"
        $jsonString = '{"key": "' + $setKey + '", "value": "json-value"}'
        $result = Set-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $setKey -JsonString $jsonString
        $result | Should -Not -BeNullOrEmpty
        $result.Value | Should -Be "json-value"
        # Cleanup
        Remove-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $setKey
    }
}
