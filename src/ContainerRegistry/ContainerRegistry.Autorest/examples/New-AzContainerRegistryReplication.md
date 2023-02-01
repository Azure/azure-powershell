### Example 1: {{ Add title here }}
```powershell
 New-AzContainerRegistryReplication -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -Name replication001 -Location 'west us' -Tag @{tagName='MyTag'}
```

```output
Name           Location ProvisioningState StatusTimestamp
----           -------- ----------------- ---------------
replication001 westus   Succeeded         1/19/2023 5:57:00 AM
```

Creates a container registry replication.

