### Example 1: Delete a service instance.
```powershell
PS C:\> Remove-AzHealthcareAPIsService -ResourceGroupName azps_test_group -Name azpsapiservice

```

Delete a service instance.

### Example 2: Delete a service instance.
```powershell
PS C:\> Get-AzHealthcareAPIsService -ResourceGroupName azps_test_group -Name azpsapiservice | Remove-AzHealthcareAPIsService

```

Delete a service instance.