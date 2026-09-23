if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkCloudKubernetesClusterFeature'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudKubernetesClusterFeature.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkCloudKubernetesClusterFeature' {
    It 'CreateExpanded' {
        {
        $tagHash = @{
            tag1 = $clusterconfig.tags
        }
        $kubernetesFeatureConfig = $global:config.AzNetworkCloudKubernetesClusterFeature
        $common = $global:config.common
            $tagHash = @{
        tag1 = $kubernetesFeatureConfig.tags
        }

        New-AzNetworkCloudKubernetesClusterFeature -FeatureName $kubernetesFeatureConfig.featureName `
        -KubernetesClusterName $kubernetesFeatureConfig.kubernetesClusterName `
        -ResourceGroupName $kubernetesFeatureConfig.resourceGroup `
        -SubscriptionId $kubernetesFeatureConfig.subscriptionId `
        -Location $common.location `
        -Tag @{"key"="value"} 
         } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityKubernetesClusterExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityKubernetesCluster' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
