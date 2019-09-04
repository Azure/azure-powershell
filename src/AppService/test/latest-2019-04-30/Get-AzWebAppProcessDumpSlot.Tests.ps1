$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppProcessDumpSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppProcessDumpSlot' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
