---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/update-azmanagedcassandracluster
schema: 2.0.0
---

# Update-AzManagedCassandraCluster

## SYNOPSIS
Update an existing Azure Managed Instances for Apache Cassandra cluster.

## SYNTAX

### NameParameterSet (Default)
```
Update-AzManagedCassandraCluster 
 -ResourceGroupName <String> 
 -ClusterName <String>
 [-ExternalGossipCertificate <String[]>]
 [-ClientCertificate <String[]>]
 [-RepairEnabled <bool>]
 [-TimeBetweenBackupInHours <int>]
 [-AuthenticationMethod <String>]
 [-CassandraVersion <String>]
 [-ExternalSeedNode <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Update-AzManagedCassandraCluster 
 -ResourceId <String> 
 [-Tag <Hashtable>]
 [-ExternalGossipCertificate <String[]>]
 [-ClientCertificate <String[]>]
 [-RepairEnabled <bool>]
 [-TimeBetweenBackupInHours <int>]
 [-AuthenticationMethod <String>]
 [-CassandraVersion <String>]
 [-ExternalSeedNode <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ObjectParameterSet
```
Update-AzManagedCassandraCluster 
 -InputObject <PSClusterResource> 
 [-Tag <Hashtable>]
 [-ExternalGossipCertificate <String[]>]
 [-ClientCertificate <String[]>]
 [-RepairEnabled <bool>]
 [-TimeBetweenBackupInHours <int>]
 [-AuthenticationMethod <String>]
 [-CassandraVersion <String>]
 [-ExternalSeedNode <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzManagedCassandraCluster** cmdlet alters an existing managed Cassandra cluster.

## EXAMPLES

### Example 1
```powershell
Update-AzManagedCassandraCluster `
 -ResourceGroupName {resourceGroupName} `
 -ClusterName {clusterName} `
 -ExternalGossipCertificate {certificates} `
 -ClientCertificate {certificates} `
 -RepairEnabled {boolean}
```

### Example 2
```powershell
Update-AzManagedCassandraCluster `
 -ResourceId {clusterResourceId} `
 -ExternalGossipCertificate {certificates} `
 -ClientCertificate {certificates} `
 -RepairEnabled {boolean}
```

### Example 3
```powershell
$clusterResource | Update-AzManagedCassandraCluster `
 -ExternalGossipCertificate {certificates} `
 -ClientCertificate {certificates} `
 -RepairEnabled {boolean}
```

## PARAMETERS

### -AuthenticationMethod
How to authenticate clients, one of `Cassandra` (for password authentication), `Ldap` (for LDAP/AD authentication), or `None` (for no authentication required).

```yaml
Type: System.String
Parameter Sets: (All)

Required: False
Position: Named
Default value: Cassandra
Accept pipeline input: False
Accept wildcard characters: False
```

### -CassandraVersion
Which version of Cassandra to run. Currently only 3.11 is supported.

```yaml
Type: System.String
Parameter Sets: (All)

Required: False
Position: Named
Default value: 3.11
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientCertificate
The list of TLS certificates to use to authenticate clients. If this is omitted, all client connections still connect with TLS, but are not required to provide valid client certificates. If this is provided, clients most provide a valid TLS client certificate to connect to the cluster.

```yaml
Type: System.String[]
Parameter Sets: (All)

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

### -ExternalGossipCertificate
A list of additional TLS certificates the managed Cassandra cluster will use to authenticate gossip.

```yaml
Type: System.String[]
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalSeedNode
List of IP addresses of external seed nodes to bridge this cluster to.

```yaml
Type: System.String[]
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
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

### -RepairEnabled
If true, managed Cassandra will run reaper to repair the database regularly. This should only be disabled for hybrid clusters which run their own repair process outside of Azure.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: True
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

### -Tag
Hashtable of tags to set on the data center resource.

```yaml
Type: System.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeBetweenBackupInHours
Hours between taking full backups of the cluster.

```yaml
Type: System.Integer
Parameter Sets: (All))
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSClusterResource

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSClusterResource

## NOTES

## RELATED LINKS
