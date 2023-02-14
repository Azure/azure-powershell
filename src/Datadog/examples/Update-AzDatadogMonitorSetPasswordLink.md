### Example 1: Refresh the set password link and return a latest one
```powershell
<<<<<<< HEAD
Update-AzDatadogMonitorSetPasswordLink -ResourceGroupName azure-rg-Datadog -Name Datadog
```

```output
=======
PS C:\> Update-AzDatadogMonitorSetPasswordLink -ResourceGroupName azure-rg-Datadog -Name Datadog

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
https://us3.Datadoghq.com/account/reset_password/xxxxxxxxxxxxxxxxxxxxxxxxxxx
```

This command refresh the set password link and return a latest one.

### Example 2: Refresh the set password link and return a latest one by pipeline
```powershell
<<<<<<< HEAD
Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Update-AzDatadogMonitorSetPasswordLink
```

```output
=======
PS C:\> Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Update-AzDatadogMonitorSetPasswordLink

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
https://us3.Datadoghq.com/account/reset_password/xxxxxxxxxxxxxxxxxxxxxxxxxxx
```

This command refresh the set password link and return a latest one by pipeline.

