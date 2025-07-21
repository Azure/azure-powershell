$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareHost.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareHost' {
    It 'List' {
        {
            $result = Get-AzVMwareHost -ClusterName $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result | Should -Not -BeNullOrEmpty
            $result[0].Name | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $result = Get-AzVMwareHost -ClusterName $env.rstr1 -Id "esx03-r52.1111111111111111111.westcentralus.prod.azure.com" -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be "esx03-r52.1111111111111111111.westcentralus.prod.azure.com"
        } | Should -Not -Throw
    }
}