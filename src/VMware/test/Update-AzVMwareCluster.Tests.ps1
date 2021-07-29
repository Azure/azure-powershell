$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzVMwareCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzVMwareCluster' {
    It 'UpdateExpanded' {
        {
            $config = New-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2 -ClusterSize 3 -SkuName av36
            $config.Name | Should -Be $env.rstr2

            $config = Update-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2 -ClusterSize 4
            $config.Name | Should -Be $env.rstr2

            Remove-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = New-AzVMwareCluster -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -ClusterSize 3 -SkuName av20
            $config.Name | Should -Be $env.rstr1

            $Id1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup1)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName1)/clusters/$($env.rstr1)"
            $config = Update-AzVMwareCluster -InputObject $Id1 -ClusterSize 4
            $config.Name | Should -Be $env.rstr1

            Remove-AzVMwareCluster -InputObject $Id1
        } | Should -Not -Throw
    }
}
