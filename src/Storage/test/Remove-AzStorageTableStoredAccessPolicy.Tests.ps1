$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Remove-AzStorageTableStoredAccessPolicy.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzStorageTableStoredAccessPolicy' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
