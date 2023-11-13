if(($null -eq $TestName) -or ($TestName -contains 'ClusterJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'sessionRecords\ClusterJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'ClusterJob' {
    BeforeAll {
        # Cluster configuration info
        $location = "West US 3"
        $clusterResourceGroupName = "Group"
        $clusterpoolName = "ps-test-pool"
        $clusterName = "flinkcluster"

        $clusterType = "Flink"
        $vmSize = "Standard_E4s_v3"
        $clusterVersion= (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object {$_.ClusterType -eq $clusterType})[0]
        $ComputeProfileNode = New-AzHdInsightOnAksNodeProfileObject -Type "Worker" -Count 3 -VMSize "Standard_D8d_v5"
    }

    # If you do not have a cluster, please use this to create a cluster, then do the following tests.
    It "New-AzHdInsightOnAksCluster_Flink" -Skip {
        $clusterName = "testpsflink1"
        $storageUri = "abfs://testcontainerflink2@hilostorage.dfs.core.windows.net"

        New-AzHdInsightOnAksCluster -Name $clusterName -PoolName $clusterpoolName `
        -ResourceGroupName $clusterResourceGroupName `
        -Location $location `
        -ClusterType $clusterType `
        -ClusterVersion $clusterVersion.ClusterVersionValue `
        -OssVersion $clusterVersion.OssVersion `
        -ComputeProfileNode $ComputeProfileNode `
        -AuthorizationUserId $env.authorizationUserId `
        -AssignedIdentityClientId $env.msiClientId `
        -AssignedIdentityObjectId $env.msiObjectId `
        -AssignedIdentityResourceId $env.identityProfileMsiResourceId `
        -FlinkStorageUrl $storageUri `
        -JobManagerCpu 1 -JobManagerMemory 2000 -TaskManagerCpu 6 -TaskManagerMemory 49016
        
        [Console]::WriteLine("New-AzHdInsightOnAksCluster_Flink done")
    }

    
    It "Start-AzHdInsightOnAksClusterJob"{

        $flinkJobProperties = New-AzHdInsightOnAksFlinkJobObject -Action "NEW" -JobName "job1" `
        -JarName "JarName" -EntryClass "com.microsoft.hilo.flink.job.streaming.SleepJob" `
        -JobJarDirectory "abfs://flinkjob@hilosa.dfs.core.windows.net/jars" `
        -FlinkConfiguration @{parallelism=1}

        [Console]::WriteLine("New-AzHdInsightOnAksFlinkJobProperties done")

        {$script:jobRes=Start-AzHdInsightOnAksClusterJob -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName -ClusterJob $flinkJobProperties} | Should -Not -Throw
        $script:jobRes.JobType | Should -Be "FlinkJob"
        $script:jobRes.Id | Should -Not -BeNullOrEmpty

        [Console]::WriteLine("Start-AzHdInsightOnAksClusterJob done")
    }



    It "Start-AzHdInsightOnAksClusterJob"{

        {$script:jobs=Get-AzHdInsightOnAksClusterJob -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName }  | Should -Not -Throw
        $script:jobs[0].JobType | Should -Be "FlinkJob"

        [Console]::WriteLine("Get-AzHdInsightOnAksClusterJob done")
    }

    AfterAll{
        # Remove-AzHdInsightOnAksClusterPool -ResourceGroupName $clusterResourceGroupName -Name $clusterpoolName 
    }

}
