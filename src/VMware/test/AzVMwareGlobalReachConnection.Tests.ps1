$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareGlobalReachConnection.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareGlobalReachConnection' {
    It 'List' {
        {
            $keyValue = Get-AzVMwareAuthorization -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $circuitExpressRouteId = Get-AzVMwarePrivateCloud -Name $env.privateCloudName3 -ResourceGroupName $env.resourceGroup3

            $config = New-AzVMwareGlobalReachConnection -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -AuthorizationKey $keyValue.Key -PeerExpressRouteResourceId $circuitExpressRouteId.CircuitExpressRouteId
            # $config.AuthorizationKey | Should -Be $keyValue.Key
            $config.AuthorizationKey | Should -Be "01010101-0101-0101-0101-010101010101"

            $config = Get-AzVMwareGlobalReachConnection -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzVMwareGlobalReachConnection -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.AuthorizationKey | Should -Be "01010101-0101-0101-0101-010101010101"
            $config.Key | Should -Be $keyValue.Key
        } | Should -Not -Throw
    }

    It 'CreateExpanded' {
        {
            $keyValue = Get-AzVMwareAuthorization -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $circuitExpressRouteId = Get-AzVMwarePrivateCloud -Name $env.privateCloudName3 -ResourceGroupName $env.resourceGroup3

            $config = New-AzVMwareGlobalReachConnection -Name $env.rstr4 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -AuthorizationKey $keyValue.Key -PeerExpressRouteResourceId $circuitExpressRouteId.CircuitExpressRouteId
            $config.AuthorizationKey | Should -Be "01010101-0101-0101-0101-010101010101"
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzVMwareGlobalReachConnection -Name $env.rstr4 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
        } | Should -Not -Throw
    }
}
