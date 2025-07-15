if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDataTransferPendingFlow'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataTransferPendingFlow.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDataTransferPendingFlow' {
    It 'List' {
        {
            $pendingFlows = Get-AzDataTransferPendingFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked
            $pendingFlows.Count | Should -BeGreaterThan 0
            $pendingFlows | ForEach-Object {
                $_.Name | Should -Not -BeNullOrEmpty
            }
        } | Should -Not -Throw
    }
}
