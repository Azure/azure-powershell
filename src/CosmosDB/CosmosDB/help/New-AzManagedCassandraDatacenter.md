---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/en-us/powershell/module/az.cosmosdb/new-azmanagedcassandradatacenter
schema: 2.0.0
---

# New-AzManagedCassandraDatacenter

## SYNOPSIS
Create a new ManagedCassandra Datacenter.

## SYNTAX

```
New-AzManagedCassandraDatacenter -Location <String> -DelegatedSubnetId <String> -ResourceGroupName <String>
 -ClusterName <String> -DatacenterName <String> [-NodeCount <Int32>]
 [-Base64EncodedCassandraYamlFragment <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
This cmdlet is used to create a ManagedCassandra Datacenter in supported regions.

## EXAMPLES

### Example 1: Create a New Managed Cassandra Datacenter
```powershell
PS C:\> New-AzManagedCassandraDatacenter -ResourceGroupName "test-powershell" -ClusterName "Cluster01" -DatacenterName "dc01" -Location "westus" -NodeCount 3 -DelegatedSubnetId "/subscriptions/94d9b402-77b4-4049-b4c1-947bc6b7729b/resourceGroups/My-vnet/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/test-subnet"
```

Id                                                                                                                                                           Name Properties
--                                                                                                                                                           ---- ----------
/subscriptions/{subscriptionId}/resourceGroups/test-powershell/providers/Microsoft.DocumentDB/cassandraClusters/Cluster01/dataCenters/dc01 dc01  Microsoft.Azure.Commands.CosmosDB.Models.PSDataCenterResourceProperties


This command creates a ManagedCassandra datacenter dc01 in cluster01 with 3 nodes in region West US.

## PARAMETERS

### -Base64EncodedCassandraYamlFragment
This is a Base64 encoded yaml file that is a subset of cassandra.yaml.
Supported fields will be honored and others will be ignored.

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

### -ClusterName
Managed Cassandra Cluster Name.

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

### -DatacenterName
Managed Cassandra Datacenter Name.

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

### -DelegatedSubnetId
The resource id of a subnet where ip addresses of the Cassandra virtual machines will be allocated.
This must be in the same region as datacenter location.

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

### -Location
Azure Location of the DataCenter.

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

### -NodeCount
The number of Cassandra virtual machines in this data center.
The minimum value is 3.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group.

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSManagedCassandraDatacenterGetResults

### Microsoft.Azure.Commands.CosmosDB.Exceptions.ConflictingResourceException

## NOTES

## RELATED LINKS
