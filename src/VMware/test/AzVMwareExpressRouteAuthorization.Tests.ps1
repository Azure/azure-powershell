$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareExpressRouteAuthorization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareExpressRouteAuthorization' {
    It 'Expanded' {
        {
            New-AzVMwareAuthorization -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            New-AzVMwareAuthorization -Name $env.rstr2 -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2
            $Id1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup1)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName1)/authorizations/$($env.rstr1)"
            $Id2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup2)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName2)/authorizations/$($env.rstr2)"

            Get-AzVMwareAuthorization -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1

            Get-AzVMwareAuthorization -Name $env.rstr2 -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2

            Get-AzVMwareAuthorization -InputObject $Id1

            Remove-AzVMwareAuthorization -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            Remove-AzVMwareAuthorization -InputObject $Id2
        } | Should -Not -Throw
    }
}