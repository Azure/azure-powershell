# 1. New-AzAppConfigurationStore
# 1.1. Without -IdentityType
# 1.2. -IdentityType SystemAssigned
#   $result.IdentityPrincipalId should NOT be null
#   $result.IdentityTenantId should NOT be null
#   $result.IdentityType should equal "SystemAssigned"
#   $result.IdentityUserAssignedIdentity.Count should equal 0
# 1.3. -IdentityType UserAssigned -UserAssignedIdentity /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/yemingac/providers/Microsoft.ManagedIdentity/userAssignedIdentities/yemingactest (you need to create a user-assigned managed identity first: https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/how-to-manage-ua-identity-powershell)
#   $result.IdentityType should equal "UserAssigned"
#   $result.IdentityUserAssignedIdentity.Count should > 0
# 1.4 -IdentityType SystemAssignedAndUserAssigned -UserAssignedIdentity /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/yemingac/providers/Microsoft.ManagedIdentity/userAssignedIdentities/yemingactest
#   $result.IdentityPrincipalId should NOT be null
#   $result.IdentityTenantId should NOT be null
#   $result.IdentityType should equal "SystemAssigned, UserAssigned"
#   $result.IdentityUserAssignedIdentity.Count should > 0

# 2. Update-AzAppConfigurationStore
# 2.1 Assign a system assigned or user assigned managed identity
# 2.2 Enable encryption using system-assigned identity (-EncryptionKeyIdentifier https://yemingac.vault.azure.net/keys/encryptionkey/10f3811b78a24208ae5ebbfe18983f6d)
#   To enable encryption, the managed identity must have access to the key vault (key vault must enable soft delete, purge protection), with key permissions GET WRAP UNWRAP
#   $result.KeyVaultPropertyKeyIdentifier should equal EncryptionKeyIdentifier
# 2.3 Enable encryption using user-assigned identity (-EncryptionKeyIdentifier https://yemingac.vault.azure.net/keys/encryptionkey/10f3811b78a24208ae5ebbfe18983f6d -KeyVaultIdentityClientId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/yemingac/providers/Microsoft.ManagedIdentity/userAssignedIdentities/yemingactest)
# 2.4 Update tags
# 2.5 Upgrade SKU (free -> Standard)
# 2.6 Disable managed identity (-IdentityType None)

