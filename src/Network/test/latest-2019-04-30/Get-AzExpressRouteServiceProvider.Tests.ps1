$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzExpressRouteServiceProvider.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzExpressRouteServiceProvider' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
