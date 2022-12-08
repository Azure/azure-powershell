if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzMobileNetworkCollectPacketCoreControlPlaneDiagnosticPackage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzMobileNetworkCollectPacketCoreControlPlaneDiagnosticPackage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzMobileNetworkCollectPacketCoreControlPlaneDiagnosticPackage' {
    It 'CollectExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Collect' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CollectViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CollectViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
