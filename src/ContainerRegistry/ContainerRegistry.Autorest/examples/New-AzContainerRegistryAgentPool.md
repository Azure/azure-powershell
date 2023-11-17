### Example 1: Creates an agent pool for a container registry with the specified parameters.
```powershell
New-AzContainerRegistryAgentPool -name agent  -RegistryName RegistryExample -ResourceGroupName MyResourceGroup -Location 'eastus' -Count 1 -Tier S1 -os 'Linux'
```

```output
Name  Location OS    Count ProvisioningState
----  -------- --    ----- -----------------
agent eastus   Linux 1     Succeeded

```

Creates an agent pool for a container registry with the specified parameters.
Please notice that some parameters are required in this cmdlets but not marked as required in syntax, we would change it later.
