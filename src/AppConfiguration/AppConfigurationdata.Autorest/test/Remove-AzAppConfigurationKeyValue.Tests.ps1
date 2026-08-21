if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAppConfigurationKeyValue'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAppConfigurationKeyValue.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAppConfigurationKeyValue' {
    It 'Delete' {
        # Create a key-value, then delete it
        $deleteKey = "deletetest-key1"
        Set-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $deleteKey -Value "to-be-deleted"
        {
            Remove-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $deleteKey
        } | Should -Not -Throw
        # Verify the key no longer exists (Get throws NotFound for deleted keys)
        { Get-AzAppConfigurationKeyValue -Endpoint $env.endpoint -Key $deleteKey } | Should -Throw
    }
}
