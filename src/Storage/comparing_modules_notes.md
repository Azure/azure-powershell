## StorageAccount

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzStorageAccount` | No | - Just list subscription and resource group level (no name parameter) |
| `Set-AzStorageAccount` | No | - Implement "Failover" operation, not the "Set" |
| `New-AzStorageAccount` | No | - The original cmdlet uses the `NameAvailability` check before creating<br>- The original cmdlet returns results from `GetProperties`<br>- `-CustomDomainUseSubDomainName` -> `-UseSubDOmain`<br>- Missing `-AssignIdentity` that resets `Identity`<br>- rename the parameter prefix `NetworkAcls` to `NetworkRuleSet`?<br>- `-IsHnsEnabled` -> `-EnableHierarchicalNamespace` |
| `Remove-AzStorageAccount` | No | - No `-Force` and `-AsJob` |
| `Update-AzStorageAccount` -> `Set-AzStorageAccount` | Yes | - The original cmdlet returns results from `GetProperties` |
| `Get-AzStorageAccountProperty` | Yes | - The original `Get-AzStorageAccount` have a parameter set that uses this for getting single storage account information |
| `Get-AzStorageAccountKey`<br>`New-AzStorageAccountKey` | No | - Correct |
| `Get-AzStorageAccountSas` | Yes ||
| `Get-AzStorageAccountServiceSas` | Yes ||
| `Revoke-AzStorageAccountUserDelegationKey` | Yes | |
| `Test-AzStorageAccountNameAvailability` -> `Get-AzStorageAccountNameAvailability` | No | |
| `Get-AzManagementPolicy` -> `Get-AzStorageAccountManagementPolicy` | No | |
| `Set-AzManagementPolicy` -> `Set-AzStorageAccountManagementPolicy` | No | |
| `Remove-AzManagementPolicy` -> `Remove-AzStorageAccountManagementPolicy` | No | |
| `New-AzManagementPolicy` | Yes | - "New" version of `Set-AzStorageAccountManagementPolicy` |
| `Add-AzStorageAccountManagementPolicyAction` | X | - Missing in-memory object creation `PSManagementPolicyActionGroup` |
| `New-AzStorageAccountManagementPolicyFilter` | X | - Missing in-memory object creation `PSManagementPolicyRuleFilter` |
| `New-AzStorageAccountManagementPolicyRule` | X | - Missing in-memory object creation `PSManagementPolicyRule` |
| `Get-AzStorageAccountNetworkRuleSet`| X | - NetworkRuleSet is extracted from `StorageAccountProperty` |
| `Update-AzStorageAccountNetworkRuleSet` | X | - Update NetworkRuleSet using `Set-AzStorageAccount` |
| `Add-AzStorageAccountNetworkRule` | X | - Missing in-memory object creation `PSNetworkRuleSet`<br>- Information extracted from `StorageAccountProperty` |
| `Remove-AzStorageAccountNetworkRule` | X | - Remove the different rules using `Set-AzStorageAccount` |
| `Set-AzCurrentStorageAccount` | X | - Set defaul storage account to the context |

## Others

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzSku` | Yes | |
| `Get-AzUsage` | Yes | |