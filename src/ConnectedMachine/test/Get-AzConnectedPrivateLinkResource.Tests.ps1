$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedPrivateLinkResource.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzConnectedPrivateLinkResource' {
    BeforeAll {
        $resourceGroupName = $env.ResourceGroupName
        $scopeName = $env.PrivateLinkScopeName
    }

    It "Get Private Link Resource" {
        $all = @(Get-AzConnectedPrivateLinkResource -ResourceGroupName $resourceGroupName -ScopeName $scopeName)
        $all[0].Name | Should -Be "hybridcompute"
        $all[0].Type | Should -Be "Microsoft.HybridCompute/privateLinkScopes/privateLinkResources"
    }
}
