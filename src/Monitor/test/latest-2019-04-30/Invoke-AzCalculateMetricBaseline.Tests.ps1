$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzCalculateMetricBaseline.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzCalculateMetricBaseline' {
    It 'CalculateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Calculate' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CalculateViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CalculateViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
