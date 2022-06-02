---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version:
schema: 2.0.0
---

# New-AzCosmosDbClientEncryptionKey

## SYNOPSIS
Creates a new CosmosDB Client Encryption Key.

## SYNTAX

### ByNameParameterSet (Default)
```
New-AzCosmosDbClientEncryptionKey -ResourceGroupName <String> -AccountName <String> -DatabaseName <String>
 -Name <String> -EncryptionAlgorithmName <String> -KeyWrapMetadata <PSSqlKeyWrapMetadata>
 [-KeyEncryptionKeyResolver <IKeyEncryptionKeyResolver>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
New-AzCosmosDbClientEncryptionKey -Name <String> -EncryptionAlgorithmName <String>
 -KeyWrapMetadata <PSSqlKeyWrapMetadata> [-KeyEncryptionKeyResolver <IKeyEncryptionKeyResolver>]
 -SqlDatabaseObject <PSSqlDatabaseGetResults> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzCosmosDbClientEncryptionKey** creates a new CosmosDB Client Encryption Key.

## EXAMPLES

### Example 1
```powershell
$myKeyWrapMetadataObject = [Microsoft.Azure.Commands.CosmosDB.Models.PSSqlKeyWrapMetadata]::new([Microsoft.Azure.Management.CosmosDB.Models.KeyWrapMetadata]::new("myKekV1","AZURE_KEY_VAULT", "https://contoso.vault.azure.net/keys/myKekV1/78deebed173b48e48f55abf87ed4cf71", "RSA-OAEP"))
New-AzCosmosDbClientEncryptionKey -AccountName myAccountName -DatabaseName myDatabaseName -ResourceGroupName myRgName -Name myClientEncryptionKeyName -EncryptionAlgorithmName "AEAD_AES_256_CBC_HMAC_SHA256" -KeyWrapMetadata $myKeyWrapMetadataObject
```

```output
Name     : myContainerName
Id       : /subscriptions/mySubscriptionId/resourceGroups/myRgName/providers/Microsoft.DocumentDB/databaseAccounts/myAccountName/sqlDatabases/myDatabaseName/clientEncryptionKeys/myClientEncryptionKeyName
Resource : Microsoft.Azure.Commands.CosmosDB.Models.PSSqlClientEncryptionKeyGetPropertiesResource
```

This example shows how a new key is created. If KeyEncryptionKeyResolver is not passed Azure Key Vault KeyResolver is used by default.
The first command creates a KeyWrapMetadata object with name myKekV1 of type AZURE_KEY_VAULT with value set to key id https://contoso.vault.azure.net/keys/myKekV1/78deebed173b48e48f55abf87ed4cf71 and algorithm type "RSA-OAEP" used to encrypt the key.
In the second command a new key is created with name as set in myClientEncryptionKeyName variable and with KeyWrapMetadata set to value returned by first command.

### Example 2
```powershell
$myKeyWrapMetadataObject = [Microsoft.Azure.Commands.CosmosDB.Models.PSSqlKeyWrapMetadata]::new([Microsoft.Azure.Management.CosmosDB.Models.KeyWrapMetadata]::new("myKekV1","AZURE_KEY_VAULT", "https://contoso.vault.azure.net/keys/myKekV1/78deebed173b48e48f55abf87ed4cf71", "RSA-OAEP"))
$azureKeyVaultKeyResolver = [Azure.Security.KeyVault.Keys.Cryptography.KeyResolver]::new([Azure.Identity.DefaultAzureCredential]::new())
New-AzCosmosDbClientEncryptionKey -AccountName myAccountName -DatabaseName myDatabaseName -ResourceGroupName myRgName -Name myClientEncryptionKeyName -EncryptionAlgorithmName "AEAD_AES_256_CBC_HMAC_SHA256" -KeyWrapMetadata $myKeyWrapMetadataObject -KeyEncryptionKeyResolver $azureKeyVaultKeyResolver
```

```output
Name     : myContainerName
Id       : /subscriptions/mySubscriptionId/resourceGroups/myRgName/providers/Microsoft.DocumentDB/databaseAccounts/myAccountName/sqlDatabases/myDatabaseName/clientEncryptionKeys/myClientEncryptionKeyName
Resource : Microsoft.Azure.Commands.CosmosDB.Models.PSSqlClientEncryptionKeyGetPropertiesResource
```

This example shows how a new key is created and how KeyEncryptionKeyResolver can be passed as a parameter.
The first command creates a KeyWrapMetadata object with name myKekV1 of type AZURE_KEY_VAULT with value set to key id https://contoso.vault.azure.net/keys/myKekV1/78deebed173b48e48f55abf87ed4cf71 and algorithm type "RSA-OAEP" used to encrypt the key.
The second command creates a Azure Key Vault KeyResolver object using the Azure Default credentials.
In the third command a new key is created with name as set in myClientEncryptionKeyName variable, KeyWrapMetadata set to value returned by first command and KeyEncryptionKeyResolver value set to KeyResolver object obtained via the second command.

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

### -EncryptionAlgorithmName
Client Encryption Algorithm name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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
Parameter Sets: (All)
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlKeyWrapMetadata

### System.Byte[]

### Microsoft.Data.Encryption.Cryptography.EncryptionKeyStoreProvider

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlDatabaseGetResults

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlClientEncryptionKeyGetResults

### Microsoft.Azure.Commands.CosmosDB.Exceptions.ConflictingResourceException

## NOTES

## RELATED LINKS

[Get-AzCosmosDbClientEncryptionKey](./Get-AzCosmosDbClientEncryptionKey.md)

[Update-AzCosmosDbClientEncryptionKey](./Update-AzCosmosDbClientEncryptionKey.md)
