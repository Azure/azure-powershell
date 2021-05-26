---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version:
schema: 2.0.0
---

# Get-AzManagedCassandraDatacenter

## SYNOPSIS
Gets the ManagedCassandra Datacenters.

## SYNTAX

```
Get-AzManagedCassandraDatacenter -ResourceGroupName <String> -ClusterName <String> [-DataCenterName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet can be used to list the ManagedCassandra Datacenters in a Cluster and get a datacenter by its Name.

## EXAMPLES

### Example 1: Get a Managed Cassandra Datacenter by Name
```powershell
PS C:\> Get-AzManagedCassandraDatacenter -ResourceGroupName "RG01" -ClusterName "Cluster01" -DataCenterName "dc01"
```

### Example 2: List Managed Cassandra Datacenters a Cluster
```powershell
PS C:\> Get-AzManagedCassandraDatacenter -ResourceGroupName "RG01" -ClusterName "Cluster01"
```

## PARAMETERS

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

### -DataCenterName
Managed Cassandra Datacenter Name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSManagedCassandraClusterGetResults

## NOTES

## RELATED LINKS
