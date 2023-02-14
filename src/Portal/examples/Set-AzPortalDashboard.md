### Example 1: Update the dashboard definition using a dashboard template
```powershell
<<<<<<< HEAD
Set-AzPortalDashboard -DashboardPath .\resources\dash1-update.json -ResourceGroupName my-rg -DashboardName dashbase03
```

```output
=======
PS C:\> Set-AzPortalDashboard -DashboardPath .\resources\dash1-update.json -ResourceGroupName my-rg -DashboardName dashbase03

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name       Type
-------- ----       ----
eastasia dashbase03 Microsoft.Portal/dashboards
```

Update a dashboard definition using a dashbaord template file.

