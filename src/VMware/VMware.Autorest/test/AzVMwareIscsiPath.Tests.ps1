$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareIscsiPath.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareIscsiPath' {
    It 'Create' {
        {
            $result = New-AzVMwareIscsiPath -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result.Name | Should -Be "default"
            $result.NetworkBlock | Should -Be "192.168.0.0/24"
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $result = Get-AzVMwareIscsiPath -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result.Name | Should -Be "default"
            $result.NetworkBlock | Should -Be "192.168.0.0/24"
        } | Should -Not -Throw
    }

    It 'Update' {
        {
            $result = Update-AzVMwareIscsiPath -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result.Name | Should -Be "default"
            $result.NetworkBlock | Should -Be "192.168.0.0/24"
        } | Should -Not -Throw
    }

    It 'Remove' {
        {
            Remove-AzVMwareIscsiPath -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
        } | Should -Not -Throw
    }
}