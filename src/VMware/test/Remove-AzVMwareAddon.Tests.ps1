$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzVMwareAddon.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzVMwareAddon' {
    It 'Delete' {
        {
            Remove-AzVMwareAddon -Name vr -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGourp2
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $Id1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup1)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName1)/addons/srm"
            Remove-AzVMwareAddon -InputObject $Id1
        } | Should -Not -Throw
    }
}
