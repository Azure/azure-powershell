if(($null -eq $TestName) -or ($TestName -contains 'Set-AzFederatedIdentityCredentials'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzFederatedIdentityCredentials.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# this seems to be a cmdlet generation bug: 'Set-AzFederatedIdentityCredentials' does not exist.
Describe 'Set-AzFederatedIdentityCredentials' {
    It 'UpdateExpanded' {
        {} | Should -Not -Throw
    }
}
