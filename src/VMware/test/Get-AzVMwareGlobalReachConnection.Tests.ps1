$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVMwareGlobalReachConnection.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzVMwareGlobalReachConnection' {
    It 'List' {
        {
            $keyValue = Get-AzVMwareExpressRouteAuthorization -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $circuitExpressRouteId = Get-AzVMwarePrivateCloud -Name $env.privateCloudName3 -ResourceGroupName $env.resourceGroup3

            $config = New-AzVMwareGlobalReachConnection -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -AuthorizationKey $keyValue.Key -PeerExpressRouteResourceId $circuitExpressRouteId.CircuitExpressRouteId
            $config.AuthorizationKey | Should -Be $keyValue.Key

            $config = Get-AzVMwareGlobalReachConnection -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzVMwareGlobalReachConnection -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Key | Should -Be $keyValue.Key
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $Id3 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup1)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName1)/globalReachConnections/$($env.rstr3)"
            $config = Get-AzVMwareGlobalReachConnection -InputObject $Id3
            $config.CircuitExpressRouteId | Should -Be $circuitExpressRouteId.CircuitExpressRouteId
        } | Should -Not -Throw
    }
}
