### Example 1: Creates or updates a service.
```powershell
$ServiceDataFlowTemplate = New-AzMobileNetworkServiceDataFlowTemplateObject -Direction "Bidirectional" -Protocol "255" -RemoteIPList "any" -TemplateName azps-mn-flow-template

$PccRule = New-AzMobileNetworkPccRuleConfigurationObject -RuleName azps-mn-service-rule -RulePrecedence 0 -ServiceDataFlowTemplate $ServiceDataFlowTemplate -TrafficControl 'Enabled' -RuleQoPolicyPreemptionVulnerability 'Preemptable' -RuleQoPolicyPreemptionCapability 'NotPreempt' -RuleQoPolicyAllocationAndRetentionPriorityLevel 9 -RuleQoPolicyMaximumBitRateDownlink "1 Gbps" -RuleQoPolicyMaximumBitRateUplink "500 Mbps"

New-AzMobileNetworkService -MobileNetworkName azps-mn -Name azps-mn-service -ResourceGroupName azps_test_group -Location eastus -PccRule $PccRule -ServicePrecedence 0 -MaximumBitRateDownlink "1 Gbps" -MaximumBitRateUplink "500 Mbps" -ServiceQoPolicyAllocationAndRetentionPriorityLevel 9 -ServiceQoPolicyFiveQi 9 -ServiceQoPolicyPreemptionCapability 'MayPreempt' -ServiceQoPolicyPreemptionVulnerability 'Preemptable'
```

```output
Location Name            ResourceGroupName ProvisioningState Precedence MaximumBitRateDownlink MaximumBitRateUplink QoPolicyAllocationAndRetentionPriorityLevel QoPolicyFiveQi
-------- ----            ----------------- ----------------- ---------- ---------------------- -------------------- ------------------------------------------- --------------
eastus   azps-mn-service azps_test_group   Succeeded         0          1 Gbps                 500 Mbps             9                                           9
```

Creates or updates a service.
Must be created in the same location as its parent mobile network.