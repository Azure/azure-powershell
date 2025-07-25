$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzContainerInstanceEnvironmentVariableObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzContainerInstanceEnvironmentVariableObject' {
    It 'Test plain value' {
        $env1 = New-AzContainerInstanceEnvironmentVariableObject -Name "env1" -Value "value1"
        $env1.Name | Should -Be "env1"
        $env1.Value | Should -Be "value1"
    }

    It 'Test secure value' {
        $env2 = New-AzContainerInstanceEnvironmentVariableObject -Name "env2" -SecureValue (ConvertTo-SecureString -String "value2" -AsPlainText -Force)
        $env2.Name | Should -Be "env2"
        $env2.SecureValue | Should -Be "value2"
    }
}
