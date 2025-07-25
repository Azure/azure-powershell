if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSecurityConnectorAzureDevOpsOrg'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSecurityConnectorAzureDevOpsOrg.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSecurityConnectorAzureDevOpsOrg' {
    It 'List' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $orgs = Get-AzSecurityConnectorAzureDevOpsOrg -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01"
        $orgs.Count | Should -BeGreaterThan 0
    }

    It 'Get' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $org = Get-AzSecurityConnectorAzureDevOpsOrg -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01" -OrgName "dfdsdktests"
        $org | Should -Not -Be $null
        $org.Name.Contains('dfdsdktests') | Should -Be $true
    }

    It 'GetViaIdentity' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $InputObject = @{Id = "/subscriptions/$sid/resourcegroups/$rg/providers/Microsoft.Security/securityConnectors/dfdsdktests-azdo-01/devops/default/azureDevOpsOrgs/dfdsdktests" }
        $org = Get-AzSecurityConnectorAzureDevOpsOrg -InputObject $InputObject
        $org.Count | Should -Be 1
        $org.Name.Contains('dfdsdktests') | Should -Be $true
    }
}
