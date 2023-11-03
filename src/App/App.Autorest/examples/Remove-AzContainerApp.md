### Example 1: Delete a Container App.
```powershell
Remove-AzContainerApp -Name azps-containerapp -ResourceGroupName azpstest_gp
```

Delete a Container App.

### Example 2: Delete a Container App.
```powershell
Get-AzContainerApp -Name azps-containerapp -ResourceGroupName azpstest_gp | Remove-AzContainerApp
```

Delete a Container App.