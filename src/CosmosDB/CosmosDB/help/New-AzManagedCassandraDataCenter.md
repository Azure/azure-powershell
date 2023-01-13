---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/new-azmanagedcassandradatacenter
schema: 2.0.0
---

# New-AzManagedCassandraDatacenter

## SYNOPSIS
Create a new Azure Managed Instances for Apache Cassandra data center.

## SYNTAX

### ByNameParameterSet (Default)
```
New-AzManagedCassandraDatacenter -Location <String> -DelegatedSubnetId <String> [-Sku <String>]
 [-DiskCapacity <Int32>] [-ManagedDiskCustomerKeyUri <String>] [-UseAvailabilityZone]
 -ResourceGroupName <String> -ClusterName <String> -DatacenterName <String> [-NodeCount <Int32>]
 [-Base64EncodedCassandraYamlFragment <String>] [-BackupStorageCustomerKeyUri <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
New-AzManagedCassandraDatacenter -Location <String> -DelegatedSubnetId <String>
 -ParentObject <PSClusterResource> [-Sku <String>] [-DiskCapacity <Int32>]
 [-ManagedDiskCustomerKeyUri <String>] [-UseAvailabilityZone] [-NodeCount <Int32>]
 [-Base64EncodedCassandraYamlFragment <String>] [-BackupStorageCustomerKeyUri <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzManagedCassandraDataCenter** cmdlet creates a new managed Cassandra data center.

## EXAMPLES

### Example 1
```powershell
New-AzManagedCassandraDataCenter `
 -ResourceGroupName "resourceGroupName" `
 -ClusterName "clusterName" `
 -DataCenterName "dataCenterName" `
 -DelegatedSubnetId "resourceId" `
 -Location "location" `
 -NodeCount 3
```

## PARAMETERS

### -BackupStorageCustomerKeyUri
URI to a KeyVault key used to encrypt backups of the cluster. If omitted, Azure's own keys will be used.

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

### -Base64EncodedCassandraYamlFragment
Fragment of configuration to include in `cassandra.yaml` on nodes of this data center, Base64 encoded.

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
Name of the managed Cassandra cluster.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
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
Parameter Sets: ByNameParameterSet
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
The resource id of the virtual network subnet where managed Cassandra should attach network interfaces.

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

### -DiskCapacity
The number of data disks to connect to each node in the cluster.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 4
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location to create the managed Cassandra cluster in.

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

### -ManagedDiskCustomerKeyUri
URI of a KeyVault key used to encrypt data at rest in the cluster. If omitted, Azure's own keys will be used.

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

### -NodeCount
The number of nodes to create in this data center.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 3
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
Cassandra cluster object to create a data center in.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSClusterResource
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
Name of the virtual machine sku to use for nodes in this data center. See the [documentation](https://docs.microsoft.com/en-us/azure/managed-instance-apache-cassandra/create-cluster-cli) for supported skus.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: Standard_DS14_v2
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseAvailabilityZone
If set, allocate nodes in this data center using availability zones if they are supported in the region.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: True
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSClusterResource

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSDataCenterResource

## NOTES

## RELATED LINKS
