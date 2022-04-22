---
external help file:
Module Name: Az.CustomerInsights
online version: https://docs.microsoft.com/en-us/powershell/module/az.customerinsights/new-azcustomerinsightsauthorizationpolicysecondarykey
schema: 2.0.0
---

# New-AzCustomerInsightsAuthorizationPolicySecondaryKey

## SYNOPSIS
Regenerates the secondary policy key of the specified authorization policy.

## SYNTAX

### Regenerate (Default)
```
New-AzCustomerInsightsAuthorizationPolicySecondaryKey -AuthorizationPolicyName <String> -HubName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RegenerateViaIdentity
```
New-AzCustomerInsightsAuthorizationPolicySecondaryKey -InputObject <ICustomerInsightsIdentity>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Regenerates the secondary policy key of the specified authorization policy.

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

### -AuthorizationPolicyName
The name of the policy.

```yaml
Type: System.String
Parameter Sets: Regenerate
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

### -HubName
The name of the hub.

```yaml
Type: System.String
Parameter Sets: Regenerate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.ICustomerInsightsIdentity
Parameter Sets: RegenerateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Regenerate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Regenerate
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

### Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.ICustomerInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.Api20170426.IAuthorizationPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ICustomerInsightsIdentity>: Identity Parameter
  - `[AssignmentName <String>]`: The assignment name
  - `[AuthorizationPolicyName <String>]`: The name of the policy.
  - `[ConnectorName <String>]`: The name of the connector.
  - `[HubName <String>]`: The name of the Hub.
  - `[Id <String>]`: Resource identity path
  - `[InteractionName <String>]`: The name of the interaction.
  - `[KpiName <String>]`: The name of the KPI.
  - `[LinkName <String>]`: The name of the link.
  - `[MappingName <String>]`: The name of the connector mapping.
  - `[PredictionName <String>]`: The name of the Prediction.
  - `[ProfileName <String>]`: The name of the profile.
  - `[RelationshipLinkName <String>]`: The name of the relationship link.
  - `[RelationshipName <String>]`: The name of the Relationship.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[ViewName <String>]`: The name of the view.
  - `[WidgetTypeName <String>]`: The name of the widget type.

## RELATED LINKS

