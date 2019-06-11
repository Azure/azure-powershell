---
external help file:
Module Name: Az.Monitor
online version: https://docs.microsoft.com/en-us/powershell/module/az.monitor/get-aztenantactivitylog
schema: 2.0.0
---

# Get-AzTenantActivityLog

## SYNOPSIS
Gets the Activity Logs for the Tenant.<br>Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.).<br>One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level.

## SYNTAX

```
Get-AzTenantActivityLog [-Filter <String>] [-Select <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the Activity Logs for the Tenant.<br>Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.).<br>One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

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
Dynamic: False
```

### -Filter
Reduces the set of data collected.
The **$filter** is very restricted and allows only the following patterns.
- List events for a resource group: $filter=eventTimestamp ge '<Start Time>' and eventTimestamp le '<End Time>' and eventChannels eq 'Admin, Operation' and resourceGroupName eq '<ResourceGroupName>'.
- List events for resource: $filter=eventTimestamp ge '<Start Time>' and eventTimestamp le '<End Time>' and eventChannels eq 'Admin, Operation' and resourceUri eq '<ResourceURI>'.
- List events for a subscription: $filter=eventTimestamp ge '<Start Time>' and eventTimestamp le '<End Time>' and eventChannels eq 'Admin, Operation'.
- List events for a resource provider: $filter=eventTimestamp ge '<Start Time>' and eventTimestamp le '<End Time>' and eventChannels eq 'Admin, Operation' and resourceProvider eq '<ResourceProviderName>'.
- List events for a correlation Id: api-version=2014-04-01&$filter=eventTimestamp ge '2014-07-16T04:36:37.6407898Z' and eventTimestamp le '2014-07-20T04:36:37.6407898Z' and eventChannels eq 'Admin, Operation' and correlationId eq '<CorrelationID>'.
**NOTE**: No other syntax is allowed.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Select
Used to fetch events with only the given properties.
The **$select** argument is a comma separated list of property names to be returned.
Possible values are: *authorization*, *claims*, *correlationId*, *description*, *eventDataId*, *eventName*, *eventTimestamp*, *httpRequest*, *level*, *operationId*, *operationName*, *properties*, *resourceGroupName*, *resourceProviderName*, *resourceId*, *status*, *submissionTimestamp*, *subStatus*, *subscriptionId*

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20150401.IEventData

## ALIASES

## RELATED LINKS

