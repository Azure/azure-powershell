$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzADApplication.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Update-AzADApplication' {
    It 'PatchByApplicationId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
