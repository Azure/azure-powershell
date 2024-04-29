if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityConnectorDevOpsConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityConnectorDevOpsConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityConnectorDevOpsConfiguration' {
    It 'CreateExpanded' {
        $rg = "securityConnectors-pwsh-tmp"
        $sid = $env.SubscriptionId
        $connectorName = "ado-sdk-pwsh-test02"
        $hierarchyIdentifier = "75ebbca5-8b2b-48b2-93e6-d241b2993ed3"

        # Tests require complecated environment setup. For now, validating that resource provider is accepting payload and trying to access DevOps environment
        try {
            New-AzSecurityConnector -SubscriptionId $sid -ResourceGroupName $rg -Name $connectorName -EnvironmentName AzureDevOps -EnvironmentData (New-AzSecurityAzureDevOpsScopeEnvironmentObject) -HierarchyIdentifier $hierarchyIdentifier -Location "CentralUS" -Offering @(New-AzSecurityCspmMonitorAzureDevOpsOfferingObject)
    
            New-AzSecurityConnectorDevOpsConfiguration -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName $connectorName -AutoDiscovery Disabled -TopLevelInventoryList @("abc", "def") -AuthorizationCode "dummyCode"
        } catch {
            $Error[0] | Should -Match "OAuth token exchange failed"
            $Error[0].Exception.ResponseBody | Should -Match "TokenExchangeFailed"
        } finally {
            try { Remove-AzSecurityConnectorDevOpsConfiguration -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName $connectorName } catch {}
            try { Remove-AzSecurityConnector -SubscriptionId $sid -ResourceGroupName $rg -Name $connectorName } catch {}
        }
    }
}
