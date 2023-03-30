---
external help file:
Module Name: Az.ResourceHealth
online version: https://learn.microsoft.com/powershell/module/az.resourcehealth/get-azresourcehealthevent
schema: 2.0.0
---

# Get-AzResourceHealthEvent

## SYNOPSIS
Service health event in the subscription by event tracking id

## SYNTAX

### List (Default)
```
Get-AzResourceHealthEvent [-SubscriptionId <String[]>] [-Filter <String>] [-QueryStartTime <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzResourceHealthEvent -TrackingId <String> [-SubscriptionId <String[]>] [-Filter <String>]
 [-QueryStartTime <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzResourceHealthEvent -TrackingId <String> [-Filter <String>] [-QueryStartTime <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzResourceHealthEvent -InputObject <IResourceHealthIdentity> [-Filter <String>] [-QueryStartTime <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzResourceHealthEvent -InputObject <IResourceHealthIdentity> [-Filter <String>] [-QueryStartTime <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzResourceHealthEvent [-Filter <String>] [-QueryStartTime <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List2
```
Get-AzResourceHealthEvent -ResourceUri <String> [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Service health event in the subscription by event tracking id

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

### -Filter
The filter to apply on the operation.
For more information please see https://docs.microsoft.com/en-us/rest/api/apimanagement/apis?redirectedfrom=MSDN

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ResourceHealth.Models.IResourceHealthIdentity
Parameter Sets: GetViaIdentity, GetViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -QueryStartTime
Specifies from when to return events, based on the lastUpdateTime property.
For example, queryStartTime = 7/24/2020 OR queryStartTime=7%2F24%2F2020

```yaml
Type: System.String
Parameter Sets: Get, Get1, GetViaIdentity, GetViaIdentity1, List, List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The fully qualified ID of the resource, including the resource name and resource type.
Currently the API support not nested and one nesting level resource types : /subscriptions/{subscriptionId}/resourceGroups/{resource-group-name}/providers/{resource-provider-name}/{resource-type}/{resource-name} and /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resource-provider-name}/{parentResourceType}/{parentResourceName}/{resourceType}/{resourceName}

```yaml
Type: System.String
Parameter Sets: List2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrackingId
Event Id which uniquely identifies ServiceHealth event.

```yaml
Type: System.String
Parameter Sets: Get, Get1
Aliases: EventTrackingId

Required: True
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

