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
    It 'CreateExpanded' {
        {
            $keyValue = Get-AzVMwareAuthorization -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $circuitExpressRouteId = Get-AzVMwarePrivateCloud -Name $env.privateCloudName3 -ResourceGroupName $env.resourceGroup3

            $config = New-AzVMwareGlobalReachConnection -Name $env.rstr4 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -AuthorizationKey $keyValue.Key -PeerExpressRouteResourceId $circuitExpressRouteId.CircuitExpressRouteId
            $config.AuthorizationKey | Should -Be $keyValue.Key
        } | Should -Not -Throw
    }
}
