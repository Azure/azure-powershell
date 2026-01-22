---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/new-azpostgresqlflexibleservervirtualendpoint
schema: 2.0.0
---

# New-AzPostgreSqlFlexibleServerVirtualEndpoint

## SYNOPSIS
Create a pair of virtual endpoints for a server.

## SYNTAX

### CreateExpanded (Default)
```
New-AzPostgreSqlFlexibleServerVirtualEndpoint -Name <String> -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String>] [-EndpointType <String>] [-Member <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityFlexibleServerExpanded
```
New-AzPostgreSqlFlexibleServerVirtualEndpoint -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity>
 -Name <String> [-EndpointType <String>] [-Member <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzPostgreSqlFlexibleServerVirtualEndpoint -Name <String> -ResourceGroupName <String> -ServerName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzPostgreSqlFlexibleServerVirtualEndpoint -Name <String> -ResourceGroupName <String> -ServerName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a pair of virtual endpoints for a server.

## EXAMPLES

### Example 1: Create a read-write virtual endpoint
```powershell
New-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -VirtualEndpointName "primary-endpoint" -EndpointType "ReadWrite" -Member @("myPostgreSqlServer", "read-replica-1")
```

```output
Name              : primary-endpoint
ResourceGroupName : myResourceGroup
ServerName        : myPostgreSqlServer
EndpointType      : ReadWrite
VirtualEndpoints  : {"primary-endpoint.postgres.database.azure.com"}
Members           : {"myPostgreSqlServer", "read-replica-1"}
State             : Creating
```

Creates a new read-write virtual endpoint that includes the primary server and a read replica.

### Example 2: Create a read-only virtual endpoint for analytics
```powershell
New-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -VirtualEndpointName "analytics-endpoint" -EndpointType "ReadOnly" -Member @("analytics-replica-1", "analytics-replica-2")
```

```output
Name              : analytics-endpoint
ResourceGroupName : production-rg
ServerName        : prod-postgresql-01
EndpointType      : ReadOnly
VirtualEndpoints  : {"analytics-endpoint.postgres.database.azure.com"}
Members           : {"analytics-replica-1", "analytics-replica-2"}
State             : Creating
```

Creates a new read-only virtual endpoint for analytics workloads using multiple read replicas.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -EndpointType
Type of endpoint for the virtual endpoints.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFlexibleServerExpanded
Aliases:

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
Parameter Sets: CreateViaIdentityFlexibleServerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Member
List of servers that one of the virtual endpoints can refer to.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Base name of the virtual endpoints.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VirtualEndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpoint

## NOTES

## RELATED LINKS

