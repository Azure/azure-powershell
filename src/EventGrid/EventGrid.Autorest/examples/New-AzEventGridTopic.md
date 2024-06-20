### Example 1: Asynchronously creates a new topic with the specified parameters.
```powershell
$inboundIpRule = New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
New-AzEventGridTopic -Name azps-topic -ResourceGroupName azps_test_group_eventgrid -Location eastus -PublicNetworkAccess Enabled -InboundIPRule $inboundIpRule
```

```output
Location Name       Kind  ResourceGroupName
-------- ----       ----  -----------------
eastus   azps-topic Azure azps_test_group_eventgrid
```

Asynchronously creates a new topic with the specified parameters.