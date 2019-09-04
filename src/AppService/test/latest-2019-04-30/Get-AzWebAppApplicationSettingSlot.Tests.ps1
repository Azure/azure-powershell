$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppApplicationSettingSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppApplicationSettingSlot' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
