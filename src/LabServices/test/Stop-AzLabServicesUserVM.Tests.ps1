if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzLabServicesUserVM'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzLabServicesUserVM.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Stop-AzLabServicesUserVM' {
    It 'Stop' -skip {
        Start-AzLabServicesUserVM -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Email $ENV:UserEmail
        Stop-AzLabServicesUserVM -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Email $ENV:UserEmail
        Get-AzLabServicesUserVM -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Email $ENV:UserEmail | Select -ExpandProperty State |  Should -BeExactly "Stopped"        
    }
}