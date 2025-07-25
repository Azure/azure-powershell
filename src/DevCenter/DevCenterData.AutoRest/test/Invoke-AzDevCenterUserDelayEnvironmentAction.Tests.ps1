if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDevCenterUserDelayEnvironmentAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDevCenterUserDelayEnvironmentAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzDevCenterUserDelayEnvironmentAction' {
    It 'Delay' {
        if ($Record -or $Live) {
            $action = Get-AzDevCenterUserEnvironmentAction -Endpoint $env.endpoint10 -EnvironmentName $env.envName11 -ProjectName $env.projectName10 -Name "Delete"
            $delayTime = New-TimeSpan -Minutes 5
            $newScheduledTime = $action.NextScheduledTime + $delayTime
            $delayAction = Invoke-AzDevCenterUserDelayEnvironmentAction -Endpoint $env.endpoint10 -EnvironmentName $env.envName11 -ProjectName $env.projectName10 -Name "Delete" -DelayTime "00:05"
            $delayAction.NextScheduledTime | Should -Be $newScheduledTime
        }
    }


}
