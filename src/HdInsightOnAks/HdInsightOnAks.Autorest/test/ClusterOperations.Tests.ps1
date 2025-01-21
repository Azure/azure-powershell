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
        $location = "westus2"
        $resourceGroupName = "psGroup"

        $clusterpoolName = "ps-hilopool"
        $clusterType = "Spark"
        $poolvmSize = "Standard_D4a_v4"
        $clusterName = "ps-operations"
        $StorageUri = "abfs://ps-operations@yuchenhilostorage.dfs.core.windows.net"

        # { New-AzHdInsightOnAksClusterPool -Name "ps-hilopool11" -ResourceGroupName $resourceGroupName -VmSize $poolvmSize -Location $location -ClusterPoolVersion 1.1 } | Should -Not -Throw
        { New-AzHdInsightOnAksClusterPool -Name $clusterpoolName -ResourceGroupName $resourceGroupName -VmSize $poolvmSize -Location $location -ClusterPoolVersion 1.2 } | Should -Not -Throw
        # $clusterVersion11 = (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object { $_.ClusterType -eq $clusterType } | Where-Object ClusterPoolVersion -eq "1.1")[0]
        $clusterVersion12 = (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object { $_.ClusterType -eq $clusterType } | Where-Object ClusterPoolVersion -eq "1.2")[0]

        [Console]::WriteLine("Get-AzHdInsightOnAksAvailableClusterVersion done")
    }

    It "Get AzHdInsightOnAksLocationNameAvailability" {
        $teststring = $clusterpoolName, $clusterName -join "/"
        { $script:res = Test-AzHdInsightOnAksLocationNameAvailability -Location $location -Name  $teststring -Type Microsoft.HDInsight/clusterPools/clusters } | Should -Not -Throw
        $script:res.nameAvailable | Should -Be $true

        [Console]::WriteLine("Test-AzHdInsightOnAksLocationNameAvailability done")
    }

    It 'New AzHdInsightOnAksCluster version11' -Skip{
        { $script:ComputeProfileNode = New-AzHdInsightOnAksNodeProfileObject -Type "Worker" -Count 3 -VMSize "Standard_E8ads_v5" } | Should -Not -Throw
        $script:ComputeProfileNode.Type | Should -Be "Worker"
        $script:ComputeProfileNode.Count | Should -Be 3
        $script:ComputeProfileNode.VMSize | Should -Be "Standard_E8ads_v5"

        [Console]::WriteLine("New-AzHdInsightOnAksNodeProfileObject done")
        
        { New-AzHdInsightOnAksCluster -Name "ps-operations11" -PoolName "ps-hilopool11" `
                -ResourceGroupName $resourceGroupName `
                -Location $location `
                -ClusterType $clusterType `
                -ClusterVersion $clusterVersion11.ClusterVersionValue `
                -OssVersion $clusterVersion11.OssVersion `
                -ComputeProfileNode $script:ComputeProfileNode `
                -AuthorizationUserId $env.authorizationUserId `
                -AssignedIdentityClientId $env.msiClientId `
                -AssignedIdentityObjectId $env.msiObjectId `
                -AssignedIdentityResourceId $env.identityProfileMsiResourceId `
                -SparkStorageUrl $StorageUri 
        } | Should -Not -Throw

        [Console]::WriteLine("New-AzHdInsightOnAksCluster done")

    }

    It 'New AzHdInsightOnAksCluster version12' {
        { $script:ComputeProfileNode = New-AzHdInsightOnAksNodeProfileObject -Type "Worker" -Count 3 -VMSize "Standard_D8ds_v4" } | Should -Not -Throw
        [Console]::WriteLine("New-AzHdInsightOnAksNodeProfileObject done")

        { $script:ManagedIdentity = New-AzHdInsightOnAksManagedIdentityObject -ClientId $env.msiClientId -ObjectId $env.msiObjectId -ResourceId $env.identityProfileMsiResourceId -Type cluster } | Should -Not -Throw
        [Console]::WriteLine("New-AzHdInsightOnAksManagedIdentityObject done")
        
        { New-AzHdInsightOnAksCluster -Name $clusterName -PoolName $clusterpoolName `
                -ResourceGroupName $resourceGroupName `
                -Location $location `
                -ClusterType $clusterType `
                -ClusterVersion $clusterVersion12.ClusterVersionValue `
                -OssVersion $clusterVersion12.OssVersion `
                -ComputeProfileNode $script:ComputeProfileNode `
                -AuthorizationUserId $env.authorizationUserId `
                -ManagedIdentityProfileIdentityList  $ManagedIdentity `
                -SparkStorageUrl $StorageUri 
        } | Should -Not -Throw

        [Console]::WriteLine("New-AzHdInsightOnAksCluster done")

    }
        
    It 'Get AzHdInsightOnAksClusterWithClusterName' {
        { $script:cluster = Get-AzHdInsightOnAksCluster -ResourceGroupName $resourceGroupName -Name $clusterName -PoolName $clusterpoolName } | Should -Not -Throw
        $script:cluster | Should -Not -Be $null
        $script:cluster.Name | Should -Be $clusterName
        $script:cluster.Location | Should -Be $location

        [Console]::WriteLine("Get-AzHdInsightOnAksCluster done")
    }

    It 'Get AzHdInsightOnAksClusterWithPoolName' {
        { $script:clusters = Get-AzHdInsightOnAksCluster -ResourceGroupName $resourceGroupName -PoolName $clusterpoolName } | Should -Not -Throw
        $script:clusters | Should -Not -Be $null
        $script:clusters[0].Location | Should -Be $location

        [Console]::WriteLine("Get-AzHdInsightOnAksCluster done")
    }

    It "Resize AzHdInsightOnAksCluster" {
        { Resize-AzHdInsightOnAksCluster -ResourceGroupName $resourceGroupName -Location $location -PoolName $clusterpoolName -Name $clusterName -TargetWorkerNodeCount 4 } | Should -Not -Throw
        { $script:cluster = Get-AzHdInsightOnAksCluster -ResourceGroupName $resourceGroupName -PoolName $clusterpoolName -Name $clustername } | Should -Not -Throw
        $script:cluster.ComputeProfileNode[1].Count | Should -Be 4

        [Console]::WriteLine("Resize-AzHdInsightOnAksCluster done")
    }

    It 'Get AzHdInsightOnAksClusterInstanceView' {
        { $script:instance = Get-AzHdInsightOnAksClusterInstanceView -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName } | Should -Not -Throw

        $script:instance | Should -Not -Be $null
        $script:instance.StatusReady | Should -Be $true

        [Console]::WriteLine("Get-AzHdInsightOnAksClusterInstanceView done")
    }

    It 'Remove AzHdInsightOnAksCluster' {
        { Remove-AzHdInsightOnAksCluster -ResourceGroupName $resourceGroupName -Name $clusterName -PoolName $clusterpoolName } | Should -Not -Throw

        [Console]::WriteLine("Remove-AzHdInsightOnAksCluster done")
    }
}
