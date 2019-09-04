$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzVmssExtension.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzVmssExtension' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
