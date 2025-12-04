---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/restore-azsqlserver
schema: 2.0.0
---

# Restore-AzSqlServer

## SYNOPSIS
Restores a deleted Azure SQL Database server that is still within its soft-delete retention period

## SYNTAX

```
Restore-AzSqlServer -ServerName <String> -Location <String> [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Restore-AzSqlServer** cmdlet restores a deleted Azure SQL Database server that is still within its soft-delete retention period

## EXAMPLES

### Example 1
```powershell
Restore-AzSqlServer -ResourceGroupName "resourcegroup01" -ServerName "server01" -Location "CentralUS"
```

```output
ResourceGroupName             : resourcegroup01
ServerName                    : server01
Location                      : centralus
SqlAdministratorLogin         : SqlAdminUser
SqlAdministratorPassword      :
ServerVersion                 : 12.0
Tags                          :
Identity                      :
FullyQualifiedDomainName      : server01.database.windows.net
MinimalTlsVersion             : 1.2
PublicNetworkAccess           : Enabled
RestrictOutboundNetworkAccess : Disabled
Administrators                :
PrimaryUserAssignedIdentityId :
KeyId                         :
FederatedClientId             :
SoftDeleteRetentionDays       : 7
```

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

### -Location
The location in which to create the server

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

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerName
SQL Database server name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.Server.Model.AzureSqlServerModel

## NOTES

## RELATED LINKS

[Get-AzSqlServer](./Get-AzSqlServer.md)

[New-AzSqlServer](./New-AzSqlServer.md)

[Set-AzSqlServer](./Set-AzSqlServer.md)

[SQL Database Documentation](https://learn.microsoft.com/azure/sql-database/)
