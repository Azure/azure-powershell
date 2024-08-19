### Example 1: Asynchronously updates a domain with the specified parameters.
```powershell
$inboundIpRule = New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
Update-AzEventGridDomain -Name azps-domain -ResourceGroupName azps_test_group_eventgrid -PublicNetworkAccess Enabled -InboundIPRule $inboundIpRule
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
westus2  azps-domain azps_test_group_eventgrid
```

Asynchronously updates a domain with the specified parameters.