$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'New-AzADApplicationPasswordCredential.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzADApplicationPasswordCredential' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
