$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResourceProviderOperationDetail.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzResourceProviderOperationDetail' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
