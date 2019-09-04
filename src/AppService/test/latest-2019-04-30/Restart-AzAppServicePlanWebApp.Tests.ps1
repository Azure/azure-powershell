$TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzAppServicePlanWebApp.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Restart-AzAppServicePlanWebApp' {
    It 'Restart' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestartViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
