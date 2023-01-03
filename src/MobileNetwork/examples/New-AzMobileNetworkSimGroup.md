### Example 1: Creates or updates a SIM group.
```powershell
$ManagedIdentity = @{"/subscriptions/{subId}/resourcegroups/azps_test_group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azps-mn-mi"="{}"}

New-AzMobileNetworkSimGroup -Name azps-mn-simgroup -ResourceGroupName azps_test_group -Location eastus -IdentityType 'UserAssigned' -EncryptionKeyUrl "https://azps-keyvault.vault.azure.net/keys/keyvault" -IdentityUserAssignedIdentity $ManagedIdentity -MobileNetworkId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn"
```

```output
Location Name             ResourceGroupName ProvisioningState IdentityType
-------- ----             ----------------- ----------------- ------------
eastus   azps-mn-simgroup azps_test_group   Succeeded         UserAssigned
```

Creates or updates a SIM group.
You need to create Keyvault, managementiidentity, and give Keyvault some permissions on the ManagementIdentity