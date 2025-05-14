if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDataTransferListPendingConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataTransferListPendingConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDataTransferListPendingConnection' {
    It 'List' {
        {
            $pendingConnections = Get-AzDataTransferListPendingConnection -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName
            $pendingConnections.Count | Should -BeGreaterThan 0
            $pendingConnections | ForEach-Object {
                $_.ConnectionName | Should -Be $env:ConnectionName
                $_.ResourceGroupName | Should -Be $env:ResourceGroupName
                $_.Status | Should -Be "Pending"
            }
        } | Should -Not -Throw
    }
}
