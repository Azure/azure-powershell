if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSecurityConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSecurityConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSecurityConnector' {
    It 'Delete' {
        "Tested in New-AzSecurityConnector.Tests" | Should -Not -BeNullOrEmpty
    }

    It 'DeleteViaIdentity' {
        "Tested in New-AzSecurityConnector.Tests" | Should -Not -BeNullOrEmpty
    }
}
