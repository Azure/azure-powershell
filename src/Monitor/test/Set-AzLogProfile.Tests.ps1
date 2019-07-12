$TestRecordingFile = Join-Path 'C:\Users\niassis\source\repos\generating\azure-powershell\src\Monitor\test' 'Set-AzLogProfile.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzLogProfile' {
    It 'Update' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
