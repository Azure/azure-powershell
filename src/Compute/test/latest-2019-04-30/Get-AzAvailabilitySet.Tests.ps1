$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAvailabilitySet.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAvailabilitySet' {
    It 'List2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List3' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
