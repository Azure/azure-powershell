<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Upcoming Breaking Changes", and should adhere to the following format:

    # Upcoming Breaking Changes

    ## Release X.0.0 - January 2017

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above section follows the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

# Upcoming Breaking Changes

The following cmdlets were affected this release:

**Add-AzureKeyVaultCertificate**
- The -Certificate parameter has become mandatory.

**Set-AzureKeyVaultManagedStorageSasDefinition**
- The -Parameter parameter has been removed and replaced by -TemplateUri and -SasType

**Set-AzureKeyVaultCertificateIssuer**
- The -IssuerProvider parameter has become mandatory.

**Undo-AzureKeyVaultCertificateRemoval**
- The output of this cmdlet has changed from CertificateBundle to PSKeyVaultCertificate.

**Undo-AzureRmKeyVaultRemoval**
- ResourceGroupName has been removed from the InputObject parameter set, and is instead obtained from the InputObject parameter's ResourceId property.

**Set-AzureRmKeyVaultAccessPolicy**
- The "all" permission was removed from "PermissionsToKeys", "PermissionsToSecrets", and "PermissionsToCertificates".

**General**
- ValueFromPipelineByPropertyName was removed from all cmdlets where piping by InputObject was enabled.  These cmdlets are:
    - Add-AzureKeyVaultCertificate
    - Add-AzureKeyVaultCertificateContact
    - Add-AzureKeyVaultKey
    - Backup-AzureKeyVaultKey
    - Backup-AzureKeyVaultSecret
    - Get-AzureKeyVaultCertficate
    - Get-AzureKeyVaultCertificateContact
    - Get-AzureKeyVaultCertificateIssuer
    - Get-AzureKeyVaultCertificateOperation
    - Get-AzureKeyVaultCertificatePolicy
    - Get-AzureKeyVaultKey
    - Get-AzureKeyVaultSecret
    - Remove-AzureRmKeyVault
    - Remove-AzureRmKeyVaultAccessPolicy
    - Remove-AzureKeyVaultCertificate
    - Remove-AzureKeyVaultCertificateContact
    - Remove-AzureKeyVaultCertificateIssuer
    - Remove-AzureKeyVaultCertificateOperation
    - Remove-AzureKeyVaultKey
    - Remove-AzureKeyVaultSecret
    - Restore-AzureKeyVaultKey
    - Restore-AzureKeyVaultSecret
    - Set-AzureRmKeyVaultAccessPolicy
    - Set-AzureKeyVaultCertificateAttribute
    - Set-AzureKeyVaultCertificateIssuer
    - Set-AzureKeyVaultCertificatePolicy
    - Set-AzureKeyVaultKeyAttribute
    - Set-AzureKeyVaultSecret
    - Set-AzureKeyVaultSecretAttribute
    - Stop-AzureKeyVaultCertificateOperation
    - Undo-AzureKeyVaultCertificateRemoval
    - Undo-AzureKeyVaultKeyRemoval
    - Undo-AzureRmKeyVaultRemoval
    - Undo-AzureKeyVaultSecretRemoval
- ConfirmImpact levels were removed from all cmdlets.  Those affected are:
    - Remove-AzureRmKeyVault
    - Remove-AzureKeyVaultCertificate
    - Remove-AzureKeyVaultCertificateIssuer
    - Remove-AzureKeyVaultCertificateOperation
    - Remove-AzureKeyVaultKey
    - Remove-AzureKeyVaultSecret
    - Stop-AzureKeyVaultCertificateOperation
- The IKeyVaultDataServiceClient was updated so all Certificate operations return PSTypes instead of SDK types. This includes:
    - SetCertificateContacts
    - GetCertificateContacts
    - GetCertificate
    - GetDeletedCertificate
    - MergeCertificate
    - ImportCertificate
    - DeleteCertificate
    - RecoverCertificate
    - EnrollCertificate
    - UpdateCertificate
    - GetCertificateOperation
    - DeleteCertificateOperation
    - CancelCertificateOperation
    - GetCertificatePolicy
    - UpdateCertificatePolicy
    - GetCertificateIssuer
    - SetCertificateIssuer
    - DeleteCertificateIssuer

## Release 3.0.0

    The following cmdlets were affected this release:

    **Backup-AzureKeyVaultKey**
    - The cmdlet now accepts a Key object as input
    - The cmdlet now accepts a -Force switch to overwrite an existing file
    - The cmdlet will no longer throw on attempting to overwrite an existing file without the Force parameter; instead, the 
      cmdlet will prompt the user to confirm whether it should proceed with overwriting, suspend or abandon the execution.

    ```powershell
    # Old
  
    $key = Add-AzureKeyVaultKey -VaultName myVault -Name myKey -Destination Software
    $backupFile = Backup-AzureKeyVaultKey -VaultName $key.VaultName -Name $keyName -OutputFile .\keybackup.file
    
    Backup-AzureKeyVaultKey -VaultName $key.VaultName -Name $key.Name -OutputFile .\keybackup.file  (will throw)

    # New

    # The second Backup call will now yield: 
    #Overwrite File ?
    #Overwrite existing file at '.\keybackup.file' ?
    #[Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"):
    
    # The second Backup call can be attempted as:
    
    Backup-AzureKeyVaultKey -VaultName $key.VaultName -Name $key.Name -OutputFile .\keybackup.file -Force (will overwrite, no prompt)
    
    or
    
    Backup-AzureKeyVaultKey -Key $key -OutputFile .\keybackup.file -Force (will overwrite, no prompt)
    
    ```
