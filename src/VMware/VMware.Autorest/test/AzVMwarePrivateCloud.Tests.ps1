$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwarePrivateCloud.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwarePrivateCloud' {
    It 'List1' {
        {
            $config = New-AzVMwarePrivateCloud -Name $env.rstr1 -ResourceGroupName $env.resourceGroup1 -NetworkBlock 192.168.48.0/22 -Sku av36 -ManagementClusterSize 3 -Location $env.location1 -AcceptEULA
            $config.ManagementClusterSize | Should -BeGreaterThan 0
            
            $config = Get-AzVMwarePrivateCloud
            $config | Should -Not -Be $NULL
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzVMwarePrivateCloud -Name $env.rstr1 -ResourceGroupName $env.resourceGroup1
            $config.ManagementClusterSize | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzVMwarePrivateCloud -ResourceGroupName $env.resourceGroup1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'CreateExpanded' {
        {
            $config = New-AzVMwarePrivateCloud -Name $env.rstr2 -ResourceGroupName $env.resourceGroup2 -NetworkBlock 192.168.48.0/22 -Sku av20 -ManagementClusterSize 3 -Location $env.location1 -AcceptEULA
            $config.ManagementClusterSize | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzVMwarePrivateCloud -Name $env.rstr2 -ResourceGroupName $env.resourceGroup2
            $config.ManagementClusterSize | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $Id2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup2)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName2)"
            $config = Update-AzVMwarePrivateCloud -InputObject $Id2
            $config.ManagementClusterSize | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzVMwarePrivateCloud -ResourceGroupName $env.resourceGroup2 -Name $env.rstr2 -Confirm:$false
        } | Should -Not -Throw
    }
}