---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
ms.assetid: C39ACCAC-2BFF-48D0-95EA-D5B402D74D46
online version: https://learn.microsoft.com/powershell/module/az.sql/get-azsqlserver
schema: 2.0.0
---

# Get-AzSqlServer

## SYNOPSIS
Returns information about SQL Database servers.

## SYNTAX

```
Get-AzSqlServer [[-ResourceGroupName] <String>] [[-ServerName] <String>] [-ExpandActiveDirectoryAdministrator]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSqlServer** cmdlet returns information about one or more Azure SQL Database servers.
Specify the name of a server to see information for only that server.

## EXAMPLES

### Example 1: Get all instances of SQL Server assigned to a resource group
```powershell
Get-AzSqlServer -ResourceGroupName "ResourceGroup01"
```

```output
ResourceGroupName        : resourcegroup01
ServerName               : server01
Location                 : Central US
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
Identity                 :
FullyQualifiedDomainName : server01.database.windows.net

ResourceGroupName        : resourcegroup01
ServerName               : server02
Location                 : West US
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
Identity                 :
FullyQualifiedDomainName : server02.database.windows.net
```

This command gets information about all the Azure SQL Database servers assigned to the resource group ResourceGroup01.

### Example 2: Get information about an Azure SQL Database server
```powershell
Get-AzSqlServer -ResourceGroupName "ResourceGroup01" -ServerName "Server01"
```

```output
ResourceGroupName        : resourcegroup01
ServerName               : server01
Location                 : Central US
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
Identity                 :
FullyQualifiedDomainName : server01.database.windows.net
```

This command gets information about the Azure SQL Database server named Server01.

### Example 3: Get all instances of SQL Server in the subscription
```powershell
Get-AzResourceGroup | Get-AzSqlServer
```

```output
ResourceGroupName        : resourcegroup01
ServerName               : server01
Location                 : Central US
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
Identity                 :
FullyQualifiedDomainName : server01.database.windows.net

ResourceGroupName        : resourcegroup01
ServerName               : server02
Location                 : West US
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
Identity                 :
FullyQualifiedDomainName : server02.database.windows.net

ResourceGroupName        : resourcegroup02
ServerName               : server03
Location                 : East US
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
Identity                 :
FullyQualifiedDomainName : server03.database.windows.net
```

This command gets information about all the Azure SQL Database servers in the current subscription.

### Example 4: Get all instances of SQL Server assigned to a resource group using filtering
```powershell
Get-AzSqlServer -ResourceGroupName "ResourceGroup01" -ServerName "server*"
```

```output
ResourceGroupName        : resourcegroup01
ServerName               : server01
Location                 : Central US
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
Identity                 :
FullyQualifiedDomainName : server01.database.windows.net

ResourceGroupName        : resourcegroup01
ServerName               : server02
Location                 : West US
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
Identity                 :
FullyQualifiedDomainName : server02.database.windows.net
```

This command gets information about all the Azure SQL Database servers assigned to the resource group ResourceGroup01 that start with "server".

### Example 5: Get all instances of SQL Server assigned to a resource group with external administrator information
<!-- Skip: Output cannot be splitted from code -->
```powershell
$val = Get-AzSqlServer -ResourceGroupName "ResourceGroup01" -ExpandActiveDirectoryAdministrator

ResourceGroupName        : resourcegroup01
ServerName               : server01
Location                 : Central US
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
Identity                 :
FullyQualifiedDomainName : server01.database.windows.net
Administrators           : Microsoft.Azure.Management.Sql.Models.ServerExternalAdministrator

ResourceGroupName        : resourcegroup01
ServerName               : server02
Location                 : West US
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
Identity                 :
FullyQualifiedDomainName : server02.database.windows.net
Administrators           : Microsoft.Azure.Management.Sql.Models.ServerExternalAdministrator

$val.Administrators
AdministratorType         : ActiveDirectory
PrincipalType             : Group
Login                     : Dummy
Sid                       : df7667b8-f9fd-4029-a0e3-b43c75ce9538
TenantId                  : 00001111-aaaa-2222-bbbb-3333cccc4444
AzureADOnlyAuthentication : True

AdministratorType         : ActiveDirectory
PrincipalType             : Group
Login                     : Dummy2
Sid                       : df7667b8-f9fd-4029-a0e3-b43c75ce9538
TenantId                  : 00001111-aaaa-2222-bbbb-3333cccc4444
AzureADOnlyAuthentication : True
```

This command gets information about all the Azure SQL Database servers assigned to the resource group ResourceGroup01.

### Example 6: Get information about an Azure SQL Database server with external administrator information
<!-- Skip: Output cannot be splitted from code -->
```powershell
$val = Get-AzSqlServer -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -ExpandActiveDirectoryAdministrator
ResourceGroupName        : resourcegroup01
ServerName               : server01
Location                 : Central US
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
Identity                 :
FullyQualifiedDomainName : server01.database.windows.net
Administrators           : Microsoft.Azure.Management.Sql.Models.ServerExternalAdministrator

$val.Administrators
AdministratorType         : ActiveDirectory
PrincipalType             : Group
Login                     : Dummy
Sid                       : df7667b8-f9fd-4029-a0e3-b43c75ce9538
TenantId                  : 00001111-aaaa-2222-bbbb-3333cccc4444
AzureADOnlyAuthentication : True
```

This command gets information about the Azure SQL Database server named Server01.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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

### -ExpandActiveDirectoryAdministrator
Expand Active Directory Administrator Information on the server.

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

### -ResourceGroupName
Specifies the name of the resource group to which servers are assigned.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ServerName
Specifies the name of the server that this cmdlet gets.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
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

[New-AzSqlServer](./New-AzSqlServer.md)

[Remove-AzSqlServer](./Remove-AzSqlServer.md)

[Set-AzSqlServer](./Set-AzSqlServer.md)

[SQL Database Documentation](https://learn.microsoft.com/azure/sql-database/)


