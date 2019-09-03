$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceProviderOperation.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceProviderOperation' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
