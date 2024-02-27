if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSecurityConnectorDevOpsConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSecurityConnectorDevOpsConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSecurityConnectorDevOpsConfiguration' {
    It 'UpdateExpanded' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId

        $devops = Update-AzSecurityConnectorDevOpsConfiguration -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01" -AutoDiscovery Disabled -TopLevelInventoryList @("dfdsdktests")
        $devops.AutoDiscovery | Should -Be "Disabled"
    }

    It 'UpdateViaIdentityExpanded' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId

        $devops = Get-AzSecurityConnectorDevOpsConfiguration -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01"
        Update-AzSecurityConnectorDevOpsConfiguration -InputObject $devops -AutoDiscovery Disabled -TopLevelInventoryList @("dfdsdktests")
    }
}
