if(($null -eq $TestName) -or ($TestName -contains 'Get-AzLabServicesVM'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLabServicesVM.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Get-AzLabServicesVM' {
    It 'List' {
        Get-AzLabServicesVM -LabName $env.LabName -ResourceGroupName $env.ResourceGroupName | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        Get-AzLabServicesVM -LabName $env.LabName -ResourceGroupName $env.ResourceGroupName -Name 0 | Should -Not -BeNullOrEmpty
    }

    It 'Pipeline' {
        $lab = Get-AzLabServicesLab -Name $env.LabName -ResourceGroupName $env.ResourceGroupName
        Get-AzLabServicesVM -Lab $lab -Name 0 | Select -ExpandProperty State |  Should -BeExactly "Stopped"
    }
}
