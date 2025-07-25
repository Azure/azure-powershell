if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminCatalogSyncErrorDetail'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminCatalogSyncErrorDetail.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminCatalogSyncErrorDetail' {
    It 'Get' {
        $syncError = Get-AzDevCenterAdminCatalogSyncErrorDetail -DevCenterName $env.devCenterName20 -CatalogName $env.devCenterCatalogWithSyncError -ResourceGroupName $env.resourceGroupName20 -SubscriptionId $env.SubscriptionId2
        $syncError.Conflict.Name | Should -Be $env.functionAppName
        $syncError.Conflict.Path | Should -Be $env.functionAppPath
    }
}