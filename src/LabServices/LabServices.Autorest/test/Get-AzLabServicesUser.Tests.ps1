if(($null -eq $TestName) -or ($TestName -contains 'Get-AzLabServicesUser'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLabServicesUser.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Get-AzLabServicesUser' {
    It 'List' {
        Get-AzLabServicesUser -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        Get-AzLabServicesUser -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Name $ENV:UserName | Should -Not -BeNullOrEmpty
    }

    It 'Lab' {
        $lab = Get-AzLabServicesLab -Name $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName
        Get-AzLabServicesUser -Lab $lab -Name $ENV:UserName | Select-Object -Property Email | Should -BeExactly "@{Email=$($ENV:UserEmail)}"
    }
}
