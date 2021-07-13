$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVMwareAuthorization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzVMwareAuthorization' {
    It 'List' {
        {
            New-AzVMwareAuthorization -Name $env.rstr3 -PrivateCloudName $env.privatecloudname1 -ResourceGroupName $env.resourceGroup
            Get-AzVMwareAuthorization -PrivateCloudName $env.privatecloudname1 -ResourceGroupName $env.resourceGroup
            Remove-AzVMwareAuthorization -Name $env.rstr3 -PrivateCloudName $env.privatecloudname1 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            New-AzVMwareAuthorization -Name $env.rstr3 -PrivateCloudName $env.privatecloudname1 -ResourceGroupName $env.resourceGroup
            Get-AzVMwareAuthorization -Name $env.rstr3 -PrivateCloudName $env.privatecloudname1 -ResourceGroupName $env.resourceGroup
            Remove-AzVMwareAuthorization -Name $env.rstr3 -PrivateCloudName $env.privatecloudname1 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            New-AzVMwareAuthorization -Name $env.rstr3 -PrivateCloudName $env.privatecloudname1 -ResourceGroupName $env.resourceGroup
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.AVS/privateClouds/$($env.privatecloudname1)/authorizations/$($env.rstr3)"
            Get-AzVMwareAuthorization -InputObject $ID
            Remove-AzVMwareAuthorization -Name $env.rstr3 -PrivateCloudName $env.privatecloudname1 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
