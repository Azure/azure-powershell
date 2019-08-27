$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMetricAlert.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzMetricAlert' {
    It 'CreateByResourceId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateByScope' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
