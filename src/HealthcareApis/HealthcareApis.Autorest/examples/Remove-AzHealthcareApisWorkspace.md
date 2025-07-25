### Example 1: Deletes a specified workspace.
```powershell
Remove-AzHealthcareApisWorkspace -Name azpshcws -ResourceGroupName azps_test_group
```

Deletes a specified workspace.

### Example 2: Deletes a specified workspace.
```powershell
Get-AzHealthcareApisWorkspace -Name azpshcws -ResourceGroupName azps_test_group | Remove-AzHealthcareApisWorkspace
```

Deletes a specified workspace.