$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppSlotConfigurationName.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppSlotConfigurationName' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByWebApp' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
