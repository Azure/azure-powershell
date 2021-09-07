### Example 1: Get a tag rule set for a given monitor resource
```powershell
PS C:\> Get-AzElasticTagRule -ResourceGroupName azure-elastic-test -MonitorName elastic-pwsh02

Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         azure-elastic-test
```

This command gets a tag rule set for a given monitor resource.

### Example 2: Get a tag rule set for a given monitor resource by pipeline
```powershell
PS C:\> New-AzElasticTagRule -ResourceGroupName azps-elastic-test -MonitorName elastic-pwsh02 | Get-AzElasticTagRule

Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         azure-elastic-test
```

This command gets a tag rule set for a given monitor resource by pipeline.

