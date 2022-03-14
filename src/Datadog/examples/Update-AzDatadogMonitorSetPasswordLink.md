### Example 1: Refresh the set password link and return a latest one
```powershell
Update-AzDatadogMonitorSetPasswordLink -ResourceGroupName azure-rg-Datadog -Name Datadog
```

```output
https://us3.Datadoghq.com/account/reset_password/xxxxxxxxxxxxxxxxxxxxxxxxxxx
```

This command refresh the set password link and return a latest one.

### Example 2: Refresh the set password link and return a latest one by pipeline
```powershell
Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Update-AzDatadogMonitorSetPasswordLink
```

```output
https://us3.Datadoghq.com/account/reset_password/xxxxxxxxxxxxxxxxxxxxxxxxxxx
```

This command refresh the set password link and return a latest one by pipeline.

