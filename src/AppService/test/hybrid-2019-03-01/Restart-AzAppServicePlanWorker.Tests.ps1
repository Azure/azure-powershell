$TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzAppServicePlanWorker.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Restart-AzAppServicePlanWorker' {
    It 'Reboot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RebootViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
