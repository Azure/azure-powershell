---
Module Name: Az.KeyVault
Module Guid: bf1e620f-fefa-4441-215c-6cb11384ed1a
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.keyvault
Help Version: 1.0.0.0
Locale: en-US
---

# Az.KeyVault Module
## Description
Microsoft Azure PowerShell: KeyVault cmdlets

## Az.KeyVault Cmdlets
### [Backup-AzKeyVaultCertificate](Backup-AzKeyVaultCertificate.md)
Requests that a backup of the specified certificate be downloaded to the client.
All versions of the certificate will be downloaded.
This operation requires the certificates/backup permission.

### [Backup-AzKeyVaultKey](Backup-AzKeyVaultKey.md)
The Key Backup operation exports a key from Azure Key Vault in a protected form.
Note that this operation does NOT return key material in a form that can be used outside the Azure Key Vault system, the returned key material is either protected to a Azure Key Vault HSM or to Azure Key Vault itself.
The intent of this operation is to allow a client to GENERATE a key in one Azure Key Vault instance, BACKUP the key, and then RESTORE it into another Azure Key Vault instance.
The BACKUP operation may be used to export, in protected form, any key type from Azure Key Vault.
Individual versions of a key cannot be backed up.
BACKUP / RESTORE can be performed within geographical boundaries only; meaning that a BACKUP from one geographical area cannot be restored to another geographical area.
For example, a backup from the US geographical area cannot be restored in an EU geographical area.
This operation requires the key/backup permission.

### [Backup-AzKeyVaultSecret](Backup-AzKeyVaultSecret.md)
Requests that a backup of the specified secret be downloaded to the client.
All versions of the secret will be downloaded.
This operation requires the secrets/backup permission.

### [Backup-AzKeyVaultStorageAccount](Backup-AzKeyVaultStorageAccount.md)
Requests that a backup of the specified storage account be downloaded to the client.
This operation requires the storage/backup permission.

### [Clear-AzKeyVaultDeleted](Clear-AzKeyVaultDeleted.md)
Permanently deletes the specified vault.
aka Purges the deleted Azure key vault.

### [Clear-AzKeyVaultDeletedCertificate](Clear-AzKeyVaultDeletedCertificate.md)
The PurgeDeletedCertificate operation performs an irreversible deletion of the specified certificate, without possibility for recovery.
The operation is not available if the recovery level does not specify 'Purgeable'.
This operation requires the certificate/purge permission.

### [Clear-AzKeyVaultDeletedKey](Clear-AzKeyVaultDeletedKey.md)
The Purge Deleted Key operation is applicable for soft-delete enabled vaults.
While the operation can be invoked on any vault, it will return an error if invoked on a non soft-delete enabled vault.
This operation requires the keys/purge permission.

### [Clear-AzKeyVaultDeletedSecret](Clear-AzKeyVaultDeletedSecret.md)
The purge deleted secret operation removes the secret permanently, without the possibility of recovery.
This operation can only be enabled on a soft-delete enabled vault.
This operation requires the secrets/purge permission.

### [Clear-AzKeyVaultDeletedStorageAccount](Clear-AzKeyVaultDeletedStorageAccount.md)
The purge deleted storage account operation removes the secret permanently, without the possibility of recovery.
This operation can only be performed on a soft-delete enabled vault.
This operation requires the storage/purge permission.

### [Get-AzKeyVault](Get-AzKeyVault.md)
Gets the specified Azure key vault.

### [Get-AzKeyVaultCertificate](Get-AzKeyVaultCertificate.md)
Gets information about a specific certificate.
This operation requires the certificates/get permission.

### [Get-AzKeyVaultCertificateContact](Get-AzKeyVaultCertificateContact.md)
The GetCertificateContacts operation returns the set of certificate contact resources in the specified key vault.
This operation requires the certificates/managecontacts permission.

### [Get-AzKeyVaultCertificateIssuer](Get-AzKeyVaultCertificateIssuer.md)
The GetCertificateIssuers operation returns the set of certificate issuer resources in the specified key vault.
This operation requires the certificates/manageissuers/getissuers permission.

