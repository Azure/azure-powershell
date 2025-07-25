$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareScriptStringExecutionParameterObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareScriptStringExecutionParameterObject' {
    It 'Rotate' {
        {
            $config = New-AzVMwareScriptStringExecutionParameterObject -Name azps_test_stringvalue -Value "stringValue"
            $config.Type | Should -Be "Value"
        } | Should -Not -Throw
    }
}