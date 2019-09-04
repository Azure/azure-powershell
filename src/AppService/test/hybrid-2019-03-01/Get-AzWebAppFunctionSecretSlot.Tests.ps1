$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppFunctionSecretSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppFunctionSecretSlot' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
