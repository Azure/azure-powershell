---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/get-azeventhubapplicationgroup
schema: 2.0.0
---

# Get-AzEventHubApplicationGroup

## SYNOPSIS
Gets a list of application groups for a Namespace.

## SYNTAX

```
Get-AzEventHubApplicationGroup -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a list of application groups for a Namespace.

## EXAMPLES

### Example 1: Get an application group from an EventHub namespace
```powershell
Get-AzEventHubApplicationGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAppGroup
```

```output
ClientAppGroupIdentifier     : NamespaceSASKeyName=RootManageSharedAccessKey
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/applicationGroups/
                               myAppGroup
IsEnabled                    : True
Location                     : Central US
Name                         : myAppGroup
Policy                       : {{
                                 "name": "throttlingPolicy1",
                                 "type": "ThrottlingPolicy",
                                 "rateLimitThreshold": 10000,
                                 "metricId": "OutgoingMessages"
                               }, {
                                 "name": "throttlingPolicy2",
                                 "type": "ThrottlingPolicy",
                                 "rateLimitThreshold": 11111,
                                 "metricId": "OutgoingBytes"
                               }}
ResourceGroupName            : myResourceGroup
```

Gets details of application group `myAppGroup` from namespace `myNamespace`.

### Example 2: Lists all application groups in an EventHub namespace
```powershell
Get-AzEventHubApplicationGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

Lists all application groups from namespace `myNamespace`.

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

### -NamespaceName
The Namespace name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group within the azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IApplicationGroup

## NOTES

## RELATED LINKS