### [Get-AzKeyVaultCertificateOperation](Get-AzKeyVaultCertificateOperation.md)
Gets the creation operation associated with a specified certificate.
This operation requires the certificates/get permission.

### [Get-AzKeyVaultCertificatePolicy](Get-AzKeyVaultCertificatePolicy.md)
The GetCertificatePolicy operation returns the specified certificate policy resources in the specified key vault.
This operation requires the certificates/get permission.

### [Get-AzKeyVaultCertificateVersion](Get-AzKeyVaultCertificateVersion.md)
The GetCertificateVersions operation returns the versions of a certificate in the specified key vault.
This operation requires the certificates/list permission.

### [Get-AzKeyVaultDeleted](Get-AzKeyVaultDeleted.md)
Gets the deleted Azure key vault.

### [Get-AzKeyVaultDeletedCertificate](Get-AzKeyVaultDeletedCertificate.md)
The GetDeletedCertificates operation retrieves the certificates in the current vault which are in a deleted state and ready for recovery or purging.
This operation includes deletion-specific information.
This operation requires the certificates/get/list permission.
This operation can only be enabled on soft-delete enabled vaults.

### [Get-AzKeyVaultDeletedKey](Get-AzKeyVaultDeletedKey.md)
Retrieves a list of the keys in the Key Vault as JSON Web Key structures that contain the public part of a deleted key.
This operation includes deletion-specific information.
The Get Deleted Keys operation is applicable for vaults enabled for soft-delete.
While the operation can be invoked on any vault, it will return an error if invoked on a non soft-delete enabled vault.
This operation requires the keys/list permission.

### [Get-AzKeyVaultDeletedSecret](Get-AzKeyVaultDeletedSecret.md)
The Get Deleted Secrets operation returns the secrets that have been deleted for a vault enabled for soft-delete.
This operation requires the secrets/list permission.

### [Get-AzKeyVaultDeletedStorageAccount](Get-AzKeyVaultDeletedStorageAccount.md)
The Get Deleted Storage Accounts operation returns the storage accounts that have been deleted for a vault enabled for soft-delete.
This operation requires the storage/list permission.

### [Get-AzKeyVaultDeletedStorageDeletedSasDefinition](Get-AzKeyVaultDeletedStorageDeletedSasDefinition.md)
The Get Deleted Sas Definitions operation returns the SAS definitions that have been deleted for a vault enabled for soft-delete.
This operation requires the storage/listsas permission.

### [Get-AzKeyVaultKey](Get-AzKeyVaultKey.md)
The get key operation is applicable to all key types.
If the requested key is symmetric, then no key material is released in the response.
This operation requires the keys/get permission.

### [Get-AzKeyVaultKeyVersion](Get-AzKeyVaultKeyVersion.md)
The full key identifier, attributes, and tags are provided in the response.
This operation requires the keys/list permission.

### [Get-AzKeyVaultSecret](Get-AzKeyVaultSecret.md)
The GET operation is applicable to any secret stored in Azure Key Vault.
This operation requires the secrets/get permission.

### [Get-AzKeyVaultSecretVersion](Get-AzKeyVaultSecretVersion.md)
The full secret identifier and attributes are provided in the response.
No values are returned for the secrets.
This operations requires the secrets/list permission.

### [Get-AzKeyVaultStorageAccount](Get-AzKeyVaultStorageAccount.md)
List storage accounts managed by the specified key vault.
This operation requires the storage/list permission.

### [Get-AzKeyVaultStorageSasDefinition](Get-AzKeyVaultStorageSasDefinition.md)
List storage SAS definitions for the given storage account.
This operation requires the storage/listsas permission.

### [Import-AzKeyVaultCertificate](Import-AzKeyVaultCertificate.md)
Imports an existing valid certificate, containing a private key, into Azure Key Vault.
The certificate to be imported can be in either PFX or PEM format.
If the certificate is in PEM format the PEM file must contain the key as well as x509 certificates.
This operation requires the certificates/import permission.

