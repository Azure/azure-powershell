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
    It 'Expanded' {
        {
            $Id1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup1)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName1)/"
            $Id2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup2)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName2)/"
            New-AzVMwareCloudLink -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -LinkedCloud $Id2

            Get-AzVMwareCloudLink -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            Get-AzVMwareCloudLink -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            Get-AzVMwareCloudLink -InputObject $ID1

            Remove-AzVMwareCloudLink -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -resourceGroupName $env.resourceGroup1
        } | Should -Not -Throw
    }
}