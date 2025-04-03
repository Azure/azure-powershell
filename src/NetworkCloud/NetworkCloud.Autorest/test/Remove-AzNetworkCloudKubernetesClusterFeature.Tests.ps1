if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkCloudKubernetesClusterFeature'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkCloudKubernetesClusterFeature.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkCloudKubernetesClusterFeature' {
    It 'Delete' {
        { 
        $kubernetesFeatureConfig = $global:config.AzNetworkCloudKubernetesClusterFeature
        $common = $global:config.common

        Remove-AzNetworkCloudKubernetesClusterFeature  -FeatureName  $kubernetesFeatureConfig.featureName `
            -KubernetesClusterName $kubernetesFeatureConfig.kubernetesClusterName `
            -ResourceGroupName $kubernetesFeatureConfig.resourceGroup `
            -Subscription $kubernetesFeatureConfig.subscriptionId } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
