## Generated

### KeyVault Management Plane

#### Access Policies

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Set-AzKeyVaultAccessPolicy` | No | - For AD parameters (`-ServicePrincipalName`, `-UserPrincipalName`, `-ObjectId`, `-EmailAddress`, `-ApplicationId`), determine if we want to update current variant(s) to include these for filtering<br>- Look into additional all other missing parameters (found in properties of policy) |

### Vaults

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzKeyVault` | No | - Add variant that uses hidden deleted vault variant (brings in `-Location` and `-InRemovedState` parameters)<br>- Look at adding custom filter for `-Tag` parameter |
| `New-AzKeyVault` | No | - Do we want to add an alias to `-Sku` for the new `-SkuName` parameter? |
| `Remove-AzKeyVault` | No | - Add variant that uses hidden deleted vault variant (brings in `-Location` and `-InRemovedState` parameters)<br>- Look at adding `-Force` and `-AsJob` parameters |
| `Set-AzKeyVault` | Yes |  |
| `Test-AzKeyVaultNameAvailability` | Yes |  |
| `Update-AzKeyVault` | Yes |  |

### KeyVault Data Plane

#### General

- All data plane cmdlets are missing `-VaultName` parameter
- `-PassThru` is missing from select `Remove-*` cmdlets

#### Certificates

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Backup-AzKeyVaultCertificate` | No | - This cmdlet should write to a file instead of returning `byte[]`; add optional `-OutputFile` parameter to enable this<br>- Should we add `-Force` parameter? |
| `Get-AzKeyVaultCertificate` | No | - Add variant that has `-IncludeVersions` switch, which uses an empty string for `-Version`<br>- Add variant to get deleted certificates (which is currently hidden) |
| `Get-AzKeyVaultCertificateContact` | No | - Missing `-InputObject` parameter will be included when `-VaultName` (or similar parameter) is added |
| `Get-AzKeyVaultCertificateIssuer` | No |  |
| `Get-AzKeyVaultCertificateOperation` | No |  |
| `Get-AzKeyVaultCertificatePolicy` | No |
| `Get-AzKeyVaultCertificateVersion` | Yes |  |
| `Import-AzKeyVaultCertificate` | No | - Add `-FilePath` parameter to specify the path of the certificate<br>- Check if generated `-Base64EncodedCertificate` parameter is the same as the current `-CertificateString` parameter<br>- Allow user to pass a certificate directly (can replace `-CertificateCollection` parameter) |
| `Merge-AzKeyVaultCertificate` | Yes |  |
| `New-AzKeyVaultCertificate` | No - `Add-AzKeyVaultCertificate` | - Add alias to `-Policy` for `-CertificatePolicy` |
| `Remove-AzKeyVaultCertificate` | No | - Should we add `-InRemovedState` switch parameter, or use generated `Clear-AzKeyVaultDeletedCertificate` cmdlet?<br>- See if we need `-Force` parameter |
| `Remove-AzKeyVaultCertificateContract` | No | - Missing `-InputObject` parameter will be included when `-VaultName` (or similar parameter) is added<br>- Should we add missing `-EmailAddress` parameter? |
| `Remove-AzKeyVaultCertificateIssuer` | No | - See if we need `-Force` parameter |
| `Remove-AzKeyVaultCertificateOperation` | No | - See if we need `-Force` parameter |
| `Restore-AzKeyVaultCertificate` | No | - Missing `-InputObject` parameter will be included when `-VaultName` (or similar parameter) is added<br>- Add variant to allow user to provide `-InputFile` instead of providing a `byte[]` value for `-BundleBackup` |
| `Set-AzKeyVaultCertificateContact` | No - `Add-AzKeyVaultCertificateContact` |  |
| `Set-AzKeyVaultCertificateIssuer` | No | - Add alias to `-Provider` for `-IssuerProvider`<br>- Add alias to `-CredentialsAccountId` for `-AccountId`<br>- See if `-CredentialsPassword` can be used for `-ApiKey`<br>- See if we need `-OrganizationDetails` since it's been broken into its components |
| `Undo-AzKeyVaultCertificateRemoval` | No |  |
| `Update-AzKeyVaultCertificate` | No | - Add alias to `-AttributesEnabled` for  `-Enabled` |
| `Update-AzKeyVaultCertificateIssuer` | Yes |  |
| `Update-AzKeyVaultCertificateOperation` | No - `Stop-AzKeyVaultCertificateOperation` |  |
| `Update-AzKeyVaultCertificatePolicy` | No - `Set-AzKeyVaultCertificatePolicy` |  |

#### Keys

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Backup-AzKeyVaultKey` | No | - This cmdlet should write to a file instead of returning `byte[]`; add optional `-OutputFile` parameter to enable this<br>- Should we add `-Force` parameter? |
| `Get-AzKeyVaultKey` | No | - Add variant that has `-IncludeVersions` switch, which uses an empty string for `-Version`<br>- Add variant to get deleted keys (which is currently hidden) |
| `Get-AzKeyVaultKeyVersion` | Yes |  |
| `Import-AzKeyVaultKey` | No - `Add-AzKeyVaultKey` |  |
| `New-AzKeyVaultKey` | No - `Add-AzKeyVaultKey` | - `-Attribute` parameter not being flattened like it is in `Update-AzKeyVaultSecret` |
| `Remove-AzKeyVaultKey` | No | - Should we add `-InRemovedState` switch parameter, or use generated `Clear-AzKeyVaultDeletedKey` cmdlet?<br>- See if we need `-Force` parameter |
| `Restore-AzKeyVaultKey` | No | - Missing `-InputObject` parameter will be included when `-VaultName` (or similar parameter) is added<br>- Add variant to allow user to provide `-InputFile` instead of providing a `byte[]` value for `-BundleBackup` |
| `Test-AzKeyVaultKey` | Yes |  |
| `Undo-AzKeyVaultKeyRemoval` | No |  |
| `Update-AzKeyVaultKey` | No | - `-Attribute` parameter not being flattened like it is in `Update-AzKeyVaultSecret` |

