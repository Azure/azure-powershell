if(($null -eq $TestName) -or ($TestName -contains 'Update-AzLabServicesLab'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzLabServicesLab.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)
Describe 'Update-AzLabServicesLab' {
    It 'Update AutoShutdown Disconnect Delay'  {
        Update-AzLabServicesLab -Name $ENV:LabName `
            -ResourceGroupName $ENV:ResourceGroupName `
            -AutoShutdownProfileShutdownOnDisconnect Enabled `
            -AutoShutdownProfileDisconnectDelay "00:25:00"
        Get-AzLabServicesLab -Name $ENV:LabName -ResourceGroupname $ENV:ResourceGroupName | Select -ExpandProperty AutoShutdownProfileDisconnectDelay | Should -BeExactly '00:25:00'
    }
}
