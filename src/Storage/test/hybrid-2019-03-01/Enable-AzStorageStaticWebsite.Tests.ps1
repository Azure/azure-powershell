$TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzStorageStaticWebsite.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Enable-AzStorageStaticWebsite' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
