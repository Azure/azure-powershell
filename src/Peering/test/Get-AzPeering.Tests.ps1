if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPeering'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPeering.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPeering' {
    It 'List1' {
        {
            $allPeerings = Get-AzPeering
            $allPeerings.Count| Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $peering = Get-AzPeering -Name DemoPeering -ResourceGroupName DemoRG
            $peering.Name | Should -Be "DemoPeering"
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $rgPeerings = Get-AzPeering -ResourceGroupName DemoRG
            $rgPeerings.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
