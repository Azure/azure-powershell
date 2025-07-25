if(($null -eq $TestName) -or ($TestName -contains 'Deploy-AzMobileNetworkRollbackPacketCoreControlPlane'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Deploy-AzMobileNetworkRollbackPacketCoreControlPlane.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Deploy-AzMobileNetworkRollbackPacketCoreControlPlane' {
    It 'Rollback' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RollbackViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
