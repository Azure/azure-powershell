$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzVMwareCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzVMwareCluster' {
    It 'Delete' {
        {
            Remove-AzVMwarePrivateCloud -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -Name $env.rstr1
        } | Should -Not -Throw
    }
    
    It 'DeleteViaIdentity' {
        {
            $Id2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGorup2)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName2)/clusters/$($env.rstr2)"
            Remove-AzVMwarePrivateCloud -InputObject $Id2
        } | Should -Not -Throw
    }
}
