### Example 1: Refresh the set password link and return a latest one
```powershell
PS C:\> Update-AzDataDogMonitorSetPasswordLink -ResourceGroupName azure-rg-datadog -Name lucasdatadog

https://us3.datadoghq.com/account/reset_password/xxxxxxxxxxxxxxxxxxxxxxxxxxx
```

This command refresh the set password link and return a latest one.

### Example 2: Refresh the set password link and return a latest one by pipeline
```powershell
PS C:\> Get-AzDataDogMonitor -ResourceGroupName azure-rg-datadog -Name lucasdatadog | Update-AzDataDogMonitorSetPasswordLink

https://us3.datadoghq.com/account/reset_password/cb4944722db3d009edc994dc2eed24c5179d5903
```

This command refresh the set password link and return a latest one by pipeline.

