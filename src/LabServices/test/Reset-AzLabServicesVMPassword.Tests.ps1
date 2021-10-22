if(($null -eq $TestName) -or ($TestName -contains 'Reset-AzLabServicesVMPassword'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Reset-AzLabServicesVMPassword.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Reset-AzLabServicesVMPassword' {
    It 'Reset' {
        Start-AzLabServicesVM -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Name 0
        {Reset-AzLabServicesVMPassword -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -VirtualMachineName 0 -UserName $ENV:UserName -Password $(ConvertTo-SecureString "Junk@1234stuff" -AsPlainText -Force)} | Should -Not -Throw
        Stop-AzLabServicesVM -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Name 0
    }
}