### [Import-AzKeyVaultKey](Import-AzKeyVaultKey.md)
The import key operation may be used to import any key type into an Azure Key Vault.
If the named key already exists, Azure Key Vault creates a new version of the key.
This operation requires the keys/import permission.

### [Invoke-AzKeyVaultSignKey](Invoke-AzKeyVaultSignKey.md)
The SIGN operation is applicable to asymmetric and symmetric keys stored in Azure Key Vault since this operation uses the private portion of the key.
This operation requires the keys/sign permission.

### [Invoke-AzKeyVaultUnwrapKey](Invoke-AzKeyVaultUnwrapKey.md)
The UNWRAP operation supports decryption of a symmetric key using the target key encryption key.
This operation is the reverse of the WRAP operation.
The UNWRAP operation applies to asymmetric and symmetric keys stored in Azure Key Vault since it uses the private portion of the key.
This operation requires the keys/unwrapKey permission.

### [Invoke-AzKeyVaultWrapKey](Invoke-AzKeyVaultWrapKey.md)
The WRAP operation supports encryption of a symmetric key using a key encryption key that has previously been stored in an Azure Key Vault.
The WRAP operation is only strictly necessary for symmetric keys stored in Azure Key Vault since protection with an asymmetric key can be performed using the public portion of the key.
This operation is supported for asymmetric keys as a convenience for callers that have a key-reference but do not have access to the public key material.
This operation requires the keys/wrapKey permission.

### [Merge-AzKeyVaultCertificate](Merge-AzKeyVaultCertificate.md)
The MergeCertificate operation performs the merging of a certificate or certificate chain with a key pair currently available in the service.
This operation requires the certificates/create permission.

### [New-AzKeyVault](New-AzKeyVault.md)
Create or update a key vault in the specified subscription.

### [New-AzKeyVaultCertificate](New-AzKeyVaultCertificate.md)
If this is the first version, the certificate resource is created.
This operation requires the certificates/create permission.

### [New-AzKeyVaultKey](New-AzKeyVaultKey.md)
The create key operation can be used to create any key type in Azure Key Vault.
If the named key already exists, Azure Key Vault creates a new version of the key.
It requires the keys/create permission.

### [New-AzKeyVaultStorageAccountKey](New-AzKeyVaultStorageAccountKey.md)
Regenerates the specified key value for the given storage account.
This operation requires the storage/regeneratekey permission.

### [Protect-AzKeyVaultKey](Protect-AzKeyVaultKey.md)
The ENCRYPT operation encrypts an arbitrary sequence of bytes using an encryption key that is stored in Azure Key Vault.
Note that the ENCRYPT operation only supports a single block of data, the size of which is dependent on the target key and the encryption algorithm to be used.
The ENCRYPT operation is only strictly necessary for symmetric keys stored in Azure Key Vault since protection with an asymmetric key can be performed using public portion of the key.
This operation is supported for asymmetric keys as a convenience for callers that have a key-reference but do not have access to the public key material.
This operation requires the keys/encrypt permission.

### [Remove-AzKeyVault](Remove-AzKeyVault.md)
Deletes the specified Azure key vault.

### [Remove-AzKeyVaultCertificate](Remove-AzKeyVaultCertificate.md)
Deletes all versions of a certificate object along with its associated policy.
Delete certificate cannot be used to remove individual versions of a certificate object.
This operation requires the certificates/delete permission.

### [Remove-AzKeyVaultCertificateContact](Remove-AzKeyVaultCertificateContact.md)
Deletes the certificate contacts for a specified key vault certificate.
This operation requires the certificates/managecontacts permission.

### [Remove-AzKeyVaultCertificateIssuer](Remove-AzKeyVaultCertificateIssuer.md)
The DeleteCertificateIssuer operation permanently removes the specified certificate issuer from the vault.
This operation requires the certificates/manageissuers/deleteissuers permission.

### [Remove-AzKeyVaultCertificateOperation](Remove-AzKeyVaultCertificateOperation.md)
Deletes the creation operation for a specified certificate that is in the process of being created.
The certificate is no longer created.
This operation requires the certificates/update permission.

