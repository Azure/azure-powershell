if(($null -eq $TestName) -or `
   ($TestName -contains 'New-AzMonitorHealthModelDiscoveryRule') -or `
   ($TestName -contains 'New-AzMonitorHealthModelResourceGraphQuerySpecificationObject') -or `
   ($TestName -contains 'New-AzMonitorHealthModelApplicationInsightsTopologySpecificationObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMonitorHealthModelDiscoveryRule.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMonitorHealthModelDiscoveryRule' {
    It 'CreateExpanded' {
        {
            $specification = New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where isnotempty(id) | project id | take 1"
            $result = New-AzMonitorHealthModelDiscoveryRule -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.DiscoveryRuleCreateName -AuthenticationSetting $env.AuthenticationSettingName -AddRecommendedSignal Enabled -AddResourceHealthSignal Disabled -DiscoverRelationship Disabled -DisplayName 'Create discovery rule' -Specification $specification
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.DiscoveryRuleCreateName
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}

Describe 'New-AzMonitorHealthModelResourceGraphQuerySpecificationObject' {
    It '__AllParameterSets' {
        $specification = New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where isnotempty(id) | project id"
        $specification.ResourceGraphQuery | Should -Be "resources | where isnotempty(id) | project id"
    }

}

Describe 'New-AzMonitorHealthModelApplicationInsightsTopologySpecificationObject' {
    It '__AllParameterSets' {
        $resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Insights/components/demo-ai"
        $specification = New-AzMonitorHealthModelApplicationInsightsTopologySpecificationObject -ApplicationInsightsResourceId $resourceId
        $specification.ApplicationInsightsResourceId | Should -Be $resourceId
    }

}
