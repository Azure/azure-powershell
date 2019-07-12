$TestRecordingFile = Join-Path 'C:\Users\niassis\source\repos\generating\azure-powershell\src\Monitor\test' 'New-AzAlertRule.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzAlertRule' {
    It 'CreateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
