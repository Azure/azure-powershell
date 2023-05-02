if(($null -eq $TestName) -or ($TestName -contains 'AzMobileNetworkService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzMobileNetworkService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzMobileNetworkService' {
    It 'CreateExpanded' {
        {
            $ServiceDataFlowTemplate = New-AzMobileNetworkServiceDataFlowTemplateObject -Direction "Bidirectional" -Protocol "255" -RemoteIPList "any" -TemplateName test-mn-flow-template
            $PccRule = New-AzMobileNetworkPccRuleConfigurationObject -RuleName test-mn-service-rule -RulePrecedence 0 -ServiceDataFlowTemplate $ServiceDataFlowTemplate -TrafficControl 'Enabled' -RuleQoPolicyPreemptionVulnerability 'Preemptable' -RuleQoPolicyPreemptionCapability 'NotPreempt' -RuleQoPolicyAllocationAndRetentionPriorityLevel 9 -RuleQoPolicyMaximumBitRateDownlink "1 Gbps" -RuleQoPolicyMaximumBitRateUplink "500 Mbps"
            $config = New-AzMobileNetworkService -MobileNetworkName $env.testNetwork3 -Name $env.testService -ResourceGroupName $env.resourceGroup -Location $env.location -PccRule $PccRule -ServicePrecedence 0 -MaximumBitRateDownlink "1 Gbps" -MaximumBitRateUplink "500 Mbps" -ServiceQoPolicyAllocationAndRetentionPriorityLevel 9 -ServiceQoPolicyFiveQi 9 -ServiceQoPolicyPreemptionCapability 'MayPreempt' -ServiceQoPolicyPreemptionVulnerability 'Preemptable'
            $config.Name | Should -Be $env.testService
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzMobileNetworkService -MobileNetworkName $env.testNetwork3 -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzMobileNetworkService -MobileNetworkName $env.testNetwork3 -ResourceGroupName $env.resourceGroup -Name $env.testService
            $config.Name | Should -Be $env.testService
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' -skip {
        {
            $config = Update-AzMobileNetworkService -MobileNetworkName $env.testNetwork3 -ServiceName $env.testService -ResourceGroupName $env.resourceGroup -Tag @{"abc"="123"} -ServicePrecedence 0
            $config.Name | Should -Be $env.testService
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzMobileNetworkService -MobileNetworkName $env.testNetwork3 -ResourceGroupName $env.resourceGroup -Name $env.testService
        } | Should -Not -Throw
    }
}
