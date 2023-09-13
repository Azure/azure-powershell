# if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserDevBoxOperation'))
# {
#   $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
#   if (-Not (Test-Path -Path $loadEnvPath)) {
#       $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
#   }
#   . ($loadEnvPath)
#   $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserDevBoxOperation.Recording.json'
#   $currentPath = $PSScriptRoot
#   while(-not $mockingPath) {
#       $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
#       $currentPath = Split-Path -Path $currentPath -Parent
#   }
#   . ($mockingPath | Select-Object -First 1).FullName
# }
# Describe 'Get-AzDevCenterUserDevBoxOperation' {
#     It 'List' {
#         $listOfOperations = Get-AzDevCenterUserDevBoxOperation -Endpoint $env.endpoint -ProjectName $env.projectName -DevBoxName $env.devboxName
#         $listOfOperations.Count | Should -BeGreaterOrEqual 1

#         if ($Record -or $Live) {
#             $listOfOperations = Get-AzDevCenterUserDevBoxAction -DevCenter $env.devCenterName -DevBoxName $env.devboxName -ProjectName $env.projectName
#             $listOfOperations.Count | Should -BeGreaterOrEqual 1
#         }

#     }

#     It 'Get' -skip {
#         { throw [System.NotImplementedException] } | Should -Not -Throw
#     }

#     It 'GetViaIdentity' -skip {
#         { throw [System.NotImplementedException] } | Should -Not -Throw
#     }
# }
