if(($null -eq $TestName) -or ($TestName -contains 'Update-AzLabServicesPlanImage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzLabServicesPlanImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Update-AzLabServicesPlanImage' {
    It 'Update Image Name' { 
        Update-AzLabServicesPlanImage -ResourceGroupName $ENV:ResourceGroupName -LabPlanName $ENV:LabPlanName -Name "canonical.0001-com-ubuntu-server-focal.20_04-lts" -EnabledState "Enabled" | Select -ExpandProperty EnabledState |  Should -BeExactly "Enabled"
    }
}
