if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserEnvironmentOutput'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserEnvironmentOutput.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterUserEnvironmentOutput' {
    It 'Get' -skip {
        Get-AzDevCenterUserEnvironmentOutput -Endpoint $env.endpoint10 -EnvironmentName $env.envName10 -ProjectName $env.projectName10 -OperationId "4d48a4d5-7edc-437d-9bfa-30e9b4328f68"

       }

    It 'GetViaIdentity' -skip {
        $environmentInput = @{"EnvironmentName" = $env.envName10; "UserId" = "me"; "ProjectName" = $env.projectName10; "OperationId" = "4d48a4d5-7edc-437d-9bfa-30e9b4328f68" }
        Get-AzDevCenterUserDevBoxOperation -Endpoint $env.endpoint10 -InputObject $environmentInput
        }


}
