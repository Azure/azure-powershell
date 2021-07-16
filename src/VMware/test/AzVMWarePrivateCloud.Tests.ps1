$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwarePrivateCloud.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwarePrivateCloud' {
    It 'Expanded' {
        { 
            New-AzVMwarePrivateCloud -Name $env.rstr1 -ResourceGroupName $env.resourceGroup1 -NetworkBlock 192.168.48.0/22 -Sku av36 -ManagementClusterSize 3 -Location $env.location -AcceptEULA
            New-AzVMwarePrivateCloud -Name $env.rstr2 -ResourceGroupName $env.resourceGroup2 -NetworkBlock 192.168.48.0/22 -Sku av20 -ManagementClusterSize 3 -Location $env.location -AcceptEULA
            $Id1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup1)/providers/Microsoft.AVS/privateClouds/$($env.rstr1)"
            $Id2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup2)/providers/Microsoft.AVS/privateClouds/$($env.rstr2)"

            Get-AzVMwarePrivateCloud
            Get-AzVMwarePrivateCloud -ResourceGroupName $env.resourceGroup1

            Update-AzVMwarePrivateCloud -Name $env.rstr1 -ResourceGroupName $env.resourceGroup1 -ManagementClusterSize 4

            Get-AzVMwarePrivateCloud -InputObject $Id1

            Update-AzVMwarePrivateCloud -InputObject $ID2 -ManagementClusterSize 4

            Get-AzVMwarePrivateCloud -Name $env.rstr2 -ResourceGroupName $env.resourceGroup2

            Remove-AzVMwarePrivateCloud -ResourceGroupName $env.resourceGroup1 -Name $env.rstr1
            Remove-AzVMwarePrivateCloud -InputObject $Id2
        } | Should -Not -Throw
    }
}