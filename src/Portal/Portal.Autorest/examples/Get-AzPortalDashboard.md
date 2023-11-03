### Example 1: List all dashboards in a subscription
```powershell
Get-AzPortalDashboard                                                        
```

```output                                                        
Location Name                                           Type
-------- ----                                           ----
eastasia my-custom-dashboard1                           Microsoft.Portal/dashboards
westus   my-second-custom-dashboard1                    Microsoft.Portal/dashboards
```

List all dashboards in a subscription

### Example 2: Get details for a single Portal Dashboard
```powershell
Get-AzPortalDashboard -ResourceGroupName my-rg -Name mydashboard
```

```output
Location Name        Type
-------- ----        ----
eastus   mydashboard Microsoft.Portal/dashboards
```

Get details for a single dashboard

