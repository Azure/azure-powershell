$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzADGroupOwner.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzADGroupOwner' {
    It 'Remove' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RemoveViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
