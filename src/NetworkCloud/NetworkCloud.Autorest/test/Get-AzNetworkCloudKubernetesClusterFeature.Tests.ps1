if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudKubernetesClusterFeature'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudKubernetesClusterFeature.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudKubernetesClusterFeature' {
    It 'Get' {
        { 
        $kubernetesFeatureConfig = $global:config.AzNetworkCloudKubernetesClusterFeature
        Get-AzNetworkCloudKubernetesClusterFeature -Subscription $kubernetesFeatureConfig.subscriptionId `
         -FeatureName $kubernetesFeatureConfig.featureName `
         -KubernetesClusterName $kubernetesFeatureConfig.kubernetesClusterName `
         -ResourceGroupName $kubernetesFeatureConfig.resourceGroup }  | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
