if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserEnvironmentOperation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserEnvironmentOperation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterUserEnvironmentOperation' {
    It 'List' {
        $listOfOperations = Get-AzDevCenterUserEnvironmentOperation -Endpoint $env.endpoint10 -EnvironmentName $env.envName10 -ProjectName $env.projectName10
        $listOfOperations.Count | Should -BeGreaterOrEqual 1
        }

    It 'Get' {
        $operation = Get-AzDevCenterUserEnvironmentOperation -Endpoint $env.endpoint10 -EnvironmentName $env.envName10 -ProjectName $env.projectName10 -OperationId "4d48a4d5-7edc-437d-9bfa-30e9b4328f68"
        $operation.Kind | Should -Be "Deploy"
        $operation.OperationId | Should -Be "4d48a4d5-7edc-437d-9bfa-30e9b4328f68"
        $operation.Status | Should -Be "Succeeded"

       }

    It 'GetViaIdentity' {
        $environmentInput = @{"EnvironmentName" = $env.envName10; "UserId" = "me"; "ProjectName" = $env.projectName10; "OperationId" = "4d48a4d5-7edc-437d-9bfa-30e9b4328f68" }
        $operation = Get-AzDevCenterUserEnvironmentOperation -Endpoint $env.endpoint10 -InputObject $environmentInput
        $operation.Kind | Should -Be "Deploy"
        $operation.OperationId | Should -Be "4d48a4d5-7edc-437d-9bfa-30e9b4328f68"
        $operation.Status | Should -Be "Succeeded"
        }
}
