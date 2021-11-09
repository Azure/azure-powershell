if(($null -eq $TestName) -or ($TestName -contains 'Update-AzLabServicesUser'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzLabServicesUser.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Update-AzLabServicesUser' {
    It 'Update Existing' {
        $user = Get-AzLabServicesUser -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Name $ENV:UserNameSecond
        Update-AzLabServicesUser -ResourceId $($user.Id) -AdditionalUsageQuota $(New-TimeSpan -Hours 2)  | Should -Not -BeNullOrEmpty
        Get-AzLabServicesUser -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Name $ENV:UserNameSecond | Select-Object -Property AdditionalUsageQuota | Should -BeExactly "@{AdditionalUsageQuota=02:00:00}"
    }

}
