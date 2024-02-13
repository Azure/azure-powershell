if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSecurityConnectorAzureDevOpsRepos'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSecurityConnectorAzureDevOpsRepos.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSecurityConnectorAzureDevOpsRepos' {
    It 'UpdateExpanded' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $config = New-AzSecurityConnectorActionableRemediationObject -State Enabled -InheritFromParentState Enabled -CategoryConfiguration @( @{category="IaC"; minimumSeverityLevel="High"})
        Update-AzSecurityConnectorAzureDevOpsRepos -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01" -OrgName "dfdsdktests" -ProjectName "ContosoSDKDfd" -RepoName "TestApp2" -ActionableRemediation $config
    }

    It 'UpdateViaIdentityExpanded' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        
        $config = New-AzSecurityConnectorActionableRemediationObject -State Enabled -InheritFromParentState Enabled -CategoryConfiguration @( @{category="IaC"; minimumSeverityLevel="High"})
        $repo = Get-AzSecurityConnectorAzureDevOpsRepos -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01" -OrgName "dfdsdktests" -ProjectName "ContosoSDKDfd" -RepoName "TestApp2"
        Update-AzSecurityConnectorAzureDevOpsRepos -InputObject $repo -ActionableRemediation $config
    }
}
