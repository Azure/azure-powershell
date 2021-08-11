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
    It 'List' -skip {
        {
            $config = New-AzVMwareAddonVrPropertiesObject -AddonType VR -VrsCount 2
            $config = New-AzVMwareAddon -Name vr -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGourp1 -Property $config
            $config.Name | Should -Be "VR"

            $config = Get-AzVMwareAddon -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGourp1
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzVMwareAddon -Name vr -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGourp1
            $config.Name | Should -Be "vr"
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $Id1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup1)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName1)/addons/srm"
            $config = Get-AzVMwareAddon -InputObject $Id1
            $config.Type | Should -Be "Microsoft.AVS/privateClouds/addons"
        } | Should -Not -Throw
    }
}
