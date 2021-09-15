### Example 1: Refresh the set password link and return a latest one
```powershell
PS C:\> Update-AzDatadogMonitorSetPasswordLink -ResourceGroupName azure-rg-Datadog -Name Datadog

https://us3.Datadoghq.com/account/reset_password/xxxxxxxxxxxxxxxxxxxxxxxxxxx
```

This command refresh the set password link and return a latest one.

### Example 2: Refresh the set password link and return a latest one by pipeline
```powershell
PS C:\> Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Update-AzDatadogMonitorSetPasswordLink

https://us3.Datadoghq.com/account/reset_password/xxxxxxxxxxxxxxxxxxxxxxxxxxx
```

This command refresh the set password link and return a latest one by pipeline.

