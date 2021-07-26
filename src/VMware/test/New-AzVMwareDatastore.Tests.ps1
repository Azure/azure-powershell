$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwareDatastore.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVMwareDatastore' {
    It 'CreateExpanded' {
        {
            New-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup -ClusterSize 3 -SkuName av36

            New-AzVMwareDatastore -Name $env.rstr3 -ClusterName $env.rstr2 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup

            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName1)/clusters/$($env.rstr2)/datastores/$($env.rstr3)"
            Get-AzVMwareDatastore -ClusterName $env.rstr2 -PrivateCloudName $env.rstr1 -ResourceGroupName $env.resourceGroup
            Get-AzVMwareDatastore -Name $env.rstr3 -ClusterName $env.rstr2 -PrivateCloudName $env.rstr1 -ResourceGroupName $env.resourceGroup
            Get-AzVMwareDatastore -InputObject $ID

            Remove-AzVMwareDatastore -InputObject $ID

        } | Should -Not -Throw
    }
}
