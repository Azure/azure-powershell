$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareAddon.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareAddon' {
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

    It 'CreateExpanded' {
        {
            $config = New-AzVMwareAddonVrPropertiesObject -VrsCount 2
            $config = New-AzVMwareAddon -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2 -Property $config
            $config.Name | Should -Be "VR"
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzVMwareAddon -AddonType vr -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2
        } | Should -Not -Throw
    }
}
