$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzADApplicationOwner.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzADApplicationOwner' {
    It 'Remove' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RemoveViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
