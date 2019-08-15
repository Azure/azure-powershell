$TestRecordingFile = Join-Path 'C:\Code\azps-generation\src\Dns\test' 'Get-AzDnsResourceReference.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

# Describe 'Get-AzDnsResourceReference' {
#     It 'GetExpanded' {
#         { throw [System.NotImplementedException] } | Should -Not -Throw
#     }
# }
