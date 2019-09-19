$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'Get-AzResourceLock.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzResourceLock' {
    It 'GetTopLevelResource' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListTopLevelResource' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
