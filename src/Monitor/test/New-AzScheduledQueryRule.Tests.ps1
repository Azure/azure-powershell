$TestRecordingFile = Join-Path 'C:\Users\niassis\source\repos\generating\azure-powershell\src\Monitor\test' 'New-AzScheduledQueryRule.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzScheduledQueryRule' {
    It 'CreateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
