### Example 1: Updates an agent pool with the specified parameters
```powershell
 update-AzContainerRegistryAgentPool -AgentPoolName agent -RegistryName RegistryExample -ResourceGroupName MyResourceGroup -Count 5
```

```output
Name  Location OS    Count ProvisioningState
----  -------- --    ----- -----------------
agent eastus   Linux 5     Succeeded
```

Updates an agent pool with the specified parameters


