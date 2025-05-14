if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDataTransferListPendingFlow'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataTransferListPendingFlow.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDataTransferListPendingFlow' {
    It 'List' {
        {
            $pendingFlows = Get-AzDataTransferListPendingFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName
            $pendingFlows.Count | Should -BeGreaterThan 0
            $pendingFlows | ForEach-Object {
                $_.ConnectionName | Should -Be $env:ConnectionName
                $_.ResourceGroupName | Should -Be $env:ResourceGroupName
                $_.Status | Should -Be "Pending"
            }
        } | Should -Not -Throw
    }
}
