### Example 1: Get a tag rule set for a given monitor resource
```powershell
<<<<<<< HEAD
Get-AzElasticTagRule -ResourceGroupName azure-elastic-test -MonitorName elastic-pwsh02
```

```output
=======
PS C:\> Get-AzElasticTagRule -ResourceGroupName azure-elastic-test -MonitorName elastic-pwsh02

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         azure-elastic-test
```

This command gets a tag rule set for a given monitor resource.

### Example 2: Get a tag rule set for a given monitor resource by pipeline
```powershell
<<<<<<< HEAD
New-AzElasticTagRule -ResourceGroupName azps-elastic-test -MonitorName elastic-pwsh02 | Get-AzElasticTagRule
```

```output
=======
PS C:\> New-AzElasticTagRule -ResourceGroupName azps-elastic-test -MonitorName elastic-pwsh02 | Get-AzElasticTagRule

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         azure-elastic-test
```

This command gets a tag rule set for a given monitor resource by pipeline.

