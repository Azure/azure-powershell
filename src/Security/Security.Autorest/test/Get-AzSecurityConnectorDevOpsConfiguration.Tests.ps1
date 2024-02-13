if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSecurityConnectorDevOpsConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSecurityConnectorDevOpsConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSecurityConnectorDevOpsConfiguration' {
    It 'Get' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $config = Get-AzSecurityConnectorDevOpsConfiguration -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01"
        $config.Count | Should -Be 1
    }

    It 'List' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $configs = Get-AzSecurityConnectorDevOpsConfiguration -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01"
        $configs.Count | Should -Be 1
    }

    It 'GetViaIdentity' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $InputObject = @{Id = "/subscriptions/$sid/resourcegroups/$rg/providers/Microsoft.Security/securityConnectors/dfdsdktests-azdo-01/devops/default" }
        $config = Get-AzSecurityConnectorDevOpsConfiguration -InputObject $InputObject
        $config.Count | Should -Be 1
        $config.Name.Contains('default') | Should -Be $true
    }
}
