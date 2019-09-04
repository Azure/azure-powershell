$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppAzureStorageAccount.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppAzureStorageAccount' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
