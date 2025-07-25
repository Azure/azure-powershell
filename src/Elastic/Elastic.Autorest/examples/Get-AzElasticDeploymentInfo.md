### Example 1: Fetch information regarding Elastic cloud deployment corresponding to the Elastic monitor resource
```powershell
Get-AzElasticDeploymentInfo -ResourceGroupName elastic-rg-3eytki -Name elastic-rhqz1v
```

```output
DiskCapacity MemoryCapacity Status  Version
------------ -------------- ------  -------
491520       16384          Healthy 7.14.1
```

This command fetches information regarding Elastic cloud deployment corresponding to the Elastic monitor resource.
