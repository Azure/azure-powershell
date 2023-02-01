### Example 1: Enable admin user for a specified container registry
```powershell
Update-AzContainerRegistry -ResourceGroupName "MyResourceGroup" -Name "RegistryExample" -EnableAdminUser
```

```output
Name             SkuName  LoginServer                 CreationDate         ProvisioningState AdminUserEnabled
----             -------  -----------                 ------------         ----------------- ----------------
RegistryExample Basic    registryexample.azurecr.io 1/19/2023 6:10:49 AM Succeeded         True
```

This command enables admin user for the specified container registry.


