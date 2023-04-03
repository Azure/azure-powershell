---
external help file:
Module Name: Az.PostgreSql
online version: https://learn.microsoft.com/powershell/module/az.postgresql/invoke-azpostgresqlexecutevirtualnetworksubnetusage
schema: 2.0.0
---

# Invoke-AzPostgreSqlExecuteVirtualNetworkSubnetUsage

## SYNOPSIS
Get virtual network subnet usage for a given vNet resource id.

## SYNTAX

### ExecuteExpanded (Default)
```
Invoke-AzPostgreSqlExecuteVirtualNetworkSubnetUsage -LocationName <String> [-SubscriptionId <String>]
 [-VirtualNetworkArmResourceId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Execute
```
Invoke-AzPostgreSqlExecuteVirtualNetworkSubnetUsage -LocationName <String>
 -Parameter <IVirtualNetworkSubnetUsageParameter> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ExecuteViaIdentity
```
Invoke-AzPostgreSqlExecuteVirtualNetworkSubnetUsage -InputObject <IPostgreSqlIdentity>
 -Parameter <IVirtualNetworkSubnetUsageParameter> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ExecuteViaIdentityExpanded
```
Invoke-AzPostgreSqlExecuteVirtualNetworkSubnetUsage -InputObject <IPostgreSqlIdentity>
 [-VirtualNetworkArmResourceId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Get virtual network subnet usage for a given vNet resource id.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.IPostgreSqlIdentity
Parameter Sets: ExecuteViaIdentity, ExecuteViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocationName
The name of the location.

```yaml
Type: System.String
Parameter Sets: Execute, ExecuteExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Virtual network subnet usage parameter
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20221201.IVirtualNetworkSubnetUsageParameter
Parameter Sets: Execute, ExecuteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Execute, ExecuteExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkArmResourceId
Virtual network resource id.

```yaml
Type: System.String
Parameter Sets: ExecuteExpanded, ExecuteViaIdentityExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20221201.IVirtualNetworkSubnetUsageParameter

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.IPostgreSqlIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20221201.IVirtualNetworkSubnetUsageResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IPostgreSqlIdentity>`: Identity Parameter
  - `[BackupName <String>]`: The name of the backup.
  - `[ConfigurationName <String>]`: The name of the server configuration.
  - `[DatabaseName <String>]`: The name of the database.
  - `[FirewallRuleName <String>]`: The name of the server firewall rule.
  - `[Id <String>]`: Resource identity path
  - `[LocationName <String>]`: The name of the location.
  - `[ObjectId <String>]`: Guid of the objectId for the administrator.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ServerName <String>]`: The name of the server.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

`PARAMETER <IVirtualNetworkSubnetUsageParameter>`: Virtual network subnet usage parameter
  - `[VirtualNetworkArmResourceId <String>]`: Virtual network resource id.

## RELATED LINKS

