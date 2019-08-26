$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServicePlanHybridConnectionPlanLimit.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServicePlanHybridConnectionPlanLimit' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
