---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/set-azeventhubapplicationgroup
schema: 2.0.0
---

# Set-AzEventHubApplicationGroup

## SYNOPSIS
Sets an EventHub Application Group

## SYNTAX

### SetExpanded (Default)
```
Set-AzEventHubApplicationGroup -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ClientAppGroupIdentifier <String>] [-IsEnabled]
 [-Policy <IApplicationGroupPolicy[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SetViaIdentityExpanded
```
Set-AzEventHubApplicationGroup -InputObject <IEventHubIdentity> [-ClientAppGroupIdentifier <String>]
 [-IsEnabled] [-Policy <IApplicationGroupPolicy[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Sets an EventHub Application Group

## EXAMPLES

### Example 1: Add throttling policies to an Application Group
```powershell
$t3 = New-AzEventHubThrottlingPolicyConfig -Name t3 -MetricId OutgoingMessages -RateLimitThreshold 12000
$appGroup = Get-AzEventHubApplicationGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAppGroup
$appGroup.Policy += $t3
Set-AzEventHubApplicationGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAppGroup -Policy $appGroup.Policy
```

```output
ClientAppGroupIdentifier     : NamespaceSASKeyName=a
Id                           : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/applicationGroups/
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
                               }, {
                                 "name": "t3",
                                 "type": "ThrottlingPolicy",
                                 "rateLimitThreshold": 12000,
                                 "metricId": "OutgoingMessages"
                               }}
ResourceGroupName            : myResourceGroup
```

`-Policy` takes an array of Policy objects.
It represents the entire set of throttling policies defined on the appplication group and not just the one.
If you want to add or remove throttling policies, the right way to do it is to get the application group and query the Policy data member of the object returned as shown above.

### Example 2: Update application group using InputObject parameter set
```powershell
$appGroup = Get-AzEventHubApplicationGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAppGroup
Set-AzEventHubApplicationGroup -InputObject $appGroup -IsEnabled:$false
```

```output
ClientAppGroupIdentifier     : NamespaceSASKeyName=a
Id                           : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/applicationGroups/
                               myAppGroup
IsEnabled                    : False
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
                               }, {
                                 "name": "t3",
                                 "type": "ThrottlingPolicy",
                                 "rateLimitThreshold": 12000,
                                 "metricId": "OutgoingMessages"
                               }}
ResourceGroupName            : myResourceGroup
```

Disables application group `myAppGroup`.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -ClientAppGroupIdentifier
The Unique identifier for application group.Supports SAS(SASKeyName=KeyName) or AAD(AADAppID=Guid)

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -InputObject
Identity parameter.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
Parameter Sets: SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the Application Group.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases: ApplicationGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The name of EventHub namespace

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: SetExpanded
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
Type: System.String
Parameter Sets: SetExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IApplicationGroupPolicy[]

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity

### System.Management.Automation.SwitchParameter

### System.String

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IApplicationGroup

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IEventHubIdentity>`: Identity parameter.
  - `[Alias <String>]`: The Disaster Recovery configuration name
  - `[ApplicationGroupName <String>]`: The Application Group name 
  - `[AuthorizationRuleName <String>]`: The authorization rule name.
  - `[ClusterName <String>]`: The name of the Event Hubs Cluster.
  - `[ConsumerGroupName <String>]`: The consumer group name
  - `[EventHubName <String>]`: The Event Hub name
  - `[Id <String>]`: Resource identity path
  - `[NamespaceName <String>]`: The Namespace name
  - `[PrivateEndpointConnectionName <String>]`: The PrivateEndpointConnection name
  - `[ResourceAssociationName <String>]`: The ResourceAssociation Name
  - `[ResourceGroupName <String>]`: Name of the resource group within the azure subscription.
  - `[SchemaGroupName <String>]`: The Schema Group name 
  - `[SubscriptionId <String>]`: Subscription credentials that uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

`POLICY <IApplicationGroupPolicy[]>`: List of group policies that define the behavior of application group. The policies can support resource governance scenarios such as limiting ingress or egress traffic.
  - `Name <String>`: The Name of this policy

## RELATED LINKS

