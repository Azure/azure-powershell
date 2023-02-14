### Example 1: Delete a monitor resource
```powershell
<<<<<<< HEAD
Remove-AzElasticMonitor -ResourceGroupName azure-elastic-test -Name elastic-pwsh02
=======
PS C:\> Remove-AzElasticMonitor -ResourceGroupName azure-elastic-test -Name elastic-pwsh02

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command delete a monitor resource.

### Example 2: Delete a monitor resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzElasticMonitor -ResourceGroupName azure-elastic-test -Name elastic-pwsh03 | Remove-AzElasticMonitor
=======
PS C:\> Get-AzElasticMonitor -ResourceGroupName azure-elastic-test -Name elastic-pwsh03 | Remove-AzElasticMonitor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command delete a monitor resource by pipeline.

