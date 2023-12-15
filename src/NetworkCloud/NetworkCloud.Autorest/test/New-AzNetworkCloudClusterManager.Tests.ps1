if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkCloudClusterManager'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudClusterManager.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkCloudClusterManager' {
    It 'Create' {
        { $cmconfig = $global:config.AzNetworkCloudClusterManager
            $common = $global:config.common
            $tagshash = @{
                $cmconfig.tagsKey1 = $cmconfig.tagsValue1
                $cmconfig.tagsKey2 = $cmconfig.tagsValue2
            }

            New-AzNetworkCloudClusterManager -Name $cmconfig.clusterManagerName `
                -ResourceGroupName $cmconfig.resourceGroup `
                -Location $common.Location -Tag $tagshash `
                -AnalyticsWorkspaceId $cmconfig.analyticsWorkspaceId `
                -FabricControllerId $cmconfig.fabricControllerId `
                -SubscriptionId $cmconfig.subscriptionId
        } | Should -Not -Throw
    }
}
