### Example 1: Remove a Dashboard
```powershell
<<<<<<< HEAD
Remove-AzPortalDashboard -ResourceGroupName my-rg -DashboardName dashbase02
=======
PS C:\td\> Remove-AzPortalDashboard -ResourceGroupName my-rg -DashboardName dashbase02
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Remove a Dashbaord using resource group name and dashboard name.

### Example 2: Remove a Dashboard using the pipeline
```powershell
<<<<<<< HEAD
Get-AzPortalDashboard -ResourceGroupName my-rg -DashboardName dashbase02 | Remove-AzPortalDashboard
=======
PS C:\> Get-AzPortalDashboard -ResourceGroupName my-rg -DashboardName dashbase02 | Remove-AzPortalDashboard
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Remove the dashboard returned from a Get-AzDashboard call.

