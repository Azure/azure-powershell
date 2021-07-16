$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareCluster' {
    It 'Expanded' {
        {
            New-AzVMwareCluster -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -ClusterSize 3 -SkuName av20
            New-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2 -ClusterSize 3 -SkuName av36
            $Id1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGorup1)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName1)/clusters/$($env.rstr1)"
            $Id2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGorup2)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName2)/clusters/$($env.rstr2)"

            Get-AzVMwareCluster -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1

            Get-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2

            Update-AzVMwareCluster -InputObject $Id1 -ClusterSize 4
            Update-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2 -ClusterSize 4

            Get-AzVMwareCluster -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            Get-AzVMwareCluster -InputObject $Id2

            Remove-AzVMwarePrivateCloud -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -Name $env.rstr1
            Remove-AzVMwarePrivateCloud -InputObject $Id2
        } | Should -Not -Throw
    }
}