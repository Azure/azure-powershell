$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppSnapshotFromDrSecondary.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppSnapshotFromDrSecondary' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
