---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/new-azeventgridpartnernamespace
schema: 2.0.0
---

# New-AzEventGridPartnerNamespace

## SYNOPSIS
Asynchronously creates a new partner namespace with the specified parameters.

## SYNTAX

### CreateExpanded (Default)
```
New-AzEventGridPartnerNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-DisableLocalAuth] [-InboundIPRule <IInboundIPRule[]>]
 [-MinimumTlsVersionAllowed <String>] [-PartnerRegistrationFullyQualifiedId <String>]
 [-PartnerTopicRoutingMode <String>] [-PublicNetworkAccess <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzEventGridPartnerNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzEventGridPartnerNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzEventGridPartnerNamespace -InputObject <IEventGridIdentity> -Location <String> [-DisableLocalAuth]
 [-InboundIPRule <IInboundIPRule[]>] [-MinimumTlsVersionAllowed <String>]
 [-PartnerRegistrationFullyQualifiedId <String>] [-PartnerTopicRoutingMode <String>]
 [-PublicNetworkAccess <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Asynchronously creates a new partner namespace with the specified parameters.

## EXAMPLES

### Example 1: Asynchronously creates a new partner namespace with the specified parameters.
```powershell
New-AzEventGridPartnerNamespace -Name azps-partnernamespace -ResourceGroupName azps_test_group_eventgrid -Location eastus -PartnerTopicRoutingMode SourceEventAttribute -PartnerRegistrationFullyQualifiedId "/subscriptions/{subId}/resourceGroups/azps_test_group_eventgrid/providers/Microsoft.EventGrid/partnerRegistrations/azps-registration"
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps-partnernamespace azps_test_group_eventgrid
```

Asynchronously creates a new partner namespace with the specified parameters.

### Example 2: Asynchronously creates a new partner namespace with the specified parameters.
```powershell
New-AzEventGridPartnerNamespace -Name azps-partnernamespace -ResourceGroupName azps_test_group_eventgrid -Location eastus -PartnerTopicRoutingMode ChannelNameHeader -PartnerRegistrationFullyQualifiedId "/subscriptions/{subId}/resourceGroups/azps_test_group_eventgrid/providers/Microsoft.EventGrid/partnerRegistrations/azps-registration"
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps-partnernamespace azps_test_group_eventgrid
```

Asynchronously creates a new partner namespace with the specified parameters.

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
When the property is set to true, only AAD token will be used to authenticate if user is allowed to publish to the partner namespace.

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
Minimum TLS version of the publisher allowed to publish to this partner namespace

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
Name of the partner namespace.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases: PartnerNamespaceName

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

### -PartnerRegistrationFullyQualifiedId
The fully qualified ARM Id of the partner registration that should be associated with this partner namespace.
This takes the following format:/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/partnerRegistrations/{partnerRegistrationName}.

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

### -PartnerTopicRoutingMode
This determines if events published to this partner namespace should use the source attribute in the event payloador use the channel name in the header when matching to the partner topic.
If none is specified, source attribute routing will be used to match the partner topic.

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
By default it is enabled.You can further restrict to specific IPs by configuring \<seealso cref="P:Microsoft.Azure.Events.ResourceProvider.Common.Contracts.PartnerNamespaceProperties.InboundIpRules" /\>

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IPartnerNamespace

## NOTES

## RELATED LINKS
