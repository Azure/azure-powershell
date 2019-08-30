$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsZone.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzDnsZone' {
    It 'CreatePublic' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreatePrivate' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
