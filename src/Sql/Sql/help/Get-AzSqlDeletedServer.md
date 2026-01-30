---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/get-azsqldeletedserver
schema: 2.0.0
---

# Get-AzSqlDeletedServer

## SYNOPSIS
Gets information about deleted Azure SQL servers.

## SYNTAX

```
Get-AzSqlDeletedServer -Location <String> [-ServerName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSqlDeletedServer** cmdlet gets information about deleted Azure SQL servers in a specified location. 
You can get information about a specific deleted server by providing the server name, or you can list all deleted servers in a location.

## EXAMPLES

### Example 1: Get all deleted servers in a location
```powershell
Get-AzSqlDeletedServer -Location "centralus"
```

```output
ServerName                : myserver
Location                  : centralus
DeletionTime              : 11/6/2025 12:30:00 PM
FullyQualifiedDomainName  : myserver.database.windows.net
Version                   : 12.0
Id                        : /subscriptions/12345678-1234-1234-1234-123456789012/providers/Microsoft.Sql/locations/centralus/deletedServers/myserver
OriginalId                : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/myresourcegroup/providers/Microsoft.Sql/servers/myserver
ResourceGroupName         : myresourcegroup
SubscriptionId            : 12345678-1234-1234-1234-123456789012
```

This command gets all deleted SQL servers in the Central US location under the current subscription.

### Example 2: Get a specific deleted server
```powershell
Get-AzSqlDeletedServer -Location "centralus" -ServerName "myserver"
```

```output
ServerName                : myserver
DeletionTime              : 11/6/2025 12:30:00 PM
FullyQualifiedDomainName  : myserver.database.windows.net
Version                   : 12.0
Id                        : /subscriptions/12345678-1234-1234-1234-123456789012/providers/Microsoft.Sql/locations/centralus/deletedServers/myserver
OriginalId                : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/myresourcegroup/providers/Microsoft.Sql/servers/myserver
ResourceGroupName         : myresourcegroup
SubscriptionId            : 12345678-1234-1234-1234-123456789012
```

This command gets information about a specific deleted SQL server named "myserver" in the Central US location.

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
The Azure region where the deleted server was located.

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
The name of the deleted server to retrieve. If not specified, lists all deleted servers in the location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.Server.Model.AzureSqlDeletedServerModel

## NOTES

## RELATED LINKS

[Get-AzSqlServer](./Get-AzSqlServer.md)

[New-AzSqlServer](./New-AzSqlServer.md)

[Remove-AzSqlServer](./Remove-AzSqlServer.md)

[SQL Database Documentation](https://learn.microsoft.com/azure/sql-database/)