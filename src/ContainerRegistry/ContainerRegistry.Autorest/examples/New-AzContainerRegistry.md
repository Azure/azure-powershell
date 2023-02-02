### Example 1: Create a container registry with a new storage account.
```powershell
 New-AzContainerRegistry -ResourceGroupName "MyResourceGroup" -Name "RegistryExample" -SkuName "Basic" -Location "west us"
```

```output
Name             SkuName LoginServer                 CreationDate         ProvisioningState AdminUserEnabled
----             ------- -----------                 ------------         ----------------- ----------------
RegistryExample Basic   registryexample.azurecr.io 1/19/2023 6:10:49 AM Succeeded         False
```

Create a container registry with a new storage account.

### Example 2: Create a container registry with admin user enabled.
```powershell
 New-AzContainerRegistry -ResourceGroupName "MyResourceGroup" -Name "RegistryExample" -SkuName "Basic" -Location "west us" -AdminUserEnabled
```

```output
Name             SkuName LoginServer                 CreationDate         ProvisioningState AdminUserEnabled
----             ------- -----------                 ------------         ----------------- ----------------
RegistryExample Basic   registryexample.azurecr.io 1/19/2023 6:10:49 AM Succeeded         True
```

Create a container registry with admin user enabled.

