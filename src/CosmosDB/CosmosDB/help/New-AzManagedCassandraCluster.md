---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/new-azmanagedcassandracluster
schema: 2.0.0
---

# New-AzManagedCassandraCluster

## SYNOPSIS
Creates a new Azure Managed Instances for Apache Cassandra cluster.

## SYNTAX

```
New-AzManagedCassandraCluster -Location <String> -DelegatedManagementSubnetId <String>
 [-InitialCassandraAdminPassword <String>] [-ClusterNameOverride <String>] [-RestoreFromBackupId <String>]
 -ResourceGroupName <String> -ClusterName <String> [-Tag <Hashtable>] [-ExternalGossipCertificate <String[]>]
 [-ClientCertificate <String[]>] [-RepairEnabled <Boolean>] [-TimeBetweenBackupInHours <Int32>]
 [-AuthenticationMethod <String>] [-CassandraVersion <String>] [-ExternalSeedNode <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzManagedCassandraCluster** cmdlet creates a new managed Cassandra cluster.

## EXAMPLES

### Example 1
```powershell
New-AzManagedCassandraCluster `
 -ResourceGroupName "resourceGroupName" `
 -ClusterName "clusterName" `
 -DelegatedManagementSubnetId "resourceId" `
 -Location "location" `
 -InitialCassandraAdminPassword "password"
```

## PARAMETERS

### -AuthenticationMethod
How to authenticate clients, one of `Cassandra` (for password authentication), `Ldap` (for LDAP/AD authentication), or `None` (for no authentication required).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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
Aliases:

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterNameOverride
If the cluster name in `cassandra.yaml` needs to be different than the argument of `-ClusterName`, use this property to set.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: Same as -ClusterName
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

### -ExternalGossipCertificate
A list of additional TLS certificates the managed Cassandra cluster will use to authenticate gossip.

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

### -ExternalSeedNode
List of IP addresses of external seed nodes to bridge this cluster to.

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

### -InitialCassandraAdminPassword
The initial password for the admin account on the cluster if the cluster is using password auth.

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
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
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

### -RestoreFromBackupId
Resource id of backup to restore into this cluster. If omitted, creates a new, empty cluster.

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
Hashtable of tags to set on the cluster resource.

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

### -TimeBetweenBackupInHours
Hours between taking full backups of the cluster.

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

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSClusterResource

## NOTES

## RELATED LINKS
