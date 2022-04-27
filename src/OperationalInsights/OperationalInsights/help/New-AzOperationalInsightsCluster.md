---
external help file: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.dll-Help.xml
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/new-azoperationalinsightscluster
schema: 2.0.0
---

# New-AzOperationalInsightsCluster

## SYNOPSIS
Create cluster

## SYNTAX

```
New-AzOperationalInsightsCluster [-ResourceGroupName] <String> [-ClusterName] <String> [-Location] <String>
 [-IdentityType <String>] [-SkuName <String>] -SkuCapacity <Int64> [-Tag <Hashtable>] [-KeyVaultUri <String>]
 [-KeyName <String>] [-KeyVersion <String>] [-IsAvailabilityZonesEnabled <Boolean>]
 [-IsDoubleEncryptionEnabled <Boolean>] [-BillingType <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION

Create cluster

## EXAMPLES

### Example 1
```powershell
New-AzOperationalInsightsCluster -ResourceGroupName "rg-name" -ClusterName "cluster-name" -Location eastus -IdentityType SystemAssigned -SkuName CapacityReservation -SkuCapacity 1000
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

Create cluster

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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
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
Parameter Sets: (All)
Aliases:
Accepted values: SystemAssigned, None, UserAssigned

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsAvailabilityZonesEnabled
Flag for availability Zones,can be set to true only in supported regions

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

### -IsDoubleEncryptionEnabled
Flag for Double Encryption, can be set to true only in supported regions

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

### -KeyName
Key Name

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

### -KeyVaultUri
Key Vault Uri

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

### -KeyVersion
Key Version

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
The geographic region that the cluster will be deployed.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
Sku Capacity, value need to be multiple of 100 and in the range of 1000-2000.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: True
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.OperationalInsights.Models.PSCluster

## NOTES

## RELATED LINKS
