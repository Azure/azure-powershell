### Example 1: Remove a Dashboard
```powershell
Remove-AzPortalDashboard -ResourceGroupName my-rg -DashboardName dashbase02
```

Remove a Dashboard using resource group name and dashboard name.

### Example 2: Remove a Dashboard using the pipeline
```powershell
Get-AzPortalDashboard -ResourceGroupName my-rg -DashboardName dashbase02 | Remove-AzPortalDashboard
```

Remove the dashboard returned from a Get-AzDashboard call.

