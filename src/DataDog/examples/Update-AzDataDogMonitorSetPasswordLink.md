### Example 1: Refresh the set password link and return a latest one
```powershell
PS C:\> Update-AzDataDogMonitorSetPasswordLink -ResourceGroupName azure-rg-datadog -Name datadog

https://us3.datadoghq.com/account/reset_password/xxxxxxxxxxxxxxxxxxxxxxxxxxx
```

This command refresh the set password link and return a latest one.

### Example 2: Refresh the set password link and return a latest one by pipeline
```powershell
PS C:\> Get-AzDataDogMonitor -ResourceGroupName azure-rg-datadog -Name datadog | Update-AzDataDogMonitorSetPasswordLink

https://us3.datadoghq.com/account/reset_password/xxxxxxxxxxxxxxxxxxxxxxxxxxx
```

This command refresh the set password link and return a latest one by pipeline.

