$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwarePrivateCloudVcenterPassword.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwarePrivateCloudVcenterPassword' {
    It 'Rotate' {
        {
            $config = New-AzVMwarePrivateCloudVcenterPassword -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'RotateViaIdentity' {
        {
            $Id = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup1)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName1)"
            $config = New-AzVMwarePrivateCloudVcenterPassword -InputObject $Id -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }
}