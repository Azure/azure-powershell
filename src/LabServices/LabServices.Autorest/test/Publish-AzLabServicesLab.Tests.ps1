if(($null -eq $TestName) -or ($TestName -contains 'Publish-AzLabServicesLab'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Publish-AzLabServicesLab.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Publish-AzLabServicesLab' {
    It 'Publish' {
        $lab = Get-AzLabServicesLab -Name $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName
        Publish-AzLabServicesLab -Lab $lab
    }
}
