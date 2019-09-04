$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceProviderAvailableStack.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceProviderAvailableStack' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
