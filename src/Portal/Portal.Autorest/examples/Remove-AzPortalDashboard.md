### Example 1: Remove a Dashboard
```powershell
PS C:\td\> Remove-AzPortalDashboard -ResourceGroupName my-rg -DashboardName dashbase02
```

Remove a Dashbaord using resource group name and dashboard name.

### Example 2: Remove a Dashboard using the pipeline
```powershell
PS C:\> Get-AzPortalDashboard -ResourceGroupName my-rg -DashboardName dashbase02 | Remove-AzPortalDashboard
```

Remove the dashboard returned from a Get-AzDashboard call.

