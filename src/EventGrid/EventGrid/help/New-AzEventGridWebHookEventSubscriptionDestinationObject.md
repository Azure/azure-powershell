---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridwebhookeventsubscriptiondestinationobject
schema: 2.0.0
---

# New-AzEventGridWebHookEventSubscriptionDestinationObject

## SYNOPSIS
Create an in-memory object for WebHookEventSubscriptionDestination.

## SYNTAX

```
New-AzEventGridWebHookEventSubscriptionDestinationObject [-AzureActiveDirectoryApplicationIdOrUri <String>]
 [-AzureActiveDirectoryTenantId <String>] [-DeliveryAttributeMapping <IDeliveryAttributeMapping[]>]
 [-EndpointUrl <String>] [-MaxEventsPerBatch <Int32>] [-MinimumTlsVersionAllowed <String>]
 [-PreferredBatchSizeInKilobyte <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for WebHookEventSubscriptionDestination.

## EXAMPLES

### Example 1: Create an in-memory object for WebHookEventSubscriptionDestination.
```powershell
New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
```

```output
EndpointType
------------
WebHook
```

Create an in-memory object for WebHookEventSubscriptionDestination.
A usable EndpointUrl can be created from this link: https://learn.microsoft.com/en-us/azure/event-grid/custom-event-quickstart-powershell

## PARAMETERS

### -AzureActiveDirectoryApplicationIdOrUri
The Azure Active Directory Application ID or URI to get the access token that will be included as the bearer token in delivery requests.

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

### -AzureActiveDirectoryTenantId
The Azure Active Directory Tenant ID to get the access token that will be included as the bearer token in delivery requests.

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

### -DeliveryAttributeMapping
Delivery attribute details.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IDeliveryAttributeMapping[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointUrl
The URL that represents the endpoint of the destination of an event subscription.

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

### -MaxEventsPerBatch
Maximum number of events per batch.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinimumTlsVersionAllowed
Minimum TLS version that should be supported by webhook endpoint.

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

### -PreferredBatchSizeInKilobyte
Preferred batch size in Kilobytes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.WebHookEventSubscriptionDestination

## NOTES

## RELATED LINKS
