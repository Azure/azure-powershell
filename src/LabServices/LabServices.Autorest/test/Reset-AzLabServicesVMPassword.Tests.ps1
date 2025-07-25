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
        Start-AzLabServicesVM -LabName $env.LabName -ResourceGroupName $env.ResourceGroupName -Name 0
        $string = ConvertTo-SecureString "REDACTED" -AsPlainText -Force
        {Reset-AzLabServicesVMPassword -LabName $env.LabName -ResourceGroupName $env.ResourceGroupName -VirtualMachineName 0 -UserName $env.UserName -Password $string } | Should -Not -Throw
        Stop-AzLabServicesVM -LabName $env.LabName -ResourceGroupName $env.ResourceGroupName -Name 0
    }
}
