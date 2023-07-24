if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkCloudKubernetesCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudKubernetesCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkCloudKubernetesCluster' {
  It 'Create' {
        { $kubernetesClusterConfig = $global:config.AzNetworkCloudKubernetesCluster
            $common = $global:config.common
            $agentPoolConfiguration = @{
                count = $kubernetesClusterConfig.nodeCount
                mode = $kubernetesClusterConfig.agentPoolMode
                name = $kubernetesClusterConfig.agentPoolName
                vmSkuName = $kubernetesClusterConfig.vmSkuName
                administratorConfiguration = $kubernetesClusterConfig.administratorConfiguration
            }
            $sshPublicKey = @{
                KeyData = $kubernetesClusterConfig.sshPublicKey
            }
            New-AzNetworkCloudKubernetesCluster -ResourceGroupName $kubernetesClusterConfig.resourceGroup `
                -KubernetesClusterName $kubernetesClusterConfig.kubernetesClusterName -Location  $common.location `
                -ExtendedLocationName $common.extendedLocation `
                -ExtendedLocationType $common.customLocationType `
                -KubernetesVersion $kubernetesClusterConfig.kubernetesVersion `
                -AadConfigurationAdminGroupObjectId $kubernetesClusterConfig.adminGroupObjectIds `
                -AdminUsername $kubernetesClusterConfig.adminUsername `
                -SshPublicKey $sshPublicKey `
                -InitialAgentPoolConfiguration $agentPoolConfiguration `
                -NetworkConfigurationCloudServicesNetworkId $kubernetesClusterConfig.cnsId `
                -NetworkConfigurationCniNetworkId $kubernetesClusterConfig.cniId `
                -ControlPlaneNodeConfigurationCount $kubernetesClusterConfig.nodeCount `
                -ControlPlaneNodeConfigurationVMSkuName $kubernetesClusterConfig.vmSkuName `
                -SubscriptionId $kubernetesClusterConfig.subscriptionId `
                -Tag @{tags = $kubernetesClusterConfig.tags }`
        } | Should -Not -Throw
    }
}
