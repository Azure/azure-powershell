$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppApplicationSetting.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppApplicationSetting' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
