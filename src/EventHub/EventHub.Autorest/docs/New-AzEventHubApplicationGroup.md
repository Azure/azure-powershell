---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/new-azeventhubapplicationgroup
schema: 2.0.0
---

# New-AzEventHubApplicationGroup

## SYNOPSIS
Creates or updates an ApplicationGroup for a Namespace.

## SYNTAX

```
New-AzEventHubApplicationGroup -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ClientAppGroupIdentifier <String>] [-IsEnabled]
 [-Policy <IApplicationGroupPolicy[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an ApplicationGroup for a Namespace.

## EXAMPLES

### Example 1: Create an application group with 2 Throttling policies
```powershell
$t1 = New-AzEventHubThrottlingPolicyConfig -Name t1 -MetricId IncomingMessages -RateLimitThreshold 10000
$t2 = New-AzEventHubThrottlingPolicyConfig -Name t2 -MetricId OutgoingBytes -RateLimitThreshold 20000
New-AzEventHubApplicationGroup -NamespaceName myNamespace -ResourceGroupName myResourceGroup -Name myAppGroup -ClientAppGroupIdentifier NamespaceSASKeyName=a -Policy $t1,$t2
```

```output
ClientAppGroupIdentifier     : NamespaceSASKeyName=a
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/applicationGroups/
                               myAppGroup
IsEnabled                    : True
Location                     : Central US
Name                         : myAppGroup
Policy                       : {{
                                 "name": "t1",
                                 "type": "ThrottlingPolicy",
                                 "rateLimitThreshold": 10000,
                                 "metricId": "IncomingMessages"
                               }, {
                                 "name": "t2",
                                 "type": "ThrottlingPolicy",
                                 "rateLimitThreshold": 20000,
                                 "metricId": "OutgoingBytes"
                               }}
ResourceGroupName            : myResourceGroup
```

Creates a new application group `myAppGroup` on namespace `myNamespace` with 2 throttling policies.

## PARAMETERS

### -ClientAppGroupIdentifier
The Unique identifier for application group.Supports SAS(SASKeyName=KeyName) or AAD(AADAppID=Guid)

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

### -IsEnabled
Determines if Application Group is allowed to create connection with namespace or not.
Once the isEnabled is set to false, all the existing connections of application group gets dropped and no new connections will be allowed

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

### -Name
The Application Group name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ApplicationGroupName

Required: True
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

### -Policy
List of group policies that define the behavior of application group.
The policies can support resource governance scenarios such as limiting ingress or egress traffic.
To construct, see NOTES section for POLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IApplicationGroupPolicy[]
Parameter Sets: (All)
Aliases:

Required: False
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
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IApplicationGroup

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`POLICY <IApplicationGroupPolicy[]>`: List of group policies that define the behavior of application group. The policies can support resource governance scenarios such as limiting ingress or egress traffic.
  - `Name <String>`: The Name of this policy

## RELATED LINKS

