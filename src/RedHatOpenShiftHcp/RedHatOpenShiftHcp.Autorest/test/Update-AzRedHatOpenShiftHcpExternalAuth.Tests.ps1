if(($null -eq $TestName) -or ($TestName -contains 'Update-AzRedHatOpenShiftHcpExternalAuth'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzRedHatOpenShiftHcpExternalAuth.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Same throwaway external auth created by New-AzRedHatOpenShiftHcpExternalAuth.Tests.ps1.
$authName = 'eatest-ps'

Describe 'Update-AzRedHatOpenShiftHcpExternalAuth' {
    It 'UpdateExpanded' {
        # Change the username claim mapping (a cheap config PATCH).
        $ea = Update-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName $env.ResourceGroupName `
            -HcpOpenShiftClusterName $env.ClusterName -Name $authName -UsernameClaim 'preferred_username'
        $ea.Name | Should -Be $authName
        @('AwaitingSecret', 'Succeeded') | Should -Contain $ea.ProvisioningState
    }
}
