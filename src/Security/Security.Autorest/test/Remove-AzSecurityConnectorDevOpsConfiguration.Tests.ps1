if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSecurityConnectorDevOpsConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSecurityConnectorDevOpsConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSecurityConnectorDevOpsConfiguration' {
    It 'Delete' {
        "Tested in New-AzSecurityConnectorDevOpsConfiguration.Tests" | Should -Not -BeNullOrEmpty    }

    It 'DeleteViaIdentity' {
        "Tested in New-AzSecurityConnectorDevOpsConfiguration.Tests" | Should -Not -BeNullOrEmpty
    }
}
