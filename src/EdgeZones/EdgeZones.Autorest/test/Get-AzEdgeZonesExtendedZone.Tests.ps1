if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEdgeZonesExtendedZone'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEdgeZonesExtendedZone.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEdgeZonesExtendedZone' {
    It 'List' {
        { 
            $config = Get-AzEdgeZonesExtendedZone
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        { 
            $config = Get-AzEdgeZonesExtendedZone -Name $env.extendedZoneName1
            $config.Name | Should -Be $env.extendedZoneName1
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { 
            $config = Get-AzEdgeZonesExtendedZone -Name $env.extendedZoneName1
            $config = Get-AzEdgeZonesExtendedZone -InputObject $config
            $config.Name | Should -Be $env.extendedZoneName1
        } | Should -Not -Throw
    }
}
