### Example 1: Asynchronously Create a new domain with the specified parameters.
```powershell
$inboundIpRule = New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
New-AzEventGridDomain -Name azps-domain -ResourceGroupName azps_test_group_eventgrid -Location westus2 -PublicNetworkAccess Enabled -InboundIPRule $inboundIpRule
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
westus2  azps-domain azps_test_group_eventgrid
```

Asynchronously Create a new domain with the specified parameters.