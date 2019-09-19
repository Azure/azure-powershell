$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'New-AzResource.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzResource' {
    It 'CreateTopLevelResource' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