### [Remove-AzKeyVaultKey](Remove-AzKeyVaultKey.md)
The delete key operation cannot be used to remove individual versions of a key.
This operation removes the cryptographic material associated with the key, which means the key is not usable for Sign/Verify, Wrap/Unwrap or Encrypt/Decrypt operations.
This operation requires the keys/delete permission.

### [Remove-AzKeyVaultSecret](Remove-AzKeyVaultSecret.md)
The DELETE operation applies to any secret stored in Azure Key Vault.
DELETE cannot be applied to an individual version of a secret.
This operation requires the secrets/delete permission.

### [Remove-AzKeyVaultStorageAccount](Remove-AzKeyVaultStorageAccount.md)
Deletes a storage account.
This operation requires the storage/delete permission.

### [Remove-AzKeyVaultStorageSasDefinition](Remove-AzKeyVaultStorageSasDefinition.md)
Deletes a SAS definition from a specified storage account.
This operation requires the storage/deletesas permission.

### [Restore-AzKeyVaultCertificate](Restore-AzKeyVaultCertificate.md)
Restores a backed up certificate, and all its versions, to a vault.
This operation requires the certificates/restore permission.

### [Restore-AzKeyVaultKey](Restore-AzKeyVaultKey.md)
Imports a previously backed up key into Azure Key Vault, restoring the key, its key identifier, attributes and access control policies.
The RESTORE operation may be used to import a previously backed up key.
Individual versions of a key cannot be restored.
The key is restored in its entirety with the same key name as it had when it was backed up.
If the key name is not available in the target Key Vault, the RESTORE operation will be rejected.
While the key name is retained during restore, the final key identifier will change if the key is restored to a different vault.
Restore will restore all versions and preserve version identifiers.
The RESTORE operation is subject to security constraints: The target Key Vault must be owned by the same Microsoft Azure Subscription as the source Key Vault The user must have RESTORE permission in the target Key Vault.
This operation requires the keys/restore permission.

### [Restore-AzKeyVaultSecret](Restore-AzKeyVaultSecret.md)
Restores a backed up secret, and all its versions, to a vault.
This operation requires the secrets/restore permission.

### [Restore-AzKeyVaultStorageAccount](Restore-AzKeyVaultStorageAccount.md)
Restores a backed up storage account to a vault.
This operation requires the storage/restore permission.

### [Set-AzKeyVault](Set-AzKeyVault.md)
Create or update a key vault in the specified subscription.

### [Set-AzKeyVaultAccessPolicy](Set-AzKeyVaultAccessPolicy.md)
Update access policies in a key vault in the specified subscription.

### [Set-AzKeyVaultCertificateContact](Set-AzKeyVaultCertificateContact.md)
Sets the certificate contacts for the specified key vault.
This operation requires the certificates/managecontacts permission.

### [Set-AzKeyVaultCertificateIssuer](Set-AzKeyVaultCertificateIssuer.md)
The SetCertificateIssuer operation adds or updates the specified certificate issuer.
This operation requires the certificates/setissuers permission.

### [Set-AzKeyVaultSecret](Set-AzKeyVaultSecret.md)
The SET operation adds a secret to the Azure Key Vault.
If the named secret already exists, Azure Key Vault creates a new version of that secret.
This operation requires the secrets/set permission.

### [Set-AzKeyVaultStorageAccount](Set-AzKeyVaultStorageAccount.md)
Creates or updates a new storage account.
This operation requires the storage/set permission.

### [Set-AzKeyVaultStorageSasDefinition](Set-AzKeyVaultStorageSasDefinition.md)
Creates or updates a new SAS definition for the specified storage account.
This operation requires the storage/setsas permission.

### [Test-AzKeyVault](Test-AzKeyVault.md)
Checks that the vault name is valid and is not already in use.

### [Test-AzKeyVaultKey](Test-AzKeyVaultKey.md)
The VERIFY operation is applicable to symmetric keys stored in Azure Key Vault.
VERIFY is not strictly necessary for asymmetric keys stored in Azure Key Vault since signature verification can be performed using the public portion of the key but this operation is supported as a convenience for callers that only have a key-reference and not the public portion of the key.
This operation requires the keys/verify permission.

