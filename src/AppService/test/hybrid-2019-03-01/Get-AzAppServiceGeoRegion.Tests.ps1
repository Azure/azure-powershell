$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceGeoRegion.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceGeoRegion' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
