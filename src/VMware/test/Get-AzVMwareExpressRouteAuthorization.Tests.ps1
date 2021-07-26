$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVMwareExpressRouteAuthorization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzVMwareExpressRouteAuthorization' {
    It 'List' {
        {
            $config = New-AzVMwareExpressRouteAuthorization -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Name | Should -Be $env.rstr3

            $config = Get-AzVMwareExpressRouteAuthorization -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Count | Should -Be 2
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzVMwareExpressRouteAuthorization -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Name | Should -Be $env.rstr3
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $Id1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup1)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName1)/authorizations/$($env.rstr3)"
            $config = Get-AzVMwareExpressRouteAuthorization -InputObject $Id1
            $config.Name | Should -Be $env.rstr3
        } | Should -Not -Throw
    }
}
