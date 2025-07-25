### Example 1: Create a dashboard using a dashboard template file
```powershell
New-AzPortalDashboard -DashboardPath .\resources\dash1.json -ResourceGroupName mydash-rg -DashboardName my-dashboard03
```

```output
Location Name           Type
-------- ----           ----
eastasia my-dashboard03 Microsoft.Portal/dashboards
`````

Create a new dashboard using the provided dashboard template file.


