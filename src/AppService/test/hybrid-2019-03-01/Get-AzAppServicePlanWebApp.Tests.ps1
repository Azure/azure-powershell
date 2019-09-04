$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServicePlanWebApp.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServicePlanWebApp' {
    It 'List1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
