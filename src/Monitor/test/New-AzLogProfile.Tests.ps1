$TestRecordingFile = Join-Path 'C:\Users\niassis\source\repos\generating\azure-powershell\src\Monitor\test' 'New-AzLogProfile.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzLogProfile' {
    It 'CreateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
