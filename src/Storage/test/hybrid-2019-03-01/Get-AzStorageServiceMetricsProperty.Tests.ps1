$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageServiceMetricsProperty.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzStorageServiceMetricsProperty' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
