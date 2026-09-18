if(($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkCloudKubernetesClusterFeature'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudKubernetesClusterFeature.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkCloudKubernetesClusterFeature' {
    It 'UpdateExpanded'  {
       {
        $kubernetesFeatureConfig = $global:config.AzNetworkCloudKubernetesClusterFeature
        $common = $global:config.common
        $tagUpdatedHash = @{
            tag1 = $global:config.AzNetworkCloudKubernetesClusterFeature.tags
            tag2 = $global:config.AzNetworkCloudKubernetesClusterFeature.tagsUpdate
        }

        Update-AzNetworkCloudKubernetesClusterFeature -FeatureName $kubernetesFeatureConfig.featureName `
        -KubernetesClusterName $kubernetesFeatureConfig.kubernetesClusterName `
        -ResourceGroupName $kubernetesFeatureConfig.resourceGroup `
        -SubscriptionId $kubernetesFeatureConfig.subscriptionId `
        -Tag $tagUpdatedHash
         } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
