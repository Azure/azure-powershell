if(($null -eq $TestName) -or ($TestName -contains 'Update-AzLabServicesQuota'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzLabServicesQuota.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Update-AzLabServicesQuota' {
    It 'Add Quota' {
        Update-AzLabServicesQuota -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -LabQuota (New-TimeSpan -Hours 3) | Select -ExpandProperty VirtualMachineProfileUsageQuota | Should -Be "03:00:00"
    }
}
