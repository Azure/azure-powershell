$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzVMwareCloudLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzVMwareCloudLink' {
    It 'Delete' {
        {
            $config = Remove-AzVMwareCloudLink -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -resourceGroupName $env.resourceGroup1
            $config | Should -Be $NULL
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $Id2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup2)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName2)"
            $config = New-AzVMwareCloudLink -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -LinkedCloud $Id2
            $config.Name | Should -Be $env.rstr3

            $Id2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup2)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName2)/cloudLinks/$($env.rstr3)"
            $config = Remove-AzVMwareCloudLink -InputObject $Id2
            $config | Should -Be $NULL
        } | Should -Not -Throw
    }
}
