### Example 1: Deletes a specified workspace.
```powershell
PS C:\> Remove-AzHealthcareApisWorkspace -Name azpshcws -ResourceGroupName azps_test_group

```

Deletes a specified workspace.

### Example 2: Deletes a specified workspace.
```powershell
PS C:\> Get-AzHealthcareApisWorkspace -Name azpshcws -ResourceGroupName azps_test_group | Remove-AzHealthcareApisWorkspace

```

Deletes a specified workspace.