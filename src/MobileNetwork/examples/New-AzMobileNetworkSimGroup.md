### Example 1: Creates or updates a SIM group.
```powershell
New-AzMobileNetworkSimGroup -Name azps-mn-simgroup -ResourceGroupName azps_test_group -Location eastus -IdentityType 'UserAssigned' -EncryptionKeyUrl "https://azps-keyvault.vault.azure.net/keys/keyvault" -IdentityUserAssignedIdentity $ManagedIdentity -MobileNetworkId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn"
```

```output
Location Name             ResourceGroupName ProvisioningState IdentityType
-------- ----             ----------------- ----------------- ------------
eastus   azps-mn-simgroup azps_test_group   Succeeded         UserAssigned
```

Creates or updates a SIM group.
You need to create Keyvault, managementiidentity, and give Keyvault some permissions on the ManagementIdentity