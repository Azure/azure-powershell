---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version:
schema: 2.0.0
---

# Update-AzCosmosDbClientEncryptionKey

## SYNOPSIS
Updates the CosmosDB Client Encryption Key. Performs a client side patch operation by reading the existing Client Encryption Key.

## SYNTAX

### ByNameParameterSet (Default)
```
Update-AzCosmosDbClientEncryptionKey -ResourceGroupName <String> -AccountName <String> -DatabaseName <String>
 -Name <String> -KeyWrapMetadata <PSSqlKeyWrapMetadata> [-KeyEncryptionKeyResolver <IKeyEncryptionKeyResolver>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Update-AzCosmosDbClientEncryptionKey -Name <String> -KeyWrapMetadata <PSSqlKeyWrapMetadata>
 [-KeyEncryptionKeyResolver <IKeyEncryptionKeyResolver>] -SqlDatabaseObject <PSSqlDatabaseGetResults>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Update-AzCosmosDbClientEncryptionKey -KeyWrapMetadata <PSSqlKeyWrapMetadata>
 [-KeyEncryptionKeyResolver <IKeyEncryptionKeyResolver>] -InputObject <PSSqlClientEncryptionKeyGetResults>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzCosmosDbClientEncryptionKey** updates the CosmosDb Client Encryption Key. Performs a client side patch operation by reading the existing CosmosDB Client Encryption Key.

## EXAMPLES

### Example 1
```powershell
$updatedKeyWrapMetadataObject = [Microsoft.Azure.Commands.CosmosDB.Models.PSSqlKeyWrapMetadata]::new([Microsoft.Azure.Management.CosmosDB.Models.KeyWrapMetadata]::new("myKekV2","AZURE_KEY_VAULT", "https://contoso.vault.azure.net/keys/myKekV2/78deebed173b48e48f55abf87ed4cf71", "RSA-OAEP"))
Update-AzCosmosDbClientEncryptionKey -AccountName myAccountName -DatabaseName myDatabaseName -ResourceGroupName myRgName -Name myClientEncryptionKeyName -KeyWrapMetadata $updatedKeyWrapMetadataObject
```

```output
Name     : myContainerName
Id       : /subscriptions/mySubscriptionId/resourceGroups/myRgName/providers/Microsoft.DocumentDB/databaseAccounts/myAccountName/sqlDatabases/myDatabaseName/clientEncryptionKeys/myClientEncryptionKeyName
Resource : Microsoft.Azure.Commands.CosmosDB.Models.PSSqlClientEncryptionKeyGetPropertiesResource
```

This example shows how a key is updated. If KeyEncryptionKeyResolver is not passed Azure Key Vault KeyResolver is used by default.
The first command creates a KeyWrapMetadata object with name myKekV2 of type AZURE_KEY_VAULT with value set to key id https://contoso.vault.azure.net/keys/myKekV2/78deebed173b48e48f55abf87ed4cf71 and algorithm type "RSA-OAEP" used to encrypt the key.
In the second command a key with name as set in myClientEncryptionKeyName variable is updated with KeyWrapMetadata set to value returned by first command.

### Example 2
```powershell
$updatedKeyWrapMetadataObject = [Microsoft.Azure.Commands.CosmosDB.Models.PSSqlKeyWrapMetadata]::new([Microsoft.Azure.Management.CosmosDB.Models.KeyWrapMetadata]::new("myKekV2","AZURE_KEY_VAULT", "https://contoso.vault.azure.net/keys/myKekV2/78deebed173b48e48f55abf87ed4cf71", "RSA-OAEP"))
$azureKeyVaultKeyResolver = [Azure.Security.KeyVault.Keys.Cryptography.KeyResolver]::new([Azure.Identity.DefaultAzureCredential]::new())
Update-AzCosmosDbClientEncryptionKey -AccountName myAccountName -DatabaseName myDatabaseName -ResourceGroupName myRgName -Name myClientEncryptionKeyName -KeyWrapMetadata $updatedKeyWrapMetadataObject -KeyEncryptionKeyResolver $azureKeyVaultKeyResolver
```

```output
Name     : myContainerName
Id       : /subscriptions/mySubscriptionId/resourceGroups/myRgName/providers/Microsoft.DocumentDB/databaseAccounts/myAccountName/sqlDatabases/myDatabaseName/clientEncryptionKeys/myClientEncryptionKeyName
Resource : Microsoft.Azure.Commands.CosmosDB.Models.PSSqlClientEncryptionKeyGetPropertiesResource
```

This example shows how a key is updated and how KeyEncryptionKeyResolver can be passed as a parameter.
The first command creates a KeyWrapMetadata object with name myKekV2 of type AZURE_KEY_VAULT with value set to key id https://contoso.vault.azure.net/keys/myKekV2/78deebed173b48e48f55abf87ed4cf71 and algorithm type "RSA-OAEP" used to encrypt the key.
The second command creates a Azure Key Vault KeyResolver object using the Azure Default credentials.
In the third command a key with name as set in myClientEncryptionKeyName variable is updated with KeyWrapMetadata set to value returned by first command and KeyEncryptionKeyResolver value set to KeyResolver object obtained via the second command.

### Example 3
```powershell
$updatedKeyWrapMetadataObject = [Microsoft.Azure.Commands.CosmosDB.Models.PSSqlKeyWrapMetadata]::new([Microsoft.Azure.Management.CosmosDB.Models.KeyWrapMetadata]::new("myKekV2","AZURE_KEY_VAULT", "https://contoso.vault.azure.net/keys/myKekV2/78deebed173b48e48f55abf87ed4cf71", "RSA-OAEP"))
$keyToUpdate = Get-AzCosmosDbClientEncryptionKey -AccountName myAccountName -DatabaseName myDatabaseName -ResourceGroupName myRgName -ClientEncryptionKeyName myClientEncryptionKeyName
Update-AzCosmosDbClientEncryptionKey -InputObject $keyToUpdate -KeyWrapMetadata $updatedKeyWrapMetadataObject -KeyEncryptionKeyResolver $azureKeyVaultKeyResolver
```

```output
Name     : myContainerName
Id       : /subscriptions/mySubscriptionId/resourceGroups/myRgName/providers/Microsoft.DocumentDB/databaseAccounts/myAccountName/sqlDatabases/myDatabaseName/clientEncryptionKeys/myClientEncryptionKeyName
Resource : Microsoft.Azure.Commands.CosmosDB.Models.PSSqlClientEncryptionKeyGetPropertiesResource
```

This example shows how a key is updated using an InputObject which is obtained by reading the key which has to be updated.
The first command creates a KeyWrapMetadata object with name myKekV2 of type AZURE_KEY_VAULT with value set to key id https://contoso.vault.azure.net/keys/myKekV2/78deebed173b48e48f55abf87ed4cf71 and algorithm type "RSA-OAEP" used to encrypt the key.
In the second command reads the key which is to be updated.
The third command updates the key which was read earlier in the second command. The object read in the second command is passed as the InputObject along with the updated KeyWrapMetadata obtained in the first command.

## PARAMETERS

### -AccountName
Name of the Cosmos DB database account.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseName
Database name.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -InputObject
Client Encryption Key object.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSSqlClientEncryptionKeyGetResults
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyEncryptionKeyResolver
IKeyEncryptionKeyResolver interface of type Azure.Core.Cryptography.IKeyEncryptionKeyResolver

```yaml
Type: Azure.Core.Cryptography.IKeyEncryptionKeyResolver
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyWrapMetadata
KeyWrapMetaData Object of type Microsoft.Azure.Commands.CosmosDB.PSSqlKeyWrapMetadata.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSSqlKeyWrapMetadata
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Client Encryption Key name.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet, ByParentObjectParameterSet
Aliases: ClientEncryptionKeyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlDatabaseObject
Sql Database object.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSSqlDatabaseGetResults
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### System.Byte[]

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlKeyWrapMetadata

### Microsoft.Data.Encryption.Cryptography.EncryptionKeyStoreProvider

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlDatabaseGetResults

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlClientEncryptionKeyGetResults

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlClientEncryptionKeyGetResults

### Microsoft.Azure.Commands.CosmosDB.Exceptions.ResourceNotFoundException

## NOTES

## RELATED LINKS

[Get-AzCosmosDbClientEncryptionKey](./Get-AzCosmosDbClientEncryptionKey.md)

[New-AzCosmosDbClientEncryptionKey](./New-AzCosmosDbClientEncryptionKey.md)
