$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwareCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVMwareCluster' {
    It 'CreateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
        # $job_cloud_new = New-AzVMwarePrivateCloud -Name $env.rstr1 -ResourceGroupName $env.resourceGroup -NetworkBlock 192.168.48.0/22 -SkuName av36 -ManagementClusterSize 3 -Location $env.location -AsJob
        # $job_cloud_new | Wait-Job
        # $cloud = ($job_cloud_new | Receive-Job)

        # $job_cluster_new = New-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.rstr1 -ResourceGroupName $env.resourceGroup -ClusterSize 3 -SkuName av36 -AsJob
        # $job_cluster_new | Wait-Job
        # $cluster = ($job_cluster_new | Receive-Job)
        # $cluster_get = Get-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.rstr1 -ResourceGroupName $env.resourceGroup
        
        # $job_cluster_update = Update-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.rstr1 -ResourceGroupName $env.resourceGroup -ClusterSize 4 -AsJob
        # $job_cluster_update | Wait-Job
        # $cluster_update = ($job_cluster_update | Receive-Job)
        # $cluster_get = Get-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.rstr1 -ResourceGroupName $env.resourceGroup

        # $job_cluster_remove = Remove-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.rstr1 -ResourceGroupName $env.resourceGroup -AsJob
        # $job_cluster_remove | Wait-Job
        # $cluster_remove = ($job_cluster_remove | Receive-Job)

        # $job_cloud_remove = Remove-AzVMwarePrivateCloud -ResourceGroupName $env.resourceGroup -Name $env.rstr1 -AsJob
        # $job_cloud_remove | Wait-Job
        # $cloud_remove = ($job_cloud_remove | Receive-Job)
    }
}
