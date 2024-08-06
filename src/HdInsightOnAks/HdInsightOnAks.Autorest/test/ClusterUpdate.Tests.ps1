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
        $location = "West US 2"
        $clusterResourceGroupName = "psGroup"
        $clusterpoolName = "ps-hilopool"
        $clusterName = "ps-spark"
        $poolVmSize = "Standard_D4a_v4"
        $clusterPoolVersion = "1.2"
        $clusterType = "Spark"
        $clusterOfferingVersions = Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object ClusterPoolVersion -eq $clusterPoolVersion | Where-Object ClusterType -eq $clusterType
        $StorageUri = "abfs://pscontainer1@yuchenhilostorage.dfs.core.windows.net"
        $ComputeProfileNode = New-AzHdInsightOnAksNodeProfileObject -Type "Worker" -Count 3 -VMSize "Standard_D8ds_v4"

        $coreSiteConfigKey = "testvalue1"
        $coreSiteConfigValue = "111"
        $yarnServiceConfigProfile
    }

    # If you have donnot have a cluster, you can use this test to create a cluster, and then run other tests.
    It "New-AzHdInsightOnAksCluster_Spark" -skip{

        { $script:ManagedIdentity = New-AzHdInsightOnAksManagedIdentityObject -ClientId $env.msiClientId -ObjectId $env.msiObjectId -ResourceId $env.identityProfileMsiResourceId -Type cluster } | Should -Not -Throw
        
        { New-AzHdInsightOnAksCluster -Name $clusterName -PoolName $clusterpoolName `
                -ResourceGroupName $clusterResourceGroupName `
                -Location $location `
                -ClusterType $clusterType `
                -ClusterVersion $clusterOfferingVersions[0].ClusterVersionValue -OssVersion $clusterOfferingVersions[0].OssVersion `
                -ComputeProfileNode $ComputeProfileNode `
                -AuthorizationUserId $env.authorizationUserId `
                -ManagedIdentityProfileIdentityList  $ManagedIdentity `
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
