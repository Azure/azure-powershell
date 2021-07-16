$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwareGlobalReachConnection.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVMwareGlobalReachConnection' {
    It 'CreateExpanded' -skip {
        {
            New-AzVMwareAuthorization -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup

            New-AzVMwareGlobalReachConnection -Name $env.rstr4 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup

        } | Should -Not -Throw
    }
}
