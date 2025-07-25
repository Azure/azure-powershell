### Example 1: Generate keys for a token of a specified container registry.
```powershell
 New-AzContainerRegistryCredentials -TokenId /subscriptions/xxxx/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/myRegistry/tokens/mytoken -RegistryName myRegistry -ResourceGroupName MyResourceGroup
```

```output
Username Password  Password2
-------- --------  ---------
token    xxxxxxxx  xxxxxxxxx
```

Generate keys for a token of a specified container registry.
