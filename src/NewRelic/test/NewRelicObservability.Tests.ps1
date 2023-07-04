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

DEscribe 'NewRelicObservability' {
    # New monitor
    It 'MonitorCreateExpanded' {
        {
            New-AzNewRelicMonitor -Name $env.NewMonitorName -ResourceGroupName $env.resourceGroup -Location $env.region -PlanDataPlanDetail $env.planDetails -PlanDataBillingCycle $env.billingCycle -PlanDataUsageType $env.usageType -PlanDataEffectiveDate (Get-Date -DisplayHint DateTime) -UserInfoEmailAddress $env.testerEmail -UserInfoFirstName "Joyer" -UserInfoLastName "Jin"
        } | Should -Not -Throw
    }
    # New monitor tag rule
    It 'MonitorTagRuleCreateExpanded' {
        {
            New-AzNewRelicMonitorTagRule -MonitorName $env.NewMonitorName -ResourceGroupName $env.resourceGroup -RuleSetName default -LogRuleSendAadLog 'Enabled' -LogRuleSendActivityLog 'Enabled' -LogRuleSendSubscriptionLog 'Enabled' -MetricRuleSendMetric 'Enabled' -MetricRuleUserEmail $env.testerEmail
        } | Should -Not -Throw
    }

    It 'MonitorTagRuleList' {
        {
            Get-AzNewRelicMonitorTagRule -MonitorName $env.NewMonitorName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'MonitorListSub' {
        {
            $result = Get-AzNewRelicMonitor
            $result.Count | Should -BeGreaterThan 5
        } | Should -Not -Throw
    }

    It 'MonitorListGp' {
        {
            $result = Get-AzNewRelicMonitor -ResourceGroupName $env.resourceGroup
            $result.Count | Should -BeGreaterThan 1
        } | Should -Not -Throw
    }

    It 'MonitorGet' {
        {
            $result = Get-AzNewRelicMonitor -Name $env.NewMonitorName -ResourceGroupName $env.resourceGroup
            $result.Name | Should -Be $env.NewMonitorName
        } | Should -Not -Throw
    }

    # available test
    It 'AppServiceList' {
        {
            Get-AzNewRelicMonitorAppService -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup -UserEmail $env.testerEmail -AzureResourceId $env.testApp
        } | Should -Not -Throw
    }

    It 'HostList' {
        {
            Get-AzNewRelicMonitorHost -MonitorName $env.NewMonitorName -ResourceGroupName $env.resourceGroup -VMId saurg-vm-01 -UserEmail $env.testerEmail
        } | Should -Not -Throw
    }

    It 'MetricRuleList' {
        {
            Get-AzNewRelicMonitorMetricRule -MonitorName $env.testMonitorName -ResourceGroupName $env.resourceGroup -UserEmail $env.testerEmail
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
            # PlanList
            Get-AzNewRelicPlan -OrganizationId $accountlist[0].OrganizationId
        } | Should -Not -Throw
    }

    It 'OrganizationList' {
        {
            Get-AzNewRelicOrganization -Location eastus -UserEmail $env.testerEmail
        } | Should -Not -Throw
    }

    It 'InvokeHost' -skip {
        {
            Invoke-AzNewRelicHostMonitor -MonitorName $env.NewMonitorName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    # Update monitor tag rule
    It 'MonitorTagRuleUpdateExpanded'{
        {
            $rule = Update-AzNewRelicMonitorTagRule -MonitorName $env.NewMonitorName -ResourceGroupName $env.resourceGroup -RuleSetName default -LogRuleSendActivityLog 'Disabled'
            $rule.LogRuleSendActivityLog | Should -Be 'Disabled'
        } | Should -Not -Throw
    }

    # Remove monitor tag rule
    It 'MonitorTagRuleDelete' {
        {
            Remove-AzNewRelicMonitorTagRule -MonitorName $env.NewMonitorName -ResourceGroupName $env.resourceGroup -RuleSetName default
        } | Should -Not -Throw
    }
    # Remove monitor
    It 'MonitorDelete' {
        {
            Remove-AzNewRelicMonitor -Name test-01 -ResourceGroupName $env.resourceGroup -UserEmail $env.testerEmail
        } | Should -Not -Throw
    }
}