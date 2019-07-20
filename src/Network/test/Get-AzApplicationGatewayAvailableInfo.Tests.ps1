$TestRecordingFile = Join-Path 'C:\Code\azps-generation\src\Network\test' 'Get-AzApplicationGatewayAvailableInfo.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzApplicationGatewayAvailableInfo' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
