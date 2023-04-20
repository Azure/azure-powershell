### Example 1: Get the agent pool of an registry
```powershell
Get-AzContainerRegistryAgentPool -RegistryName RegistryExample -ResourceGroupName MyResourceGroup
```

```output
Name  Location OS    Count ProvisioningState
----  -------- --    ----- -----------------
agent eastus   Linux 5     Succeeded
```

Get the agent pool of an registry
