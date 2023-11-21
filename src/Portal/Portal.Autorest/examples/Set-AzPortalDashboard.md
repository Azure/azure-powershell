### Example 1: Update the dashboard definition using a dashboard template
```powershell
Set-AzPortalDashboard -DashboardPath .\resources\dash1-update.json -ResourceGroupName my-rg -DashboardName dashbase03
```

```output
Location Name       Type
-------- ----       ----
eastasia dashbase03 Microsoft.Portal/dashboards
```

Update a dashboard definition using a dashbaord template file.

