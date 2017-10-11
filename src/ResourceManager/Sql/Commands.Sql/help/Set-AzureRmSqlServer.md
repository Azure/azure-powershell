---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
ms.assetid: FAAF458C-1662-4130-9A16-0514B714D11D
online version:
schema: 2.0.0
---

# Set-AzureRmSqlServer

## SYNOPSIS
Modifies properties of a SQL Database server.

## SYNTAX

```
Set-AzureRmSqlServer [-ServerName] <String> [-SqlAdministratorPassword <SecureString>] [-Tags <Hashtable>]
 [-ServerVersion <String>] [-AssignIdentity] [-Force] [-ResourceGroupName] <String> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmSqlServer** cmdlet modifies properties of an Azure SQL Database server.

## EXAMPLES

### Example 1: Reset the administrator password
```
PS C:\>$ServerPassword = "newpassword"
PS C:\> $SecureString = ConvertTo-SecureString $ServerPassword -AsPlainText -Force
PS C:\> Set-AzureRmSqlServer -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -SqlAdministratorPassword $secureString
ResourceGroupName        : ResourceGroup01
ServerName               : Server01
Location                 : Australia East
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
```

This command resets the administrator password on the AzureSQL Server named server01.

## PARAMETERS

### -AssignIdentity
Generate and assign an Azure Active Directory Identity for this server for use with key management services like Azure KeyVault.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Forces the command to run without asking for user confirmation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group to which the server is assigned.

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
Specifies the name of the server that this cmdlet modifies.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerVersion
Specifies the version to which this cmdlet changes the server. The acceptable values for this
parameter are: 2.0 and 12.0.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlAdministratorPassword
Specifies a new password, as a **SecureString**, for the database server administrator. To obtain a
**SecureString**, use the Get-Credential cmdlet. For more information, type `Get-Help
ConvertTo-SecureString`.

```yaml
Type: SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tags
Specifies a dictionary of tags that this cmdlet associates with the server. Key-value pairs in the
form of a hash table set as tags on the server. For example:

@{key0="value0";key1=$null;key2="value2"}

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: Tag

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

## OUTPUTS

### Microsoft.Azure.Commands.Sql.Server.Model.AzureSqlServerModel

## NOTES

## RELATED LINKS

[SQL Database Documentation](https://docs.microsoft.com/azure/sql-database/)
