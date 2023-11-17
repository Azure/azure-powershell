### Example 1: Create an Azure Load Testing resource
```powershell
New-AzLoad -Name sampleres -ResourceGroupName sample-rg -Location eastus
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command creates a new Azure Load Testing resource named sampleres in resource group named sample-rg and in the region East US.

### Example 2: Create an Azure Load Testing resource with Managed Identity
```powershell
$userAssigned = @{"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1" = @{}; "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity2" = @{}}

New-AzLoad -Name sampleres -ResourceGroupName sample-rg -Location eastus -IdentityType "SystemAssigned,UserAssigned" -IdentityUserAssigned $userAssigned
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command creates a new Azure Load Testing resource named sampleres in resource group named sample-rg and in the region East US, with System-Assigned and 2 provided User-Assigned managed identities.

### Example 3: Create an Azure Load Testing resource with Customer Managed key encryption
```powershell
$userAssigned = @{"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1" = @{}}

New-AzLoad -Name sampleres -ResourceGroupName sample-rg -Location eastus -IdentityType "SystemAssigned,UserAssigned" -IdentityUserAssigned $userAssigned -EncryptionIdentity "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1" -EncryptionKey "https://sample-akv.vault.azure.net/keys/cmk/2d1ccd5c50234ea2a0858fe148b69cde"
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command creates a new Azure Load Testing resource named sampleres in resource group named sample-rg and in the region East US, with the provided User-Assigned managed identity and uses the Encryption Identity to access the Encryption Key for CMK encryption.

### Example 4: Create an Azure Load Testing resource with tags
```powershell
$tag = @{"key1" = "value1"; "key2" = "value2"}
New-AzLoad -Name sampleres -ResourceGroupName sample-rg -Location eastus -Tag $tag
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command creates a new Azure Load Testing resource named sampleres in resource group named sample-rg and in the region East US with the provided tags.
