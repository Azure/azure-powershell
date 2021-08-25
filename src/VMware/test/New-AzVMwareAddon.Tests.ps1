$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwareAddon.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVMwareAddon' {
    It 'CreateExpanded' {
        {
            $config = New-AzVMwareAddonVrPropertiesObject -VrsCount 2
            $config = New-AzVMwareAddon -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2 -Property $config
            $config.Name | Should -Be "VR"
        } | Should -Not -Throw
    }
}
