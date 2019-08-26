$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzWebAppBackupConfiguration.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzWebAppBackupConfiguration' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateExpandedSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
