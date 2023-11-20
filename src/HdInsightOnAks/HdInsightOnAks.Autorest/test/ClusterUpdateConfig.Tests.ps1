if(($null -eq $TestName) -or ($TestName -contains 'ClusterUpdateConfig'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'sessionRecords\ClusterUpdateConfig.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'ClusterUpdateConfig' {
    BeforeAll {
        # Cluster configuration info
        $location = "West US 3"
        $clusterResourceGroupName = "PStestGroup"
        $clusterpoolName = "ps-test-pool-operations"
        $clusterName = "testpsspark"
        $vmSize = "Standard_E4s_v3"
        $clusterOfferingVersions = Get-AzHdInsightOnAksAvailableClusterVersion -Location $location
        $StorageUri = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PSGroup/providers/Microsoft.Storage/storageAccounts/hilostorage"
        $ComputeProfileNode = New-AzHdInsightOnAksNodeProfileObject -Type "Worker" -Count 3 -VMSize "Standard_D8d_v5"

        # New-AzHdInsightOnAksClusterPool -Name $clusterpoolName -ResourceGroupName $clusterResourceGroupName -VmSize $vmSize -Location $location
        $coreSiteConfigKey="testvalue1"
        $coreSiteConfigValue="111"
        $yarnServiceConfigProfile
    }

    # If you have donnot have a cluster, you can use this test to create a cluster, and then run other tests.
    It "New-AzHdInsightOnAksCluster_Spark" -Skip {
        $clusterType = "Spark"
        $StorageUri = "abfs://testcontainer1@hilostorage.dfs.core.windows.net"
        
        { New-AzHdInsightOnAksCluster -Name $clusterName -PoolName $clusterpoolName `
        -ResourceGroupName $clusterResourceGroupName `
        -Location $location `
        -ClusterType $clusterType `
        -ClusterVersion $clusterOfferingVersions[1].ClusterVersionValue -OssVersion $clusterOfferingVersions[1].OssVersion `
        -ServiceConfigsProfile $profileServiceConfigsProfile `
        -ComputeProfileNode $ComputeProfileNode `
        -AuthorizationUserId $env.authorizationUserId `
        -AssignedIdentityClientId $env.msiClientId `
        -AssignedIdentityObjectId $env.msiObjectId `
        -AssignedIdentityResourceId $env.identityProfileMsiResourceId `
        -SparkStorageUrl $StorageUri } | Should -Not -Throw
        
        [Console]::WriteLine("New-AzHdInsightOnAksCluster_Spark done")
    }

    It "New AzHDInsightAksClusterServiceConfigsProfile"{
        $coreSiteConfigFile = New-AzHdInsightOnAksClusterConfigFileObject -FileName "core-site.xml" -Value @{"testvalue1"="111"}
        $yarnComponentConfig = New-AzHdInsightOnAksClusterServiceConfigObject -ComponentName "hadoop-config" -File $coreSiteConfigFile
        $yarnServiceConfigProfile = New-AzHdInsightOnAksClusterServiceConfigsProfileObject -ServiceName "yarn-service" -Config $yarnComponentConfig

        [Console]::WriteLine("New-AzHdInsightOnAksClusterServiceConfigsProfileObject done")
    }

    It "Update AzHdInsightOnAksCluster"{
        { Update-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -PoolName $clusterpoolName -Name $clusterName -ClusterProfileServiceConfigsProfile $yarnServiceConfigProfile} | Should -Not -Throw

        [Console]::WriteLine("Update-AzHdInsightOnAksCluster done")
    }

    It "Get AzHdInsightOnAksClusterServiceConfig"{
        { $script:configs =  Get-AzHdInsightOnAksClusterServiceConfig -ResourceGroupName $clusterResourceGroupName -ClusterPoolName $clusterpoolName -ClusterName $clusterName } | Should -Not -Throw
        $config
        foreach ($config in $script:configs) {
            if ($config.ComponentName -eq "hadoop-config" -And $config.FileName -eq "core-site.xml" -And $config.ServiceName -eq "yarn-service"){
                break
            }
        }
        $config.CustomKey.Keys | Should -Be $coreSiteConfigKey
        $config.CustomKey.Values | Should -Be $coreSiteConfigValue


        [Console]::WriteLine("Get-AzHdInsightOnAksClusterServiceConfig done")
    }

}
