### Example 1: List properties of channel.
```powershell
Get-AzEventGridChannel -ResourceGroupName azps_test_group_eventgrid -PartnerNamespaceName azps-partnernamespace
```

```output
Name         ResourceGroupName
----         -----------------
azps-channel azps_test_group_eventgrid
```

List properties of channel.

### Example 2: Get properties of a channel.
```powershell
Get-AzEventGridChannel -ResourceGroupName azps_test_group_eventgrid -PartnerNamespaceName azps-partnernamespace -Name azps-channel
```

```output
Name         ResourceGroupName
----         -----------------
azps-channel azps_test_group_eventgrid
```

Get properties of a channel.

### Example 3: Get properties of a channel.
```powershell
$partnerNamespace = Get-AzEventGridPartnerNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-partnernamespace
Get-AzEventGridChannel -PartnerNamespaceInputObject $partnerNamespace -Name azps-channel
```

```output
Name         ResourceGroupName
----         -----------------
azps-channel azps_test_group_eventgrid
```

Get properties of a channel.