#### Secrets

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Backup-AzKeyVaultSecret` | No | - This cmdlet should write to a file instead of returning `byte[]`; add optional `-OutputFile` parameter to enable this<br>- Should we add `-Force` parameter? |
| `Get-AzKeyVaultSecret` | No | - Add variant that has `-IncludeVersions` switch, which uses an empty string for `-Version`<br>- Add variant to get deleted secrets (which is currently hidden) |
| `Get-AzKeyVaultSecretVersion` | Yes |  |
| `Remove-AzKeyVaultSecret` | No | - Should we add `-InRemovedState` switch parameter, or use generated `Clear-AzKeyVaultDeletedSecret` cmdlet?<br>- See if we need `-Force` parameter |
| `Restore-AzKeyVaultSecret` | No | - Missing `-InputObject` parameter will be included when `-VaultName` (or similar parameter) is added<br>- Add variant to allow user to provide `-InputFile` instead of providing a `byte[]` value for `-BundleBackup` |
| `Set-AzKeyVaultSecret` | No | - Add alias to `-AttributesEnabled` for `-Enabled`<br>- Add alias to `-AttributesExpire` for `-Expires`<br>- Add alias to `-AttributesNotBefore` for `-NotBefore`<br>- See if the `-Value` parameter can be changed to `-SecretValue` that is of type `SecureString` |
| `Undo-AzKeyVaultSecretRemoval` | No |  |
| `Update-AzKeyVaultSecret` | No | - Add alias to `-AttributesEnabled` for `-Enabled`<br>- Add alias to `-AttributesExpire` for `-Expires`<br>- Add alias to `-AttributesNotBefore` for `-NotBefore` |

#### Storage Accounts

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Backup-AzKeyVaultStorageAccount` | No - `Backup-AzKeyVaultManagedStorageAccount` |  |
| `Get-AzKeyVaultStorageAccount` | No - `Get-AzKeyVaultManagedStorageAccount` |  |
| `New-AzKeyVaultStorageAccountKey` | No - `Update-AzKeyVaultManagedStorageAccountKey` |  |
| `Remove-AzKeyVaultStorageAccount` | No - `Remove-AzKeyVaultManagedStorageAccount` |  |
| `Restore-AzKeyVaultStorageAccount` | No - `Restore-AzKeyVaultManagedStorageAccount` and `Undo-AzKeyVaultManagedStorageAccountRemoval` |  |
| `Set-AzKeyVaultStorageAccount` | No - `Add-AzKeyVaultManagedStorageAccount` |  |
| `Undo-AzKeyVaultStorageAccountRemoval` | No |  |
| `Update-AzKeyVaultStorageAccount` | No - `Update-AzKeyVaultManagedStorageAccount` |  |

#### Storage Account Sas Definition

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzKeyVaultStorageSasDefinition` | No - `Get-AzKeyVaultManagedStorageSasDefinition` |  |
| `Remove-AzKeyVaultStorageSasDefinition` | No - `Remove-AzKeyVaultManagedStorageSasDefinition` |  |
| `Set-AzKeyVaultStorageSasDefinition` | No - `Set-AzKeyVaultManagedStorageSasDefinition` |  |
| `Undo-AzKeyVaultStorageSasDefinitionRemoval` | No |  |
| `Update-AzKeyVaultStorageSasDefinition` | No - `Update-AzKeyVaultManagedStorageSasDefinition` |  |

#### Other

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Invoke-AzKeyVaultSignKey` | Yes | - Determine what should be provided to `-Value` |
| `Invoke-AzKeyVaultUnwrapKey` | Yes | - Determine what should be provided to `-Value` |
| `Invoke-AzKeyVaultWrapKey` | Yes | - Determine what should be provided to `-Value` |
| `Protect-AzKeyVaultKey` | Yes | - Determine what should be provided to `-Value` |
| `Test-AzKeyVaultNameAvailability` | Yes |  |
| `Unprotect-AzKeyVaultKey` | Yes | - Determine what should be provided to `-Value` |

## Not Generated

### KeyVault Management Plane

#### Access Policies

- `Remove-AzKeyVaultAccessPolicy`

#### Vaults

- `Undo-AzKeyVaultRemoval` (makes call to `CreateOrUpdate` in KeyVault SDK)

### KeyVault Data Plane

#### Certificates

- `New-AzKeyVaultCertificateAdministratorDetails` (in-memory object creation cmdlet)
- `New-AzKeyVaultCertificateOrganizationDetails` (in-memory object creaton cmdlet)
- `New-AzKeyVaultCertificatePolicy` (in-memory object creation cmdlet)

#### Network Rule

- `Add-AzKeyVaultNetworkRule` (network rules are properties on a vault, we can leverage existing variants to create this cmdlet)
- `Remove-AzKeyVaultNetworkRule` (network rules are properties on a vault, we can leverage existing variants to create this cmdlet)
- `Update-AzKeyVaultNetworkRuleSet` (network rules are properties on a vault, we can leverage existing variants to create this cmdlet)