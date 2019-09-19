$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteProviderAvailableStack.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteProviderAvailableStack' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
