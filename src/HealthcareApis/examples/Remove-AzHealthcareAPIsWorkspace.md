### Example 1: Delete
```powershell
PS C:\> Remove-AzHealthcareAPIsWorkspace -Name azpshcws -ResourceGroupName azps_test_group

```

Deletes a specified workspace.

### Example 2: DeleteViaIdentity
```powershell
PS C:\> Get-AzHealthcareAPIsWorkspace -Name azpshcws -ResourceGroupName azps_test_group | Remove-AzHealthcareAPIsWorkspace

```

Deletes a specified workspace.