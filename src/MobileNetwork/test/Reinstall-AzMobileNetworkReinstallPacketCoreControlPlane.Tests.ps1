if(($null -eq $TestName) -or ($TestName -contains 'Reinstall-AzMobileNetworkReinstallPacketCoreControlPlane'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Reinstall-AzMobileNetworkReinstallPacketCoreControlPlane.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Reinstall-AzMobileNetworkReinstallPacketCoreControlPlane' {
    It 'Reinstall' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReinstallViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
