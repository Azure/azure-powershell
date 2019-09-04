$TestRecordingFile = Join-Path $PSScriptRoot 'Export-AzResourceGroup.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Export-AzResourceGroup' {
    It 'ExportExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Export' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExportViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExportViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
