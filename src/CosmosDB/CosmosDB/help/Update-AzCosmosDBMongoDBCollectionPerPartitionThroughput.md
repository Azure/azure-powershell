---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version:
schema: 2.0.0
---

# Update-AzCosmosDBMongoDBCollectionPerPartitionThroughput

## SYNOPSIS
Updates the Partition Throughput for a MongoDB collection.

## SYNTAX

### ByNameParameterSet (Default)
```
Update-AzCosmosDBMongoDBCollectionPerPartitionThroughput -ResourceGroupName <String> -DatabaseName <String>
 [-Name <String>] [-SourcePhysicalPartitionThroughputObject <PSPhysicalPartitionThroughputInfo[]>]
 [-TargetPhysicalPartitionThroughputObject <PSPhysicalPartitionThroughputInfo[]>] [-EqualDistributionPolicy]
 [-DefaultProfile <IAzureContextContainer>] -AccountName <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Update-AzCosmosDBMongoDBCollectionPerPartitionThroughput [-Name <String>]
 -ParentObject <PSSqlDatabaseGetResults>
 [-SourcePhysicalPartitionThroughputObject <PSPhysicalPartitionThroughputInfo[]>]
 [-TargetPhysicalPartitionThroughputObject <PSPhysicalPartitionThroughputInfo[]>] [-EqualDistributionPolicy]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Update-AzCosmosDBMongoDBCollectionPerPartitionThroughput [-Name <String>]
 -InputObject <PSSqlContainerGetResults>
 [-SourcePhysicalPartitionThroughputObject <PSPhysicalPartitionThroughputInfo[]>]
 [-TargetPhysicalPartitionThroughputObject <PSPhysicalPartitionThroughputInfo[]>] [-EqualDistributionPolicy]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet can be used to redistribute the throughput across partitions in a MongoDB collection.

## EXAMPLES

### Example 1
```powershell
$partitions = Get-AzCosmosDBMongoDBCollectionPerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -Name $ContainerName -AllPartitions
      $sources = @()
      $targets = @()
      Foreach($partition in $partitions)
      {
          if($partition.Id -lt 2)
          {
            $throughput = $partition.Throughput - 100
            $sources += New-AzCosmosDBPhysicalPartitionThroughputObject -Id $partition.Id -Throughput $throughput
          }
          else
          {
              $throughput = $partition.Throughput + 100
              $targets += New-AzCosmosDBPhysicalPartitionThroughputObject -Id $partition.Id -Throughput $throughput
          }
      }
      
      $newPartitions = Update-AzCosmosDBMongoDBCollectionPerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -Name $ContainerName -SourcePhysicalPartitionThroughputObject $sources -TargetPhysicalPartitionThroughputObject $targets
      
      $resetPartitions = Update-AzCosmosDBMongoDBCollectionPerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -Name $ContainerName -EqualDistributionPolicy      

      $somePartitions = Get-AzCosmosDBMongoDBCollectionPerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -Name $ContainerName -PhysicalPartitionIds ('0', '1')
```

{{ Add example description here }}

## PARAMETERS

### -AccountName
Name of the Cosmos DB database account.

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

### -DatabaseName
Database name.

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

### -EqualDistributionPolicy
Set this switch to reset the throughput layout for all partitions.

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

### -InputObject
Sql Container object.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSSqlContainerGetResults
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Container name.

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

### -ParentObject
Sql Database object.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSSqlDatabaseGetResults
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

### -SourcePhysicalPartitionThroughputObject
Source physical partitions

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSPhysicalPartitionThroughputInfo[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetPhysicalPartitionThroughputObject
Target physical partitions

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSPhysicalPartitionThroughputInfo[]
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlDatabaseGetResults

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlContainerGetResults

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSPhysicalPartitionThroughputInfo

## NOTES

## RELATED LINKS
