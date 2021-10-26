if(($null -eq $TestName) -or ($TestName -contains 'Update-AzLabServicesLabPlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzLabServicesLabPlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Update-AzLabServicesLabPlan' {
    It 'Update' {
        Update-AzLabServicesLabPlan `
        -Name $ENV:LabPlanName `
        -ResourceGroupName $ENV:ResourceGroupName `
        -DefaultAutoShutdownProfileShutdownOnDisconnect 'Enabled' `
        -DefaultAutoShutdownProfileDisconnectDelay "00:17:00" | Should -Not -BeNullOrEmpty

        Get-AzLabServicesLabPlan -Name $ENV:LabPlanName -ResourceGroupName $ENV:ResourceGroupName | Select -ExpandProperty DefaultAutoShutdownProfileDisconnectDelay | Should -BeExactly "00:17:00"
    }
}
