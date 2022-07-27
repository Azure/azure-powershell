---
external help file: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.dll-Help.xml
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/update-azoperationalinsightscluster
schema: 2.0.0
---

# Update-AzOperationalInsightsCluster

## SYNOPSIS
update cluster

## SYNTAX

### UpdateByNameParameterSet (Default)
```
Update-AzOperationalInsightsCluster -ResourceGroupName <String> -ClusterName <String> [-SkuName <String>]
 [-SkuCapacity <Int64>] [-KeyVaultUri <String>] [-KeyName <String>] [-KeyVersion <String>] [-Tag <Hashtable>]
 [-IdentityType <String>] [-BillingType <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### AllParameterSet
```
Update-AzOperationalInsightsCluster [-ResourceGroupName <String>] [-ClusterName <String>]
 [-ResourceId <String>] [-InputCluster <PSCluster>] [-SkuName <String>] [-SkuCapacity <Int64>]
 [-KeyVaultUri <String>] [-KeyName <String>] [-KeyVersion <String>] [-Tag <Hashtable>] [-IdentityType <String>]
 [-BillingType <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateByResourceIdParameterSet
```
Update-AzOperationalInsightsCluster -ResourceId <String> [-SkuName <String>] [-SkuCapacity <Int64>]
 [-KeyVaultUri <String>] [-KeyName <String>] [-KeyVersion <String>] [-Tag <Hashtable>] [-IdentityType <String>]
 [-BillingType <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateByInputObjectParameterSet
```
Update-AzOperationalInsightsCluster -InputCluster <PSCluster> [-SkuName <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
update cluster

## EXAMPLES

### Example 1
```powershell
Update-AzOperationalInsightsCluster -ResourceGroupName "rg-name" -ClusterName "cluster-name" -SkuName CapacityReservation -SkuCapacity 1200 -KeyVaultUri "uri" -KeyName "key-name" -KeyVersion "version"
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
LastModifiedDate				: 
CreatedDate						: 
AssociatedWorkspaces			: {workspaces}
CapacityReservationProperties	: Microsoft.Azure.Management.OperationalInsights.Models.CapacityReservationProperties
Location						: South Central US
Id								: /subscriptions/{subscription}/resourceGroups/{rg-name}/providers/Microsoft.OperationalInsights/clusters/{cluster-name}
Name							: {cluster-name}
Type							: Microsoft.OperationalInsights/clusters
Tags							: {}
```

update cluster with key vault properties and sku

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -BillingType
Billing type can be set as 'Cluster' or 'Workspaces'

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet, AllParameterSet, UpdateByResourceIdParameterSet
Aliases:
Accepted values: Cluster, Workspaces

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The cluster name.

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: AllParameterSet
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

### -IdentityType
the identity type, value can be 'SystemAssigned', 'None'.

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet, AllParameterSet, UpdateByResourceIdParameterSet
Aliases:
Accepted values: SystemAssigned, None, UserAssigned

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputCluster
Specifies the cluster to be updated.

```yaml
Type: Microsoft.Azure.Commands.OperationalInsights.Models.PSCluster
Parameter Sets: AllParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: Microsoft.Azure.Commands.OperationalInsights.Models.PSCluster
Parameter Sets: UpdateByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyName
Key Name

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet, AllParameterSet, UpdateByResourceIdParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultUri
Key Vault Uri, "Purge Protection" and "Soft Delete" have to be enabled for this keyvault

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet, AllParameterSet, UpdateByResourceIdParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVersion
Key Version

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet, AllParameterSet, UpdateByResourceIdParameterSet
Aliases:

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
Parameter Sets: UpdateByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: AllParameterSet
Aliases:

Required: False
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
Parameter Sets: AllParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: UpdateByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
Sku Capacity

```yaml
Type: System.Int64
Parameter Sets: UpdateByNameParameterSet, AllParameterSet, UpdateByResourceIdParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Sku Name, now can be 'CapacityReservation' only

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: CapacityReservation

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tags of the cluster

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateByNameParameterSet, AllParameterSet, UpdateByResourceIdParameterSet
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

### System.String

### Microsoft.Azure.Commands.OperationalInsights.Models.PSCluster

## OUTPUTS

### Microsoft.Azure.Commands.OperationalInsights.Models.PSCluster

## NOTES

## RELATED LINKS
