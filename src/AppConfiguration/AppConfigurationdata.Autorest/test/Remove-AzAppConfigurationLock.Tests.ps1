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

Describe 'Remove-AzAppConfigurationLock' {
    It 'Delete' {
        # Create a dedicated key and lock it
        $lockKey = "unlocktest-" + (RandomString -allChars $false -len 6)
        Set-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $lockKey -Value "unlock-value"
        Set-AzAppConfigurationLock -Endpoint $env.endpoint -Key $lockKey
        $result = Remove-AzAppConfigurationLock -Endpoint $env.endpoint -Key $lockKey
        $result | Should -Not -BeNullOrEmpty
        $result.Locked | Should -BeFalse
        # Cleanup
        Remove-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $lockKey
    }
}
