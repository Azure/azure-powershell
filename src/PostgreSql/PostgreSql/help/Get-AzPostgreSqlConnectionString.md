---
external help file: Az.PostgreSql-help.xml
Module Name: Az.PostgreSql
online version: https://learn.microsoft.com/powershell/module/az.postgresql/get-azpostgresqlconnectionstring
schema: 2.0.0
---

# Get-AzPostgreSqlConnectionString

## SYNOPSIS
Get the connection string according to client connection provider.

## SYNTAX

### Get (Default)
```
Get-AzPostgreSqlConnectionString -Client <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPostgreSqlConnectionString -Client <String> -InputObject <IServer> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the connection string according to client connection provider.

## EXAMPLES

### Example 1: Get PostgreSql server connection string by resource group and server name
```powershell
Get-AzPostgreSqlConnectionString -Client ADO.NET -Name PostgreSqlTestServer -ResourceGroupName PostgreSqlTestRG
```

```output
Server=postgresqltestserver.postgres.database.azure.com;Database={your_database};Port=5432;User Id=pwsh@postgresqltestserver;Password={your_password};Ssl Mode=Require;
```

This cmdlet gets PostgreSql server connection string by resource group and server name.

### Example 2: Get PostgreSql server connection string by identity
```powershell
Get-AzPostgreSqlServer -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer | Get-AzPostgreSqlConnectionString -Client PHP
```

```output
host=postgresqltestserver.postgres.database.azure.com port=5432 dbname={your_database} user=pwsh@postgresqltestserver password={your_password} sslmode=require
```

This cmdlet gets PostgreSql server connection string by identity.

## PARAMETERS

### -Client
Client connection provider.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The server for the connection string
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServer
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the server.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ServerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource, You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID that identifies an Azure subscription.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServer

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
