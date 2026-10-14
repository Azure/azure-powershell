if(($null -eq $TestName) -or ($TestName -contains 'Set-AzAppConfigurationLock'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzAppConfigurationLock.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzAppConfigurationLock' {
    It 'Put' {
        # Create a dedicated key for this test
        $lockKey = "locktest-key1"
        Set-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $lockKey -Value "lock-value"
        $result = Set-AzAppConfigurationLock -Endpoint $env.endpoint -Key $lockKey
        $result | Should -Not -BeNullOrEmpty
        $result.Locked | Should -BeTrue
        # Unlock and cleanup
        Remove-AzAppConfigurationLock -Endpoint $env.endpoint -Key $lockKey
        Remove-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $lockKey
    }
}
