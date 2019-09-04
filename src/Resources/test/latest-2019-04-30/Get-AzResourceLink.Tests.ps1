$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResourceLink.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzResourceLink' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
