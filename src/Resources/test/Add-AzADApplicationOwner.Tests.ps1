$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'Add-AzADApplicationOwner.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Add-AzADApplicationOwner' {
    It 'AddByComponents' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
