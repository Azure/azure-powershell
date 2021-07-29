$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVMwareCloudLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzVMwareCloudLink' {
    It 'List' {
        {
            $Id2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup2)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName2)"
            $config = New-AzVMwareCloudLink -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -LinkedCloud $Id2
            $config.Name | Should -Be $env.rstr3

            $config = Get-AzVMwareCloudLink -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzVMwareCloudLink -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Name | Should -Be $env.rstr3
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { 
            $Id2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup1)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName1)/cloudLinks/$($env.rstr3)"
            $config = Get-AzVMwareCloudLink -InputObject $Id2
            $config.Name | Should -Be $env.rstr3
        } | Should -Not -Throw
    }
}