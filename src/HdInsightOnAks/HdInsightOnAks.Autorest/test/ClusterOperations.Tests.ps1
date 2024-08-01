if (($null -eq $TestName) -or ($TestName -contains 'ClusterOperations')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'sessionRecords\ClusterOperations.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

# If you did not manually create a clusterpool, please uncomment the code.
Describe 'ClusterOperations' {
    BeforeAll {
        $location = "West US 3"
        # need create resources group manually.
        $clusterResourceGroupName = "PStestGroup"
        $clusterpoolName = "hilo-pool"
        $clusterType = "Spark"
        $poolvmSize = "Standard_E4s_v3"
        $clusterName = "testpsoperations"
        $StorageUri = "abfs://pscontainer2@hilostorage.dfs.core.windows.net"
        { New-AzHdInsightOnAksClusterPool -Name $clusterpoolName -ResourceGroupName $clusterResourceGroupName -VmSize $poolvmSize -Location $location -ClusterPoolVersion 1.1 } | Should -Not -Throw
        $clusterVersion = (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object { $_.ClusterType -eq $clusterType } | Where-Object ClusterPoolVersion -eq "1.1")[0]

        [Console]::WriteLine("Get-AzHdInsightOnAksAvailableClusterVersion done")
    }

    It "Get AzHdInsightOnAksLocationNameAvailability" {
        $teststring = $clusterpoolName, $clusterName -join "/"
        { $script:res = Test-AzHdInsightOnAksLocationNameAvailability -Location $location -Name  $teststring -Type Microsoft.HDInsight/clusterPools/clusters } | Should -Not -Throw
        $script:res.nameAvailable | Should -Be $true

        [Console]::WriteLine("Test-AzHdInsightOnAksLocationNameAvailability done")
    }

    It 'New AzHdInsightOnAksCluster' {
        { $script:ComputeProfileNode = New-AzHdInsightOnAksNodeProfileObject -Type "Worker" -Count 3 -VMSize "Standard_D16a_v4" } | Should -Not -Throw
        $script:ComputeProfileNode.Type | Should -Be "Worker"
        $script:ComputeProfileNode.Count | Should -Be 3
        $script:ComputeProfileNode.VMSize | Should -Be "Standard_D16a_v4"

        [Console]::WriteLine("New-AzHdInsightOnAksNodeProfileObject done")
        
        { New-AzHdInsightOnAksCluster -Name $clusterName -PoolName $clusterpoolName `
                -ResourceGroupName $clusterResourceGroupName `
                -Location $location `
                -ClusterType $clusterType `
                -ClusterVersion $clusterVersion.ClusterVersionValue `
                -OssVersion $clusterVersion.OssVersion `
                -ComputeProfileNode $script:ComputeProfileNode `
                -AuthorizationUserId $env.authorizationUserId `
                -AssignedIdentityClientId $env.msiClientId `
                -AssignedIdentityObjectId $env.msiObjectId `
                -AssignedIdentityResourceId $env.identityProfileMsiResourceId `
                -SparkStorageUrl $StorageUri 
        } | Should -Not -Throw

        [Console]::WriteLine("New-AzHdInsightOnAksCluster done")

    }
        
    It 'Get AzHdInsightOnAksClusterWithClusterName' {
        { $script:cluster = Get-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -Name $clusterName -PoolName $clusterpoolName } | Should -Not -Throw
        $script:cluster | Should -Not -Be $null
        $script:cluster.Name | Should -Be $clusterName
        $script:cluster.Location | Should -Be $location

        [Console]::WriteLine("Get-AzHdInsightOnAksCluster done")
    }

    It 'Get AzHdInsightOnAksClusterWithPoolName' {
        { $script:clusters = Get-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -PoolName $clusterpoolName } | Should -Not -Throw
        $script:clusters | Should -Not -Be $null
        $script:clusters[0].Name | Should -Be $clusterName
        $script:clusters[0].Location | Should -Be $location

        [Console]::WriteLine("Get-AzHdInsightOnAksCluster done")
    }

    It "Resize AzHdInsightOnAksCluster" {
        { Resize-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -Location $location -PoolName $clusterpoolName -Name $clusterName -TargetWorkerNodeCount 6 } | Should -Not -Throw
        { $script:cluster = Get-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -PoolName $clusterpoolName -Name $clustername } | Should -Not -Throw
        $script:cluster.ComputeProfileNode[1].Count | Should -Be 6

        [Console]::WriteLine("Resize-AzHdInsightOnAksCluster done")
    }

    It 'Get AzHdInsightOnAksClusterInstanceView' {
        { $script:instance = Get-AzHdInsightOnAksClusterInstanceView -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName } | Should -Not -Throw

        $script:instance | Should -Not -Be $null
        $script:instance.StatusReady | Should -Be $true
        [Console]::WriteLine("Get-AzHdInsightOnAksClusterInstanceView done")
    }

    It 'Remove AzHdInsightOnAksCluster' {
        { Remove-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -Name $clusterName -PoolName $clusterpoolName } | Should -Not -Throw

        [Console]::WriteLine("Remove-AzHdInsightOnAksCluster done")
    }

    # AfterAll {
    #     { Remove-AzHdInsightOnAksClusterPool -ResourceGroupName $clusterResourceGroupName -Name $clusterpoolName } | Should -Not -Throw

    #     [Console]::WriteLine("Remove-AzHdInsightOnAksClusterPool done")

    # }
}
