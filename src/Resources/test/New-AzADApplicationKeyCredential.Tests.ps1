$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'New-AzADApplicationKeyCredential.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzADApplicationKeyCredential' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
