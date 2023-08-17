### Example 1: Update an Azure Load Testing resource with tags
```powershell
$tag = @{"key0" = "value0"}
Update-AzLoad -Name sampleres -ResourceGroupName sample-rg -Tag $tag
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command updates the Azure Load Testing resource named sampleres in resource group named sample-rg with the provided tags.

### Example 2: Update an Azure Load Testing resource to use System-Assigned identity for CMK encryption
```powershell
Update-AzLoad -Name sampleres -ResourceGroupName sample-rg -IdentityType "SystemAssigned" -EncryptionIdentity "SystemAssigned" -EncryptionKey "https://sample-akv.vault.azure.net/keys/cmk/2d1ccd5c50234ea2a0858fe148b69cde"
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command updates the Azure Load Testing resource named sampleres in resource group named sample-rg, to use System-assigned identity for accessing the encryption key for CMK encryption.

### Example 3: Update an Azure Load Testing resource to remove an existing User-Assigned managed identity
```powershell
$userAssigned = @{"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1" = @{}; "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity2" = $null}

Update-AzLoad -Name sampleres -ResourceGroupName sample-rg -IdentityType "SystemAssigned,UserAssigned" -IdentityUserAssigned $userAssigned
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command updates the Azure Load Testing resource named sampleres in resource group named sample-rg, to remove the user-assigned managed identity "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity2" if already assigned to the resource.
