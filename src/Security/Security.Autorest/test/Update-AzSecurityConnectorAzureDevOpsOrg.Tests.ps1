if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSecurityConnectorAzureDevOpsOrg'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSecurityConnectorAzureDevOpsOrg.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSecurityConnectorAzureDevOpsOrg' {
    It 'UpdateExpanded' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $config = New-AzSecurityConnectorActionableRemediationObject -State Enabled -InheritFromParentState Disabled -CategoryConfiguration @( @{category="IaC"; minimumSeverityLevel="High"})
        Update-AzSecurityConnectorAzureDevOpsOrg -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01" -OrgName "dfdsdktests" -ActionableRemediation $config
    }

    It 'UpdateViaIdentityExpanded' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        
        $config = New-AzSecurityConnectorActionableRemediationObject -State Enabled -InheritFromParentState Disabled -CategoryConfiguration @( @{category="IaC"; minimumSeverityLevel="High"})
        $org = Get-AzSecurityConnectorAzureDevOpsOrg -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01" -OrgName "dfdsdktests"
        Update-AzSecurityConnectorAzureDevOpsOrg -InputObject $org -ActionableRemediation $config
    }
}
