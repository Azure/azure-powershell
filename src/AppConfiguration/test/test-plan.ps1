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

