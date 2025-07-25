### Example 1: Get the full endpoint URL of a partner destination channel.
```powershell
Get-AzEventGridChannelFullUrl -ResourceGroupName azps_test_group_eventgrid -PartnerNamespaceName azps-partnernamespace -ChannelName azps-destination
```

```output
EndpointUrl
-----------
https://azpssite.azurewebsites.net/api/updates
```

Get the full endpoint URL of a partner destination channel.

### Example 2: Get the full endpoint URL of a partner destination channel.
```powershell
$partnerObj = Get-AzEventGridPartnerNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-partnernamespace
Get-AzEventGridChannelFullUrl -PartnerNamespaceInputObject $partnerObj -ChannelName azps-destination
```

```output
EndpointUrl
-----------
https://azpssite.azurewebsites.net/api/updates
```

Get the full endpoint URL of a partner destination channel.