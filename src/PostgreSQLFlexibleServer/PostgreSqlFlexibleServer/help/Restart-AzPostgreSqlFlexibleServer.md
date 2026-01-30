---
external help file: Az.PostgreSqlFlexibleServer-help.xml
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/restart-azpostgresqlflexibleserver
schema: 2.0.0
---

# Restart-AzPostgreSqlFlexibleServer

## SYNOPSIS
Restarts PostgreSQL database engine in a server.

## SYNTAX

### RestartExpanded (Default)
```
Restart-AzPostgreSqlFlexibleServer -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-FailoverMode <String>] [-RestartWithFailover] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestartViaJsonString
```
Restart-AzPostgreSqlFlexibleServer -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestartViaJsonFilePath
```
Restart-AzPostgreSqlFlexibleServer -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Restart
```
Restart-AzPostgreSqlFlexibleServer -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Parameter <IRestartParameter> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestartViaIdentityExpanded
```
Restart-AzPostgreSqlFlexibleServer -InputObject <IPostgreSqlFlexibleServerIdentity> [-FailoverMode <String>]
 [-RestartWithFailover] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestartViaIdentity
```
Restart-AzPostgreSqlFlexibleServer -InputObject <IPostgreSqlFlexibleServerIdentity>
 -Parameter <IRestartParameter> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Restarts PostgreSQL database engine in a server.

## EXAMPLES

### Example 1: Restart a PostgreSQL Flexible Server
```powershell
Restart-AzPostgreSqlFlexibleServer -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

Restarts the specified PostgreSQL Flexible Server. This is required after certain configuration changes or to apply patches.

### Example 2: Restart a server with specific restart type
```powershell
Restart-AzPostgreSqlFlexibleServer -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -RestartWithFailover
```

Restarts the PostgreSQL Flexible Server with failover enabled. This ensures high availability during the restart process for servers configured with zone redundancy.

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

### -FailoverMode
Failover mode.

```yaml
Type: System.String
Parameter Sets: RestartExpanded, RestartViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: RestartViaIdentityExpanded, RestartViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Restart operation

```yaml
Type: System.String
Parameter Sets: RestartViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Restart operation

```yaml
Type: System.String
Parameter Sets: RestartViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the server.

```yaml
Type: System.String
Parameter Sets: RestartExpanded, RestartViaJsonString, RestartViaJsonFilePath, Restart
Aliases: ServerName

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

### -Parameter
PostgreSQL database engine restart parameters.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IRestartParameter
Parameter Sets: Restart, RestartViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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
Parameter Sets: RestartExpanded, RestartViaJsonString, RestartViaJsonFilePath, Restart
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestartWithFailover
Indicates if restart the PostgreSQL database engine should failover or switch over from primary to standby.
This only works if server has high availability enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RestartExpanded, RestartViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: RestartExpanded, RestartViaJsonString, RestartViaJsonFilePath, Restart
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IRestartParameter

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
