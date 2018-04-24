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

## Release 4.4.0

    The following cmdlets were affected this release:

    **Set-AzureKeyVaultManagedStorageSasDefinition**
    - The cmdlet no longer accepts individual parameters that compose the access token; instead, the cmdlet replaces explicit token parameters such as Service or Permissions with a generic 'TemplateUri' parameter, corresponding to a sample access token defined elsewhere (presumably using Storage PowerShell cmdlets, or composed manually according to the Storage documentation.) The cmdlet retains the 'ValidityPeriod' parameter.
	
	For more information on composing shared access tokens for Azure Storage, please refer to the documentation pages, respectively:
	- [Constructing a Service SAS] (https://docs.microsoft.com/en-us/rest/api/storageservices/Constructing-a-Service-SAS)
	- [Constructing an Account SAS] (https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-an-account-sas)
    
    ```powershell
    # Old
  
    $sas = Set-AzureKeyVaultManagedStorageSasDefinition -VaultName myVault -Name myKey -Service Blob -Permissions 'rcw' -ValidityPeriod 180d
        
    
    # New

	$sctx=New-AzureStorageContext -StorageAccountName $sa.StorageAccountName -Protocol Https -StorageAccountKey Key1
	$start=[System.DateTime]::Now.AddDays(-1)
	$end=[System.DateTime]::Now.AddMonths(1)
	$at=New-AzureStorageAccountSasToken -Service blob -ResourceType Service,Container,Object -Permission "racwdlup" -Protocol HttpsOnly -StartTime $start -ExpiryTime $end -Context $sctx
	$sas=Set-AzureKeyVaultManagedStorageSasDefinition -AccountName $sa.StorageAccountName -VaultName $kv.VaultName -Name accountsas -TemplateUri $at -SasType 'account' -ValidityPeriod ([System.Timespan]::FromDays(30))    
    
    ```


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
