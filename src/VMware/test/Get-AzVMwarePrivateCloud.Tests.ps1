$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVMwarePrivateCloud.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzVMwarePrivateCloud' {
    It 'List1' {
        {
            $config = New-AzVMwarePrivateCloud -Name $env.rstr1 -ResourceGroupName $env.resourceGroup1 -NetworkBlock 192.168.48.0/22 -Sku av36 -ManagementClusterSize 3 -Location $env.location1 -AcceptEULA
            $config.ManagementClusterSize | Should -Be 3
            
            $config = Get-AzVMwarePrivateCloud
            $config | Should -Not -Be $NULL
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Update-AzVMwarePrivateCloud -Name $env.rstr1 -ResourceGroupName $env.resourceGroup1 -ManagementClusterSize 4
            $config.ManagementClusterSize | Should -Be 4
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzVMwarePrivateCloud -ResourceGroupName $env.resourceGroup1
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $Id1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup1)/providers/Microsoft.AVS/privateClouds/$($env.rstr1)"
            $config = Get-AzVMwarePrivateCloud -InputObject $Id1
            $config.Name | Should -Be $env.rstr1
        } | Should -Not -Throw
    }
}