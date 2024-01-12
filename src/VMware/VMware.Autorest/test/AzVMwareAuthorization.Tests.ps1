$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareAuthorization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareAuthorization' {
    It 'List' {
        {
            $config = New-AzVMwareAuthorization -Name "authorization1" -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Name | Should -Be "authorization1"

            $config = Get-AzVMwareAuthorization -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzVMwareAuthorization -Name "authorization1" -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Name | Should -Be "authorization1"
        } | Should -Not -Throw
    }

    It 'CreateExpanded' {
        {
            $config = New-AzVMwareAuthorization -Name "authorization1" -PrivateCloudName $env.privateCloudName3 -ResourceGroupName $env.resourceGroup3
            $config.Name | Should -Be "authorization1"
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzVMwareAuthorization -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
        } | Should -Not -Throw
    }
}
