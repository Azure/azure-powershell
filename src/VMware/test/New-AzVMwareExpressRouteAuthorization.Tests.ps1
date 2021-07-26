$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwareExpressRouteAuthorization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVMwareExpressRouteAuthorization' {
    It 'CreateExpanded' {
        {
            $config = New-AzVMwareExpressRouteAuthorization -Name $env.rstr4 -PrivateCloudName $env.privateCloudName3 -ResourceGroupName $env.resourceGroup3
            $config.Name | Should -Be $env.rstr4
        } | Should -Not -Throw
    }
}
