### Example 1: List properties of partner namespace.
```powershell
Get-AzEventGridPartnerNamespace
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps-partnernamespace azps_test_group_eventgrid
```

List properties of partner namespace.

### Example 2: List properties of partner namespace.
```powershell
Get-AzEventGridPartnerNamespace -ResourceGroupName azps_test_group_eventgrid
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps-partnernamespace azps_test_group_eventgrid
```

List properties of partner namespace.

### Example 3: Get properties of a partner namespace.
```powershell
Get-AzEventGridPartnerNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-partnernamespace
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps-partnernamespace azps_test_group_eventgrid
```

Get properties of a partner namespace.