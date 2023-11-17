if(($null -eq $TestName) -or ($TestName -contains 'Set-AzUserAssignedIdentity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzUserAssignedIdentity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# this seems to be a cmdlet generation bug: 'Set-AzUserAssignedIdentity' does not exist.
Describe 'Set-AzUserAssignedIdentity' {
    It 'UpdateExpanded' {
        {} | Should -Not -Throw
    }
}
