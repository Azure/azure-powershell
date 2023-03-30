---
external help file:
Module Name: Az.ResourceHealth
online version: https://learn.microsoft.com/powershell/module/az.resourcehealth/invoke-azresourcehealthfetcheventdetail
schema: 2.0.0
---

# Invoke-AzResourceHealthFetchEventDetail

## SYNOPSIS
Service health event details in the subscription by event tracking id.
This can be used to fetch sensitive properties for Security Advisory events

## SYNTAX

### Fetch (Default)
```
Invoke-AzResourceHealthFetchEventDetail -EventTrackingId <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Fetch1
```
Invoke-AzResourceHealthFetchEventDetail -EventTrackingId <String> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### FetchViaIdentity
```
Invoke-AzResourceHealthFetchEventDetail -InputObject <IResourceHealthIdentity> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### FetchViaIdentity1
```
Invoke-AzResourceHealthFetchEventDetail -InputObject <IResourceHealthIdentity> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Service health event details in the subscription by event tracking id.
This can be used to fetch sensitive properties for Security Advisory events

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

### -EventTrackingId
Event Id which uniquely identifies ServiceHealth event.

```yaml
Type: System.String
Parameter Sets: Fetch, Fetch1
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ResourceHealth.Models.IResourceHealthIdentity
Parameter Sets: FetchViaIdentity, FetchViaIdentity1
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
Parameter Sets: Fetch
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

### Microsoft.Azure.PowerShell.Cmdlets.ResourceHealth.Models.IResourceHealthIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResourceHealth.Models.Api20221001Preview.IEvent

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IResourceHealthIdentity>`: Identity Parameter
  - `[EventTrackingId <String>]`: Event Id which uniquely identifies ServiceHealth event.
  - `[Id <String>]`: Resource identity path
  - `[ImpactedResourceName <String>]`: Name of the Impacted Resource.
  - `[IssueName <IssueNameParameter?>]`: The name of the emerging issue.
  - `[Name <String>]`: Name of metadata entity.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[ResourceUri <String>]`: The fully qualified ID of the resource, including the resource name and resource type. Currently the API support not nested and one nesting level resource types : /subscriptions/{subscriptionId}/resourceGroups/{resource-group-name}/providers/{resource-provider-name}/{resource-type}/{resource-name} and /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resource-provider-name}/{parentResourceType}/{parentResourceName}/{resourceType}/{resourceName}
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

