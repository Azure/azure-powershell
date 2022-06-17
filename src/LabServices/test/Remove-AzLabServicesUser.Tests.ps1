if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzLabServicesUser'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzLabServicesUser.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Remove-AzLabServicesUser' {
    It 'Delete' {
        {Remove-AzLabServicesUser -ResourceGroupName $ENV:ResourceGroupName -LabName $ENV:LabName -Name $ENV:UserName} | Should -Not -Throw
        {Get-AzLabServicesUser -ResourceGroupName $ENV:ResourceGroupName -LabName $ENV:LabName -Name $ENV:UserName} | Should -Throw
    }
}
