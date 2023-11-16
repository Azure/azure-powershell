if(($null -eq $TestName) -or ($TestName -contains 'Skip-AzDevCenterUserEnvironmentAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Skip-AzDevCenterUserEnvironmentAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Skip-AzDevCenterUserEnvironmentAction' {
    It 'Skip' {
        Skip-AzDevCenterUserEnvironmentAction -Endpoint $env.endpoint10 -EnvironmentName $env.envName10 -ProjectName $env.projectName10 -Name "Delete"
        $listOfActions = Get-AzDevCenterUserEnvironmentAction -Endpoint $env.endpoint10 -EnvironmentName $env.envName10 -ProjectName $env.projectName10
        $listOfActions.Count | Should -Be 0
    
    }

    It 'SkipViaIdentity' {
        $environmentInput = @{"EnvironmentName" = $env.envName11; "UserId" = "me"; "ProjectName" = $env.projectName10; "ActionName" = "Delete" }


        Skip-AzDevCenterUserEnvironmentAction -Endpoint $env.endpoint10 -InputObject $environmentInput

        $listOfActions = Get-AzDevCenterUserEnvironmentAction -Endpoint $env.endpoint10 -EnvironmentName $env.envName11 -ProjectName $env.projectName10
        $listOfActions.Count | Should -Be 0
            }


}
