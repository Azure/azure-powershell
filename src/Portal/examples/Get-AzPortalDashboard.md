### Example 1: List all dashboards in a subscription
```powershell
<<<<<<< HEAD
Get-AzPortalDashboard                                                        
```

```output                                                        
=======
PS C:> Get-AzPortalDashboard                                                                                                                     
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                                           Type
-------- ----                                           ----
eastasia my-custom-dashboard1                           Microsoft.Portal/dashboards
westus   my-second-custom-dashboard1                    Microsoft.Portal/dashboards
<<<<<<< HEAD
=======

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

List all dashboards in a subscription

### Example 2: Get details for a single Portal Dashboard
```powershell
<<<<<<< HEAD
Get-AzPortalDashboard -ResourceGroupName my-rg -Name mydashboard
```

```output
=======
PS C:\> Get-AzPortalDashboard -ResourceGroupName my-rg -Name mydashboard

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name        Type
-------- ----        ----
eastus   mydashboard Microsoft.Portal/dashboards
```

Get details for a single dashboard

