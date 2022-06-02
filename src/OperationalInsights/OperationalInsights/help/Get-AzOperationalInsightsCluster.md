---
external help file: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.dll-Help.xml
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/get-azoperationalinsightscluster
schema: 2.0.0
---

# Get-AzOperationalInsightsCluster

## SYNOPSIS
Get or list clusters

## SYNTAX

### ListParameterSet (Default)
```
Get-AzOperationalInsightsCluster [-ResourceGroupName <String>] [-ClusterName <String>] [-ResourceId <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByNameParameterSet
```
Get-AzOperationalInsightsCluster -ResourceGroupName <String> -ClusterName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzOperationalInsightsCluster -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Get or list clusters, list clusters under resource group when "-ClusterName" was not provided, list clusters under subscription when "-ClusterName" and "ResourceGroupName" were not provided.

## EXAMPLES

### Example 1
```powershell
Get-AzOperationalInsightsCluster -ResourceGroupName "rg-name" -ClusterName "cluster-name"
```

```output
Identity						: Microsoft.Azure.Commands.OperationalInsights.Models.PSIdentity
Sku								: Microsoft.Azure.Commands.OperationalInsights.Models.PSClusterSku
ClusterId						: {cluster-id}
ProvisioningState				: Succeeded
IsDoubleEncryptionEnabled		: True
IsAvailabilityZonesEnabled		: False
BillingType						: Cluster
KeyVaultProperties				: Microsoft.Azure.Commands.OperationalInsights.Models.PSKeyVaultProperties
LastModifiedDate				: Wed, 26 May 2021 15:19:38 GMT
CreatedDate						: Sun, 27 Dec 2020 11:17:11 GMT
AssociatedWorkspaces			: {workspaces}
CapacityReservationProperties	: Microsoft.Azure.Management.OperationalInsights.Models.CapacityReservationProperties
Location						: South Central US
Id								: /subscriptions/{subscription}/resourceGroups/{rg-name}/providers/Microsoft.OperationalInsights/clusters/{cluster-name}
Name							: {cluster-name}
Type							: Microsoft.OperationalInsights/clusters
Tags							: {}
```

Get cluster

## PARAMETERS

### -ClusterName
The cluster name.

```yaml
Type: System.String
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
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

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The destination resource ID.
This can be copied from the Properties entry of the destination resource in Azure.

```yaml
Type: System.String
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.OperationalInsights.Models.PSCluster

## NOTES

## RELATED LINKS
