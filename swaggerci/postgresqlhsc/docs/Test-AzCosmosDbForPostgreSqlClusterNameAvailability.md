---
external help file:
Module Name: Az.CosmosDbForPostgreSql
online version: https://learn.microsoft.com/powershell/module/az.cosmosdbforpostgresql/test-azcosmosdbforpostgresqlclusternameavailability
schema: 2.0.0
---

# Test-AzCosmosDbForPostgreSqlClusterNameAvailability

## SYNOPSIS
Check the availability of name for resource

## SYNTAX

### CheckExpanded (Default)
```
Test-AzCosmosDbForPostgreSqlClusterNameAvailability -Name <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzCosmosDbForPostgreSqlClusterNameAvailability -NameAvailabilityRequest <INameAvailabilityRequest>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzCosmosDbForPostgreSqlClusterNameAvailability -InputObject <ICosmosDbForPostgreSqlIdentity>
 -NameAvailabilityRequest <INameAvailabilityRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzCosmosDbForPostgreSqlClusterNameAvailability -InputObject <ICosmosDbForPostgreSqlIdentity>
 -Name <String> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Check the availability of name for resource

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
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CosmosDbForPostgreSql.Models.ICosmosDbForPostgreSqlIdentity
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Resource name to verify.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NameAvailabilityRequest
Request from client to check resource name availability.
To construct, see NOTES section for NAMEAVAILABILITYREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CosmosDbForPostgreSql.Models.Api20221108.INameAvailabilityRequest
Parameter Sets: Check, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Check, CheckExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.CosmosDbForPostgreSql.Models.Api20221108.INameAvailabilityRequest

### Microsoft.Azure.PowerShell.Cmdlets.CosmosDbForPostgreSql.Models.ICosmosDbForPostgreSqlIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CosmosDbForPostgreSql.Models.Api20221108.INameAvailability

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <ICosmosDbForPostgreSqlIdentity>`: Identity Parameter
  - `[ClusterName <String>]`: The name of the cluster.
  - `[ConfigurationName <String>]`: The name of the cluster configuration.
  - `[FirewallRuleName <String>]`: The name of the cluster firewall rule.
  - `[Id <String>]`: Resource identity path
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection associated with the Azure resource.
  - `[PrivateLinkResourceName <String>]`: The name of the private link resource.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RoleName <String>]`: The name of the cluster role.
  - `[ServerName <String>]`: The name of the server.
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.

`NAMEAVAILABILITYREQUEST <INameAvailabilityRequest>`: Request from client to check resource name availability.
  - `Name <String>`: Resource name to verify.

## RELATED LINKS

