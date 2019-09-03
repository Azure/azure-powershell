$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppAzureStorageAccountSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppAzureStorageAccountSlot' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
