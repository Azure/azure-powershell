$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzVMwarePrivateCloud.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzVMwarePrivateCloud' {
    It 'UpdateExpanded' {
        {
            $config = Update-AzVMwarePrivateCloud -Name $env.rstr1 -ResourceGroupName $env.resourceGroup1 -ManagementClusterSize 4
            $config.ManagementClusterSize | Should -Be 4
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $Id2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup2)/providers/Microsoft.AVS/privateClouds/$($env.rstr2)"
            $config = Update-AzVMwarePrivateCloud -InputObject $ID2 -ManagementClusterSize 4
            $config.ManagementClusterSize | Should -Be 4
        } | Should -Not -Throw
    }
}