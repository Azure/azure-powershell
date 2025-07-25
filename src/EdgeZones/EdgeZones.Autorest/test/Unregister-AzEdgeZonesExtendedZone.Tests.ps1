if(($null -eq $TestName) -or ($TestName -contains 'Unregister-AzEdgeZonesExtendedZone'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Unregister-AzEdgeZonesExtendedZone.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Unregister-AzEdgeZonesExtendedZone' {
    It 'Unregister' {
        { 
            $config = Unregister-AzEdgeZonesExtendedZone -Name $env.extendedZoneName2
            $config.Name | Should -Be $env.extendedZoneName2
        } | Should -Not -Throw
    }

    It 'UnregisterViaIdentity' {
        { 
            $config = Get-AzEdgeZonesExtendedZone -Name $env.extendedZoneName2
            $config = Unregister-AzEdgeZonesExtendedZone -InputObject $config
            $config.Name | Should -Be $env.extendedZoneName2
        } | Should -Not -Throw
    }
}
