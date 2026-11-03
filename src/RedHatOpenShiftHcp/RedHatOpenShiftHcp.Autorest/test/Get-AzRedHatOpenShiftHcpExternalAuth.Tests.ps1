if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRedHatOpenShiftHcpExternalAuth'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRedHatOpenShiftHcpExternalAuth.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRedHatOpenShiftHcpExternalAuth' {
    It 'List (by cluster)' {
        $list = @(Get-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName $env.ResourceGroupName -HcpOpenShiftClusterName $env.ClusterName)
        $list.Count | Should -BeGreaterOrEqual 1
        $list.Name | Should -Contain $env.ExternalAuthName
    }

    It 'Get (by name)' {
        $ea = Get-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName $env.ResourceGroupName -HcpOpenShiftClusterName $env.ClusterName -Name $env.ExternalAuthName
        $ea.Name | Should -Be $env.ExternalAuthName
        $ea.ProvisioningState | Should -Be 'Succeeded'
    }
}
