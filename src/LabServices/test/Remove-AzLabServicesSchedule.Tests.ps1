if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzLabServicesSchedule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzLabServicesSchedule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Remove-AzLabServicesSchedule' {
    It 'Delete' {
        {Remove-AzLabServicesSchedule -ResourceGroupName $ENV:ResourceGroupName -LabName $ENV:LabName -Name $ENV:ScheduleNameSecond } | Should -Not -Throw
        {Get-AzLabServicesSchedule -ResourceGroupName $ENV:ResourceGroupName -LabName $ENV:LabName -Name $ENV:ScheduleNameSecond} | Should -Throw
    }
}
