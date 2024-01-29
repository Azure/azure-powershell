---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricroutepolicy
schema: 2.0.0
---

# New-AzNetworkFabricRoutePolicy

## SYNOPSIS
Implements Route Policy PUT method.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkFabricRoutePolicy -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> -NetworkFabricId <String> [-AddressFamilyType <String>] [-Annotation <String>]
 [-DefaultAction <String>] [-Statement <IRoutePolicyStatementProperties[]>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkFabricRoutePolicy -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkFabricRoutePolicy -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Implements Route Policy PUT method.

## EXAMPLES

### EXAMPLE 1
```
$statements = @(@{
    ActionType = "Permit"
    SequenceNumber = 12345
    ActionLocalPreference = 123
    ConditionIPCommunityId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipCommunities/ipCommunityName"
    ConditionIPPrefixId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipPrefixes/ipPrefixTestName"
    ConditionType = "Or"
    IPCommunityPropertyAddIpcommunityId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipCommunities/ipCommunityName"
})
```

New-AzNetworkFabricRoutePolicy -Name $name -ResourceGroupName $resourceGroupName -Location $location -NetworkFabricId $nfId -AddressFamilyType "IPv4" -DefaultAction "Permit" -Statement $statements

### EXAMPLE 2
```
$statements = @(@{
    ActionType = "Permit"
    SequenceNumber = 12345
    ActionLocalPreference = 123
    ConditionIPExtendedCommunityId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipExtendedCommunities/ipExtCommName"
    ConditionIPPrefixId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipPrefixes/ipPrefixName"
    ConditionType = "Or"
    IPExtendedCommunityPropertyAddIpextendedCommunityId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipExtendedCommunities/ipExtCommName"
})
```

New-AzNetworkFabricRoutePolicy -Name $name -ResourceGroupName $resourceGroupName -Location $location -NetworkFabricId $nfId -AddressFamilyType "IPv4" -DefaultAction "Permit" -Statement $statements

## PARAMETERS

### -AddressFamilyType
AddressFamilyType.
This parameter decides whether the given ipv4 or ipv6 route policy.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Annotation
Switch configuration description.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Break
Wait for .NET debugger to attach

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultAction
Default action that needs to be applied when no condition is matched.
Example: Permit | Deny.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -HttpPipelineAppend
SendAsync Pipeline Steps to be appended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelinePrepend
SendAsync Pipeline Steps to be prepended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Runtime.SendAsyncStep[]
Parameter Sets: (All)
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
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Route Policy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: RoutePolicyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkFabricId
Arm Resource ID of Network Fabric.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Proxy
The URI for the proxy server to use

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyCredential
Credentials for a proxy server to use for the remote call

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyUseDefaultCredentials
Use the default credentials for the proxy

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -Statement
Route Policy statements.
To construct, see NOTES section for STATEMENT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IRoutePolicyStatementProperties[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IRoutePolicy
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

STATEMENT \<IRoutePolicyStatementProperties\[\]\>: Route Policy statements.
  ActionType \<String\>: Action type.
Example: Permit | Deny | Continue.
  SequenceNumber \<Int64\>: Sequence to insert to/delete from existing route.
  \[Annotation \<String\>\]: Switch configuration description.
  \[ActionLocalPreference \<Int64?\>\]: Local Preference of the route policy.
  \[ConditionIPCommunityId \<List\<String\>\>\]: List of IP Community resource IDs.
  \[ConditionIPExtendedCommunityId \<List\<String\>\>\]: List of IP Extended Community resource IDs.
  \[ConditionIPPrefixId \<String\>\]: Arm Resource Id of IpPrefix.
  \[ConditionType \<String\>\]: Type of the condition used.
  \[IPCommunityPropertyAddIpcommunityId \<List\<String\>\>\]: List of IP Community resource IDs.
  \[IPCommunityPropertyDeleteIpcommunityId \<List\<String\>\>\]: List of IP Community resource IDs.
  \[IPCommunityPropertySetIpcommunityId \<List\<String\>\>\]: List of IP Community resource IDs.
  \[IPExtendedCommunityPropertyAddIpextendedCommunityId \<List\<String\>\>\]: List of IP Extended Community resource IDs.
  \[IPExtendedCommunityPropertyDeleteIpextendedCommunityId \<List\<String\>\>\]: List of IP Extended Community resource IDs.
  \[IPExtendedCommunityPropertySetIpextendedCommunityId \<List\<String\>\>\]: List of IP Extended Community resource IDs.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricroutepolicy](https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricroutepolicy)

