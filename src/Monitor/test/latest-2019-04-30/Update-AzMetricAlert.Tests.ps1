$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMetricAlert.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Update-AzMetricAlert' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateExpandedByResourceId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateExpandedByScope' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpandedByResourceId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpandedByScope' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
