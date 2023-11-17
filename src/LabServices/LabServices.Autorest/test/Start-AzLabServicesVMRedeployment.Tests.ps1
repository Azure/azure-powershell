if(($null -eq $TestName) -or ($TestName -contains 'Start-AzLabServicesVMRedeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzLabServicesVMRedeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)
Describe 'Start-AzLabServicesVMRedeployment' {
    It 'Redeploy' {
        Start-AzLabServicesVM -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Name 0
        {Start-AzLabServicesVMRedeployment  -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -VirtualMachineName 0} | Should -Not -Throw
        Stop-AzLabServicesVM -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Name 0
    }
}
