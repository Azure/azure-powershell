$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzVMwareCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzVMwareCluster' {
    It 'Delete' -skip {
        {
            $job_cluster_new = New-AzVMwareCluster -Name $env.rstr3 -PrivateCloudName $env.privatecloudname1 -ResourceGroupName $env.resourceGroup -ClusterSize 3 -SkuName av36 -AsJob
            $job_cluster_new | Wait-Job
            $job_cluster_new | Receive-Job

            $job_cluster_remove = Remove-AzVMwareCluster -Name $env.rstr3 -PrivateCloudName $env.privatecloudname1 -ResourceGroupName $env.resourceGroup -AsJob
            $job_cluster_remove | Wait-Job
            $job_cluster_remove | Receive-Job
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        {
            $job_cluster_new = New-AzVMwareCluster -Name $env.rstr3 -PrivateCloudName $env.privatecloudname1 -ResourceGroupName $env.resourceGroup -ClusterSize 3 -SkuName av36 -AsJob
            $job_cluster_new | Wait-Job
            $job_cluster_new | Receive-Job

            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGorup)/providers/Microsoft.AVS/privateClouds/$($env.privatecloudname1)/clusters/$($env.rstr3)"
            $job_cluster_remove = Remove-AzVMwareCluster -InputObject $ID -AsJob
            $job_cluster_remove | Wait-Job
            $job_cluster_remove | Receive-Job
        } | Should -Not -Throw
    }
}