### Example 1: Create a dashboard using a dashboard template file
```powershell
<<<<<<< HEAD
New-AzPortalDashboard -DashboardPath .\resources\dash1.json -ResourceGroupName mydash-rg -DashboardName my-dashboard03
```

```output
=======
PS C:\> New-AzPortalDashboard -DashboardPath .\resources\dash1.json -ResourceGroupName mydash-rg -DashboardName my-dashboard03

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name           Type
-------- ----           ----
eastasia my-dashboard03 Microsoft.Portal/dashboards
`````

Create a new dashboard using the provided dashboard template file.


