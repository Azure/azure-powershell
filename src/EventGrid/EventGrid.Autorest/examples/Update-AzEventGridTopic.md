### Example 1: Asynchronously updates a topic with the specified parameters.
```powershell
$inboundIpRule = New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
Update-AzEventGridTopic -Name azps-topic -ResourceGroupName azps_test_group_eventgrid -PublicNetworkAccess Enabled -InboundIPRule $inboundIpRule
```

```output
Location Name       Kind  ResourceGroupName
-------- ----       ----  -----------------
eastus   azps-topic Azure azps_test_group_eventgrid
```

Asynchronously updates a topic with the specified parameters.

### Example 2: Asynchronously updates a topic with the specified parameters.
```powershell
$inboundIpRule = New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
$topic = Get-AzEventGridTopic -ResourceGroupName azps_test_group_eventgrid -Name azps-topic
Update-AzEventGridTopic -InputObject $topic -PublicNetworkAccess Enabled -InboundIPRule $inboundIpRule
```

```output
Location Name       Kind  ResourceGroupName
-------- ----       ----  -----------------
eastus   azps-topic Azure azps_test_group_eventgrid
```

Asynchronously updates a topic with the specified parameters.