if (($null -eq $TestName) -or ($TestName -contains 'ClusterJob')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'sessionRecords\ClusterJob.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'ClusterJob' {
    BeforeAll {
        # Cluster configuration info
        $location = "westus2"
        $clusterResourceGroupName = "psGroup"
        $clusterpoolName = "ps-hilopool"
        $clusterName = "ps-flink12"
        $clusterType = "Flink"
        $clusterVersion = (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object { $_.ClusterType -eq $clusterType } | Where-Object ClusterPoolVersion -eq "1.2")
        $ComputeProfileNode = New-AzHdInsightOnAksNodeProfileObject -Type "Worker" -Count 3 -VMSize "Standard_D4a_v4"

        $StorageUri = "abfs://flinkdemo125dfsuoi@flinkdemo125stuoi.dfs.core.windows.net"
    }

    # If you do not have a cluster, please use this to create a cluster, then do the following tests.
    It "New-AzHdInsightOnAksCluster_Flink" -skip {

        { $script:ManagedIdentity = New-AzHdInsightOnAksManagedIdentityObject -ClientId $env.msiClientId -ObjectId $env.msiObjectId -ResourceId $env.identityProfileMsiResourceId -Type cluster } | Should -Not -Throw
        [Console]::WriteLine("New-AzHdInsightOnAksManagedIdentityObject done")

        New-AzHdInsightOnAksCluster -Name $clusterName -PoolName $clusterpoolName `
            -ResourceGroupName $clusterResourceGroupName `
            -Location $location `
            -ClusterType $clusterType `
            -ClusterVersion $clusterVersion.ClusterVersionValue `
            -OssVersion $clusterVersion.OssVersion `
            -ComputeProfileNode $ComputeProfileNode `
            -AuthorizationUserId $env.authorizationUserId `
            -ManagedIdentityProfileIdentityList  $ManagedIdentity `
            -FlinkStorageUrl $storageUri `
            -JobManagerCpu 1 -JobManagerMemory 2000 -HistoryServerCpu 0.25 -HistoryServerMemory 2000 -TaskManagerCpu 14 -TaskManagerMemory 49016
        
        [Console]::WriteLine("New-AzHdInsightOnAksCluster_Flink done")
    }

    
    It "Start-AzHdInsightOnAksClusterJob" {

        $flinkJobProperties = New-AzHdInsightOnAksFlinkJobObject -Action "NEW" -JobName "job1" `
            -JarName "FlinkJobDemo-1.0-SNAPSHOT.jar" -EntryClass "org.example.SleepJob" `
            -JobJarDirectory "abfs://flinkdemo125dfsuoi@flinkdemo125stuoi.dfs.core.windows.net/jars" `
            -FlinkConfiguration @{parallelism = 1 }

        [Console]::WriteLine("New-AzHdInsightOnAksFlinkJobProperties done")

        { $script:jobRes = Start-AzHdInsightOnAksClusterJob -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName -ClusterJob $flinkJobProperties } | Should -Not -Throw
        $script:jobRes.JobType | Should -Be "FlinkJob"
        $script:jobRes.Id | Should -Not -BeNullOrEmpty

        [Console]::WriteLine("Start-AzHdInsightOnAksClusterJob done")
    }



    It "Get-AzHdInsightOnAksClusterJob" {

        { $script:jobs = Get-AzHdInsightOnAksClusterJob -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName }  | Should -Not -Throw
        $script:jobs[0].JobType | Should -Be "FlinkJob"

        [Console]::WriteLine("Get-AzHdInsightOnAksClusterJob done")
    }

}
