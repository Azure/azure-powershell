---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.sql/get-azurermsqlserverkeyvaultkey
schema: 2.0.0
---

# Get-AzureRmSqlServerKeyVaultKey

## SYNOPSIS
Gets a SQL server's Key Vault keys.

## SYNTAX

```
Get-AzureRmSqlServerKeyVaultKey [[-KeyId] <String>] [-ServerName] <String> [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmSqlServerKeyVaultKey cmdlet gets information about the Key Vault keys on a SQL server.
You can view all keys on a server or view a specific key by providing the KeyId.

## EXAMPLES

### Example 1: Get all Key Vault keys
```
PS C:\> Get-AzureRmSqlServerKeyVaultKey -ServerName 'ContosoServer' -ResourceGroupName 'ContosoResourceGroup'
```

This command gets all the Key Vault keys on a SQL server.

ResourceGroupName : ContosoResourceGroup
ServerName        : ContosoServer
ServerKeyName     : contoso_contosokey_01234567890123456789012345678901
Type              : AzureKeyVault
Uri               : https://contoso.vault.azure.net/keys/contosokey/01234567890123456789012345678901
Thumbprint        : 1122334455667788990011223344556677889900
CreationDate      : 1/1/2017 12:00:00 AM

ResourceGroupName : ContosoResourceGroup
ServerName        : ContosoServer
ServerKeyName     : contoso_contosokey2_01234567890123456789012345678901
Type              : AzureKeyVault
Uri               : https://contoso.vault.azure.net/keys/contosokey2/09876543210987654321098765432109
Thumbprint        : 0099887766554433221100998877665544332211
CreationDate      : 1/1/2017 12:00:00 AM

### Example 2: Get a specific Key Vault key
```
PS C:\> $MyServerKeyVaultKey = Get-AzureRmSqlServerKeyVaultKey -KeyId 'https://contoso.vault.azure.net/keys/contosokey/01234567890123456789012345678901' -ServerName 'ContosoServer' -ResourceGroupName 'ContosoResourceGroup'
```

This command gets the Key Vault key with Id 'https://contoso.vault.azure.net/keys/contosokey/01234567890123456789012345678901', and then stores it in the $MyServerKeyVaultKey variable.
You can inspect the properties of $MyServerKeyVaultKey to get details about the key vault.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyId
The Azure Key Vault KeyId.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerName
The Azure Sql Server name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[SQL Database Documentation](https://docs.microsoft.com/azure/sql-database/)
