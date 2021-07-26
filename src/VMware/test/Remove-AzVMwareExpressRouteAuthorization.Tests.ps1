$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzVMwareExpressRouteAuthorization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzVMwareExpressRouteAuthorization' {
    It 'Delete' {
        {
            Remove-AzVMwareExpressRouteAuthorization -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $Id3 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup3)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName3)/authorizations/$($env.rstr4)"
            Remove-AzVMwareExpressRouteAuthorization -InputObject $Id3
        } | Should -Not -Throw
    }
}
