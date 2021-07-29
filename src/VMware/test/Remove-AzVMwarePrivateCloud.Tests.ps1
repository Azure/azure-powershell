$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzVMwarePrivateCloud.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzVMwarePrivateCloud' {
    It 'Delete' {
        {
            Remove-AzVMwarePrivateCloud -ResourceGroupName $env.resourceGroup2 -Name $env.rstr2 -Confirm:$false
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $Id2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup1)/providers/Microsoft.AVS/privateClouds/$($env.rstr1)"
            Remove-AzVMwarePrivateCloud -InputObject $Id2 -Confirm:$false
        } | Should -Not -Throw
    }
}