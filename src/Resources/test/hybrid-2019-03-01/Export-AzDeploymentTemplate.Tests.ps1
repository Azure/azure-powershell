$TestRecordingFile = Join-Path $PSScriptRoot 'Export-AzDeploymentTemplate.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Export-AzDeploymentTemplate' {
    It 'Export' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Export1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExportViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExportViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
