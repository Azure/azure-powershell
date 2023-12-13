if(($null -eq $TestName) -or ($TestName -contains 'Start-AzLabServicesVM'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzLabServicesVM.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Start-AzLabServicesVM' {
    It 'Start' {
        Start-AzLabServicesVM -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Name 1
        Get-AzLabServicesVM -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Name 1 | Select -ExpandProperty State |  Should -BeIn @("Started","Running")
        Stop-AzLabServicesVM -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Name 1
    }
}