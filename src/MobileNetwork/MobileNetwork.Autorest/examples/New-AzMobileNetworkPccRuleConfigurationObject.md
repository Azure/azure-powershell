### Example 1: Create an in-memory object for PccRuleConfiguration.
```powershell
$ServiceDataFlowTemplate = New-AzMobileNetworkServiceDataFlowTemplateObject -Direction "Bidirectional" -Protocol "255" -RemoteIPList "any" -TemplateName azps-mn-flow-template

New-AzMobileNetworkPccRuleConfigurationObject -RuleName azps-mn-service-rule -RulePrecedence 0 -ServiceDataFlowTemplate $ServiceDataFlowTemplate -TrafficControl 'Enabled' -RuleQoPolicyPreemptionVulnerability 'Preemptable' -RuleQoPolicyPreemptionCapability 'NotPreempt' -RuleQoPolicyAllocationAndRetentionPriorityLevel 9 -RuleQoPolicyMaximumBitRateDownlink "1 Gbps" -RuleQoPolicyMaximumBitRateUplink "500 Mbps"
```

```output
RuleName             RulePrecedence TrafficControl
--------             -------------- --------------
azps-mn-service-rule 0              Enabled
```

Create an in-memory object for PccRuleConfiguration.