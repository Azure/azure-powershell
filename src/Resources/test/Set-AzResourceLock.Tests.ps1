$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'Set-AzResourceLock.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzResourceLock' {
    It 'UpdateTopLevelResource' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
