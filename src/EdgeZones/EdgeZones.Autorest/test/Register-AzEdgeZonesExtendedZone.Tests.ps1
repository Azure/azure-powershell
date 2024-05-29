if(($null -eq $TestName) -or ($TestName -contains 'Register-AzEdgeZonesExtendedZone'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Register-AzEdgeZonesExtendedZone.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Register-AzEdgeZonesExtendedZone' {
    It 'Register'
    {
        { 
            $config = Register-AzEdgeZonesExtendedZone -Name $env.extendedZoneName1
            $config.Name | Should -Be $env.extendedZoneName1
        } | Should -Not -Throw
    }

    It 'RegisterViaIdentity' {
        { 
            $config = Get-AzEdgeZonesExtendedZone -Name $env.extendedZoneName1
            $config = Register-AzEdgeZonesExtendedZone -InputObject $config
            $config.Name | Should -Be $env.extendedZoneName1
        } | Should -Not -Throw
    }
}
