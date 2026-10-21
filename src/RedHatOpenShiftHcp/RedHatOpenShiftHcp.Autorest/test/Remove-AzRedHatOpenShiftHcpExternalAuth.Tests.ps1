if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzRedHatOpenShiftHcpExternalAuth'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzRedHatOpenShiftHcpExternalAuth.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Deletes the throwaway external auth created by New-AzRedHatOpenShiftHcpExternalAuth.Tests.ps1.
$authName = 'eatest-ps'

Describe 'Remove-AzRedHatOpenShiftHcpExternalAuth' {
    It 'Delete' {
        { Remove-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName $env.ResourceGroupName `
            -HcpOpenShiftClusterName $env.ClusterName -Name $authName } | Should -Not -Throw
    }
}
