---
external help file:
Module Name: Az.Search
online version: https://docs.microsoft.com/en-us/powershell/module/az.search/update-azsearchservice
schema: 2.0.0
---

# Update-AzSearchService

## SYNOPSIS
Updates an existing search service in the given resource group.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSearchService -ResourceGroupName <String> -SearchServiceName <String> [-SubscriptionId <String>]
 [-ClientRequestId <String>] [-HostingMode <HostingMode>] [-IdentityType <IdentityType>] [-Location <String>]
 [-NetworkRuleSetIPRule <IIPRule[]>] [-PartitionCount <Int32>] [-PublicNetworkAccess <PublicNetworkAccess>]
 [-ReplicaCount <Int32>] [-SkuName <SkuName>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSearchService -InputObject <ISearchIdentity> [-ClientRequestId <String>] [-HostingMode <HostingMode>]
 [-IdentityType <IdentityType>] [-Location <String>] [-NetworkRuleSetIPRule <IIPRule[]>]
 [-PartitionCount <Int32>] [-PublicNetworkAccess <PublicNetworkAccess>] [-ReplicaCount <Int32>]
 [-SkuName <SkuName>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates an existing search service in the given resource group.

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

### -ClientRequestId
A client-generated GUID value that identifies this request.
If specified, this will be included in response information as a way to track the request.

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

### -HostingMode
Applicable only for the standard3 SKU.
You can set this property to enable up to 3 high density partitions that allow up to 1000 indexes, which is much higher than the maximum indexes allowed for any other SKU.
For the standard3 SKU, the value is either 'default' or 'highDensity'.
For all other SKUs, this value must be 'default'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Search.Support.HostingMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Search.Support.IdentityType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Search.Models.ISearchIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The geographic location of the resource.
This must be one of the supported and registered Azure Geo Regions (for example, West US, East US, Southeast Asia, and so forth).
This property is required when creating a new resource.

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

### -NetworkRuleSetIPRule
A list of IP restriction rules that defines the inbound network(s) with allowing access to the search service endpoint.
At the meantime, all other public IP networks are blocked by the firewall.
These restriction rules are applied only when the 'publicNetworkAccess' of the search service is 'enabled'; otherwise, traffic over public interface is not allowed even with any public IP rules, and private endpoint connections would be the exclusive access method.
To construct, see NOTES section for NETWORKRULESETIPRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Search.Models.Api20200801.IIPRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartitionCount
The number of partitions in the search service; if specified, it can be 1, 2, 3, 4, 6, or 12.
Values greater than 1 are only valid for standard SKUs.
For 'standard3' services with hostingMode set to 'highDensity', the allowed values are between 1 and 3.

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

### -PublicNetworkAccess
This value can be set to 'enabled' to avoid breaking changes on existing customer resources and templates.
If set to 'disabled', traffic over public interface is not allowed, and private endpoint connections would be the exclusive access method.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Search.Support.PublicNetworkAccess
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicaCount
The number of replicas in the search service.
If specified, it must be a value between 1 and 12 inclusive for standard SKUs or between 1 and 3 inclusive for basic SKU.

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

### -ResourceGroupName
The name of the resource group within the current subscription.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SearchServiceName
The name of the Azure Cognitive Search service to update.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
The SKU of the search service.
Valid values include: 'free': Shared service.
'basic': Dedicated service with up to 3 replicas.
'standard': Dedicated service with up to 12 partitions and 12 replicas.
'standard2': Similar to standard, but with more capacity per search unit.
'standard3': The largest Standard offering with up to 12 partitions and 12 replicas (or up to 3 partitions with more indexes if you also set the hostingMode property to 'highDensity').
'storage_optimized_l1': Supports 1TB per partition, up to 12 partitions.
'storage_optimized_l2': Supports 2TB per partition, up to 12 partitions.'

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Search.Support.SkuName
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The unique identifier for a Microsoft Azure subscription.
You can obtain this value from the Azure Resource Manager API or the portal.

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
Tags to help categorize the resource in the Azure portal.

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

### Microsoft.Azure.PowerShell.Cmdlets.Search.Models.ISearchIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Search.Models.Api20200801.ISearchService

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ISearchIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[Key <String>]`: The query key to be deleted. Query keys are identified by value, not by name.
  - `[KeyKind <AdminKeyKind?>]`: Specifies which key to regenerate. Valid values include 'primary' and 'secondary'.
  - `[Name <String>]`: The name of the new query API key.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection to the Azure Cognitive Search service with the specified resource group.
  - `[ResourceGroupName <String>]`: The name of the resource group within the current subscription. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[SearchServiceName <String>]`: The name of the Azure Cognitive Search service associated with the specified resource group.
  - `[SharedPrivateLinkResourceName <String>]`: The name of the shared private link resource managed by the Azure Cognitive Search service within the specified resource group.
  - `[SubscriptionId <String>]`: The unique identifier for a Microsoft Azure subscription. You can obtain this value from the Azure Resource Manager API or the portal.

NETWORKRULESETIPRULE <IIPRule[]>: A list of IP restriction rules that defines the inbound network(s) with allowing access to the search service endpoint. At the meantime, all other public IP networks are blocked by the firewall. These restriction rules are applied only when the 'publicNetworkAccess' of the search service is 'enabled'; otherwise, traffic over public interface is not allowed even with any public IP rules, and private endpoint connections would be the exclusive access method.
  - `[Value <String>]`: Value corresponding to a single IPv4 address (eg., 123.1.2.3) or an IP range in CIDR format (eg., 123.1.2.3/24) to be allowed.

## RELATED LINKS

