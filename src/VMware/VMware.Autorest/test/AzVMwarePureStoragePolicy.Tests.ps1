$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwarePureStoragePolicy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwarePureStoragePolicy' {
    It 'Create' {
        {
            $result = New-AzVMwarePureStoragePolicy -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -StoragePolicyName "storagePolicy1"
            $result.Name | Should -Be "storagePolicy1"
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $result = Get-AzVMwarePureStoragePolicy -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -StoragePolicyName "storagePolicy1"
            $result.Name | Should -Be "storagePolicy1"
        } | Should -Not -Throw
    }

    It 'Update' {
        {
            $result = Update-AzVMwarePureStoragePolicy -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -StoragePolicyName "storagePolicy1"
            $result.Name | Should -Be "storagePolicy1"
        } | Should -Not -Throw
    }

    It 'Remove' {
    {
        Remove-AzVMwarePureStoragePolicy -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -StoragePolicyName "storagePolicy1"
    } | Should -Not -Throw
}
}