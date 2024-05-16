if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSecurityConnectorAzureDevOpsProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSecurityConnectorAzureDevOpsProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSecurityConnectorAzureDevOpsProject' {
    It 'UpdateExpanded' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $config = New-AzSecurityConnectorActionableRemediationObject -State Enabled -InheritFromParentState Disabled -CategoryConfiguration @( @{category="IaC"; minimumSeverityLevel="High"})
        Update-AzSecurityConnectorAzureDevOpsProject -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01" -OrgName "dfdsdktests" -ProjectName "ContosoSDKDfd" -ActionableRemediation $config
    }

    It 'UpdateViaIdentityExpanded' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        
        $config = New-AzSecurityConnectorActionableRemediationObject -State Enabled -InheritFromParentState Disabled -CategoryConfiguration @( @{category="IaC"; minimumSeverityLevel="High"})
        $project = Get-AzSecurityConnectorAzureDevOpsProject -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01" -OrgName "dfdsdktests" -ProjectName "ContosoSDKDfd"
        Update-AzSecurityConnectorAzureDevOpsProject -InputObject $project -ActionableRemediation $config
    }
}
