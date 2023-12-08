if(($null -eq $TestName) -or ($TestName -contains 'Get-AzLabServicesTemplateVM'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLabServicesTemplateVM.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Get-AzLabServicesTemplateVM' {
    It 'Get Template' {
        Get-AzLabServicesTemplateVM -ResourceGroupName $ENV:ResourceGroupName -LabName $ENV:LabName | Should -Not -BeNullOrEmpty
    }

    It 'Get Template from Lab' {
        $lab = Get-AzLabServicesLab -Name $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName
        Get-AzLabServicesTemplateVM -Lab $lab | Should -Not -BeNullOrEmpty
    }
}
