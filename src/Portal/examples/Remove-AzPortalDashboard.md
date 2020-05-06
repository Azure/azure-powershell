### Example 1: {{ Add title here }}
```powershell
PS C:\td\> Remove-AzPortalDashboard -ResourceGroupName my-rg -DashboardName dashbase02
```

Remove a Dashbaord using resource group name and dashboard name.

### Example 2: Remove a Dashboard using the pipeline
PS C:\> Get-AzPortalDashboard -ResourceGroupName my-rg -DashboardName dashbase02 | Remove-AzPortalDashboard
```

Remove the dashboard returned from a Get-AzDashboard call.

