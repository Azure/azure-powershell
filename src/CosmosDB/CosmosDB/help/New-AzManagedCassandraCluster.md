---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/en-us/powershell/module/az.cosmosdb/new-azmanagedcassandracluster
schema: 2.0.0
---

# New-AzManagedCassandraCluster

## SYNOPSIS
Create a new ManagedCassandra Cluster.

## SYNTAX

```
New-AzManagedCassandraCluster -Location <String> -DelegatedManagementSubnetId <String>
 [-InitialCassandraAdminPassword <String>] [-ClusterNameOverride <String>] [-RestoreFromBackupId <String>]
 -ResourceGroupName <String> -ClusterName <String> [-Identity <ManagedServiceIdentity>] [-Tags <Hashtable>]
 [-ExternalGossipCertificates <String[]>] [-ClientCertificates <String[]>] [-RepairEnabled <Boolean>]
 [-HoursBetweenBackups <Int32>] [-AuthenticationMethod <String>] [-CassandraVersion <String>]
 [-ExternalSeedNodes <String[]>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
This cmdlet is used to create a ManagedCassandra Cluster in supported regions.

## EXAMPLES

### Example 1: Create a New Managed Cassandra Cluster
```powershell
PS C:\> New-AzManagedCassandraCluster -ResourceGroupName "test-powershell" -ClusterName "cluster1" -Location "westus" -InitialCassandraAdminPassword "password" -DelegatedManagementSubnetId "/subscriptions/94d9b402-77b4-4049-b4c1-947bc6b7729b/resourceGroups/My-vnet/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/test-subnet"

Id         : /subscriptions/{subscriptionId}/resourceGroups/test-powershell/providers/Microsoft.DocumentDB/cassandraClusters/cluster1
Name       : cluster1
Location   : eastus2
Tags       : {}
Properties : Microsoft.Azure.Commands.CosmosDB.Models.PSClusterResourceProperties
```

## PARAMETERS

### -AuthenticationMethod
Authentication mode can be None or Cassandra.
If None, no authentication will be required to connect to the Cassandra API.
If Cassandra, then passwords will be used.

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

### -CassandraVersion
The version of Cassandra chosen.

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

### -ClientCertificates
If specified, enables client certificate authentication to the Cassandra API.

```yaml
Type: System.String[]
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

### -ClusterNameOverride
If a cluster must have a name that is not a valid azure resource name, this field can be specified to choose the Cassandra cluster name.
Otherwise, the resource name will be used as the cluster name.

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DelegatedManagementSubnetId
The resource id of a subnet where the ip address of the cassandra management server will be allocated.
This subnet must have connectivity to the DelegatedSubnetId subnet of each data center.

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

### -ExternalGossipCertificates
A list of certificates that the managed cassandra data center's should accept.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalSeedNodes
A list of ip addresses of the seed nodes of on-premise data centers.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HoursBetweenBackups
The number of hours between backup attempts.

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

### -Identity
Identity used to authenticate.

```yaml
Type: Microsoft.Azure.Management.CosmosDB.Models.ManagedServiceIdentity
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InitialCassandraAdminPassword
The intial password to be configured when a cluster is created for AuthenticationMethod Cassandra.

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
Azure Location of the Cluster.

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

### -RepairEnabled
Enables automatic repair.

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

### -RestoreFromBackupId
The resource id of a backup.
If provided on create, the backup will be used to prepopulate the cluster.
The cluster data center count and node counts must match the backup.

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

### -Tags
Managed Cassandra Tags.

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSManagedCassandraClusterGetResults

### Microsoft.Azure.Commands.CosmosDB.Exceptions.ConflictingResourceException

## NOTES

## RELATED LINKS
