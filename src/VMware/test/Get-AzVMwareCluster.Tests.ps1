$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVMwareCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzVMwareCluster' {
    It 'List' {
        {
            $config = New-AzVMwareCluster -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -ClusterSize 3 -SkuName av20
            $config.Name | Should -Be $env.rstr1

            $config = Get-AzVMwareCluster -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }
    
    It 'Get' {
        {
            $config = Get-AzVMwareCluster -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.ClusterSize | Should -Be 3
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $Id1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup1)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName1)/clusters/$($env.rstr1)"
            $config = Get-AzVMwareCluster -InputObject $Id1
            $config.SkuName | Should -Be "av20"
        } | Should -Not -Throw
    }
}
