$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwarePSCredentialExecutionParameterObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwarePSCredentialExecutionParameterObject' {
    It 'Rotate' {
        {
            $sourcePassword = ConvertTo-SecureString "pass123" -AsPlainText -Force   
            $config = New-AzVMwarePSCredentialExecutionParameterObject -Name azps_test_credentialvalue -Password $sourcePassword -Username "usernameValue"
            $config.Type | Should -Be "Credential"
        } | Should -Not -Throw
    }
}
