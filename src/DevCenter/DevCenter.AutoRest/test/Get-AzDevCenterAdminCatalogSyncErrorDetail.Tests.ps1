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
    It 'Get' -skip {
        Get-AzDevCenterAdminCatalogSyncErrorDetail -DevCenterName $env.devCenterName10 -CatalogName $env.catalogName -ResourceGroupName $env.resourceGroupName10 -SubscriptionId $env.SubscriptionId2
    }

    It 'GetViaIdentity' -skip {
        $catalog = Get-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName10 -Name $env.catalogName -ResourceGroupName $env.resourceGroupName10 -SubscriptionId $env.SubscriptionId2
        Get-AzDevCenterAdminCatalogSyncErrorDetail -InputObject $catalog   
    }
}
