if(($null -eq $TestName) -or ($TestName -contains 'Test-AzAppConfigurationKeyValue'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzAppConfigurationKeyValue.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzAppConfigurationKeyValue' {
    It 'CheckExisting' {
        # Create a dedicated key for this test
        $testKey = "checktest-key1"
        Set-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $testKey -Value "exists"
        { Test-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $testKey } | Should -Not -Throw
        # Cleanup
        Remove-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $testKey
    }

    It 'CheckNonExisting' {
        # Test a key-value that does not exist (HEAD returns 404 which throws)
        { Test-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key "nonexistent-key-playback" } | Should -Throw
    }
}
