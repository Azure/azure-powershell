---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmSqlServerTransparentDataEncryptionProtector

## SYNOPSIS
Gets the Transparent Data Encryption (TDE) protector

## SYNTAX

```
Get-AzureRmSqlServerTransparentDataEncryptionProtector [-ServerName] <String> [-ResourceGroupName] <String>
 [-WhatIf] [-Confirm]
```

## DESCRIPTION
The Get-AzureRmSqlServerTransparentDataEncryptionProtector cmdlet gets information about the TDE protector.

## EXAMPLES

### --------------------------  Example 1: Get the Transparent Data Encryption (TDE) protector  --------------------------
```
PS C:\> Get-AzureRmSqlServerTransparentDataEncryptionProtector -ServerName 'ContosoServer' -ResourceGroup 'ContosoResourceGroup'
```

This command gets the TDE protector for the server named ContosoServer in resource group named ContosoResourceGroup.

ResourceGroupName ServerName                   Type ServerKeyVaultKeyName
----------------- ----------                   ---- ---------------------
ContosoResourceGroup ContosoServer ServiceManaged ServiceManaged

## PARAMETERS

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

## INPUTS

### System.String

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

