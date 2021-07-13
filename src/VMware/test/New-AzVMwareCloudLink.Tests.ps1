$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwareCloudLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVMwareCloudLink' {
    It 'CreateExpanded' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.AVS/privateClouds/$($env.privatecloudname2)/"
            New-AzVMwareCloudLink -Name $env.rstr2 -PrivateCloudName $env.privatecloudname1 -ResourceGroupName $env.resourceGroup -LinkedCloud $ID
            Remove-AzVMwareCloudLink -Name $env.rstr2 -PrivateCloudName $env.privatecloudname1 -resourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
