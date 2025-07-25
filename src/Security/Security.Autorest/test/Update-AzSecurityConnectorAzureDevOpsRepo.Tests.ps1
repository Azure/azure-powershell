if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSecurityConnectorAzureDevOpsRepo'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSecurityConnectorAzureDevOpsRepo.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSecurityConnectorAzureDevOpsRepo' {
    It 'UpdateExpanded' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $config = New-AzSecurityConnectorActionableRemediationObject -State Enabled -InheritFromParentState Enabled -CategoryConfiguration @( @{category="IaC"; minimumSeverityLevel="High"})
        Update-AzSecurityConnectorAzureDevOpsRepo -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01" -OrgName "dfdsdktests" -ProjectName "ContosoSDKDfd" -RepoName "TestApp2" -ActionableRemediation $config
    }

    It 'UpdateViaIdentityExpanded' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        
        $config = New-AzSecurityConnectorActionableRemediationObject -State Enabled -InheritFromParentState Enabled -CategoryConfiguration @( @{category="IaC"; minimumSeverityLevel="High"})
        $repo = Get-AzSecurityConnectorAzureDevOpsRepo -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01" -OrgName "dfdsdktests" -ProjectName "ContosoSDKDfd" -RepoName "TestApp2"
        Update-AzSecurityConnectorAzureDevOpsRepo -InputObject $repo -ActionableRemediation $config
    }
}
