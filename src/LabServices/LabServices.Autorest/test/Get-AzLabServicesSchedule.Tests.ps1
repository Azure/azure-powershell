if(($null -eq $TestName) -or ($TestName -contains 'Get-AzLabServicesSchedule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLabServicesSchedule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Get-AzLabServicesSchedule' {
    It 'List' {
        Get-AzLabServicesSchedule -LabName $env.LabName -ResourceGroupName $env.ResourceGroupName | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        Get-AzLabServicesSchedule -LabName $env.LabName -ResourceGroupName $env.ResourceGroupName -Name $env.ScheduleName  | Should -Not -BeNullOrEmpty
    }

    It 'Pipeline' {
        $lab = Get-AzLabServicesLab -Name $env.LabName -ResourceGroupName $env.ResourceGroupName
        $schedule = Get-AzLabServicesSchedule -LabName $env.LabName -ResourceGroupName $env.ResourceGroupName -Name $env.ScheduleName 
        Get-AzLabServicesSchedule -Lab $lab -Name $schedule.Name | Select-Object -Property Note | Should -BeExactly "@{Note=Automated schedule}"
    }
}
