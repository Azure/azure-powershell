---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.dll-Help.xml
Module Name: Az.ResourceGraph
online version: https://learn.microsoft.com/powershell/module/az.resourcegraph/search-azgraph
schema: 2.0.0
---

# Search-AzGraph

## SYNOPSIS
Queries the resources managed by Azure Resource Manager.

## SYNTAX

### SubscriptionScopedQuery (Default)
```
Search-AzGraph [-Query] <String> [-Subscription <String[]>] [-First <Int32>] [-Skip <Int32>]
 [-SkipToken <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ManagementGroupScopedQuery
```
Search-AzGraph [-Query] <String> -ManagementGroup <String[]> [-AllowPartialScope] [-First <Int32>]
 [-Skip <Int32>] [-SkipToken <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### TenantScopedQuery
```
Search-AzGraph [-Query] <String> [-UseTenantScope] [-AllowPartialScope] [-First <Int32>] [-Skip <Int32>]
 [-SkipToken <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Learn more about the query syntax here: https://aka.ms/resource-graph/learntoquery

## EXAMPLES

### Example 1
```powershell
Search-AzGraph "project id, name, type, location, tags" -First 3
```

```output
id         : /subscriptions/1ef51df4-f8a9-4b69-9919-1ef51df4eff6/resourceGroups/Service-INT-a/providers/Microsoft.Compute/virtualMachineScaleSets/nt
name       : nt
type       : microsoft.compute/virtualmachinescalesets
location   : eastus
tags       : @{resourceType=Service Fabric; clusterName=gov-art-int-nt-a}
ResourceId : /subscriptions/1ef51df4-f8a9-4b69-9919-1ef51df4eff6/resourceGroups/Service-INT-a/providers/Microsoft.Compute/virtualMachineScaleSets/nt

id         : /subscriptions/1ef51df4-f8a9-4b69-9919-1ef51df4eff6/resourceGroups/Service-INT-a/providers/Microsoft.EventGrid/topics/egtopic-1
name       : egtopic-1
type       : microsoft.eventgrid/topics
location   : westus2
tags       :
ResourceId : /subscriptions/1ef51df4-f8a9-4b69-9919-1ef51df4eff6/resourceGroups/Service-INT-a/providers/Microsoft.EventGrid/topics/egtopic-1
```

Simple resources query requesting a subset of resource fields.

### Example 2
```powershell
Search-AzGraph "project id, name, type, location | where type =~ 'Microsoft.Compute/virtualMachines' | summarize count() by location | top 3 by count_"
```

```output
location      count_
--------      ------
eastus            66
westcentralus     32
westus            26
```

A complex query on resources featuring field selection, filtering and summarizing.

### Example 3
```powershell
$response = Search-AzGraph -Query "project id, name, type, location" -First 2
Search-AzGraph -Query "project id, name, type, location" -SkipToken $response.SkipToken
```

```output
id         : /subscriptions/1ef51df4-f8a9-4b69-9919-1ef51df4eff6/resourceGroups/test/providers/Microsoft.Network/networkInterfaces/17ni
name       : 17ni
type       : microsoft.network/networkinterfaces
location   : westeurope
ResourceId : /subscriptions/1ef51df4-f8a9-4b69-9919-1ef51df4eff6/resourceGroups/test/providers/Microsoft.Network/networkInterfaces/17ni

id         : /subscriptions/1ef51df4-f8a9-4b69-9919-1ef51df4eff6/resourceGroups/test/providers/Microsoft.Network/networkSecurityGroups/17nsg
name       : 17nsg
type       : microsoft.network/networksecuritygroups
location   : westeurope
ResourceId : /subscriptions/1ef51df4-f8a9-4b69-9919-1ef51df4eff6/resourceGroups/test/providers/Microsoft.Network/networkSecurityGroups/17nsg
```

A query with the skip token passed from the previous query results. Please note that keeping id in the results is mandatory to get back a skip token.

### Example 4
```powershell
Search-AzGraph -Query "project id, name, type, location, tags" -First 2 -ManagementGroup MyManagementGroupId -AllowPartialScope
```

```output
id         : /subscriptions/1ef51df4-f8a9-4b69-9919-1ef51df4eff6/resourceGroups/Service-INT-a/providers/Microsoft.Compute/virtualMachineScaleSets/nt
name       : nt
type       : microsoft.compute/virtualmachinescalesets
location   : eastus
tags       : @{resourceType=Service Fabric; clusterName=gov-art-int-nt-a}
ResourceId : /subscriptions/1ef51df4-f8a9-4b69-9919-1ef51df4eff6/resourceGroups/Service-INT-a/providers/Microsoft.Compute/virtualMachineScaleSets/nt

id         : /subscriptions/1ef51df4-f8a9-4b69-9919-1ef51df4eff6/resourceGroups/Service-INT-a/providers/Microsoft.EventGrid/topics/egtopic-1
name       : egtopic-1
type       : microsoft.eventgrid/topics
location   : westus2
tags       :
ResourceId : /subscriptions/1ef51df4-f8a9-4b69-9919-1ef51df4eff6/resourceGroups/Service-INT-a/providers/Microsoft.EventGrid/topics/egtopic-1
```

A query scoped to the management group that allows the query to succeed with partial scope result if MyManagementGroupId has more than N subscriptions underneath.
N is max number of subscriptions that can be processed by server.

## PARAMETERS

### -AllowPartialScope
Indicates if query should succeed when only partial number of subscriptions underneath can be processed by server

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ManagementGroupScopedQuery, TenantScopedQuery
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementGroup
Management group(s) to run query against.

```yaml
Type: System.String[]
Parameter Sets: ManagementGroupScopedQuery
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Query
Resource Graph query.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkipToken
The skip token to use for getting the next page of results if applicable.

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

### -Subscription
Subscription(s) to run query against.

```yaml
Type: System.String[]
Parameter Sets: SubscriptionScopedQuery
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseTenantScope
Run query across all available subscriptions in the current tenant.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: TenantScopedQuery
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Ignores the first N objects and then gets the remaining objects.

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

### -First
The maximum number of objects to return. Allowed values: 1-1000.
Default value is 100.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.ResourceGraph.Models.PSResourceGraphResponse`1[[System.Management.Automation.PSObject]]

## NOTES

## RELATED LINKS
