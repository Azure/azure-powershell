### Example 1: Create a hot storage
```powershell
New-AzCommvaultStorage -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name storage-hot -Location eastus -StorageClassType HOT
```

Creates a hot storage in the East US region.

### Example 2: Create a cold storage
```powershell
New-AzCommvaultStorage -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name storage-cold -Location eastus -StorageClassType COLD
```

Creates a cold storage in the East US region.

