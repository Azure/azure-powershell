$TestRecordingFile = Join-Path $PSScriptRoot 'Unregister-AzResourceProvider.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Unregister-AzResourceProvider' {
    It 'Unregister' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UnregisterViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
