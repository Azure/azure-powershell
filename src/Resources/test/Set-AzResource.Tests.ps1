$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'Set-AzResource.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzResource' {
    It 'UpdateTopLevelResource' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
