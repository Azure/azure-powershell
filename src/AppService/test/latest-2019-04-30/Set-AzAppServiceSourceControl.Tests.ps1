$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzAppServiceSourceControl.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzAppServiceSourceControl' {
    It 'UpdateExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
