---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/update-azeventgriddomain
schema: 2.0.0
---

# Update-AzEventGridDomain

## SYNOPSIS
Asynchronously creates or updates a new domain with the specified parameters.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzEventGridDomain -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AutoCreateTopicWithFirstSubscription] [-AutoDeleteTopicWithLastSubscription]
 [-DataResidencyBoundary <String>] [-DisableLocalAuth] [-EnableSystemAssignedIdentity <Boolean>]
 [-EventTypeInfoInlineEventType <Hashtable>] [-EventTypeInfoKind <String>] [-IdentityPrincipalId <String>]
 [-IdentityTenantId <String>] [-InboundIPRule <IInboundIPRule[]>] [-InputSchema <String>] [-Location <String>]
 [-MinimumTlsVersionAllowed <String>] [-PublicNetworkAccess <String>] [-SkuName <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzEventGridDomain -InputObject <IEventGridIdentity> [-AutoCreateTopicWithFirstSubscription]
 [-AutoDeleteTopicWithLastSubscription] [-DataResidencyBoundary <String>] [-DisableLocalAuth]
 [-EnableSystemAssignedIdentity <Boolean>] [-EventTypeInfoInlineEventType <Hashtable>]
 [-EventTypeInfoKind <String>] [-IdentityPrincipalId <String>] [-IdentityTenantId <String>]
 [-InboundIPRule <IInboundIPRule[]>] [-InputSchema <String>] [-Location <String>]
 [-MinimumTlsVersionAllowed <String>] [-PublicNetworkAccess <String>] [-SkuName <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Asynchronously creates or updates a new domain with the specified parameters.

## EXAMPLES

### Example 1: Asynchronously updates a domain with the specified parameters.
```powershell
$inboundIpRule = New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
Update-AzEventGridDomain -Name azps-domain -ResourceGroupName azps_test_group_eventgrid -PublicNetworkAccess Enabled -InboundIPRule $inboundIpRule
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
westus2  azps-domain azps_test_group_eventgrid
```

Asynchronously updates a domain with the specified parameters.

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

### -AutoCreateTopicWithFirstSubscription
This Boolean is used to specify the creation mechanism for 'all' the Event Grid Domain Topics associated with this Event Grid Domain resource.In this context, creation of domain topic can be auto-managed (when true) or self-managed (when false).
The default value for this property is true.When this property is null or set to true, Event Grid is responsible of automatically creating the domain topic when the first event subscription iscreated at the scope of the domain topic.
If this property is set to false, then creating the first event subscription will require creating a domain topicby the user.
The self-management mode can be used if the user wants full control of when the domain topic is created, while auto-managed mode provides theflexibility to perform less operations and manage fewer resources by the user.
Also, note that in auto-managed creation mode, user is allowed to create thedomain topic on demand if needed.

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

### -AutoDeleteTopicWithLastSubscription
This Boolean is used to specify the deletion mechanism for 'all' the Event Grid Domain Topics associated with this Event Grid Domain resource.In this context, deletion of domain topic can be auto-managed (when true) or self-managed (when false).
The default value for this property is true.When this property is set to true, Event Grid is responsible of automatically deleting the domain topic when the last event subscription at the scopeof the domain topic is deleted.
If this property is set to false, then the user needs to manually delete the domain topic when it is no longer needed(e.g., when last event subscription is deleted and the resource needs to be cleaned up).
The self-management mode can be used if the user wants fullcontrol of when the domain topic needs to be deleted, while auto-managed mode provides the flexibility to perform less operations and manage fewerresources by the user.

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

### -DataResidencyBoundary
Data Residency Boundary of the resource.

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

### -DisableLocalAuth
This boolean is used to enable or disable local auth.
Default value is false.
When the property is set to true, only AAD token will be used to authenticate if user is allowed to publish to the domain.

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

### -EnableSystemAssignedIdentity
Decides if enable a system assigned identity for the resource.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventTypeInfoInlineEventType
A collection of inline event types for the resource.
The inline event type keys are of type string which represents the name of the event.An example of a valid inline event name is "Contoso.OrderCreated".The inline event type values are of type InlineEventProperties and will contain additional information for every inline event type.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventTypeInfoKind
The kind of event type used.

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

### -IdentityPrincipalId
The principal ID of resource identity.

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

### -IdentityTenantId
The tenant ID of resource.

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

### -InboundIPRule
This can be used to restrict traffic from specific IPs instead of all IPs.
Note: These are considered only if PublicNetworkAccess is enabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IInboundIPRule[]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputSchema
This determines the format that Event Grid should expect for incoming events published to the Event Grid Domain Resource.

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

### -Location
Location of the resource.

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

### -MinimumTlsVersionAllowed
Minimum TLS version of the publisher allowed to publish to this domain

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

### -Name
Name of the domain.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: DomainName

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

### -PassThru
Returns true when the command succeeds

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

### -PublicNetworkAccess
This determines if traffic is allowed over public network.
By default it is enabled.You can further restrict to specific IPs by configuring \<seealso cref="P:Microsoft.Azure.Events.ResourceProvider.Common.Contracts.DomainProperties.InboundIpRules" /\>

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

### -ResourceGroupName
The name of the resource group within the user's subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ResourceGroup

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
The Sku name of the resource.
The possible values are: Basic or Premium.

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

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tags of the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases: IdentityId

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IDomain

## NOTES

## RELATED LINKS
