if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPeeringRegisteredAsn'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPeeringRegisteredAsn.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPeeringRegisteredAsn' {
    It 'List' {
        {
            $asns = Get-AzPeeringRegisteredAsn -PeeringName MapsIxRs -ResourceGroupName MAPSDemo
            $asns.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $fgfgAsn = Get-AzPeeringRegisteredAsn -PeeringName MapsIxRs -ResourceGroupName MAPSDemo -Name fgfg
            $fgfgAsn.Name | Should -Be "fgfg"
        } | Should -Not -Throw
    }
}
