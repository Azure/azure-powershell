$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareScriptSecureStringExecutionParameterObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareScriptSecureStringExecutionParameterObject' {
    It 'Rotate' {
        {   
            $sourcePassword = ConvertTo-SecureString "pass123" -AsPlainText -Force   
            $config = New-AzVMwareScriptSecureStringExecutionParameterObject -Name azps_test_securevalue -SecureValue $sourcePassword
            $config.Type | Should -Be "SecureValue"
        } | Should -Not -Throw
    }
}