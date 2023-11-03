### Example 1: Delete a service instance.
```powershell
Remove-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice
```

Delete a service instance.

### Example 2: Delete a service instance.
```powershell
Get-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice | Remove-AzHealthcareApisService
```

Delete a service instance.