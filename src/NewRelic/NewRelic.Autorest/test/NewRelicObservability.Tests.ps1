if(($null -eq $TestName) -or ($TestName -contains 'NewRelicObservability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'NewRelicObservability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'NewRelicObservability' {

    # New monitor tag rule
    It 'MonitorTagRuleCreateExpanded' {
        {
            $tagrule = New-AzNewRelicMonitorTagRule -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup -RuleSetName 'default' -LogRuleSendAadLog 'Enabled' -LogRuleSendActivityLog 'Enabled' -LogRuleSendSubscriptionLog 'Enabled' -MetricRuleSendMetric 'Enabled' -MetricRuleUserEmail $env.testerEmail
            $tagrule.Name | Should -Be 'default'
            $tagrule.LogRuleSendActivityLog | Should -Be 'Enabled'
            $tagrule.LogRuleSendAadLog | Should -Be 'Enabled'
            $tagrule.LogRuleSendSubscriptionLog | Should -Be 'Enabled'
            $tagrule.MetricRuleSendMetric | Should -Be 'Enabled'
        } | Should -Not -Throw
    }

    It 'MonitorTagRuleList' {
        {
            $MonitorTagRuleList = Get-AzNewRelicMonitorTagRule -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup
            $MonitorTagRuleList.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }

    It 'MonitorListGp' {
        {
            $result = Get-AzNewRelicMonitor -ResourceGroupName $env.resourceGroup
            $result.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }

    It 'MonitorGet' {
        {
            $result = Get-AzNewRelicMonitor -Name $env.testMonitorName -ResourceGroupName $env.resourceGroup
            $result.Name | Should -Be $env.testMonitorName
        } | Should -Not -Throw
    }

    # available test
    It 'AppServiceList' {
        {
            Get-AzNewRelicMonitoredAppService -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup -UserEmail $env.testerEmail -AzureResourceId $env.testApp
        } | Should -Not -Throw
    }

    It 'HostList' {
        {
            Get-AzNewRelicMonitoredHost -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup -VMId $env.testVMName -UserEmail $env.testerEmail
        } | Should -Not -Throw
    }

    It 'MetricRuleList' {
        {
            $MetricRuleList = Get-AzNewRelicMonitorMetricRule -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup -UserEmail $env.testerEmail
            $MetricRuleList.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }

    It 'MetricStatusList' {
        {
            Get-AzNewRelicMonitorMetricStatus -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup -UserEmail $env.testerEmail -AzureResourceId $env.testApp
        } | Should -Not -Throw
    }
    
    It 'MonitoredResource' {
        {
            Get-AzNewRelicMonitorMonitoredResource -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
    
    It 'AccountPlanList' {
        {
            # AccountList
            $accountlist = Get-AzNewRelicAccount -Location eastus -UserEmail $env.testerEmail
            $accountlist.Count | Should -BeGreaterThan 1
            # PlanList
            $plan = Get-AzNewRelicPlan -OrganizationId $accountlist[0].OrganizationId
            $plan | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'OrganizationList' {
        {
            Get-AzNewRelicOrganization -Location eastus -UserEmail $env.testerEmail
        } | Should -Not -Throw
    }

    It 'ListMonitorLinkedResource' {
        {
            $LinkedResource = Get-AzNewRelicMonitor -ListLinkedResource -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup
            $LinkedResource.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'BillingInfoGet' {
        {
            $billing = Get-AzNewRelicBillingInfo -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup
            $billing.Count | Should -Be 1
        } | Should -Not -Throw
    }
    It 'GetConnectedPartnerResource' {
        {
            $ConnectedPartnerResource = Get-AzNewRelicConnectedPartnerResource -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup
            $ConnectedPartnerResource.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }

    It 'InvokeHost' -skip { # secret
        {
            Invoke-AzNewRelicHostMonitor -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    # Owner Subscription
    It 'NewMonitoredSubscription' -skip {
        {
            $testSub = '00000000-0000-0000-0000-000000000000'
            $includeFT = New-AzNewRelicFilteringTagObject -Action Include -Name testLogRule1 -Value filteringTag1
            $sub1 = New-AzNewRelicMonitoredSubscriptionObject -LogRuleFilteringTag $includeFT -LogRuleSendAadLog Enabled -LogRuleSendActivityLog Enabled -LogRuleSendSubscriptionLog Enabled -MetricRuleFilteringTag $includeFT -MetricRuleUserEmail $env.testerEmail -Status InProgress -SubscriptionId $testSub
            New-AzNewRelicMonitoredSubscription -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup -MonitoredSubscriptionList $sub1 -PatchOperation AddBegin
        } | Should -Not -Throw
    }
    It 'UpdateMonitoredSubscription' -skip {
        {
            $sub1 = New-AzNewRelicMonitoredSubscriptionObject -Status Active -SubscriptionId 00000000-0000-0000-0000-000000000000
            Update-AzNewRelicMonitoredSubscription -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup -MonitoredSubscriptionList $sub1 -PatchOperation AddComplete
        } | Should -Not -Throw
    }
    It 'GetMonitoredSubscription' -skip {
        {
            Get-AzNewRelicMonitoredSubscription -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
    It 'GetMonitoredSubscriptionList' -skip {
        {
            Get-AzNewRelicMonitoredSubscription
        } | Should -Not -Throw
    }
    It 'DeleteMonitoredSubscription' -skip {
        {
            Remove-AzNewRelicMonitoredSubscription -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    # Update monitor tag rule
    It 'MonitorTagRuleUpdateExpanded'{
        {
            $rule = Update-AzNewRelicMonitorTagRule -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup -RuleSetName default -LogRuleSendActivityLog 'Disabled'
            $rule.LogRuleSendActivityLog | Should -Be 'Disabled'
        } | Should -Not -Throw
    }

    # Remove monitor tag rule
    It 'MonitorTagRuleDelete' {
        {
            Remove-AzNewRelicMonitorTagRule -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup -RuleSetName default -PassThru | Should -Be $true
        } | Should -Not -Throw
    }
}