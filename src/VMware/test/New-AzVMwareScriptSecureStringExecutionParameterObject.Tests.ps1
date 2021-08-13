$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwareScriptSecureStringExecutionParameterObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVMwareScriptSecureStringExecutionParameterObject' {
    It 'Rotate' {
        {
            $config = New-AzVMwareScriptSecureStringExecutionParameterObject -Name azps_test_securevalue -Type SecureValue -SecureValue "passwordValue"
            $config.Type | Should -Be "SecureValue"
        } | Should -Not -Throw
    }
}