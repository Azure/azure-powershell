if(($null -eq $TestName) -or ($TestName -contains 'Get-AzLabServicesPlanImage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLabServicesPlanImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Get-AzLabServicesPlanImage' {
    It 'List from LabPlan' {
        Get-AzLabServicesPlanImage -ResourceGroupName $ENV:ResourceGroupName -LabPlanName $ENV:LabPlanName | Should -Not -BeNullOrEmpty
    }

    It 'Get specific Image name' {
        $labPlan = Get-AzLabServicesLabPlan -Name $ENV:LabPlanName -ResourceGroupName $ENV:ResourceGroupName
        Get-AzLabServicesPlanImage -LabPlan $labPlan -Name 'canonical.0001-com-ubuntu-server-focal.20_04-lts'  | Should -Not -BeNullOrEmpty
    }

    It 'Get specific Display name' {
        Get-AzLabServicesPlanImage -LabPlanName $ENV:LabPlanName -ResourceGroupName $ENV:ResourceGroupName -DisplayName  'Ubuntu Server 20.04 LTS'  | Should -Not -BeNullOrEmpty
    }
}
