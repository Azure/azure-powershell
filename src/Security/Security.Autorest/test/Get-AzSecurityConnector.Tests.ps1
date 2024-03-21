if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSecurityConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSecurityConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSecurityConnector' {
    It 'List' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $connectors = Get-AzSecurityConnector -ResourceGroupName $rg
        $connectors.Count | Should -BeGreaterThan 0
    }

    It 'ListBySubscription' {
        $connectors = Get-AzSecurityConnector
        $connectors.Count | Should -BeGreaterThan 0
    }

    It 'Get' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $connector = Get-AzSecurityConnector -SubscriptionId $sid -ResourceGroupName $rg -Name "dfdsdktests-azdo-01"
        $connector | Should -Not -Be $null
        $connector.Name.Contains('dfdsdktests-azdo-01') | Should -Be $true
    }

    It 'GetViaIdentity' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $InputObject = @{Id = "/subscriptions/$sid/resourcegroups/$rg/providers/Microsoft.Security/securityConnectors/dfdsdktests-azdo-01" }
        $connector = Get-AzSecurityConnector -InputObject $InputObject
        $connector.Count | Should -Be 1
        $connector.Name.Contains('dfdsdktests-azdo-01') | Should -Be $true
    }
}
