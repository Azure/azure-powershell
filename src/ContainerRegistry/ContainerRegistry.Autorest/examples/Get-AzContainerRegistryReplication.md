### Example 1: Gets all the replications of a container registry
```powershell
 Get-AzContainerRegistryReplication -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample"
```

```output
Name           Location ProvisioningState StatusTimestamp
----           -------- ----------------- ---------------
replication001 westus   Succeeded         1/19/2023 5:57:00 AM
eastus2        eastus2  Succeeded         1/19/2023 5:56:51 AM
```

Gets all the replications of a container registry

### Example 2: Gets a specified replication of a container registry
```powershell
Get-AzContainerRegistryReplication -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample"  -Name "replication001"
```

```output
Name           Location ProvisioningState StatusTimestamp
----           -------- ----------------- ---------------
replication001 westus   Succeeded         1/19/2023 5:57:00 AM
```

Gets a specified replication of a container registry

