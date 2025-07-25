if(($null -eq $TestName) -or ($TestName -contains 'Update-AzLabServicesSchedule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzLabServicesSchedule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Update-AzLabServicesSchedule' {
    It 'Update with Lab' {
        $lab = Get-AzLabServicesLab -ResourceGroupName $env.ResourceGroupName -Name $env.LabName
        Update-AzLabServicesSchedule -Lab $lab -Name $env.ScheduleName -Note "This is an updated note." | Select -ExpandProperty Note | Should -Be "This is an updated note."
    }

    It 'Update with ID' -Skip {
        $schedule = Get-AzLabServicesSchedule -LabName $env.LabName -ResourceGroupName $env.ResourceGroupName -Name $env.ScheduleName
        Update-AzLabServicesSchedule -ResourceId $($schedule.Id) -Note "This is a second updated note." | Select -ExpandProperty Note | Should -Be "This is a second updated note."
    }

}
