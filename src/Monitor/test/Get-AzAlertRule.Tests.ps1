$TestRecordingFile = Join-Path 'C:\Users\niassis\source\repos\generating\azure-powershell\src\Monitor\test' 'Get-AzAlertRule.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAlertRule' {
    It 'ByTargetId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
