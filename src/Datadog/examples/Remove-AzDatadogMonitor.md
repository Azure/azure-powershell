### Example 1: Delete a monitor resource
```powershell
<<<<<<< HEAD
Remove-AzDatadogMonitor -ResourceGroupName azure-rg-test -Name Datadog-portal03
=======
PS C:\> Remove-AzDatadogMonitor -ResourceGroupName azure-rg-test -Name Datadog-portal03

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a monitor resource.

### Example 2: Delete a monitor resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzDatadogMonitor -ResourceGroupName azure-rg-test -Name Datadog-portal02 | Remove-AzDatadogMonitor
=======
PS C:\> Get-AzDatadogMonitor -ResourceGroupName azure-rg-test -Name Datadog-portal02 | Remove-AzDatadogMonitor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a monitor resource by pipeline.

