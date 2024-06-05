---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/new-azeventgridnamespace
schema: 2.0.0
---

# New-AzEventGridNamespace

## SYNOPSIS
Asynchronously creates or updates a new namespace with the specified parameters.

## SYNTAX

### CreateExpanded (Default)
```
New-AzEventGridNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-ClientAuthenticationAlternativeAuthenticationNameSource <String[]>]
 [-EnableSystemAssignedIdentity] [-IdentityPrincipalId <String>] [-IdentityTenantId <String>]
 [-InboundIPRule <IInboundIPRule[]>] [-IsZoneRedundant] [-MinimumTlsVersionAllowed <String>]
 [-PrivateEndpointConnection <IPrivateEndpointConnection[]>] [-PublicNetworkAccess <String>]
 [-RoutingEnrichmentDynamic <IDynamicRoutingEnrichment[]>]
 [-RoutingEnrichmentStatic <IStaticRoutingEnrichment[]>] [-RoutingIdentityInfoType <String>]
 [-RoutingIdentityInfoUserAssignedIdentity <String>] [-SkuCapacity <Int32>] [-SkuName <String>]
 [-Tag <Hashtable>] [-TopicSpaceConfigurationMaximumClientSessionsPerAuthenticationName <Int32>]
 [-TopicSpaceConfigurationMaximumSessionExpiryInHour <Int32>]
 [-TopicSpaceConfigurationRouteTopicResourceId <String>] [-TopicSpaceConfigurationState <String>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzEventGridNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzEventGridNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzEventGridNamespace -InputObject <IEventGridIdentity> -Location <String>
 [-ClientAuthenticationAlternativeAuthenticationNameSource <String[]>] [-EnableSystemAssignedIdentity]
 [-IdentityPrincipalId <String>] [-IdentityTenantId <String>] [-InboundIPRule <IInboundIPRule[]>]
 [-IsZoneRedundant] [-MinimumTlsVersionAllowed <String>]
 [-PrivateEndpointConnection <IPrivateEndpointConnection[]>] [-PublicNetworkAccess <String>]
 [-RoutingEnrichmentDynamic <IDynamicRoutingEnrichment[]>]
 [-RoutingEnrichmentStatic <IStaticRoutingEnrichment[]>] [-RoutingIdentityInfoType <String>]
 [-RoutingIdentityInfoUserAssignedIdentity <String>] [-SkuCapacity <Int32>] [-SkuName <String>]
 [-Tag <Hashtable>] [-TopicSpaceConfigurationMaximumClientSessionsPerAuthenticationName <Int32>]
 [-TopicSpaceConfigurationMaximumSessionExpiryInHour <Int32>]
 [-TopicSpaceConfigurationRouteTopicResourceId <String>] [-TopicSpaceConfigurationState <String>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Asynchronously creates or updates a new namespace with the specified parameters.

## EXAMPLES

### Example 1: Asynchronously Create a new namespace with the specified parameters.
```powershell
New-AzEventGridNamespace -Name azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -Location eastus -TopicSpaceConfigurationState Enabled
```

```output
Location Name                    ResourceGroupName
-------- ----                    -----------------
eastus   azps-eventgridnamespace azps_test_group_eventgrid
```

Asynchronously Create a new namespace with the specified parameters.

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

### -ClientAuthenticationAlternativeAuthenticationNameSource
Alternative authentication name sources related to client authentication settings for namespace resource.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -EnableSystemAssignedIdentity
Decides if enable a system assigned identity for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsZoneRedundant
Allows the user to specify if the service is zone-redundant.
This is a required property and user needs to specify this value explicitly.Once specified, this property cannot be updated.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location of the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinimumTlsVersionAllowed
Minimum TLS version of the publisher allowed to publish to this namespace.
Only TLS version 1.2 is supported.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the namespace.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases: NamespaceName

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

### -PrivateEndpointConnection
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IPrivateEndpointConnection[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccess
This determines if traffic is allowed over public network.
By default it is enabled.You can further restrict to specific IPs by configuring \<seealso cref="P:Microsoft.Azure.Events.ResourceProvider.Common.Contracts.PubSub.NamespaceProperties.InboundIpRules" /\>

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases: ResourceGroup

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoutingEnrichmentDynamic
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IDynamicRoutingEnrichment[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoutingEnrichmentStatic
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IStaticRoutingEnrichment[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoutingIdentityInfoType
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoutingIdentityInfoUserAssignedIdentity
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
Specifies the number of Throughput Units that defines the capacity for the namespace.
The property default value is1 which signifies 1 Throughput Unit = 1MB/s ingress and 2MB/s egress per namespace.
Min capacity is 1 andmax allowed capacity is 20.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
The name of the SKU.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopicSpaceConfigurationMaximumClientSessionsPerAuthenticationName
The maximum number of sessions per authentication name.
The property default value is 1.Min allowed value is 1 and max allowed value is 100.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopicSpaceConfigurationMaximumSessionExpiryInHour
The maximum session expiry in hours.
The property default value is 1 hour.Min allowed value is 1 hour and max allowed value is 8 hours.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopicSpaceConfigurationRouteTopicResourceId
Fully qualified Azure Resource Id for the Event Grid Topic to which events will be routed to from TopicSpaces under a namespace.This property should be in the following format '/subscriptions/{subId}/resourcegroups/{resourceGroupName}/providers/microsoft.EventGrid/topics/{topicName}'.This topic should reside in the same region where namespace is located.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopicSpaceConfigurationState
Indicate if Topic Spaces Configuration is enabled for the namespace.
Default is Disabled.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.INamespace

## NOTES

## RELATED LINKS
