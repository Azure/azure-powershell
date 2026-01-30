---
external help file: Az.PostgreSqlFlexibleServer-help.xml
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleservervirtualendpoint
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerVirtualEndpoint

## SYNOPSIS
Gets information about a pair of virtual endpoints.

## SYNTAX

### List (Default)
```
Get-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityFlexibleServer
```
Get-AzPostgreSqlFlexibleServerVirtualEndpoint -Name <String>
 -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPostgreSqlFlexibleServerVirtualEndpoint -Name <String> -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPostgreSqlFlexibleServerVirtualEndpoint -InputObject <IPostgreSqlFlexibleServerIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about a pair of virtual endpoints.

## EXAMPLES

### Example 1: List all virtual endpoints for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name              EndpointType Members               VirtualEndpointType
----              ------------ -------               -------------------
readonly-endpoint ReadOnly     {replica1, replica2}  ReadReplica
write-endpoint    ReadWrite    {primary}             Primary
```

Lists all virtual endpoints configured for the PostgreSQL Flexible Server, including read-only and read-write endpoints.

### Example 2: Get details of a specific virtual endpoint
```powershell
Get-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -VirtualEndpointName "readonly-endpoint"
```

```output
Name              : readonly-endpoint
EndpointType      : ReadOnly
Members           : {prod-replica1, prod-replica2}
VirtualEndpointType: ReadReplica
ConnectionString  : readonly-endpoint.prod-postgresql-01.postgres.database.azure.com
State             : Active
```

Retrieves detailed information about a specific virtual endpoint, including its member servers and connection details.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -FlexibleServerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: GetViaIdentityFlexibleServer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Base name of the virtual endpoints.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityFlexibleServer, Get
Aliases: VirtualEndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerName
The name of the server.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpoint

## NOTES

## RELATED LINKS
