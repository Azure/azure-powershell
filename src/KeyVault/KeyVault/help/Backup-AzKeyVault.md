---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/backup-azkeyvault
schema: 2.0.0
---

# Backup-AzKeyVault

## SYNOPSIS
Fully backup a managed HSM.

## SYNTAX

### InteractiveStorageName (Default)
```
Backup-AzKeyVault [-HsmName] <String> -StorageAccountName <String> -StorageContainerName <String>
 [-SasToken <SecureString>] [-UseUserManagedIdentity] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InteractiveStorageUri
```
Backup-AzKeyVault [-HsmName] <String> -StorageContainerUri <Uri> [-SasToken <SecureString>]
 [-UseUserManagedIdentity] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectStorageUri
```
Backup-AzKeyVault -StorageContainerUri <Uri> [-SasToken <SecureString>] [-UseUserManagedIdentity]
 -HsmObject <PSManagedHsm> [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectStorageName
```
Backup-AzKeyVault -StorageAccountName <String> -StorageContainerName <String> [-SasToken <SecureString>]
 [-UseUserManagedIdentity] -HsmObject <PSManagedHsm> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Fully backup a managed HSM to a storage account.
Use `Restore-AzKeyVault` to restore the backup.

## EXAMPLES

### Example 1 Backup an HSM to Storage Container using SAS token
```powershell
$sasToken = ConvertTo-SecureString -AsPlainText -Force "?sv=2019-12-12&ss=bfqt&srt=sco&sp=rwdlacupx&se=2020-10-12T14:42:19Z&st=2020-10-12T06:42:19Z&spr=https&sig=******"

Backup-AzKeyVault -HsmName myHsm -StorageContainerUri "https://{accountName}.blob.core.windows.net/{containerName}" -SasToken $sasToken
```

```output
https://{accountName}.blob.core.windows.net/{containerName}/{backupFolder}
```

The cmdlet will create a folder (typically named `mhsm-{name}-{timestamp}`) in the storage container, store the backup in that folder and output the folder URI.

### Example 2 Backup an HSM to Storage Container via User Assigned Managed Identity Authentication
```powershell
# Make sure an identity is assigend to the Hsm
Update-AzKeyVaultManagedHsm -UserAssignedIdentity "/subscriptions/{sub-id}/resourceGroups/{rg-name}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identity-name}"
Backup-AzKeyVault -HsmName myHsm -StorageContainerUri "https://{accountName}.blob.core.windows.net/{containerName}" -UseUserManagedIdentity
```

```output
https://{accountName}.blob.core.windows.net/{containerName}/{backupFolder}
```

The cmdlet will backup the hsm in specific Storage Container and output the folder URI via User Assigned Managed Identity Authentication. The Managed Identity should be assigned access permission to the storage container.

### Example 3 Backup an HSM to Storage Container using Storage Account Name and Storage Container
```powershell
Backup-AzKeyVault -HsmName myHsm -StorageAccountName "{accountName}" -StorageContainerName "{containerName}" -UseUserManagedIdentity
```

```output
https://{accountName}.blob.core.windows.net/{containerName}/{backupFolder}
```

The cmdlet will create a folder (typically named `mhsm-{name}-{timestamp}`) in the storage container, store the backup in that folder and output the folder URI.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmName
Name of the HSM.

```yaml
Type: System.String
Parameter Sets: InteractiveStorageName, InteractiveStorageUri
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmObject
Managed HSM object

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm
Parameter Sets: InputObjectStorageUri, InputObjectStorageName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SasToken
The shared access signature (SAS) token to authenticate the storage account.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountName
Name of the storage account where the backup is going to be stored.

```yaml
Type: System.String
Parameter Sets: InteractiveStorageName, InputObjectStorageName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageContainerName
Name of the blob container where the backup is going to be stored.

```yaml
Type: System.String
Parameter Sets: InteractiveStorageName, InputObjectStorageName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageContainerUri
URI of the storage container where the backup is going to be stored.

```yaml
Type: System.Uri
Parameter Sets: InteractiveStorageUri, InputObjectStorageUri
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseUserManagedIdentity
Specified to use User Managed Identity to authenticate the storage account. Only valid when SasToken is not set.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
