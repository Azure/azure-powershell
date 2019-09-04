$TestRecordingFile = Join-Path $PSScriptRoot 'Repair-AzVmssServiceFabricUpdateDomain.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Repair-AzVmssServiceFabricUpdateDomain' {
    It 'Force' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ForceViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