### [Undo-AzKeyVaultCertificateRemoval](Undo-AzKeyVaultCertificateRemoval.md)
The RecoverDeletedCertificate operation performs the reversal of the Delete operation.
The operation is applicable in vaults enabled for soft-delete, and must be issued during the retention interval (available in the deleted certificate's attributes).
This operation requires the certificates/recover permission.

### [Undo-AzKeyVaultKeyRemoval](Undo-AzKeyVaultKeyRemoval.md)
The Recover Deleted Key operation is applicable for deleted keys in soft-delete enabled vaults.
It recovers the deleted key back to its latest version under /keys.
An attempt to recover an non-deleted key will return an error.
Consider this the inverse of the delete operation on soft-delete enabled vaults.
This operation requires the keys/recover permission.

### [Undo-AzKeyVaultSecretRemoval](Undo-AzKeyVaultSecretRemoval.md)
Recovers the deleted secret in the specified vault.
This operation can only be performed on a soft-delete enabled vault.
This operation requires the secrets/recover permission.

### [Undo-AzKeyVaultStorageAccountRemoval](Undo-AzKeyVaultStorageAccountRemoval.md)
Recovers the deleted storage account in the specified vault.
This operation can only be performed on a soft-delete enabled vault.
This operation requires the storage/recover permission.

### [Undo-AzKeyVaultStorageSasDefinitionRemoval](Undo-AzKeyVaultStorageSasDefinitionRemoval.md)
Recovers the deleted SAS definition for the specified storage account.
This operation can only be performed on a soft-delete enabled vault.
This operation requires the storage/recover permission.

### [Unprotect-AzKeyVaultKey](Unprotect-AzKeyVaultKey.md)
The DECRYPT operation decrypts a well-formed block of ciphertext using the target encryption key and specified algorithm.
This operation is the reverse of the ENCRYPT operation; only a single block of data may be decrypted, the size of this block is dependent on the target key and the algorithm to be used.
The DECRYPT operation applies to asymmetric and symmetric keys stored in Azure Key Vault since it uses the private portion of the key.
This operation requires the keys/decrypt permission.

### [Update-AzKeyVault](Update-AzKeyVault.md)
Update a key vault in the specified subscription.

### [Update-AzKeyVaultCertificate](Update-AzKeyVaultCertificate.md)
The UpdateCertificate operation applies the specified update on the given certificate; the only elements updated are the certificate's attributes.
This operation requires the certificates/update permission.

### [Update-AzKeyVaultCertificateIssuer](Update-AzKeyVaultCertificateIssuer.md)
The UpdateCertificateIssuer operation performs an update on the specified certificate issuer entity.
This operation requires the certificates/setissuers permission.

### [Update-AzKeyVaultCertificateOperation](Update-AzKeyVaultCertificateOperation.md)
Updates a certificate creation operation that is already in progress.
This operation requires the certificates/update permission.

### [Update-AzKeyVaultCertificatePolicy](Update-AzKeyVaultCertificatePolicy.md)
Set specified members in the certificate policy.
Leave others as null.
This operation requires the certificates/update permission.

### [Update-AzKeyVaultKey](Update-AzKeyVaultKey.md)
In order to perform this operation, the key must already exist in the Key Vault.
Note: The cryptographic material of a key itself cannot be changed.
This operation requires the keys/update permission.

### [Update-AzKeyVaultSecret](Update-AzKeyVaultSecret.md)
The UPDATE operation changes specified attributes of an existing stored secret.
Attributes that are not specified in the request are left unchanged.
The value of a secret itself cannot be changed.
This operation requires the secrets/set permission.

### [Update-AzKeyVaultStorageAccount](Update-AzKeyVaultStorageAccount.md)
Updates the specified attributes associated with the given storage account.
This operation requires the storage/set/update permission.

### [Update-AzKeyVaultStorageSasDefinition](Update-AzKeyVaultStorageSasDefinition.md)
Updates the specified attributes associated with the given SAS definition.
This operation requires the storage/setsas permission.

