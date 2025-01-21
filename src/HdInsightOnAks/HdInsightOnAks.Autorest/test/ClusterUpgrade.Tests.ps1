if (($null -eq $TestName) -or ($TestName -contains 'ClusterUpgrade')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'sessionRecords\ClusterUpgrade.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'ClusterUpgrade' {
    BeforeAll {
        # Cluster configuration info
        $location = "West US 2"
        $clusterResourceGroupName = "psGroup"
        $clusterpoolName = "ps-upgrade-pool"
        $clusterName = "ps-trino"
        $poolVmSize = "Standard_D4a_v4"
        $clusterPoolVersion = "1.2"
        $clusterType = "Trino"
        $clusterOfferingVersions = Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object ClusterPoolVersion -eq $clusterPoolVersion | Where-Object ClusterType -eq $clusterType
        $StorageUri = "abfs://pscontainer1@yuchenhilostorage.dfs.core.windows.net"
        $ComputeProfileNode = New-AzHdInsightOnAksNodeProfileObject -Type "Worker" -Count 3 -VMSize "Standard_D4d_v5"
    }

    It "New clusterpool" -Skip {
        { New-AzHdInsightOnAksClusterPool -Name $clusterpoolName -ResourceGroupName $clusterResourceGroupName -VmSize $poolvmSize -Location $location -ClusterPoolVersion $clusterPoolVersion } | Should -Not -Throw
        [Console]::WriteLine("New-AzHdInsightOnAksClusterPool done")
    }

    # If you have donnot have a cluster, you can use this test to create a cluster, and then run other tests.
    It "New-AzHdInsightOnAksCluster_Trino" {
        { $script:ManagedIdentity = New-AzHdInsightOnAksManagedIdentityObject -ClientId $env.msiClientId -ObjectId $env.msiObjectId -ResourceId $env.identityProfileMsiResourceId -Type cluster } | Should -Not -Throw
        

        { New-AzHdInsightOnAksCluster -Name $clusterName -PoolName $clusterpoolName `
                -ResourceGroupName $clusterResourceGroupName `
                -Location $location `
                -ClusterType $clusterType `
                -ClusterVersion $clusterOfferingVersions[0].ClusterVersionValue -OssVersion $clusterOfferingVersions[0].OssVersion `
                -ComputeProfileNode $ComputeProfileNode `
                -AuthorizationUserId $env.authorizationUserId `
                -ManagedIdentityProfileIdentityList  $ManagedIdentity  } | Should -Not -Throw
        
        [Console]::WriteLine("New-AzHdInsightOnAksCluster_Trino done")
    }

    It 'Get AzHdInsightOnAksClusterPool available upgrade' {
        { Get-AzHdInsightOnAksClusterPoolAvailableUpgrade -ResourceGroupName $clusterResourceGroupName -ClusterPoolName $clusterpoolName } | Should -Not -Throw

        [Console]::WriteLine("Get-AzHdInsightOnAksClusterPoolAvailableUpgrade done")
    }

    It "Upgrade ClusterPool" -Skip {
        { Invoke-AzHdInsightOnAksClusterPoolUpgrade -ResourceGroupName $clusterResourceGroupName -ClusterPoolName $clusterpoolName -UpgradeType "NodeOsUpgrade"  } | Should -Not -Throw
        [Console]::WriteLine("Invoke-AzHdInsightOnAksClusterPoolUpgrade done")
    }

    It "List ClusterPool upgrade history" {
        {Get-AzHdInsightOnAksClusterPoolUpgradeHistory -ResourceGroupName $clusterResourceGroupName -ClusterPoolName $clusterpoolName} | Should -Not -Throw
        [Console]::WriteLine("Get-AzHdInsightOnAksClusterPoolUpgradeHistory done")
    }

    It 'Get AzHdInsightOnAksCluster available upgrade' {
        { Get-AzHdInsightOnAksClusterAvailableUpgrade -ResourceGroupName $clusterResourceGroupName -ClusterPoolName $clusterpoolName -ClusterName $clusterName} | Should -Not -Throw

        [Console]::WriteLine("Get-AzHdInsightOnAksClusterPoolAvailableUpgrade done")
    }

    It "Upgrade Cluster" -Skip{
        { Invoke-AzHdInsightOnAksClusterUpgrade -ResourceGroupName $clusterResourceGroupName -ClusterPoolName $clusterpoolName  -ClusterName $clusterName -UpgradeType "NodeOsUpgrade"  } | Should -Not -Throw
        [Console]::WriteLine("Invoke-AzHdInsightOnAksClusterUpgrade done")

    }

    It "List Cluster upgrade history" {
        {Get-AzHdInsightOnAksClusterUpgradeHistory -ResourceGroupName $clusterResourceGroupName -ClusterPoolName $clusterpoolName  -ClusterName $clusterName} | Should -Not -Throw
        [Console]::WriteLine("Get-AzHdInsightOnAksClusterPoolUpgradeHistory done")
    }
}
