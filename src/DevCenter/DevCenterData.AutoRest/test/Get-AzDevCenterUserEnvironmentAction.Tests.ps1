if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserEnvironmentAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserEnvironmentAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterUserEnvironmentAction' {
    It 'List' {
        $listOfActions = Get-AzDevCenterUserEnvironmentAction -Endpoint $env.endpoint10 -EnvironmentName $env.envName10 -ProjectName $env.projectName10
        $listOfActions.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $action = Get-AzDevCenterUserEnvironmentAction -Endpoint $env.endpoint10 -EnvironmentName $env.envName10 -ProjectName $env.projectName10 -Name "Delete"
        
        $action.Name | Should -Be "Delete"
        $action.ActionType | Should -Be "Delete"    
    }

    It 'GetViaIdentity' {
        $environmentInput = @{"EnvironmentName" = $env.envName10; "UserId" = "me"; "ProjectName" = $env.projectName10; "ActionName" = "Delete" }

        $action = Get-AzDevCenterUserEnvironmentAction -Endpoint $env.endpoint10 -InputObject $environmentInput

        $action.Name | Should -Be "Delete"
        $action.ActionType | Should -Be "Delete"
        }

}
