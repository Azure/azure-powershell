$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareProvisionedNetwork.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareProvisionedNetwork' {
    It 'List' {
        {
            $result = Get-AzVMwareProvisionedNetwork -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result.Count | Should -BeGreaterThan 0
            $result[0].Name | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $result = Get-AzVMwareProvisionedNetwork -Name "vsan" -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result.Name | Should -Be "vsan"
        } | Should -Not -Throw
    }
}