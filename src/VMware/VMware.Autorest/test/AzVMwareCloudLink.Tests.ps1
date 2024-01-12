$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareCloudLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareCloudLink' {
    It 'List' {
        {
            $Id2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup2)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName2)"
            $config = New-AzVMwareCloudLink -Name "cloudLink1" -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -LinkedCloud $Id2
            $config.Name | Should -Be "cloudLink1"

            $config = Get-AzVMwareCloudLink -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzVMwareCloudLink -Name "cloudLink1" -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Name | Should -Be "cloudLink1"
        } | Should -Not -Throw
    }

    It 'CreateExpanded' {
        {
            $Id2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup2)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName2)"
            New-AzVMwareCloudLink -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -LinkedCloud $Id2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            $config = Remove-AzVMwareCloudLink -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -resourceGroupName $env.resourceGroup1
            $config | Should -Be $NULL
        } | Should -Not -Throw
    }
}