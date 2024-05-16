if (($null -eq $TestName) -or ($TestName -contains 'ClusterUpdate')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'sessionRecords\ClusterUpdate.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'ClusterUpdate' {
    BeforeAll {
        # Cluster configuration info
        $location = "West US 3"
        $clusterResourceGroupName = "PStestGroup"
        $clusterpoolName = "hilo-pool"
        $clusterName = "psspark"
        $poolVmSize = "Standard_D4a_v4"
        $clusterPoolVersion = "1.1"
        $clusterType = "Spark"
        $clusterOfferingVersions = Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object ClusterPoolVersion -eq $clusterPoolVersion | Where-Object ClusterType -eq $clusterType
        $StorageUri = "abfs://pscontainer1@hilostorage.dfs.core.windows.net"
        $ComputeProfileNode = New-AzHdInsightOnAksNodeProfileObject -Type "Worker" -Count 3 -VMSize "Standard_D16a_v4"

        # New-AzHdInsightOnAksClusterPool -Name $clusterpoolName -ResourceGroupName $clusterResourceGroupName -VmSize $poolVmSize -ClusterPoolVersion $clusterPoolVersion -Location $location
        $coreSiteConfigKey = "testvalue1"
        $coreSiteConfigValue = "111"
        $yarnServiceConfigProfile
    }

    # If you have donnot have a cluster, you can use this test to create a cluster, and then run other tests.
    It "New-AzHdInsightOnAksCluster_Spark" -Skip {
        
        { New-AzHdInsightOnAksCluster -Name $clusterName -PoolName $clusterpoolName `
                -ResourceGroupName $clusterResourceGroupName `
                -Location $location `
                -ClusterType $clusterType `
                -ClusterVersion $clusterOfferingVersions[0].ClusterVersionValue -OssVersion $clusterOfferingVersions[0].OssVersion `
                -ComputeProfileNode $ComputeProfileNode `
                -AuthorizationUserId $env.authorizationUserId `
                -AssignedIdentityClientId $env.msiClientId `
                -AssignedIdentityObjectId $env.msiObjectId `
                -AssignedIdentityResourceId $env.identityProfileMsiResourceId `
                -SparkStorageUrl $StorageUri } | Should -Not -Throw
        
        [Console]::WriteLine("New-AzHdInsightOnAksCluster_Spark done")
    }

    It "New AzHDInsightAksClusterServiceConfigsProfile" {
        $coreSiteConfigFile = New-AzHdInsightOnAksClusterConfigFileObject -FileName "core-site.xml" -Value @{"testvalue1" = "111" }
        $yarnComponentConfig = New-AzHdInsightOnAksClusterServiceConfigObject -ComponentName "hadoop-config" -File $coreSiteConfigFile
        $yarnServiceConfigProfile = New-AzHdInsightOnAksClusterServiceConfigsProfileObject -ServiceName "yarn-service" -Config $yarnComponentConfig

        [Console]::WriteLine("New-AzHdInsightOnAksClusterServiceConfigsProfileObject done")
    }

    It "Update AzHdInsightOnAksCluster" {
        { Update-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -PoolName $clusterpoolName -Name $clusterName -ClusterProfileServiceConfigsProfile $yarnServiceConfigProfile } | Should -Not -Throw

        [Console]::WriteLine("Update-AzHdInsightOnAksCluster done")
    }

    It "Get AzHdInsightOnAksClusterServiceConfig" {
        { $script:configs = Get-AzHdInsightOnAksClusterServiceConfig -ResourceGroupName $clusterResourceGroupName -ClusterPoolName $clusterpoolName -ClusterName $clusterName } | Should -Not -Throw
        $config = $script:configs | Where-Object ServiceName -eq "yarn-service" | Where-Object ComponentName -eq "hadoop-config" | Where-Object FileName -eq "core-site.xml"

        $config.CustomKey.Keys | Should -Be $coreSiteConfigKey
        $config.CustomKey.Values | Should -Be $coreSiteConfigValue

        [Console]::WriteLine("Get-AzHdInsightOnAksClusterServiceConfig done")
    }

}
