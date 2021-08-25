$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVMwareAddon.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzVMwareAddon' {
    It 'List' {
        {
            $config = New-AzVMwareAddonVrPropertiesObject -VrsCount 2
            $config = New-AzVMwareAddon -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -Property $config
            $config.Name | Should -Be "VR"

            $config = Get-AzVMwareAddon -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzVMwareAddon -AddonType vr -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Name | Should -Be "vr"
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $Id1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup1)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName1)/addons/vr"
            $config = Get-AzVMwareAddon -InputObject $Id1
            $config.Type | Should -Be "Microsoft.AVS/privateClouds/addons"
        } | Should -Not -Throw
    }
}
