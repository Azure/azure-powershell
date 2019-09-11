$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'Remove-AzADServicePrincipalKeyCredential.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzADServicePrincipalKeyCredential' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
