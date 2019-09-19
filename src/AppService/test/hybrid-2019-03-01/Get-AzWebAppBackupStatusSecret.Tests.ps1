$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppBackupStatusSecret.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppBackupStatusSecret' {
    It 'ListExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListExpandedSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
