---
external help file:
Module Name: Az.CustomerInsights
online version: https://docs.microsoft.com/en-us/powershell/module/az.customerinsights/get-azcustomerinsightshub
schema: 2.0.0
---

# Get-AzCustomerInsightsHub

## SYNOPSIS
Gets information about the specified hub.

## SYNTAX

### List1 (Default)
```
Get-AzCustomerInsightsHub [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzCustomerInsightsHub -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCustomerInsightsHub -InputObject <ICustomerInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzCustomerInsightsHub -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about the specified hub.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.ICustomerInsightsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the hub.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: HubName

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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.ICustomerInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.Api20170426.IHub

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

