$TestRecordingFile = Join-Path 'C:\Code\azps-generation\src\Dns\test' 'New-AzDnsRecordSet.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

# Describe 'New-AzDnsRecordSet' {
#     It 'CreateA' {
#         { throw [System.NotImplementedException] } | Should -Not -Throw
#     }

#     It 'CreateAaaa' {
#         { throw [System.NotImplementedException] } | Should -Not -Throw
#     }

#     It 'CreateCaa' {
#         { throw [System.NotImplementedException] } | Should -Not -Throw
#     }

#     It 'CreateCname' {
#         { throw [System.NotImplementedException] } | Should -Not -Throw
#     }

#     It 'CreateMX' {
#         { throw [System.NotImplementedException] } | Should -Not -Throw
#     }

#     It 'CreateNS' {
#         { throw [System.NotImplementedException] } | Should -Not -Throw
#     }

#     It 'CreatePtr' {
#         { throw [System.NotImplementedException] } | Should -Not -Throw
#     }

#     It 'CreateSrv' {
#         { throw [System.NotImplementedException] } | Should -Not -Throw
#     }

#     It 'CreateTxt' {
#         { throw [System.NotImplementedException] } | Should -Not -Throw
#     }
# }
