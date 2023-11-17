if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAutomanageReport'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAutomanageReport.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAutomanageReport' {
    It 'List' {
        { Get-AzAutomanageReport -ResourceGroupName automangerg -VMName aglinuxvm} | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzAutomanageReport -ResourceGroupName automangerg -VMName aglinuxvm -Name cb998749-f7da-4899-8273-d0fde617f49e } | Should -Not -Throw
    }
}
