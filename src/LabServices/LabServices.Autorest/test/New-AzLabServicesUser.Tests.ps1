if(($null -eq $TestName) -or ($TestName -contains 'New-AzLabServicesUser'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzLabServicesUser.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'New-AzLabServicesUser' {
    It 'Create' {        
        New-AzLabServicesUser -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Name $ENV:UserNameSecond -Email $ENV:UserEmailSecond | Should -Not -BeNullOrEmpty
        Get-AzLabServicesUser -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Name $ENV:UserNameSecond | Select-Object -Property Email | Should -BeExactly "@{Email=$($ENV:UserEmailSecond)}"
    }
}
