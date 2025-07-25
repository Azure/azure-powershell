### Example 1: Get a specified container registry
```powershell
Get-AzContainerRegistry -ResourceGroupName "MyResourceGroup" -Name "MyRegistry"
```

```output
Name  SkuName LoginServer      CreationDate          ProvisioningState AdminUserEnabled
----  ------- -----------      ------------          ----------------- ----------------
testc Premium testc.azurecr.io 16/01/2023 8:45:50 pm Succeeded         True
```

This command gets the specified container registry.

### Example 2: Get all the container registries in a resource group
```powershell
Get-AzContainerRegistry -ResourceGroupName "MyResourceGroup"
```

```output
Name   SkuName LoginServer       CreationDate          ProvisioningState AdminUserEnabled
----   ------- -----------       ------------          ----------------- ----------------
testc2 Premium testc2.azurecr.io 17/01/2023 3:47:50 pm Succeeded         True
testc  Premium testc.azurecr.io  16/01/2023 8:45:50 pm Succeeded         True
```

This command gets all the container registries in a resource group.

### Example 3:  Get all the container registries in the subscription
```powershell
Get-AzContainerRegistry
```

```output
Name   SkuName LoginServer       CreationDate          ProvisioningState AdminUserEnabled
----   ------- -----------       ------------          ----------------- ----------------
testc2 Premium testc2.azurecr.io 17/01/2023 3:47:50 pm Succeeded         True
testc  Premium testc.azurecr.io  16/01/2023 8:45:50 pm Succeeded         True
```

This command gets all the container registries in the subscription.

